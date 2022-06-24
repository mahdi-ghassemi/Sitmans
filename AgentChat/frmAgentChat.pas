unit frmAgentChat;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, IdContext, IdCustomTCPServer,
  IdTCPServer, IdBaseComponent, IdComponent, IdTCPConnection, IdTCPClient,
  Vcl.StdCtrls, Vcl.ComCtrls,Data.DB,Data.Win.ADODB,Winsock,SQLData;

type
  TfrmChat = class(TForm)
    IdTCPClient1: TIdTCPClient;
    IdTCPServer1: TIdTCPServer;
    btnSend: TButton;
    rtbMsg: TRichEdit;
    rtbLog: TRichEdit;
    lblStatus: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure StartTCPServer;
    procedure IdTCPServer1Execute(AContext: TIdContext);
    procedure btnSendClick(Sender: TObject);
    procedure AddText(szText : String; clColor : TColor; RichEdit : TRichEdit);
    procedure GetChatData;
    procedure SetConnString;
    procedure UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
    procedure RecivePM(ReciveMes:string);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure rtbMsgKeyUp(Sender: TObject; var Key: Word; Shift: TShiftState);
    procedure FormShow(Sender: TObject);
    procedure DeleteDllRecord;
    procedure SaveChatToSql(sendMsg:string);
    procedure SaveChatToDll(SMsg:string;ChDate:string;ChTime:string);
    procedure DeleteDllTempFile;

    function MemoryStreamToString(M: TMemoryStream): string;
    function GetMessageFromDll(LangCode:string;ControlName:string):string;
    function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
    function GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
    function ExecuteQueryDll(QueryString:string): integer;
    function GetIPAddress():String;
    procedure FormDestroy(Sender: TObject);






  type  // Define FLASHWINFO structure as record type
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
  end;

var
  frmChat: TfrmChat;
  AgentIPAddress : string;
  MyIPAddress : string;
  AgentPortNumber : string;
  MyPortNumber : string;
  LangCode : string;
  AgentComputerName : string;
  SenderUserName : string;
  IsPrivateChat : string;
  IsOfflineMsg : string;
  AgentId : string;
  RecordId : string;
  Msgg : string;
  ConnS1 : string;
  ConnS2 : string;
  IsFirstSend : bool;
  FWInfo: TFlashWInfo;
  SqlRes : integer;
  SqlConS : string;
  ChatTime : string;
  ChatDate : string;

  function FlashWindowEx(var pfwi: FLASHWINFO): BOOL; stdcall;

implementation

{$R *.dfm}

// Import external function from 'USER32.DLL' with the same name
function FlashWindowEx; external user32 Name 'FlashWindowEx';


procedure TfrmChat.btnSendClick(Sender: TObject);
var
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
Messg : string;

