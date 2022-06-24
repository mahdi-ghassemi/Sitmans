unit frmMain;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, CoolTrayIcon, Vcl.Menus, Vcl.ExtCtrls,
  System.Win.ScktComp,MMSystem,ShellAPI,TAgentClass,LocalData,U_usb,frmChat_RtoL,
  frmPm_RtoL, IdContext, IdBaseComponent, IdComponent, IdCustomTCPServer,
  IdTCPServer, IdCmdTCPServer, IdExplicitTLSClientServerBase, IdFTPServer,
  IdUserAccounts, Vcl.ComCtrls,IdSocketHandle, IdUDPClient, IdUDPBase, IdUDPServer,
  IdTCPConnection,  IdTCPClient,jpeg,IdSync,IdGlobal, Web.Win.Sockets,ChangeCheckThread,
  Vcl.StdCtrls,SQLData,EncDec;


type
  TMySync = class(TIdSync)
  protected
    procedure DoSynchronize; override;
  public
    class procedure DoTheWork;
  end;

type
  TMyRecord = record
    ButtonLorD: Char;
    ButtonAction: Char;
    ButtonX, ButtonY: Integer;
  end;

type
  TForm4 = class(TForm)
    CoolTrayIcon1: TCoolTrayIcon;
    PopupMenu1: TPopupMenu;
    mnuChat: TMenuItem;
    mnuAbout: TMenuItem;
    Timer1: TTimer;
    mnuSendFile: TMenuItem;
    mnuVideo: TMenuItem;
    N1: TMenuItem;
    N2: TMenuItem;
    TimerSystemChanges: TTimer;
    IdUDPServer1: TIdUDPServer;
    IdUDPClient1: TIdUDPClient;
    IdTCPClient1: TIdTCPClient;
    IdTCPChat: TIdTCPServer;
    IdTCPServerRemoteDesktop: TIdTCPServer;
    IdTCPClientFileTransfer: TIdTCPClient;
    IdTCPServerFileTransfer: TIdTCPServer;
    PublicServerSocket: TServerSocket;
    IdTCPServerCMD: TIdTCPServer;
    IdTCPServerWebinar: TIdTCPServer;
    IdTCPServerVideoConference: TIdTCPServer;
    lstWindows: TListBox;
    TimerAppRun: TTimer;
    TimerIdle: TTimer;
    TimerStatus: TTimer;
    mnuSendRequset: TMenuItem;
    mnuHelp: TMenuItem;
    mnuScreenShot: TMenuItem;

    procedure Timer1Timer(Sender: TObject);
    procedure mnuExitClick(Sender: TObject);
    procedure GetSettingAgent;
    procedure GetMessage;
    procedure FillMenu;
    procedure PopupMenu1Popup(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure UsbIN(ASender : TObject; const ADevType,ADriverName,AFriendlyName : string);
    procedure UsbOUT(ASender : TObject; const ADevType,ADriverName,AFriendlyName : string);
    procedure TimerSystemChangesTimer(Sender: TObject);
    procedure WMEndSession(var Msg: TWMEndSession); message WM_ENDSESSION;
    procedure WMPowerBroadcast(var AMessage: TMessage); message WM_POWERBROADCAST;
    procedure ReciveMessage(ReciveMes:string);
    procedure RecivePM(ReciveMes:string);
    procedure GetDirectory(Path:string);
    procedure ListFileDir(Path:string;SenderIP:string;SenderPort:string;NodeIndex:string;NodeLevel:string;TreeviewNumber:string);
    procedure FileTransferOreder(RecText:string);
    procedure IdTCPChatExecute(AContext: TIdContext);
    function MemoryStreamToString(M: TMemoryStream): string;
    procedure ReciveTCPMessage(Msg:String);
    procedure GetDriveList(RecTxt:string);
    procedure SendTCPDataToServer(data:string;HostIp:string;HostPort:string);
    procedure IdTCPServerRemoteDesktopExecute(AContext: TIdContext);
    procedure IdTCPServerFileTransferExecute(AContext: TIdContext);
    procedure ExecuteApplication(RecTxt:string);
    procedure DelFile(RecTxt:string);
    procedure RenamFile(RecTxt:string);
    procedure MakeFolder(RecTxt:string);
    procedure SendSysDirToClient(Comn : string);
    procedure SendResult(Res:string);
    function GetSysDir: string;
    function GetDosOutput(CommandLine: string; Work: string): string;
    procedure SendCmdResultToClient(Cmd : string);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure DoChangeTimer;
    procedure PublicServerSocketClientRead(Sender: TObject;
      Socket: TCustomWinSocket);
    procedure CheckAgentVersion(Ver:string);
    procedure IdTCPServerCMDExecute(AContext: TIdContext);
    procedure AddToList;
    procedure FirstRun;
    function AssignList(CList:TStringList):TstringList;
    procedure TimerAppRunTimer(Sender: TObject);
    procedure ComparLists(var NewList:TStringList;var LastList:TStringList);
    procedure ProgramOpenEvent(CList:TStringList);
    procedure ProgramCloseEvent(LList:TStringList);
    procedure TimerIdleTimer(Sender: TObject);
    procedure TimerStatusTimer(Sender: TObject);
    procedure CheckSettingUpdate;
    procedure UpdateNewSettingInDll(newSet:TSettingValues);
    procedure UpdateNewSettingInAgentClass(newSet:TSettingValues);
    function CheckAutorize(RemoteIP:string):boolean;
    procedure SendHello(RemoteIP:string;RemotePort:integer);


  private
   MyFormJpeg: TJPEGImage;
    { Private declarations }
  public
  var
  msgChat : string;
  msgScreenshot : string;
  msgVideo : string;
  msgSendFile : string;
  msgAbout : string;
  msgHelp : string;
  msgSendRequest : string;

  MyRecServer: TMyRecord;

  stAgentPassword : string;
  stSQLServerAddress : string;
  stSQLUsername : string;
  stSQLPassword  : string;
  stSQLDatabaseName  : string;
  stIsRegister  : string;
  stControlSoftware : string;
  stControlHardware : string;
  stControlNetwork : string;
  stControlAccounts : string;
  stChatPort : string;
  stUDPPort  : string;
  stAdminMachineIPAddress : string;
  stVersion : string;
  stLanguageCode : string;
  stRigthToLeft : string;
  stChatWithOther : string;
  stFileTransferToOther : string;
  stVideoConfToOther : string;
  stImageProccesing : string;
  stLockIpAddress  : string;
  stSendMail : string;
  stSendSMS : string;
  stRDport : string;
  stFTPort : string;
  stCMDPort : string;
  srVideoConfPort : string;
  stWebinarPort : string;
  stPublicPort : string;
  stUsbAccessControl : string;
  stUsbDataControl : string;
  stRegAccessControl : string;
  stAppInstallDisable : string;
  stAppRunDisable : string;
  stDisableCtrlAltDel : string;
  stUpdateCounter: string;
  stLockSerialNumber : string;

  LastAppList: TStringList;
  NewAppList : TStringList;
  TempAppList : TStringList;
  today : TDateTime;
  agid : string; //AgentID
  sqlser:string;
  sqldbn:string;
  sqlusern:string;
  sqlpass:string;

  NowStatus : string;
  IdleDuration : string;
  SumIdleToday : integer;
  SettingUpdateCounter : integer;

  IsSystemChanges : boolean;

  ErrorCounter : integer;

  MyAgentThread : TAgentThread;

  ChatForms : Array of TfrmPm;
  SenderIP : string;
  MyAgent : TMyAgent;
  MyUsb : TUsbClass;
  LocalFilePath : string;
  ClientPort,Sys32Dir,Output,ClientIP : string;

  Autorized : boolean;
  ConnectionsIP : TStringList;
  ConnectionAutorized : TStringList;
  ClientCounter : integer;

  SaveInIdleToDb : boolean;
  SaveOutIdleToDb : boolean;


    { Public declarations }
  end;

var
  Form4: TForm4;

implementation

{$R *.dfm}

function EnumWindowsProc(wHandle: HWND; lb: TListBox): BOOL; stdcall;
var
  Title, ClassName: array[0..255] of char;
begin
  GetWindowText(wHandle, Title, 255);
  GetClassName(wHandle, ClassName, 255);
  if IsWindowVisible(wHandle) then
  begin
    if string(ClassName) <> 'CabinetWClass' then
    begin
       lb.Items.Add(string(Title));
    end;
  end;
  Result := True;
end;

function IdleTime: DWord;
var
  LastInput: TLastInputInfo;
begin
  LastInput.cbSize := SizeOf(TLastInputInfo);
  GetLastInputInfo(LastInput);
  Result := (GetTickCount - LastInput.dwTime) DIV 1000;
end;



procedure TForm4.mnuExitClick(Sender: TObject);
begin
  CoolTrayIcon1.Destroy;
  CoolTrayIcon1.Free;
  IdTCPChat.Active := false;
  IdTCPChat.Bindings.Clear;
  IdTCPServerRemoteDesktop.Active := false;
  IdTCPServerRemoteDesktop.Bindings.Clear;
  MyFormJpeg.Free;
  PublicServerSocket.Active := false;
  PublicServerSocket.Free;
  IdTCPServerCMD.Active := false;
  IdTCPServerCMD.Free;
  IdTCPServerWebinar.Active := false;
  IdTCPServerWebinar.Free;
  IdTCPServerVideoConference.Active := false;
  IdTCPServerVideoConference.Free;

  Application.Terminate;
end;



procedure TForm4.PopupMenu1Popup(Sender: TObject);
begin
  PopupMenu1.AutoHotkeys := maManual ;

  if stChatWithOther = '1' then mnuChat.Enabled := true
  else  mnuChat.Enabled := false;

  if stFileTransferToOther = '1' then mnuSendFile.Enabled := true
  else  mnuSendFile.Enabled := false;

  if stVideoConfToOther = '1' then mnuVideo.Enabled := true
  else  mnuVideo.Enabled := false;

  mnuSendRequset.Enabled := false;
  mnuScreenShot.Enabled := false;

end;

procedure TForm4.CheckSettingUpdate;
var
settingProfileId : string;
currentSettingUpCount : integer;
newSetting : TSettingValues;
begin
settingProfileId := LocalData.GetSettingProfileId(agid,sqlser,sqldbn,sqlusern,sqlpass);
if settingProfileId = '0' then settingProfileId := '1';
SettingUpdateCounter := LocalData.GetLastSettingProfileUpdateCounter(settingProfileId,sqlser,sqldbn,sqlusern,sqlpass);
currentSettingUpCount := StrToInt(stUpdateCounter);
if SettingUpdateCounter > currentSettingUpCount then
begin
setlength(newSetting,23);
newSetting := LocalData.GetNewSetting(settingProfileId,sqlser,sqldbn,sqlusern,sqlpass);
if newSetting[0] <> 'SQL Exception' then
begin
   stAgentPassword :=  newSetting[0];
   stControlSoftware :=  newSetting[1];
   stControlHardware :=  newSetting[2];
   stControlNetwork :=  newSetting[3];
   stControlAccounts :=  newSetting[4];
   stChatPort :=  newSetting[5];
   stChatWithOther :=  newSetting[6];
   stFileTransferToOther :=  newSetting[7];
   stVideoConfToOther :=  newSetting[8];
   stImageProccesing :=  newSetting[9];
   stRDport :=  newSetting[10];
   stFTPort :=  newSetting[11];
   stCMDPort :=  newSetting[12];
   srVideoConfPort :=  newSetting[13];
   stWebinarPort :=  newSetting[14];
   stPublicPort :=  newSetting[15];
   stUsbAccessControl :=  newSetting[16];
   stUsbDataControl :=  newSetting[17];
   stRegAccessControl :=  newSetting[18];
   stAppInstallDisable :=  newSetting[19];
   stAppRunDisable :=  newSetting[20];
   stDisableCtrlAltDel :=  newSetting[21];
   stUpdateCounter :=  newSetting[22];

   UpdateNewSettingInDll(newSetting);
   UpdateNewSettingInAgentClass(newSetting);

end;
end;
end;

procedure TForm4.UpdateNewSettingInDll(newSet:TSettingValues);
var
ns : TSettingValues;
begin
SetLength(ns,23);
ns := newSet;
localData.UpdateFieldToDll('AgentSetting','AgentPassword',ns[0],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ControlSoftware',ns[1],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ControlHardware',ns[2],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ControlNetwork',ns[3],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ControlAccounts',ns[4],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ChatPort',ns[5],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ChatWithOther',ns[6],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','FileTransferToOther',ns[7],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','VideoConfToOther',ns[8],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','ImageProccesing',ns[9],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','RemoteDesktopPort',ns[10],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','FileTransferPort',ns[11],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','CMDPort',ns[12],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','VideoConfPort',ns[13],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','WebinarPort',ns[14],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','PublicPort',ns[15],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','UsbAccessControl',ns[16],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','UsbDataControl',ns[17],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','RegAccessControl',ns[18],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','AppInstallDisable',ns[19],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','AppRunDisable',ns[20],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','DisableCtrlAltDel',ns[21],'ID = 1');
localData.UpdateFieldToDll('AgentSetting','UpdateCounter',ns[22],'ID = 1');
end;

procedure TForm4.UpdateNewSettingInAgentClass(newSet:TSettingValues);
var
ns : TSettingValues;
begin
SetLength(ns,23);
ns := newSet;
MyAgent.AgentPassword :=  ns[0];
MyAgent.ControlSoftware :=  ns[1];
MyAgent.ControlHardware :=  ns[2];
MyAgent.ControlNetwork :=  ns[3];
MyAgent.ControlAccounts :=  ns[4];
MyAgent.ChatPort :=  ns[5];
MyAgent.ChatWithOther :=  ns[6];
MyAgent.FileTransferToOther :=  ns[7];
MyAgent.VideoConfToOther :=  ns[8];
MyAgent.ImageProccesing :=  ns[9];
MyAgent.RemoteDesktopPort :=  ns[10];
MyAgent.FileTransferPort :=  ns[11];
MyAgent.CMDPort :=  ns[12];
MyAgent.VideoConfPort :=  ns[13];
MyAgent.WebinarPort :=  ns[14];
MyAgent.PublicPort :=  ns[15];
MyAgent.UsbAccessControl :=  ns[16];
MyAgent.UsbDataControl :=  ns[17];
MyAgent.RegAccessControl :=  ns[18];
MyAgent.AppInstallDisable :=  ns[19];
MyAgent.AppRunDisable :=  ns[20];
MyAgent.DisableCtrlAltDel :=  ns[21];
MyAgent.UpdateCounter :=  ns[22];
end;

procedure TForm4.Timer1Timer(Sender: TObject);
var
  DllNotFound : boolean;
  buttonSelected : Integer;

begin
  
  SumIdleToday := 0;
  IdleDuration := '0';
  NowStatus := '1';
  timer1.Enabled := false;
  
  TimerIdle.Enabled := true;
  LocalData.SetConnString;
  Sys32Dir := GetSysDir;
  MyFormJpeg := TJPEGImage.Create;

  Form4.Hide;



  ErrorCounter := 0;

  MyAgent := TMyAgent.Create;

  MyAgent.AgentID := LocalData.GetDataFromDll('AgentDetails','AgentID','1');
  //
  GetSettingAgent;
  CheckSettingUpdate;
  MyAgent.GetSystemInfo;
  MyAgent.StartUpEvent;
 // LocalData.CloseFiles(AgentmFileHandle);
  GetMessage;
  FillMenu;

  LocalData.CreateChatUserList;
  CoolTrayIcon1.IconVisible := true;
  CoolTrayIcon1.Enabled := true;
  CoolTrayIcon1.MinimizeToTray := true;

  CheckAgentVersion(MyAgent.Version);

  MyAgent.GetHashCodesFromDll;
  TimerSystemChanges.Enabled := true;




  MyUsb := TUsbClass.Create;
  MyUsb.OnUsbInsertion := UsbIN;
  MyUsb.OnUsbRemoval := UsbOUT;

  PublicServerSocket.Port := StrToInt(stPublicPort);
  PublicServerSocket.Active := true;

  IdTCPChat.Bindings.Add.IP := LocalData.GetIPAddress;
  IdTCPChat.Bindings.Add.Port := StrToInt(stChatPort) ;
  IdTCPChat.Active := true;

  IdTCPServerRemoteDesktop.Bindings.Add.IP := LocalData.GetIPAddress;
  IdTCPServerRemoteDesktop.Bindings.Add.Port := StrToInt(stRDport) ;
  IdTCPServerRemoteDesktop.Active := true;

  IdTCPServerFileTransfer.Bindings.Add.IP := LocalData.GetIPAddress;
  IdTCPServerFileTransfer.Bindings.Add.Port := StrToInt(stFTport) ;
  IdTCPServerFileTransfer.Active := true;

  IdTCPServerCMD.Bindings.Add.IP := LocalData.GetIPAddress;
  IdTCPServerCMD.Bindings.Add.Port := StrToInt(stCMDport) ;
  IdTCPServerCMD.Active := true;

end;

procedure TForm4.TimerAppRunTimer(Sender: TObject);
begin
   lstWindows.Items.Clear;
   today := Now;
   EnumWindows(@EnumWindowsProc, LPARAM(lstWindows));
   AddToList;
end;

procedure TForm4.TimerIdleTimer(Sender: TObject);
begin
if IdleTime > 180 then
begin
  NowStatus := '4';
  IdleDuration := Format('%d' ,[IdleTime DIV 60]);
  SumIdleToday := SumIdleToday + IdleTime;
end
else
begin
  NowStatus := '1';
  IdleDuration := '0';
end;
end;

procedure TForm4.AddToList;
var
line,index : integer;
item : string;
begin
NewAppList.Clear;
line := lstWindows.Items.Count;
index := 0;
while index < line do
begin
 item := lstWindows.Items[index];
 if item <> '' then
 begin
   if item <> 'Program Manager' then
   begin
    if item <> 'Start' then
    begin
     if item <> 'Screen Saver' then
     begin
      if item <> 'AgentSrv' then
      begin
        if item <> 'Start Menu' then
        begin
           NewAppList.Add(item);
        end;
      end;
     end;
    end;
   end;
 end;
 inc(index);
end;
if LastAppList.Count = 0 then FirstRun
else
begin
   TempAppList := AssignList(NewAppList);
   ComparLists(NewAppList,LastAppList);
   if (NewAppList.Count > 0) AND (LastAppList.Count = 0) then
     begin
         ProgramOpenEvent(NewAppList);
     end;
   if (NewAppList.Count = 0) AND (LastAppList.Count > 0) then
     begin
        ProgramCloseEvent(LastAppList);
     end;
   if (NewAppList.Count > 0) AND (LastAppList.Count > 0) then
     begin
        ProgramOpenEvent(NewAppList);
        ProgramCloseEvent(LastAppList);
     end;
   LastAppList := AssignList(TempAppList);
end;
end;

procedure TForm4.FirstRun;
var
line,index : integer;
item : string;
begin
line := lstWindows.Items.Count;
index := 0;
while index < line do
begin
 item := lstWindows.Items[index];
 if item <> '' then
 begin
   if item <> 'Program Manager' then
   begin
    if item <> 'Start' then
    begin
     if item <> 'Screen Saver' then
     begin
      if item <> 'AgentSrv' then
      begin
        if item <> 'Start Menu' then
        begin
           NewAppList.Add(item);
        end;
      end;
     end;
    end;
   end;
 end;
 inc(index);
end;
  ProgramOpenEvent(NewAppList);
  LastAppList := AssignList(NewAppList);
  TempAppList := AssignList(LastAppList);
  NewAppList.Clear;
end;

procedure TForm4.TimerStatusTimer(Sender: TObject);
var
res : integer;
begin
MyAgent.UpdateAgentStatusInSql(MyAgent.AgentID,MyAgent.CurrentUser,NowStatus,IdleDuration);
if (NowStatus = '4') AND (SaveInIdleToDb = false)  then
begin
    SaveInIdleToDb := true;
    SaveOutIdleToDb := false;
    res := MyAgent.SaveEventToSql('26005','','Idle In','1','26');
    if res = 0 then
    begin
      LocalData.SaveEventInDll(MyAgent.AgentID,'26005','','Idle In','1','26');
    end;
end;
if (NowStatus <> '4') AND (SaveOutIdleToDb = false) AND (SaveInIdleToDb = true)  then
begin
    SaveOutIdleToDb := true;
    SaveInIdleToDb := false;
    res := MyAgent.SaveEventToSql('26006','','Idle Out','1','26');
    if res = 0 then
    begin
      LocalData.SaveEventInDll(MyAgent.AgentID,'26006','','Idle Out','1','26');
    end;
end;


end;

procedure TForm4.TimerSystemChangesTimer(Sender: TObject);
begin
  MyAgent.SendAppRunsFromDllToSql;
  MyAgent.SendEventFromDllToSql;
  MyAgent.GetSystemInfo;
  MyAgent.GetSystemHashCode;
  IsSystemChanges := MyAgent.CompareTotalHashCodes;
  if IsSystemChanges = true then
  begin
     MyAgent.FindChanges;
     MyAgent.UpdateTotoalSystemHashCode;
  end;
  MyAgent.GetHashCodesFromDll;


end;

procedure TForm4.DoChangeTimer;
begin
 TimerSystemChanges.Enabled := true;
end;


procedure TForm4.GetSettingAgent;
begin
  stAgentPassword := MyAgent.AgentPassword;
  stSQLServerAddress := MyAgent.SQLServerAddress;
  stSQLUsername := MyAgent.SQLUsername;
  stSQLPassword  := MyAgent.SQLPassword;
  stSQLDatabaseName  := MyAgent.SQLDatabaseName;
  stIsRegister  := MyAgent.IsRegister;
  stControlSoftware := MyAgent.ControlSoftware;
  stControlHardware := MyAgent.ControlHardware;
  stControlNetwork := MyAgent.ControlNetwork;
  stControlAccounts := MyAgent.ControlAccounts;
  stChatPort := MyAgent.ChatPort;
  stUDPPort  := MyAgent.UDPPort;
  stAdminMachineIPAddress := MyAgent.AdminMachineIPAddress;
  stVersion := MyAgent.Version;
  stLanguageCode := MyAgent.LanguageCode;
  stRigthToLeft := MyAgent.RigthToLeft;
  stChatWithOther := MyAgent.ChatWithOther;
  stFileTransferToOther := MyAgent.FileTransferToOther;
  stVideoConfToOther := MyAgent.VideoConfToOther;
  stImageProccesing := MyAgent.ImageProccesing;
  stLockIpAddress  := MyAgent.LockIpAddress;
  stSendMail := MyAgent.SendMail;
  stSendSMS := MyAgent.SendSMS;
  stRDport := MyAgent.RemoteDesktopPort;
  stFTPort := MyAgent.FileTransferPort;
  stCMDPort := MyAgent.CMDPort;
  srVideoConfPort := MyAgent.VideoConfPort;
  stWebinarPort := MyAgent.WebinarPort;
  stPublicPort := MyAgent.PublicPort;
  stUsbAccessControl := MyAgent.UsbAccessControl;
  stUsbDataControl := MyAgent.UsbDataControl;
  stRegAccessControl := MyAgent.RegAccessControl;
  stAppInstallDisable := MyAgent.AppInstallDisable;
  stAppRunDisable := MyAgent.AppRunDisable;
  stDisableCtrlAltDel := MyAgent.DisableCtrlAltDel;
  stUpdateCounter:= MyAgent.UpdateCounter;

end;



procedure TForm4.IdTCPChatExecute(AContext: TIdContext);
var
  RcvTxt,Command: string;
  RcvBuff: TMemoryStream;
begin
  RcvBuff:= TMemoryStream.Create;

  AContext.Connection.IOHandler.ReadStream(RcvBuff, -1, False);
  ClientIP := AContext.Binding.PeerIP;
  RcvBuff.Position := 0;

  RcvTxt := MemoryStreamToString(RcvBuff);

  SenderIP := AContext.Connection.Socket.Binding.PeerIP;

  RcvBuff.Free;

  //ReciveTCPMessage(RcvTxt);

  Command := Copy(RcvTxt, 1, 5);


   if (Command = 'MSGOP') then begin       {ChatBox Open}
      ReciveMessage(RcvTxt);
   end else

   if (Command = 'MSGPM') then begin       {ChatBox Open}
      RecivePM(RcvTxt);
   end else
   begin
    AContext.Connection.Disconnect;
   end;


 end;



procedure TForm4.IdTCPServerCMDExecute(AContext: TIdContext);
var
  RcvTxt: string;
  RcvBuff: TMemoryStream;
begin
  RcvBuff:= TMemoryStream.Create;

  AContext.Connection.IOHandler.ReadStream(RcvBuff, -1, False);
  ClientIP := AContext.Binding.PeerIP;
  RcvBuff.Position := 0;

  RcvTxt := MemoryStreamToString(RcvBuff);

  SenderIP := AContext.Connection.Socket.Binding.PeerIP;

  RcvBuff.Free;

  ReciveTCPMessage(RcvTxt);

 end;



procedure TForm4.IdTCPServerFileTransferExecute(AContext: TIdContext);
var
mStream: TMemoryStream;
fStream: TFileStream;
filename : string;
Autorize : boolean;
begin
//  Autorize := false;
 // Autorize := CheckAutorize(AContext.Connection.Socket.Binding.PeerIP);
 // if Autorize = true then
 // begin
  filename := AContext.Connection.IOHandler.ReadLn;

  mStream:= TMemoryStream.Create;
  fStream:= TFileStream.Create(filename,fmCreate);

  AContext.Connection.IOHandler.ReadStream(mStream, -1, False);
  mStream.Position := 0;

  fStream.CopyFrom(mStream,0);

  fStream.Free;
  mStream.Free;
 // end else
 // begin
 //  AContext.Connection.Disconnect;
 // end;

end;

procedure TForm4.IdTCPServerRemoteDesktopExecute(AContext: TIdContext);
var
  Response: string;
  fstream: TMemoryStream;
  MyJpegImage: TJPEGImage;
  tempBuf: tidbytes;
  Autorize : boolean;
begin
// Autorize := false;
  //Autorize := CheckAutorize(AContext.Connection.Socket.Binding.PeerIP);
 // if Autorize = true then
//  begin
  Response := AContext.Connection.IOHandler.ReadLn;
  if Response = 'jpg' then
  begin
    MyJpegImage := TJPEGImage.Create;
    fstream := TMemoryStream.Create;
    try
      TMySync.DoTheWork;
      MyJpegImage.Assign(MyFormJpeg);
      MyJpegImage.CompressionQuality := 75;
      MyJpegImage.SaveToStream(fstream);
      AContext.Connection.IOHandler.LargeStream := true;
      AContext.Connection.IOHandler.Write(fstream, 0, true);
    finally
      fstream.Free;
      MyJpegImage.Free;
    end;
  end;
  if Response = 'mouse' then
  begin
    AContext.Connection.IOHandler.ReadBytes(tempBuf, SizeOf(TMyRecord), false);
    BytesToRaw(tempBuf, MyRecServer, SizeOf(TMyRecord));
    // dc := GetDC(0);
    SetCursorPos(MyRecServer.ButtonX, MyRecServer.ButtonY);
    case MyRecServer.ButtonLorD of
      'L':
        case MyRecServer.ButtonAction of
          'D':
            mouse_event(MOUSEEVENTF_LEFTDOWN, MyRecServer.ButtonX,
              MyRecServer.ButtonY, 0, 0);
          'U':
            mouse_event(MOUSEEVENTF_LEFTUP, MyRecServer.ButtonX,
              MyRecServer.ButtonY, 0, 0);
        end;
      'R':
        case MyRecServer.ButtonAction of
          'D':
            mouse_event(MOUSEEVENTF_RIGHTDOWN, MyRecServer.ButtonX,
              MyRecServer.ButtonY, 0, 0);
          'U':
            mouse_event(MOUSEEVENTF_RIGHTUP, MyRecServer.ButtonX,
              MyRecServer.ButtonY, 0, 0);
        end;
    end;
  end;
  if Response = 'mousepos' then
  begin
    AContext.Connection.IOHandler.ReadBytes(tempBuf, SizeOf(TMyRecord), false);
    BytesToRaw(tempBuf, MyRecServer, SizeOf(TMyRecord));
    SetCursorPos(MyRecServer.ButtonX, MyRecServer.ButtonY);
  end;
 // end else
 // begin
 //  AContext.Connection.Disconnect;
 // end;

end;


procedure TForm4.ReciveTCPMessage(Msg:String);
 var
   RecTxt, Command : string;

begin

   RecTxt := Msg;

   Command := Copy(RecTxt, 1, 5);

   if (Command = 'GETDI') then begin       {Get Directory}
      GetDirectory(RecTxt);
   end else

   if (Command = 'FITRF') then begin       {File Transfer }
      FileTransferOreder(RecTxt);
   end else

   if (Command = 'GETDR') then begin       {Get Drive list}
      GetDriveList(RecTxt);
   end else

   if (Command = 'RDSTR') then begin       {Remote Desktop Start}
      //RemoteDesktopStart;
   end else

   if (Command = 'EXECU') then begin       {Execute a program}
      ExecuteApplication(RecTxt);
   end else

   if (Command = 'DELET') then begin       {Delete a file or folder}
      DelFile(RecTxt);
   end else

   if (Command = 'RENAM') then begin       {Rename a file or folder}
      RenamFile(RecTxt);
   end else

    if (Command = 'MKDIR') then begin       {Make a folder}
      MakeFolder(RecTxt);
   end else

   if (Command = 'SYSDR') then begin
      SendSysDirToClient(RecTxt);
   end else

   if (Command = 'DOCMD') then begin
      SendCmdResultToClient(RecTxt);
   end else

    if (Command = 'RDSTP') then begin       {Remote Desktop Stop}
      //RemoteDesktopStop;
   end else
   begin

   end;


end;

procedure TForm4.SendSysDirToClient(Comn : string);
var
sIndex : integer;
s : string;
begin
sIndex := Pos(']',Comn);
ClientPort := Copy(Comn,7,sIndex - 7);
s := 'SYSDR' + '[' + Sys32Dir + ']';
SendResult(s);
end;

function TForm4.GetSysDir: string;
var
  Buffer: array[0..MAX_PATH] of Char;
begin
   GetSystemDirectory(Buffer, MAX_PATH - 1);
   SetLength(Result, StrLen(Buffer));
   Result := Buffer;
end;

function TForm4.GetDosOutput(CommandLine: string; Work: string): string;
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

procedure TForm4.SendCmdResultToClient(Cmd : string);
var
sIndex : integer;
path,comand,r : string;
begin
sIndex := Pos(']',Cmd);
path := Copy(Cmd,7,sIndex - 7);
Delete(Cmd,1,sIndex);
sIndex := Pos(']',Cmd);
comand := Copy(Cmd,2,sIndex - 2);

output := GetDosOutput(comand,path);

r := 'DOCMD' + '[' + output + ']' ;

SendResult(r);

output := '';


end;


procedure TForm4.SendResult(Res:string);
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


procedure TForm4.MakeFolder(RecTxt:string);
var
Path : string;
begin
Path := Copy(RecTxt,7,length(RecTxt)-7);
MkDir(Path);
end;

procedure TForm4.RenamFile(RecTxt:string);
var
oldPath,newPath: string;
sIndex : integer;
begin

sIndex := Pos(']',RecTxt);

oldPath := Copy(RecTxt,7,sIndex -7);
Delete(RecTxt,1,sIndex);

newPath := Copy(RecTxt,2,length(RecTxt)-2);
RenameFile(oldPath,newPath);

end;

procedure TForm4.DelFile(RecTxt:string);
var
FileName,FileType : string;
sIndex,SelectType : integer;
begin
sIndex := Pos(']',RecTxt);

FileName := Copy(RecTxt,7,sIndex -7);
Delete(RecTxt,1,sIndex);

FileType := Copy(RecTxt,2,length(RecTxt)-2);
SelectType := StrToInt(FileType);

if SelectType > 1 then DeleteFile(FileName);
if SelectType = 1 then RmDir(FileName);

end;

procedure TForm4.ExecuteApplication(RecTxt:string);
var
FileName : string;
begin
FileName := Copy(RecTxt,7,length(RecTxt)-7);
ShellExecute(Handle, 'open', PWideChar(FileName) , nil, nil, SW_SHOWNORMAL);
end;

function TForm4.MemoryStreamToString(M: TMemoryStream): string;
begin
  SetString(Result, PChar(M.Memory), M.Size div SizeOf(Char));
end;

procedure TForm4.GetMessage;
begin
  msgChat := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','msgChat');
  msgScreenShot := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','msgScreenShot');
  msgVideo := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','msgVideo');
  msgSendFile := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','msgSendFile');
  msgAbout := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','msgAbout');
  msgHelp := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','Help');
  msgSendRequest := LocalData.GetMessageFromDll(stLanguageCode,'frmMain','SendRequest');
end;

procedure TForm4.FillMenu;
begin
   mnuChat.Caption := msgChat;
   mnuScreenshot.Caption := msgScreenShot;
   mnuAbout.Caption := msgAbout;
   mnuSendFile.Caption := msgSendFile;
   mnuVideo.Caption := msgVideo;
   mnuHelp.Caption := msgHelp;
   mnuSendRequset.Caption := msgSendRequest;
end;


procedure TForm4.FormClose(Sender: TObject; var Action: TCloseAction);
begin
CoolTrayIcon1.Destroy;
Timer1.Destroy;
TimerSystemChanges.Destroy;
IdTCPServerRemoteDesktop.Destroy;
IdUDPServer1.Destroy;
IdUDPClient1.Destroy;
IdTCPClient1.Destroy;
IdTCPChat.Destroy;
IdTCPClientFileTransfer.Destroy;
IdTCPServerFileTransfer.Destroy;
PublicServerSocket.Destroy;
IdTCPServerCMD.Destroy;
IdTCPServerWebinar.Destroy;
IdTCPServerVideoConference.Destroy;
Free;
end;

procedure TForm4.FormCreate(Sender: TObject);
var
   DllNotFound : boolean;
   buttonSelected : Integer;
begin

  //DllNotFound := false;
  //LocalData.AgentsFileHandle := LocalData.OpenFiles('Agents.dll');
  //if LocalData.AgentsFileHandle = -1 then
  //begin
  //  buttonSelected := MessageDlg('Agents.dll File not found.',mtError,[mbOk],0,mbOk);
  //  DllNotFound := true;
  //end;

  //LocalData.AgentdFileHandle := LocalData.OpenFiles('Agentd.dll');
  //if LocalData.AgentdFileHandle = -1 then
  //begin
  //  buttonSelected := MessageDlg('Agentd.dll File not found.',mtError,[mbOk],0,mbOk);
  //  DllNotFound := true;
  //end;

  //LocalData.AgentmFileHandle := LocalData.OpenFiles('Agentm.dll');
  //if LocalData.AgentmFileHandle = -1 then
  //begin
  //  buttonSelected := MessageDlg('Agentm.dll File not found.',mtError,[mbOk],0,mbOk);
  //  DllNotFound := true;
  //end;

  //if DllNotFound then Application.Terminate;
   Timer1.Enabled := true;
   Screen.MenuFont.Name := 'Tahoma';
   Screen.MenuFont.Size := 10;
   NewAppList := TStringList.Create;
   LastAppList := TStringList.Create;
   TempAppList := TStringList.Create;
   ConnectionsIP := TStringList.Create;
   ConnectionAutorized := TStringList.Create;
   ClientCounter := 0;
   today := Now;
   EnumWindows(@EnumWindowsProc, LPARAM(lstWindows));
   //TODO :check for running under disassembler-
   LocalData.SetConnString;
   agid := LocalData.GetDataFromDll('AgentDetails','AgentID','1');
   sqlser := LocalData.GetDataFromDll('AgentSetting','SQLServerAddress','1');
   sqldbn := LocalData.GetDataFromDll('AgentSetting','SQLDatabaseName','1');
   sqlusern := LocalData.GetDataFromDll('AgentSetting','SQLUsername','1');
   sqlpass := LocalData.GetDataFromDll('AgentSetting','SQLPassword','1');
   stLockSerialNumber := LocalData.GetDataFromDll('AgentSetting','LockSerialNumber','1');
   //TODO : check for correct dll with agentid and uuid
   FirstRun;
   TimerAppRun.Enabled := true;
end;

procedure TForm4.ProgramOpenEvent(CList:TStringList);
var
i,len : integer;
begin
i := 0;
len := CList.Count;
while i < len do
begin
   //save to sql
   LocalData.SaveAppRunsToSql(sqlser,sqldbn,sqlusern,sqlpass,agid,
                              CList[i],'1',FormatDateTime('hh:mm:ss',today),
                              DateToStr(today));
   inc(i);
end;
end;

procedure TForm4.ProgramCloseEvent(LList:TStringList);
var
i,len : integer;
begin
i := 0;
len := LList.Count;
while i < len do
begin
   //save to  sql
   LocalData.SaveAppRunsToSql(sqlser,sqldbn,sqlusern,sqlpass,agid,
                              LList[i],'0',FormatDateTime('hh:mm:ss',today),
                              DateToStr(today));
   inc(i);
end;
end;


function TForm4.AssignList(CList:TStringList):TstringList;
var
index , line : integer;
NList : TStringList;
begin
index := 0;
line  := CList.Count;
NList := TStringList.Create;

while index < line do
begin
  NList.Add(CList[index]);
  inc(index);
end;
result := NList;
end;

procedure TForm4.ComparLists(var NewList:TStringList;var LastList:TStringList);
var
i,m,lenList1,lenList2,findIndex : integer;
curValue : string;
begin
lenList1 := NewList.Count;
lenList2 := LastList.Count;
i := 0;
m := 0;
while i < lenList1 do
  begin
    curValue := NewList[m];
    findIndex := LastList.IndexOf(curValue);
    if findIndex <> -1 then
    begin
       LastList.Delete(findIndex);
       NewList.Delete(m);
      // m := 0;
    end else
    begin
       inc(m);
    end;
    inc(i);
end;
end;

procedure TForm4.UsbIN(ASender : TObject; const ADevType,ADriverName,
                       AFriendlyName : string);
 var
 res : integer;
 mess : string;
begin
   if AFriendlyName = '' then mess := ADevType;
   if AFriendlyName <> '' then mess := AFriendlyName;


   res := MyAgent.SaveEventToSql('27001','',mess,'2','27');
   //showmessage('USB Inserted - Device Type = ' + ADevType + #13#10 +
   //            'Driver Name = ' + ADriverName + #13+#10 +
   //            'Friendly Name = ' + AFriendlyName);
    if res = 0 then
   begin
      LocalData.SaveEventInDll(MyAgent.AgentID,'27001','',mess,'2','27');
   end;
 end;


procedure TForm4.UsbOUT(ASender : TObject; const ADevType,ADriverName,
                         AFriendlyName : string);
 var
 res : integer;
 mess : string;
 begin
   if AFriendlyName = '' then mess := ADevType;
   if AFriendlyName <> '' then mess := AFriendlyName;

   res := MyAgent.SaveEventToSql('27002','',mess,'2','27');
   if res = 0 then
   begin
      LocalData.SaveEventInDll(MyAgent.AgentID,'27002','',AFriendlyName,'2','27');
   end;
 end;

 procedure TForm4.WMEndSession(var Msg: TWMEndSession);
var
 res : integer;
begin
  if Msg.EndSession = True then
  begin
    MyAgent.UpdateAgentStatusInSql(MyAgent.AgentID,MyAgent.CurrentUser,'2','0');
    res := MyAgent.SaveEventToSql('26002','','Normal Shutdown','1','26');
    if res = 0 then
    begin
      LocalData.SaveEventInDll(MyAgent.AgentID,'26002','','Normal Shutdown','1','26');
    end;
  end;
  inherited;
end;

procedure TForm4.WMPowerBroadcast(var AMessage: TMessage);
var
res : integer;
const
  PBT_APMSUSPEND = 4;
  PBT_APMRESUMESUSPEND = 7;
begin
  case AMessage.WParam of
    PBT_APMSUSPEND:
    begin
      MyAgent.UpdateAgentStatusInSql(MyAgent.AgentID,MyAgent.CurrentUser,'3','0');
      res := MyAgent.SaveEventToSql('26003','','Power Suspend','1','26');
      if res = 0 then
      begin
       LocalData.SaveEventInDll(MyAgent.AgentID,'26003','','Power Suspend','1','26');
      end;
    end;
    PBT_APMRESUMESUSPEND:
    begin
      MyAgent.UpdateAgentStatusInSql(MyAgent.AgentID,MyAgent.CurrentUser,'1','0');
      res := MyAgent.SaveEventToSql('26004','','Power Resume Suspend','1','26');
      if res = 0 then
      begin
       LocalData.SaveEventInDll(MyAgent.AgentID,'26004','','Power Resume Suspend','1','26');
      end;
    end;
  else
     // you're going to want to handle PBT_APMRESUMECRITICAL (XP and older systems) and PBT_APMRESUMEAUTOMATIC differently
     // IIRC you did not get notification of the suspend in this case
  end;
end;

procedure TForm4.ReciveMessage(ReciveMes:string);
var
sender,msg,senderPort,myComputerName:string;
senderEndIndex,senderPortIndex,ReciveMesLength,newindex:integer;
SqlConS : string;

begin
 SqlConS := 'Provider=SQLOLEDB;Data Source='+Trim(stSQLServerAddress)+
                    ';Initial Catalog='+Trim(stSQLDatabaseName)+
                    ';User Id='+Trim(stSQLUsername)+
                    ';Password='+Trim(stSQLPassword);

 myComputerName := LocalData.GetDataFromDll('AgentDetails','ComputerName','1');
 ReciveMesLength := length(ReciveMes);
 senderEndIndex := Pos(':',ReciveMes);
 senderPortIndex :=  Pos('/',ReciveMes);
 sender := Copy(ReciveMes, 6, (senderEndIndex-6));
 senderPort := Copy(ReciveMes,senderEndIndex+1,senderPortIndex - senderEndIndex-1);
 LocalData.ChatUsersList.Add(sender);
 SetLength(ChatForms,length(ChatForms)+1);

 newindex := length(ChatForms)- 1;
 msg := copy(ReciveMes,(senderPortIndex+1),(ReciveMesLength - length(sender) - length(senderPort) - 5));
 ChatForms[newindex]  := TfrmPm.Create(msg,sender,stLanguageCode,SenderIp,stChatPort,myComputerName,senderPort,SqlConS);
 ChatForms[newindex].ShowModal;


 ChatForms[newindex].Destroy;

end;

procedure TForm4.RecivePM(ReciveMes:string);
var
sender,msg,senderPort:string;
senderEndIndex,senderPortIndex,ReciveMesLength,findindex:integer;
begin
 ReciveMesLength := length(ReciveMes);
 senderEndIndex := Pos(':',ReciveMes);
 senderPortIndex :=  Pos('/',ReciveMes);
 sender := Copy(ReciveMes, 6, (senderEndIndex-6));
 senderPort := Copy(ReciveMes,senderEndIndex+1,senderPortIndex - senderEndIndex-1);
 findIndex := LocalData.ChatUsersList.IndexOf(sender);
 msg := copy(ReciveMes,(senderPortIndex+1),(ReciveMesLength - length(sender) - length(senderPort) - 5));

 if findIndex <> -1 then
    begin
     ChatForms[findIndex].SetFocus;
     ChatForms[findIndex].lblSenderPort.Caption := senderPort;
     ChatForms[findIndex].AddText(#10#13+sender + ' : '+ msg,clRed,ChatForms[findIndex].redLog);
     ChatForms[findIndex].redLog.SetFocus;
     ChatForms[findIndex].redLog.SelStart := ChatForms[findIndex].redLog.GetTextLen;
     SendMessage(ChatForms[findIndex].redLog.Handle, WM_VSCROLL, SB_BOTTOM, 0);

     ChatForms[findIndex].redMsg.SetFocus;
    

     end;
 if findIndex = -1 then
    begin
       ReciveMessage(ReciveMes);
    end;
end;

procedure TForm4.GetDirectory(Path:string);
var
realPath,senderIP,senderPort,nodeIndex,nodeLevel,treeviewNumber: string;
indexEnd: integer;
begin
indexEnd := Pos(']',Path);
realPath := Copy(Path,7,indexEnd - 7);
Delete(Path,1,indexEnd);


indexEnd := Pos(']',Path);
nodeLevel := Copy(Path,2,indexEnd - 2);
Delete(Path,1,indexEnd);



indexEnd := Pos(']',Path);
nodeIndex := Copy(Path,2,indexEnd - 2);
Delete(Path,1,indexEnd);


indexEnd := Pos(']',Path);
senderPort := Copy(Path,2,indexEnd - 2);
Delete(Path,1,indexEnd);


indexEnd := Pos(']',Path);
senderIP := Copy(Path,2,indexEnd - 2);
Delete(Path,1,indexEnd);


indexEnd := Pos(']',Path);
treeviewNumber := Copy(Path,2,indexEnd - 2);
Delete(Path,1,indexEnd);

ListFileDir(realPath,senderIP,senderPort,nodeIndex,nodeLevel,treeviewNumber);

end;

procedure TForm4.GetDriveList(RecTxt:string);
var
DList : LocalData.TStringArray;
len : integer;
alllist : string;
SendTxt : string;
ComputerName : string;
ListNumber : string;
ServerPort : string;
begin
ListNumber := Copy(RecTxt,7,1);

ServerPort := Copy(RecTxt,10,length(RecTxt) - 10);
DList := LocalData.GetDriveLetters;
 len := 0;
ComputerName := LocalData.GetDataFromDll('AgentDetails','ComputerName','1');
alllist := '[' + ComputerName + '][' + ListNumber + ']';
  while len < length(DList) do
  begin
     alllist := alllist + '['+ DList[len] + ']';
     inc(len);
  end;
SendTxt := 'SETDR'+alllist;
SendTCPDataToServer(SendTxt,SenderIP,ServerPort);

end;


procedure TForm4.SendTCPDataToServer(data:string;HostIp:string;HostPort:string);
var
StrLen : integer;
SndBuff : TMemoryStream;
begin
     IdTCPClient1.Host := HostIp;
     IdTCPClient1.Port := StrToInt(HostPort);
     IdTCPClient1.Connect;
     StrLen := Length(data);

     SndBuff := TMemoryStream.Create;
     SndBuff.Write(data[1],StrLen * SizeOf(data[1]));
     SndBuff.Position := 0;

     IdTCPClient1.IOHandler.Write(SndBuff,0,true);
     IdTCPClient1.Disconnect;
end;

function TForm4.CheckAutorize(RemoteIP:string):boolean;
var
listIndex : integer;
res : boolean;
begin
  res := false;
  listIndex := ConnectionsIP.IndexOf(RemoteIP);
  if listIndex <> -1 then res := true;
  Result := res;
end;

procedure TForm4.PublicServerSocketClientRead(Sender: TObject;
  Socket: TCustomWinSocket);
var
 RecTxt,Command:Ansistring;
 listIndex : integer;
 Autorize : boolean;
 pass : string;
 SocketIndex : integer;
begin
//Autorize := false;
//pass := EncDec.Decrypt(stAgentPassword,stLockSerialNumber);
RecTxt := EncDec.Decrypt(Socket.ReceiveText,stLockSerialNumber);
Command := Copy(RecTxt,1,5);

if (Command = 'LOGIN') then begin
      if (Copy(RecTxt, 6, Length(RecTxt)) <> pass) then begin
        //PublicServerSocket.Socket.Disconnect(0);
        //Autorize := false;
       // Autorized := false;
      end else
      begin
       // ConnectionsIP.Add(PublicServerSocket.Socket.Connections[ClientCounter].RemoteAddress);
       // Autorized := true;
      //  inc(ClientCounter);
      end;

end else

if (Command = 'LOGOT') then begin
      // listIndex := ConnectionsIP.IndexOf(PublicServerSocket.Socket.Connections[ClientCounter].RemoteAddress);
       //ConnectionsIP.Delete(listIndex);
       PublicServerSocket.Socket.Disconnect(0);
end else

if (Command = 'HELLO') then begin       {Hello Message}
      //SendHello(Socket.RemoteHost);
end else


if (Command = 'GETDI') then begin       {Get Directory}
    GetDirectory(RecTxt);
    //  Autorize := CheckAutorize(Socket.RemoteHost);
  //    if Autorize  then GetDirectory(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'FITRF') then begin       {File Transfer }
     // Autorize := CheckAutorize(Socket.RemoteHost);
     FileTransferOreder(RecTxt);
     // if Autorize  then FileTransferOreder(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'GETDR') then begin       {Get Drive list}
     // Autorize := CheckAutorize(Socket.RemoteHost);
     GetDriveList(RecTxt);
      //if Autorize  then GetDriveList(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'RDSTR') then begin       {Remote Desktop Start}
      //Autorize := CheckAutorize(Socket.RemoteHost);
     // if Autorize  then //RemoteDesktopStart
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'EXECU') then begin       {Execute a program}
     // Autorize := CheckAutorize(Socket.RemoteHost);
     ExecuteApplication(RecTxt);
   //   if Autorize  then ExecuteApplication(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'DELET') then begin       {Delete a file or folder}
    //  Autorize := CheckAutorize(Socket.RemoteHost);
    DelFile(RecTxt);
    //  if Autorize  then DelFile(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'RENAM') then begin       {Rename a file or folder}
    //  Autorize := CheckAutorize(Socket.RemoteHost);
    RenamFile(RecTxt);
   //   if Autorize  then RenamFile(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'MKDIR') then begin       {Make a folder}
     // Autorize := CheckAutorize(Socket.RemoteHost);
     MakeFolder(RecTxt);
    //  if Autorize  then MakeFolder(RecTxt)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'SYSDR') then begin
     // Autorize := CheckAutorize(Socket.RemoteHost);
     SendSysDirToClient(RecTxt);
    //  if Autorize  then SendSysDirToClient(RecTxt)
     // else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'DOCMD') then begin
   //   Autorize := CheckAutorize(Socket.RemoteHost);
   SendCmdResultToClient(RecTxt);
    //  if Autorize  then SendCmdResultToClient(RecTxt)
   //   else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'RDSTP') then begin       {Remote Desktop Stop}
   //   Autorize := CheckAutorize(Socket.RemoteHost);
   //   if Autorize  then //RemoteDesktopStop
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'CDOPN') then begin  {CDROM Open}
   mciSendString('Set cdaudio door open wait', nil, 0, 0);
   //   Autorize := CheckAutorize(PublicServerSocket.Socket.Connections[ClientCounter - 1].RemoteAddress);
    //  if Autorize  then mciSendString('Set cdaudio door open wait', nil, 0, handle)
   //   else PublicServerSocket.Socket.Disconnect(0);


end else

if (Command = 'CDCLZ') then begin {CDROM Close}
    mciSendString('Set cdaudio door closed wait', nil, 0, 0);
  //    Autorize := CheckAutorize(PublicServerSocket.Socket.Connections[ClientCounter - 1].RemoteAddress);
  //    if Autorize  then mciSendString('Set cdaudio door closed wait', nil, 0, handle)
   //   else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'MONOF') then begin {Monitor Off}
     SendMessage(Application.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
    //  Autorize := CheckAutorize(PublicServerSocket.Socket.Connections[ClientCounter - 1].RemoteAddress);
    //  if Autorize  then SendMessage(Application.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'MONON') then begin {Monitor On}
      SendMessage(Application.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, -1);
     // Autorize := CheckAutorize(PublicServerSocket.Socket.Connections[ClientCounter - 1].RemoteAddress);
    //  if Autorize  then SendMessage(Application.Handle, WM_SYSCOMMAND, SC_MONITORPOWER, -1)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'SYSOF') then begin    {Sysyem Shutdown}
     ShellExecute(handle, 'open', 'shutdown', '-s -t 10', '', SW_NORMAL);
    //  Autorize := CheckAutorize(PublicServerSocket.Socket.Connections[ClientCounter - 1].RemoteAddress);
    //  if Autorize  then  ShellExecute(handle, 'open', 'shutdown', '-s -t 10', '', SW_NORMAL)
   //   else PublicServerSocket.Socket.Disconnect(0);

end else

if (Command = 'SYSRE') then begin       {Sysyem Restart}
      ShellExecute(handle, 'open', 'shutdown', '-r -t 10', '', SW_NORMAL);
     // Autorize := CheckAutorize(PublicServerSocket.Socket.Connections[ClientCounter - 1].RemoteAddress);
      //if Autorize  then  ShellExecute(handle, 'open', 'shutdown', '-r -t 10', '', SW_NORMAL)
    //  else PublicServerSocket.Socket.Disconnect(0);

end else
begin
     PublicServerSocket.Socket.Disconnect(0);
     //Autorize := false;
end;
end;

procedure TForm4.SendHello(RemoteIP:string;RemotePort:integer);
begin
  IdUDPClient1 := TIdUDPClient.Create(nil);
  IdUDPClient1.Host := RemoteIP;
  IdUDPClient1.Port := RemotePort;
  IdUDPClient1.Active := true;
  IdUDPClient1.Send('HELOK');
  IdUDPClient1.Active := false;
  IdUDPClient1.Disconnect;
  IdUDPClient1.Destroy;
end;

procedure TForm4.ListFileDir(Path:string;SenderIP:string;SenderPort:string;NodeIndex:string;NodeLevel:string;TreeviewNumber:string);
var
  SR: TSearchRec;
  files_folders : TStringList;
  alllist,data : string;
  len : integer;
  nullIndex : integer;
begin
  files_folders := TStringList.Create;
  if FindFirst(Path +'\*.*', faAnyFile, SR) = 0 then
  begin
    repeat
    if (SR.Name <> '.') AND (SR.Name <> '..') AND (Lowercase(SR.Name) <> '$recycle.bin') then
    begin  { Step 1 start }
      if (SR.Attr <> 32) AND (SR.Attr <> 38) AND (SR.Attr <> 8230) then {Step 2 Start - Folder}
      begin

        if files_folders.IndexOf('') = -1 then
        begin
         files_folders.Add(IntToStr(SR.Attr)+';'+SR.Name);
        end;
        if files_folders.IndexOf('') <> -1 then
        begin
          nullIndex := files_folders.IndexOf('');
          files_folders.Delete(nullIndex);
          files_folders.Insert(nullIndex,IntToStr(SR.Attr)+';'+SR.Name);
          files_folders.Insert(nullIndex+1,'');
        end;
      end else{Step 2 End - Folder}
      begin {Step 3 Start - File}
        if files_folders.IndexOf('') <> -1 then
        begin
         files_folders.Add(IntToStr(SR.Attr)+';'+SR.Name);
        end;
        if files_folders.IndexOf('') = -1 then
        begin
        files_folders.Add('');
        files_folders.Add(IntToStr(SR.Attr)+';'+SR.Name);
        end;
      end; {Step 3 End - File}

    end;  { Step 1 end }
    until FindNext(SR) <> 0;
    FindClose(SR);
  end;
  nullIndex := files_folders.IndexOf('');
  while nullIndex <> -1 do
  begin
     files_folders.Delete(nullIndex);
     nullIndex := files_folders.IndexOf('');
  end;

  len := 0;
  alllist := '[Node'+NodeLevel+']['+NodeIndex+'][' + TreeviewNumber + ']';
  while len < files_folders.Count do
  begin
     alllist := alllist + '['+ files_folders[len] + ']';
     inc(len);
  end;

  data := 'DIRDI'+alllist;
  SendTCPDataToServer(data,SenderIP,SenderPort);

end;

procedure TForm4.FileTransferOreder(RecText:string);
var
localFile,remoteFile,destFile,fileName:string;
sourceIP,destiIP:string;
eIndex,len:integer;
fStream : TFileStream;
mStream : TMemoryStream;

msg:string;
begin
len := length(RecText);
msg := Copy(RecText,6,len - 5);

eIndex := Pos(']',msg);

localFile := Copy(msg,2,eIndex -2);
Delete(msg,1,length(localFile)+2);

eIndex := Pos(']',msg);
remoteFile := Copy(msg,2,eIndex -2);
Delete(msg,1,length(remoteFile)+2);

eIndex := Pos(']',msg);
sourceIP := Copy(msg,2,eIndex -2);
Delete(msg,1,length(sourceIP)+2);

eIndex := Pos(']',msg);
destiIP := Copy(msg,2,eIndex -2);
Delete(msg,1,length(destiIP)+2);

eIndex := Pos(']',msg);
fileName := Copy(msg,2,eIndex -2);
Delete(msg,1,length(fileName)+2);

if sourceIP = destiIP then
  begin
  destFile := remoteFile+fileName;
  CopyFile(PChar(localFile), PChar(destFile), true);
  end;
if sourceIP <> destiIP then
begin
    IdTCPClientFileTransfer.Host := destiIP;
    IdTCPClientFileTransfer.Port := StrToInt(stFTPort);
    IdTCPClientFileTransfer.Connect;

    fStream := TFileStream.Create(localFile,fmOpenRead);
    IdTCPClient1.IOHandler.WriteLn(remoteFile);
    IdTCPClientFileTransfer.IOHandler.LargeStream := True;


    mStream := TMemoryStream.Create;
    mStream.LoadFromStream(fStream);
    mStream.Position := 0;

    IdTCPClient1.IOHandler.Write(mStream,0,true);
    IdTCPClient1.Disconnect;
    mStream.Free;
    fStream.Free;
end;
end;

procedure TForm4.CheckAgentVersion(Ver:string);
var
AgentVer : double;
LastAgentVer : double;
begin
AgentVer := StrToFloat(Ver);

end;



{ TMySync }

procedure TMySync.DoSynchronize;
var
  dc: HDC;
  MyBitmap: TBitmap;
  FMyJpeg: TJPEGImage;
begin
  dc := GetDC(0);
  MyBitmap := TBitmap.Create;
  FMyJpeg := TJPEGImage.Create;
  try
    MyBitmap.PixelFormat := pf32bit;
    MyBitmap.Width := Screen.Width;
    MyBitmap.Height := Screen.Height;
    BitBlt(MyBitmap.Canvas.Handle, 0, 0, MyBitmap.Width, MyBitmap.Height, dc, 0,
      0, SRCCOPY);
    FMyJpeg.Assign(MyBitmap);
    Form4.MyFormJpeg.Assign(FMyJpeg);
  finally
    FMyJpeg.Free;
    MyBitmap.Free;
    ReleaseDC(0, dc);
  end;
end;



class procedure TMySync.DoTheWork;
var
  MySync: TMySync;
begin
  MySync := TMySync.Create;
  try
    MySync.Synchronize;
  finally
    MySync.Free;
  end;
end;

end.
