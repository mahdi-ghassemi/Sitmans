unit frmPm_RtoL;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, System.Win.ScktComp, Vcl.StdCtrls
  ,LocalData, Web.Win.Sockets, Vcl.ComCtrls, IdBaseComponent, IdComponent,
  IdUDPBase, IdUDPClient, IdTCPConnection, IdTCPClient,SQLData;

type
  TfrmPm = class(TForm)
    btnSend: TButton;
    lblSendername: TLabel;
    lblSenderIp: TLabel;
    lblPort: TLabel;
    lblComputerName: TLabel;
    redLog: TRichEdit;
    redMsg: TRichEdit;
    IdTCPClient1: TIdTCPClient;
    lblSenderPort: TLabel;
    IdUDPClient1: TIdUDPClient;
    lblSqlConS: TLabel;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure btnSendClick(Sender: TObject);
    procedure AddText(szText : String; clColor : TColor; RichEdit : TRichEdit);
    procedure redMsgKeyUp(Sender: TObject; var Key: Word; Shift: TShiftState);
    procedure FormShow(Sender: TObject);
    procedure Flash;
    procedure SaveChatToSql(sendMsg:string;IsOffLine:string);
    procedure SaveChatToDll(sndMsg:string;ChDate:string;ChTime:string;IsoffL:string);

    // Define FLASHWINFO structure as record type
type
  FLASHWINFO = record
    cbSize: UINT;
    hWnd: HWND;
    dwFlags: DWORD;
    uCount: UINT;
    dwTimeOut: DWORD;
  end;
  TFlashWInfo = FLASHWINFO;

  // Define dwFlags constants
const
  FLASHW_STOP = 0;
  FLASHW_CAPTION = 1;
  FLASHW_TRAY = 2;
  FLASHW_ALL = FLASHW_CAPTION or FLASHW_TRAY;
  FLASHW_TIMER = 4;
  FLASHW_TIMERNOFG = 12;


    
  private

    { Private declarations }
  public
    { Public declarations }
  constructor Create(AOwner: TComponent); reintroduce; overload;
  constructor Create(Msg: string;Sender:string;LangCode:string;SrcIp:string;Port:string;ComputerName:string;SenderPort:string;SqlConS:string); reintroduce; overload;
  end;

var
  frmPm: TfrmPm;
  recivedMsg : string;
  sendMsg : string;
  senderName : string;
  stLanguageCode : string;
  stChatTCPPort : string;
  senderIp : string;
  FWInfo: TFlashWInfo;

  function FlashWindowEx(var pfwi: FLASHWINFO): BOOL; stdcall;

implementation

{$R *.dfm}

// Import external function from 'USER32.DLL' with the same name
function FlashWindowEx; external user32 Name 'FlashWindowEx';

constructor TfrmPm.Create(AOwner: TComponent);
begin
inherited;
sendMsg := '';
senderName := '';
if not Assigned(@FlashWindowEx) then
  begin
    ShowMessage('API Function FlashWindowEx is not present... Exit program!');
    Application.Terminate;
  end
  else

   // Set default parameters
 with FWInfo do
    begin
      cbSize    := SizeOf(FWInfo);  // Size of structure in bytes
      hWnd      := frmPm.Handle;      // Main's form handle
      dwFlags   := FLASHW_ALL;     // Flash both caption & task bar
      uCount    := 5;              // Flash 10 times
      dwTimeOut := 100;          // Timeout is 1/10 second apart
    end;



end;