begin
if rtbMsg.Text <> '' then
begin
   SndText := Trim(rtbMsg.Text);
   rtbMsg.Lines.Clear;

   AddText(#10#13'Me : '+SndText,clGreen,rtbLog);
   rtbLog.SetFocus;
   rtbLog.SelStart := rtbLog.GetTextLen;
   rtbMsg.SetFocus;

try
  IdTCPClient1.Host := AgentIPAddress;
  IdTCPClient1.Port := StrToInt(AgentPortNumber);
  IdTCPClient1.Connect;
  if IsFirstSend = true then
  begin
    Messg := 'MSGOP'+ SenderUserName +':' + MyPortNumber + '/' + SndText;
    IsFirstSend := false;
  end else
  begin
    Messg := 'MSGPM'+ SenderUserName + ':' + MyPortNumber + '/' + SndText;
  end;
  IsOffLineMsg := '0';
  StrLen := Length(Messg);
  SndBuff := TMemoryStream.Create;
  SndBuff.Write(Messg[1],StrLen * SizeOf(Messg[1]));
  SndBuff.Position := 0;
  IdTCPClient1.IOHandler.Write(SndBuff,0,true);
  IdTCPClient1.Disconnect;
  SaveChatToSql(SndText);
except
  IsOffLineMsg := '1';
  lblStatus.Caption := GetMessageFromDll(LangCode,'AgentIsOff');
  SaveChatToSql(SndText);


end;

end;
end;

procedure TfrmChat.FormClose(Sender: TObject; var Action: TCloseAction);
begin
IdTCPClient1.Destroy;
IdTCPServer1.Destroy;
DeleteDllRecord;
end;

procedure TfrmChat.FormCreate(Sender: TObject);
begin
if (FileExists('EditAgent.dll')) = false then
begin
  ShowMessage('Dll file does not exist.');
  Application.Terminate;
end;

SetConnString;
GetChatData;
if AgentComputerName = '' then
begin
  ShowMessage('This madule must be run from Control Admin Panel.');
  Application.Terminate;
  exit;
end;
UpdateFieldToDll('ActiveChatAgent','IsDataGetting','Yes',RecordId);
frmChat.Caption := AgentComputerName;
btnSend.Caption := GetMessageFromDll(LangCode,'Send');
MyIPAddress := GetIPAddress;

IsFirstSend := true;
with FWInfo do
begin
  cbSize := SizeOf(FWInfo);  // Size of structure in bytes
  hWnd   := frmChat.Handle;      // Main's form handle
  dwFlags:= FLASHW_ALL;     // Flash both caption & task bar
  uCount := 2;              // Flash 2 times
  dwTimeOut := 100;          // Timeout is 1/10 second apart
end;
StartTCPServer;

end;

procedure TfrmChat.FormDestroy(Sender: TObject);
begin
DeleteDllTempFile;
end;

procedure TfrmChat.DeleteDllTempFile;
begin
  if (FileExists('EditAgent.ldb')) = true then DeleteFile('EditAgent.ldb');
end;


procedure TfrmChat.FormShow(Sender: TObject);
begin
if Msgg = '' then
begin
   IsFirstSend := true;
end;
if Msgg <> '' then
begin
  IsFirstSend := false;
  frmChat.SetFocus;
  frmChat.AddText(#10#13+ AgentComputerName + ' : '+ Msgg,clRed,rtbLog);
  rtbLog.SetFocus;
  rtbLog.SelStart := rtbLog.GetTextLen;
  SendMessage(rtbLog.Handle, WM_VSCROLL, SB_BOTTOM, 0);
  rtbMsg.SetFocus;
end;

end;

procedure TfrmChat.AddText(szText : String; clColor : TColor; RichEdit : TRichEdit);
begin
  // Set the selected text color
  RichEdit.SelAttributes.Color := clColor;
  // Add the text
  RichEdit.SelText := szText;
  // Set the selected text back to the default
  RichEdit.SelAttributes.Color := clWindowText;
end;

procedure TfrmChat.IdTCPServer1Execute(AContext: TIdContext);
var
  RcvTxt,Command: string;
  RcvBuff: TMemoryStream;
begin
  RcvBuff:= TMemoryStream.Create;

  AContext.Connection.IOHandler.ReadStream(RcvBuff, -1, False);
  RcvBuff.Position := 0;

  RcvTxt := MemoryStreamToString(RcvBuff);
  RcvBuff.Free;

  Command := Copy(RcvTxt, 1, 5);

   if (Command = 'MSGPM') then begin
      RecivePM(RcvTxt);
   end;

end;


procedure TfrmChat.StartTCPServer;
begin
  IdTCPServer1.Bindings.Add.IP := MyIPAddress;
  IdTCPServer1.Bindings.Add.Port := StrToInt(MyPortNumber);
  IdTCPServer1.Active := true;
end;

function TfrmChat.MemoryStreamToString(M: TMemoryStream): string;
begin
  SetString(Result, PChar(M.Memory), M.Size div SizeOf(Char));
end;

function TfrmChat.GetMessageFromDll(LangCode:string;ControlName:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM Messages'+
             ' WHERE LangCode = "'+LangCode+
             '" AND ChildObject = "'+ControlName+'"';
   Result := ExecuteQueryDllToString(SQLStr,'Message');
end;

function TfrmChat.ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }

 ConnString : string;
begin
  ConnString := ConnS1 +GetCurrentDir+ConnS2;


  SQLStr := QueryString;


  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  try
    ADOQuery_FRTO.Open;
    Result := ADOQuery_FRTO.FieldByName(FieldName).AsString;

  except
    on e: EADOError do
    begin

      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;


  //Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function TfrmChat.GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM '+TableName +
             ' WHERE ID = '+Condition;
   Result := ExecuteQueryDllToString(SQLStr,FieldName);
end;

procedure TfrmChat.GetChatData;
var
  query : string;
  ADOConn  : TADOConnection;
  ADOQuery : TADOQuery; { SQL Query }

  ConnString : string;
begin
query := 'SELECT * FROM ActiveChatAgent WHERE IsDataGetting = "No"';
ConnString := ConnS1 + GetCurrentDir+ ConnS2;

  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  ADOConn.ConnectionString := ConnString;   { Setup the connection string }
  ADOConn.LoginPrompt := False;  { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin

     ADOQuery.Close;
     ADOConn.Close;
     Exit;
    end;
  end;

  ADOQuery := TADOQuery.Create(nil);  { Create the query }
  ADOQuery.Connection := ADOConn;
  ADOQuery.SQL.Add(query);
  ADOQuery.ParamCheck := false;
  ADOQuery.Prepared := true;  { Set the query to Prepared - will improve performance }

  try
    ADOQuery.Open;

  except
    on e: EADOError do
    begin

      ADOQuery.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  AgentIPAddress := ADOQuery.FieldByName('AgentIPAddress').AsString;
  AgentPortNumber := ADOQuery.FieldByName('AgentPortNumber').AsString;
  MyPortNumber := ADOQuery.FieldByName('MyPortNumber').AsString;
  AgentComputerName := ADOQuery.FieldByName('ComputerName').AsString;
  LangCode := ADOQuery.FieldByName('LangCode').AsString;
  IsPrivateChat := ADOQuery.FieldByName('IsPrivateChat').AsString;
  AgentId := ADOQuery.FieldByName('AgentId').AsString;
  RecordId := ADOQuery.FieldByName('Id').AsString;
  Msgg := ADOQuery.FieldByName('Msg').AsString;
  SenderUserName := ADOQuery.FieldByName('SenderUserName').AsString;
  SqlConS := ADOQuery.FieldByName('SqlConnString').AsString;


  ADOQuery.Close;
  ADOConn.Close;
  DeleteDllTempFile;
end;

procedure TfrmChat.UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
var
  SQLStr : string;  { SQL Query }
  res : integer;
begin

  SQLStr:= 'UPDATE '+TableName+' SET '+FiledName+' = "'+Value+
           '" WHERE Id = '+Condition;
  res := ExecuteQueryDll(SQLStr);

end;

function TfrmChat.ExecuteQueryDll(QueryString:string): integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : Integer;

 ConnString : string;
begin
ConnString := ConnS1 + GetCurrentDir+ ConnS2;
  Res := 0;
  SQLStr := QueryString;


  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
      Res := -1;
      Result := Res;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  try
    ADOQuery_FRTO.ExecSQL;

  except
    on e: EADOError do
    begin
      Res := -1;
      Result := Res;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  Res := 1;
  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

procedure TfrmChat.SetConnString;
begin
ConnS1 := PChar(char(80)+ char(114)+ char(111)+ char(118)+ char(105)+ char(100)+ char(101)+ char(114)+ char(61)+ char(77)+ char(105)+ char(99)+ char(114)+ char(111)+ char(115)+ char(111)+ char(102)+ char(116)+ char(46)+ char(74)+ char(101)+ char(116)+ char(46)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(46)+ char(52)+ char(46)+ char(48)+ char(59)+ char(68)+ char(97)+ char(116)+ char(97)+ char(32)+ char(83)+ char(111)+ char(117)+ char(114)+ char(99)+ char(101)+ char(61));
ConnS2 := PChar(char(92)+ char(69)+ char(100)+ char(105)+ char(116)+ char(65)+ char(103)+ char(101)+ char(110)+ char(116)+ char(46)+ char(100)+ char(108)+ char(108)+ char(59)+ char(106)+ char(101)+ char(116)+ char(32)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(58)+ char(68)+ char(97)+ char(116)+ char(97)+ char(98)+ char(97)+ char(115)+ char(101)+ char(32)+ char(80)+ char(97)+ char(115)+ char(115)+ char(119)+ char(111)+ char(114)+ char(100)+ char(61)+ char(115)+ char(104)+ char(97)+ char(121)+ char(97)+ char(101)+ char(101)+ char(108)+ char(49)+ char(51)+ char(53)+ char(49)+ char(38)+ char(51)+ char(53)+ char(57));

end;

Function TfrmChat.GetIPAddress():String;
type
  pu_long = ^u_long;
var
  varTWSAData : TWSAData;
  varPHostEnt : PHostEnt;
  varTInAddr : TInAddr;
  namebuf : Array[0..255] of AnsiChar;
begin
  If WSAStartup($101,varTWSAData) <> 0 Then
  Result := 'No. IP Address'
  Else Begin
    gethostname(namebuf,sizeof(namebuf));
    varPHostEnt := gethostbyname(namebuf);
    varTInAddr.S_addr := u_long(pu_long(varPHostEnt^.h_addr_list^)^);
    Result := inet_ntoa(varTInAddr);
  End;
  WSACleanup;
end;

procedure TfrmChat.RecivePM(ReciveMes:string);
var
sender,msg,senderIp:string;
senderEndIndex,senderIpIndex,ReciveMesLength:integer;
begin
 ReciveMesLength := length(ReciveMes);
 senderEndIndex := Pos(':',ReciveMes);
 senderIpIndex :=  Pos('/',ReciveMes);
 sender := Copy(ReciveMes, 6, (senderEndIndex-6));
 senderIp := Copy(ReciveMes,senderEndIndex+1,senderIpIndex - senderEndIndex-1);

 msg := copy(ReciveMes,(senderIpIndex+1),(ReciveMesLength - length(sender) - length(senderIp) - 5));

 FlashWindowEx(FWInfo);

 frmChat.SetFocus;
 frmChat.AddText(#10#13+sender + ' : '+ msg,clRed,rtbLog);
 rtbLog.SetFocus;
 rtbLog.SelStart := rtbLog.GetTextLen;
 SendMessage(rtbLog.Handle, WM_VSCROLL, SB_BOTTOM, 0);
 rtbMsg.SetFocus;
end;




procedure TfrmChat.rtbMsgKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
if (Key = VK_ESCAPE)  then
    rtbMsg.Lines.Clear;
if (Key = VK_RETURN) then
    btnSendClick(sender);
end;

procedure TfrmChat.DeleteDllRecord;
var
  SQLStr : string;  { SQL Query }
  res : integer;
begin

  SQLStr:= 'DELETE  *  FROM  ActiveChatAgent where Id = '+RecordId;
  res := ExecuteQueryDll(SQLStr);
end;

procedure TfrmChat.SaveChatToSql(sendMsg:string);
var
MySql : SQLAccess;
ParName,ParValue : array of string;
res : integer;
today : TDateTime;
begin

  MySql := SQLAccess.Create(SqlConS);
  MySql.StoredProcedureName := 'prcInsertChatMsg';

  SetLength(ParName,7);
  SetLength(ParValue,7);

  today := Now;
  ChatDate := DateToStr(today);
  ChatTime := TimeToStr(today);


  ParName[0] := '@SenderName';
  ParValue[0] := SenderUserName;

  ParName[1] := '@ReciverName';
  ParValue[1] := AgentComputerName;

  ParName[2] := '@ChatDate';
  ParValue[2] := ChatDate;

  ParName[3] := '@ChatTime';
  ParValue[3] := ChatTime;

  ParName[4] := '@ChatMsg';
  ParValue[4] := sendMsg;

  ParName[5] := '@IsPrivateChat';
  ParValue[5] := IsPrivateChat;

  ParName[6] := '@IsOffLineMsg';
  ParValue[6] := IsOffLineMsg;


  res := MySql.IntExcuteSP(ParName,ParValue);

  MySql.Free;

  if res = 0  then SaveChatToDll(sendMsg,ChatDate,ChatTime);

end;

procedure TfrmChat.SaveChatToDll(SMsg:string;ChDate:string;ChTime:string);
var
SQLStr : string;  { SQL Query }
res : integer;
begin
 SQLStr:= 'INSERT INTO  ChatArchive (SenderName,ReciverName,ChatDate,ChatTime,ChatMsg,IsPrivateChat,ISOffLineMsg,SendToSql) VALUES("'
 +SenderUserName+'","'+AgentComputerName+'","'+ ChDate + '","' + ChTime + '","' + SMsg + '","'+IsPrivateChat+'","'+IsOffLineMsg+'","0")';
 res := ExecuteQueryDll(SQLStr);

end;

end.
