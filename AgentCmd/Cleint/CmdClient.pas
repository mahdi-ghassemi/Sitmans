unit CmdClient;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, IdBaseComponent,
  IdComponent, IdTCPConnection, IdTCPClient, IdTelnet, IdContext,
  IdCustomTCPServer, IdTCPServer,Winsock,Data.Win.ADODB;

type
  TfrmAgentCmd = class(TForm)
    lblPath: TLabel;
    txbPath: TEdit;
    btnSend: TButton;
    txbCommand: TEdit;
    lblComand: TLabel;
    memResult: TMemo;
    IdTCPClient1: TIdTCPClient;
    IdTCPServer1: TIdTCPServer;
    function GetIPAddress():String;
    procedure FormCreate(Sender: TObject);
    procedure SendCommand(Comd:string);
    procedure GetSysDir;
    procedure IdTCPServer1Execute(AContext: TIdContext);
    function MemoryStreamToString(M: TMemoryStream): string;
    procedure SetSysDir(s : string);
    procedure SetCmdResult(r : string);
    procedure btnSendClick(Sender: TObject);
    procedure txbCommandKeyUp(Sender: TObject; var Key: Word;
      Shift: TShiftState);

    procedure SetConnString;
    procedure FillForm;
    function ExecuteQueryDll(QueryString:string): integer;
    procedure DeleteDllRecord;
    procedure UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
    function GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
    procedure GetAgentData;
    function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
    function GetMessageFromDll(LangCode:string;ControlName:string):string;
    procedure FormClose(Sender: TObject; var Action: TCloseAction);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmAgentCmd: TfrmAgentCmd;
  MyIP,MyPortNumber,AgentIP,Sys32Dir,AgentPort,AgentName,SqlCons : string;
  ConnS1 ,ConnS2 ,LangCode ,AgentId , RecordId: string;
implementation

{$R *.dfm}

procedure TfrmAgentCmd.SendCommand(Comd:string);
var
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin
try
IdTCPClient1.Host := AgentIP;
IdTCPClient1.Port := StrToInt(AgentPort);
IdTCPClient1.Connect;

SndText := Trim(Comd);
StrLen := Length(SndText);

SndBuff := TMemoryStream.Create;
SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
SndBuff.Position := 0;

IdTCPClient1.IOHandler.Write(SndBuff,0,true);
IdTCPClient1.Disconnect;
except
  showmessage('Agent not avaliable now.Please try later');
  Application.Terminate;
end;
end;




procedure TfrmAgentCmd.btnSendClick(Sender: TObject);
var
cmd : string;
begin
memResult.Clear;
cmd := 'DOCMD[' + txbPath.Text + '][' + Trim(txbCommand.Text) + ']';
SendCommand(cmd);
end;

procedure TfrmAgentCmd.FormClose(Sender: TObject; var Action: TCloseAction);
begin
 DeleteDllRecord;
end;

procedure TfrmAgentCmd.FormCreate(Sender: TObject);
begin
if (FileExists('EditAgent.dll')) = false then
begin
  ShowMessage('Dll file does not exist.');
  Application.Terminate;
  exit;
end;
SetConnString;
GetAgentData;
if AgentName = '' then
begin
  ShowMessage('This madule must be run from Control Admin Panel.');
  Application.Terminate;
  exit;
end;
FillForm;
MyIP := GetIPAddress;
UpdateFieldToDll('AgentCmd','GetData','Yes',RecordId);
IdTCPServer1.Bindings.Add.IP := MyIP;
IdTCPServer1.Bindings.Add.Port := StrToInt(MyPortNumber);
IdTCPServer1.Active := true;
GetSysDir;
frmAgentCmd.Caption := AgentName;


end;

procedure TfrmAgentCmd.FillForm;
begin
lblComand.Caption := GetMessageFromDll(langCode,'Command2');
lblPath.Caption :=  GetMessageFromDll(langCode,'Path');
btnSend.Caption := GetMessageFromDll(langCode,'Send');
end;

procedure TfrmAgentCmd.GetSysDir;
var
cm : string;
begin
cm := 'SYSDR['+ MyPortNumber + ']';
SendCommand(cm);
end;

procedure TfrmAgentCmd.IdTCPServer1Execute(AContext: TIdContext);
var
  RcvTxt,Command: string;
  RcvBuff: TMemoryStream;
begin
  RcvBuff:= TMemoryStream.Create;

  AContext.Connection.IOHandler.ReadStream(RcvBuff, -1, False);

  RcvBuff.Position := 0;

  RcvTxt := MemoryStreamToString(RcvBuff);

  Command := Copy(RcvTxt, 1, 5);

   if (Command = 'SYSDR') then begin
      SetSysDir(RcvTxt);
   end;
   if (Command = 'DOCMD') then begin
      SetCmdResult(RcvTxt);
   end;
 RcvBuff.Free;