procedure TfrmPm.btnSendClick(Sender: TObject);
var
Msg : TCaption;
MyIpAddress : string;
SendTxt : string;
StrLen : integer;
SndBuff : TMemoryStream;
begin
if(redMsg.Text <> '') then
begin
  Msg := Trim(redMsg.Text);
  redMsg.Lines.Clear;

  AddText(#10#13'Me : '+Msg,clGreen,redLog);
  redLog.SetFocus;
  redLog.SelStart := redLog.GetTextLen;
  SendMessage(redLog.Handle, WM_VSCROLL, SB_BOTTOM, 0);
  redMsg.SetFocus;

  try
     IdTCPClient1.Host := lblSenderIp.Caption;
     IdTCPClient1.Port := StrToInt(lblSenderPort.Caption);
     IdTCPClient1.Connect;
     MyIpAddress := LocalData.GetIPAddress;

     SendTxt := 'MSGPM'+lblComputerName.Caption+':'+MyIpAddress+'/'+Msg;

     StrLen := Length(SendTxt);

     SndBuff := TMemoryStream.Create;
     SndBuff.Write(SendTxt[1],StrLen * SizeOf(SendTxt[1]));
     SndBuff.Position := 0;

     IdTCPClient1.IOHandler.Write(SndBuff,0,true);
     IdTCPClient1.Disconnect;
     SaveChatToSql(Msg,'0');
  except

     IdUDPClient1.Host := lblSenderIp.Caption;
     IdUDPClient1.Port := StrToInt(lblPort.Caption);
     try
          IdUDPClient1.Active := true;
          MyIpAddress := LocalData.GetIPAddress;
          SendTxt := 'MSGPM'+lblComputerName.Caption+':'+MyIpAddress+'/'+Msg;
          IdUDPClient1.Send(SendTxt,TEncoding.UTF8);
          IdUDPClient1.Active := false;
          SaveChatToSql(Msg,'0'); //online pm
     except
          SaveChatToSql(Msg,'1'); //offline pm
     end;
  end;
 end;
end;

constructor TfrmPm.Create(Msg: string;Sender:string;LangCode:string;SrcIp:string;Port:string;ComputerName:string;Senderport:string;SqlConS:string);
begin
inherited Create(Application);

sendMsg := Msg;
senderName := Sender;
stLanguageCode := LangCode;
lblComputerName.Caption := ComputerName;
lblPort.Caption := Port;
senderIp := SrcIp;
btnSend.Caption := LocalData.GetMessageFromDll(stLanguageCode,'frmPm','btnSend');
lblSenderName.Caption := senderName;
lblSenderIp.Caption := senderIp;
lblSenderPort.Caption := SenderPort;
lblSqlConS.Caption := SqlConS;
caption := Sender;

redLog.Lines.Add('');
AddText(Sender + ' : '+ sendMsg,clRed,redLog);


end;

procedure TfrmPm.AddText(szText : String; clColor : TColor; RichEdit : TRichEdit);
begin
  // Set the selected text color
  RichEdit.SelAttributes.Color := clColor;
  // Add the text
  RichEdit.SelText := szText;
  // Set the selected text back to the default
  RichEdit.SelAttributes.Color := clWindowText;
end;


procedure TfrmPm.FormClose(Sender: TObject; var Action: TCloseAction);
var
i : integer;
_senderName : string;
begin
 _senderName := lblSenderName.Caption;
i := LocalData.ChatUsersList.IndexOf(_senderName);

LocalData.ChatUsersList.Delete(i);
LocalData.ChatUsersList.Insert(i,'');
IdTCPClient1.Destroy;
end;


procedure TfrmPm.FormShow(Sender: TObject);
begin
SetFocus;
FormStyle := fsNormal ;
end;

procedure TfrmPm.redMsgKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);

begin
if (Key = VK_ESCAPE) then
    redMsg.Lines.Clear;
if (Key = VK_RETURN) then
    btnSendClick(Sender);
end;

 procedure TfrmPm.Flash;
 begin
 FlashWindowEx(FWInfo);
 end;

procedure TfrmPm.SaveChatToSql(sendMsg:string;IsOffLine:string);
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
ChatDate,ChatTime : string;

begin

  MySql := SQLAccess.Create(lblSqlConS.Caption);
  MySql.StoredProcedureName := 'prcInsertChatMsg';

  SetLength(ParName,7);
  SetLength(ParValue,7);

  today := Now;
  ChatDate := DateToStr(today);
  ChatTime := TimeToStr(today);


  ParName[0] := '@SenderName';
  ParValue[0] := lblComputerName.Caption;

  ParName[1] := '@ReciverName';
  ParValue[1] := lblSenderName.Caption;

  ParName[2] := '@ChatDate';
  ParValue[2] := ChatDate;

  ParName[3] := '@ChatTime';
  ParValue[3] := ChatTime;

  ParName[4] := '@ChatMsg';
  ParValue[4] := sendMsg;

  ParName[5] := '@IsPrivateChat';
  ParValue[5] := '1';

  ParName[6] := '@IsOffLineMsg';
  ParValue[6] := IsOffLine;


  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 0  then SaveChatToDll(sendMsg,ChatDate,ChatTime,IsOffLine);

end;

procedure TfrmPm.SaveChatToDll(sndMsg:string;ChDate:string;ChTime:string;IsoffL:string);
var
SQLStr : string;  { SQL Query }
res : integer;
begin
 SQLStr:= 'INSERT INTO  ChatArchive (SenderName,ReciverName,ChatDate,ChatTime,ChatMsg,IsPrivateChat,ISOffLineMsg,SendToSql) VALUES("'
 +lblComputerName.Caption+'","'+lblSenderName.Caption+'","'+ ChDate + '","' + ChTime + '","' + sndMsg + '","'+'1'+'","'+IsoffL+'","0")';
 res := ExecuteQueryDll(SQLStr,1);

end;




end.