end;

procedure TfrmAgentCmd.SetCmdResult(r : string);
var
sIndex : integer;
res : string;
begin
sIndex := Pos(']',r);
res := Copy(r,7,sIndex - 7);
memResult.Text := res;
end;

procedure TfrmAgentCmd.SetSysDir(s : string);
var
sIndex : integer;
path : string;
begin
sIndex := Pos(']',s);
path := Copy(s,7,sIndex - 7);
txbPath.Text := path;
end;

procedure TfrmAgentCmd.txbCommandKeyUp(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
if (Key = VK_ESCAPE)  then
    txbCommand.Clear;
if (Key = VK_RETURN) then
    btnSendClick(Sender);
end;

function TfrmAgentCmd.MemoryStreamToString(M: TMemoryStream): string;
begin
  SetString(Result, PChar(M.Memory), M.Size div SizeOf(Char));
end;

function TfrmAgentCmd.GetIPAddress():String;
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

procedure TfrmAgentCmd.SetConnString;
begin
ConnS1 := PChar(char(80)+ char(114)+ char(111)+ char(118)+ char(105)+ char(100)+ char(101)+ char(114)+ char(61)+ char(77)+ char(105)+ char(99)+ char(114)+ char(111)+ char(115)+ char(111)+ char(102)+ char(116)+ char(46)+ char(74)+ char(101)+ char(116)+ char(46)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(46)+ char(52)+ char(46)+ char(48)+ char(59)+ char(68)+ char(97)+ char(116)+ char(97)+ char(32)+ char(83)+ char(111)+ char(117)+ char(114)+ char(99)+ char(101)+ char(61));
ConnS2 := PChar(char(92)+ char(69)+ char(100)+ char(105)+ char(116)+ char(65)+ char(103)+ char(101)+ char(110)+ char(116)+ char(46)+ char(100)+ char(108)+ char(108)+ char(59)+ char(106)+ char(101)+ char(116)+ char(32)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(58)+ char(68)+ char(97)+ char(116)+ char(97)+ char(98)+ char(97)+ char(115)+ char(101)+ char(32)+ char(80)+ char(97)+ char(115)+ char(115)+ char(119)+ char(111)+ char(114)+ char(100)+ char(61)+ char(115)+ char(104)+ char(97)+ char(121)+ char(97)+ char(101)+ char(101)+ char(108)+ char(49)+ char(51)+ char(53)+ char(49)+ char(38)+ char(51)+ char(53)+ char(57));

end;

function TfrmAgentCmd.ExecuteQueryDll(QueryString:string): integer;
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

procedure TfrmAgentCmd.DeleteDllRecord;
var
  SQLStr : string;  { SQL Query }
  res : integer;
begin

  SQLStr:= 'DELETE  *  FROM  AgentCmd where Id = '+RecordId;
  res := ExecuteQueryDll(SQLStr);
end;

procedure TfrmAgentCmd.UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
var
  SQLStr : string;  { SQL Query }
  res : integer;
begin

  SQLStr:= 'UPDATE '+TableName+' SET '+FiledName+' = "'+Value+
           '" WHERE Id = '+Condition;
  res := ExecuteQueryDll(SQLStr);

end;

function TfrmAgentCmd.GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM '+TableName +
             ' WHERE ID = '+Condition;
   Result := ExecuteQueryDllToString(SQLStr,FieldName);
end;

procedure TfrmAgentCmd.GetAgentData;
var
  query : string;
  ADOConn  : TADOConnection;
  ADOQuery : TADOQuery; { SQL Query }

  ConnString : string;
begin
query := 'SELECT * FROM AgentCmd WHERE GetData = "No"';
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

  AgentIP := ADOQuery.FieldByName('AgentIP').AsString;
  AgentPort := ADOQuery.FieldByName('AgentPort').AsString;
  MyPortNumber := ADOQuery.FieldByName('Port').AsString;
  AgentName := ADOQuery.FieldByName('ComputerName').AsString;
  LangCode := ADOQuery.FieldByName('LangCode').AsString;
  AgentId := ADOQuery.FieldByName('AgentId').AsString;
  RecordId := ADOQuery.FieldByName('Id').AsString;
  SqlConS := ADOQuery.FieldByName('SqlString').AsString;


  ADOQuery.Close;
  ADOConn.Close;
end;

function TfrmAgentCmd.ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
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

function TfrmAgentCmd.GetMessageFromDll(LangCode:string;ControlName:string):string;
var
   SQLStr : string;

begin

   SQLStr := 'SELECT * FROM Messages' +
             ' WHERE LangCode = "'+LangCode+
             '" AND ChildObject = "'+ControlName+'"';
   Result := ExecuteQueryDllToString(SQLStr,'Message');
end;



end.
