unit frmMain_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs,LocalData, FMX.Objects,ShellApi,
  SQLData,SaveToSqlThread,TAgentClass,frmShowInfo_RtoL,Registry,Windows,GetInfoThreadUnit,
  FMX.StdCtrls;

 {Agent Setting}
  type TAgentSetting = record
    AgentId : string;
    SQLServerAddress : string;
    SQLUsername : string;
    SQLPassword : string;
    SQLDatabaseName : string;
    AgentPassword : string;
    SQLConnString : string;
    RunOnce : string;
    IsRegister : string;
    ControlSoftware : string;
    ControlHardware : string;
    ControlNetwork : string;
    ControlAccounts : string;
    SendSMS : string;
    ChatPort : string;
    UDPPort : string;
    AdminMachineIPAddress : string;
    Version : string;
    LanguageCode : string;
    RigthToLeft : string;
    StepNumber : string;
  end;

  {Main Form Text}
  type TFormMessages = record
    frmCaption : string;
    lblTitle : string;
    lblActive : string;
    lblSQLConnection : string;
    lblGetInfo : string;
    lblRegAgent : string;
    lblSaveInfo : string;
    btnOK : string;

  end;





  type
  TfrmMain_fa = class(TForm)
    StyleBook1: TStyleBook;
    lblTitle: TLabel;
    lblActive: TLabel;
    AniIndicatorActive: TAniIndicator;
    lblSQLConnection: TLabel;
    lblGetInfo: TLabel;
    lblRegAgent: TLabel;
    lblSaveInfo: TLabel;
    AniIndicatorSQL: TAniIndicator;
    AniIndicatorRegAgent: TAniIndicator;
    AniIndicatorGetInfo: TAniIndicator;
    AniIndicatorSaveInfo: TAniIndicator;
    imgActive: TImage;
    imgSQL: TImage;
    imgActiveFail: TImage;
    imgSQLFail: TImage;
    AniIndicatorAll: TAniIndicator;
    TimerActive: TTimer;
    TimerSql: TTimer;
    imgWarning: TImage;
    TimerGetInfo: TTimer;
    imgGetInfoOk: TImage;
    imgGetInfoFail: TImage;
    TimerRegAgent: TTimer;
    imgRegAgentOK: TImage;
    imgRegAgentFail: TImage;
    TimerSaveInfo: TTimer;
    imgSaveInfoOk: TImage;
    imgSaveInfoFail: TImage;
    TimerAgentCheck: TTimer;
    TimerCheckSaveToSql: TTimer;
    imgOK: TImage;




 // procedure FormCreate(Sender: TObject);
  procedure GetAgentSettingFromDll();
  procedure GetFormMessageFromDll();
  procedure FillForm(LanguageCode:string);
  procedure TimerActiveTimer(Sender: TObject);
  procedure TimerSqlTimer(Sender: TObject);
  procedure TimerGetInfoTimer(Sender: TObject);
  procedure TimerRegAgentTimer(Sender: TObject);
  procedure TimerSaveInfoTimer(Sender: TObject);
  procedure TimerAgentCheckTimer(Sender: TObject);
  procedure TimerCheckSaveToSqlTimer(Sender: TObject);
  procedure SaveServiceToReg;
  procedure SetDllSetting;
  procedure SetRegistery;



  private
    { Private declarations }
  public
  constructor Create(AOwner: TComponent); reintroduce; overload;
  constructor Create(FormTitle:string); reintroduce; overload;
    { Public declarations }

  end;



var
  frmMain_fa: TfrmMain_fa;
  SystemAgentSetting : TAgentSetting;
  SystemMessages : TFormMessages;

  t1_result,t2_result,t4_result,t5_result:integer;
  _stepNumber,t3_result : integer;

  MySqlAccess : SQLAccess;

  MySqlThread : TSqlThread;

 // MyAgent1 : TMyAgent;

 // MyAgent : TMyAgent;

  reg : TRegistry;
  MyAgentThread : TMyThread;
  counter:integer;

implementation

{$R *.fmx}

constructor TfrmMain_fa.Create(AOwner: TComponent);
begin
inherited;

end;

constructor TfrmMain_fa.Create(FormTitle:string);
begin
inherited Create(Application);
 TimerActive.Enabled := true;
 GetAgentSettingFromDll;
 if SystemAgentSetting.LanguageCode = '1' then FillForm('1');  {Farsi form}
 if SystemAgentSetting.LanguageCode = '2' then FillForm('2');  {English form}


 AniIndicatorAll.Enabled := true;
 AniIndicatorActive.Visible := true;
 AniIndicatorActive.Enabled := true;
 lblActive.Enabled := true;

 lblActive.Enabled := false;
 lblSQLConnection.Enabled := false;
 lblGetInfo.Enabled := false;
 lblRegAgent.Enabled := false;
 lblSaveInfo.Enabled := false;

 AniIndicatorSQL.Visible := false;
 AniIndicatorGetInfo.Visible := false;
 AniIndicatorRegAgent.Visible := false;
 AniIndicatorSaveInfo.Visible := false;

 imgActive.Visible := false;
 imgSQL.Visible := false;
 imgActiveFail.Visible := false;
 imgSQLFail.Visible := false;
 imgWarning.Visible := false;
 imgGetInfoOk.Visible := false;
 imgGetInfoFail.Visible := false;
 imgRegAgentOK.Visible := false;
 imgRegAgentFail.Visible := false;
 imgSaveInfoOk.Visible := false;
 imgSaveInfoFail.Visible := false;

end;


procedure TfrmMain_fa.GetAgentSettingFromDll();
begin


  SystemAgentSetting.SQLServerAddress := LocalData.GetDataFromDll('AgentSetting','SQLServerAddress','1');
  SystemAgentSetting.SQLUsername := LocalData.GetDataFromDll('AgentSetting','SQLUsername','1');
  SystemAgentSetting.SQLPassword := LocalData.GetDataFromDll('AgentSetting','SQLPassword','1');
  SystemAgentSetting.SQLDatabaseName := LocalData.GetDataFromDll('AgentSetting','SQLDatabaseName','1');
  SystemAgentSetting.AgentPassword := LocalData.GetDataFromDll('AgentSetting','AgentPassword','1');
  SystemAgentSetting.RunOnce := LocalData.GetDataFromDll('AgentSetting','RunOnce','1');
  SystemAgentSetting.IsRegister := LocalData.GetDataFromDll('AgentSetting','IsRegister','1');
  SystemAgentSetting.ControlSoftware := LocalData.GetDataFromDll('AgentSetting','ControlSoftware','1');
  SystemAgentSetting.ControlHardware := LocalData.GetDataFromDll('AgentSetting','ControlHardware','1');
  SystemAgentSetting.ControlNetwork := LocalData.GetDataFromDll('AgentSetting','ControlNetwork','1');
  SystemAgentSetting.ControlAccounts := LocalData.GetDataFromDll('AgentSetting','ControlAccounts','1');
  SystemAgentSetting.SendSMS := LocalData.GetDataFromDll('AgentSetting','SendSMS','1');
  SystemAgentSetting.ChatPort := LocalData.GetDataFromDll('AgentSetting','ChatPort','1');
  SystemAgentSetting.UDPPort := LocalData.GetDataFromDll('AgentSetting','UDPPort','1');
  SystemAgentSetting.AdminMachineIPAddress := LocalData.GetDataFromDll('AgentSetting','AdminMachineIPAddress','1');
  SystemAgentSetting.Version := LocalData.GetDataFromDll('AgentSetting','Version','1');
  SystemAgentSetting.LanguageCode := LocalData.GetDataFromDll('AgentSetting','LanguageCode','1');
  SystemAgentSetting.RigthToLeft := LocalData.GetDataFromDll('AgentSetting','RigthToLeft','1');
  SystemAgentSetting.StepNumber := LocalData.GetDataFromDll('AgentSetting','StepNumber','1');
end;

procedure TfrmMain_fa.GetFormMessageFromDll();
begin
  SystemMessages.frmCaption := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','frmCaption');
  SystemMessages.lblTitle := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblTitle');
  SystemMessages.lblActive := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblActiveWait');
  SystemMessages.lblSQLConnection := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblSQLConnectionWait');
  SystemMessages.lblGetInfo := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblGetInfoWait');
  SystemMessages.lblRegAgent := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblRegAgentWait');
  SystemMessages.lblSaveInfo := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblSaveInfoWait');
  SystemMessages.btnOK := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','btnOK');

  end;

procedure TfrmMain_fa.FillForm(LanguageCode:string);

begin
  GetFormMessageFromDll;

  Caption := SystemMessages.frmCaption;
  lblTitle.Text := SystemMessages.lblTitle;
  lblActive.Text := SystemMessages.lblActive;
  lblSQLConnection.Text := SystemMessages.lblSQLConnection;
  lblGetInfo.Text := SystemMessages.lblGetInfo;
  lblRegAgent.Text := SystemMessages.lblRegAgent;
  lblSaveInfo.Text := SystemMessages.lblSaveInfo;


end;



procedure TfrmMain_fa.TimerActiveTimer(Sender: TObject);
var
_SoftwareActiveCheck : string;
frmShow : TfrmShowInfo_fa;
begin

  TimerActive.Enabled := false;
  {License Control Start}
  AniIndicatorActive.Visible := true;
  AniIndicatorActive.Enabled := true;
  lblActive.Enabled := true;

 _SoftwareActiveCheck := SystemAgentSetting.IsRegister;

 if _SoftwareActiveCheck = '0' then  {Application Not Actived}
  begin
   t1_result := -1;
   AniIndicatorActive.Enabled := false;
   AniIndicatorActive.Visible := false;
   imgActiveFail.Visible := true;
   SystemMessages.lblActive := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblActiveFail');
   lblActive.Text := SystemMessages.lblActive;

  end
  else if _SoftwareActiveCheck = '1' then {Application  Actived}
  begin
   t1_result := 1;
   AniIndicatorActive.Visible := false;
   imgActive.Visible := true;
   SystemMessages.lblActive := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblActiveOK');
   lblActive.Text := SystemMessages.lblActive;
   _stepNumber := StrToInt(SystemAgentSetting.StepNumber);
   if _stepNumber < 1 then LocalData.SetStepNumber(1);
   end;
 if t1_result = 1 then {Sql Connection string control start}
 begin
   AniIndicatorSQL.Visible := true;
   AniIndicatorSQL.Enabled := true;
   lblSQLConnection.Enabled := true;
   TimerSql.Enabled := true;
 end;
 if t1_result = -1 then  { Application  Active control Failed}
 begin
 AniIndicatorAll.Enabled := false;
 AniIndicatorAll.Visible := false;
 imgWarning.Visible := true;
 lblTitle.Visible := false;
 frmShow := TfrmShowInfo_fa.Create(Self);
 frmShow.PMessage := 'RegisterFail';
 frmShow.LangCode := SystemAgentSetting.LanguageCode;
 frmShow.ShowModal;
 Application.Terminate;
 end;

end;





procedure TfrmMain_fa.TimerSqlTimer(Sender: TObject);
var
_SQLConnectionCheck : string;
frmShow : TfrmShowInfo_fa;
begin
  TimerSql.Enabled := false;
  _SQLConnectionCheck := LocalData.CheckSQLConnectionString();
   AniIndicatorSQL.Enabled := false;
   if _SQLConnectionCheck = '0' then  {SQL Connection Check Faill}
   begin
   t2_result := -1;
   AniIndicatorSQL.Visible := false;
   imgSQLFail.Visible := true;
   SystemMessages.lblSQLConnection := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblSQLConnectionFail');
   lblSQLConnection.Text := SystemMessages.lblSQLConnection;
   end
   else if _SQLConnectionCheck = '1' then  {SQL Connection Check Passed}
   begin
   t2_result := 1;
   AniIndicatorSQL.Visible := false;
   imgSQL.Visible := true;
   SystemMessages.lblSQLConnection := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblSQLConnectionOK');
   lblSQLConnection.Text := SystemMessages.lblSQLConnection;
   _stepNumber := StrToInt(SystemAgentSetting.StepNumber);
   if _stepNumber < 2 then LocalData.SetStepNumber(2);
   end;

if t2_result = 1 then  {Get System Information Start}
begin
   AniIndicatorGetInfo.Visible := true;
   AniIndicatorGetInfo.Enabled := true;
   lblGetInfo.Enabled := true;
   TimerGetInfo.Enabled := true;
end;
if t2_result = -1 then
begin
  AniIndicatorAll.Enabled := false;
  AniIndicatorAll.Visible := false;
  imgWarning.Visible := true;
  lblTitle.Visible := false;
  frmShow := TfrmShowInfo_fa.Create(Self);
  frmShow.PMessage := 'SqlConFail';
  frmShow.LangCode := SystemAgentSetting.LanguageCode;
  frmShow.ShowModal;
  Application.Terminate;
end;
end;



procedure TfrmMain_fa.TimerGetInfoTimer(Sender: TObject);
begin

  TimerGetInfo.Enabled := false;

  if _stepNumber < 3 then
  begin

  MyAgentThread := TMyThread.Create(true);
  MyAgentThread.Resume;
  TimerAgentCheck.Enabled := true;


  {
  MyAgent := TMyAgent.Create;
  MyAgent.GetSystemInfo;
  MyAgent.GetSystemHashCode;
  MyAgent.SaveSystemInfoToDll;
  }
  end else
  begin
  TimerAgentCheck.Enabled := true;
  end;


end;

procedure TfrmMain_fa.TimerAgentCheckTimer(Sender: TObject);
var
_totalSystemHashCode : string;
begin

   TimerAgentCheck.Enabled := false;

   _totalSystemHashCode := LocalData.GetDataFromDll('HashCodes','HashCode','1');
    if _totalSystemHashCode <> '' then
    begin
      Counter := 0;
      AniIndicatorGetInfo.Enabled := false;
      AniIndicatorGetInfo.Visible := false;
      imgGetInfoOk.Visible := true;
      SystemMessages.lblGetInfo := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblGetInfoOK');
      lblGetInfo.Text := SystemMessages.lblGetInfo;
      AniIndicatorRegAgent.Visible := true;
      AniIndicatorRegAgent.Enabled := true;
      lblRegAgent.Enabled := true;
      _stepNumber := StrToInt(SystemAgentSetting.StepNumber);
      if _stepNumber < 3 then LocalData.SetStepNumber(3);
      TimerRegAgent.Enabled := true;  {Get AgentId From Sql Start}

  end else
  begin
  if Counter < 20 then
  begin
     inc(Counter);
     TimerAgentCheck.Enabled := true;
  end else
  begin
      TimerAgentCheck.Enabled := false;
      AniIndicatorGetInfo.Enabled := false;
      AniIndicatorGetInfo.Visible := false;
      imgGetInfoOk.Visible := true;
      SystemMessages.lblGetInfo := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblGetInfoOK');
      lblGetInfo.Text := SystemMessages.lblGetInfo;
      AniIndicatorRegAgent.Visible := true;
      AniIndicatorRegAgent.Enabled := true;
      lblRegAgent.Enabled := true;
  end;
  end;

end;



procedure TfrmMain_fa.TimerRegAgentTimer(Sender: TObject);
var
_agentId : integer;
_conSting : string;
_uuid : string;
frmShow : TfrmShowInfo_fa;
begin
  TimerRegAgent.Enabled := false;
  _stepNumber := StrToInt(SystemAgentSetting.StepNumber);

  if _stepNumber < 4 then
  begin
    _uuid := LocalData.GetDataFromDll('Sys','UUID','1');
    _conSting := 'Provider=SQLOLEDB;Data Source='+Trim(SystemAgentSetting.SQLServerAddress)+
                      ';Initial Catalog='+Trim(SystemAgentSetting.SQLDatabaseName)+
                      ';User Id='+Trim(SystemAgentSetting.SQLUsername)+
                      ';Password='+Trim(SystemAgentSetting.SQLPassword);

    MySqlAccess := SQLAccess.Create(_conSting);

   _agentId := MySqlAccess.CheckUUID(_uuid);


    if _agentId > 0 then
    begin
       frmShow := TfrmShowInfo_fa.Create(Self);
       frmShow.PMessage := 'UUID';
       frmShow.LangCode := SystemAgentSetting.LanguageCode;
       frmShow.ShowModal;
       SetDllSetting;
       SetRegistery;
       Application.Terminate;
       exit;
    end;


    _agentId := MySqlAccess.GetLastAgentId;

    LocalData.SaveAgentIdToDll(IntToStr(_agentId));

    LocalData.SetStepNumber(4);
    SystemAgentSetting.AgentId := IntToStr(_agentId);

    AniIndicatorRegAgent.Enabled := false;
    AniIndicatorRegAgent.Visible := false;
    imgRegAgentOK.Visible := true;
    SystemMessages.lblRegAgent := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblRegAgentOK');
    lblRegAgent.Text := SystemMessages.lblRegAgent;
    AniIndicatorSaveInfo.Visible := true;
    AniIndicatorSaveInfo.Enabled := true;
    lblSaveInfo.Enabled := true;
    TimerSaveInfo.Enabled := true;
  end else
  begin
    AniIndicatorRegAgent.Enabled := false;
    AniIndicatorRegAgent.Visible := false;
    imgRegAgentOK.Visible := true;
    SystemMessages.lblRegAgent := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblRegAgentOK');
    lblRegAgent.Text := SystemMessages.lblRegAgent;
    AniIndicatorSaveInfo.Visible := true;
    AniIndicatorSaveInfo.Enabled := true;
    lblSaveInfo.Enabled := true;
    TimerSaveInfo.Enabled := true;
  end;

end;

procedure TfrmMain_fa.SetDllSetting;
begin
  LocalData.SetStepNumber(5);
  LocalData.UpdateFieldToDll('AgentSetting','RunOnce','1','ID = 1');
end;

procedure TfrmMain_fa.SetRegistery;
begin
 SaveServiceToReg;
end;


procedure TfrmMain_fa.TimerSaveInfoTimer(Sender: TObject);
var
 thrResult : boolean;
begin
   TimerSaveInfo.Enabled := false;
   if _stepNumber < 5 then
   begin
   MySqlThread := TSqlThread.Create(true);
   MySqlThread.Resume;
   TimerCheckSaveToSql.Enabled := true;
   end;
end;

procedure TfrmMain_fa.TimerCheckSaveToSqlTimer(Sender: TObject);
var
_SendToSql : string;
frmShow : TfrmShowInfo_fa;
begin
 TimerCheckSaveToSql.Enabled := false;
 _SendToSql := LocalData.GetDataFromDll('AgentSetting','SendToSQL','1');
 if _SendToSql = '1' then
 begin
   AniIndicatorSaveInfo.Enabled := false;
   AniIndicatorSaveInfo.Visible := false;
   AniIndicatorAll.Enabled := false;
   AniIndicatorAll.Visible := false;
   imgSaveInfoOk.Visible := true;
   imgOk.Visible := true;
   lblTitle.Visible := false;
   SystemMessages.lblSaveInfo := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblSaveInfoOK');
   lblSaveInfo.Text := SystemMessages.lblSaveInfo;
   LocalData.SetStepNumber(5);
   LocalData.UpdateFieldToDll('AgentSetting','RunOnce','1','ID = 1');
   SaveServiceToReg;
   frmShow := TfrmShowInfo_fa.Create(Self);
   frmShow.PMessage := 'ConfigComplete';
   frmShow.LangCode := SystemAgentSetting.LanguageCode;
   frmShow.ShowModal;
   free;
   application.Terminate;
   exit;
   //ShellExecute(Handle, 'open', PWideChar('AgentSrv.exe') , nil, nil, SW_SHOWNORMAL);
   //hide;
  end else
  begin
  if Counter < 20 then
  begin
     inc(Counter);
     TimerCheckSaveToSql.Enabled := true;
  end else
  begin
   TimerCheckSaveToSql.Enabled := false;
   AniIndicatorSaveInfo.Enabled := false;
   AniIndicatorSaveInfo.Visible := false;
   imgWarning.Visible := true;
   imgSaveInfoFail.Visible := true;
   SystemMessages.lblSaveInfo := LocalData.GetMessageFromDll(SystemAgentSetting.LanguageCode,'frmMain_fa','lblSaveInfoFail');
   lblSaveInfo.Text := SystemMessages.lblSaveInfo;
  end;
 end;
end;

procedure  TfrmMain_fa.SaveServiceToReg;
var
 key : string;
 dir : string;
begin
     reg := TRegistry.Create(KEY_WRITE);
     if localdata.IsWindowsAdministrator then reg.RootKey := HKEY_LOCAL_MACHINE
     else reg.RootKey := HKEY_CURRENT_USER;

     key := '\Software\Microsoft\Windows\CurrentVersion\Run';
     Reg.CreateKey(key);
     dir := LocalData.GetSysDir;
     if Reg.OpenKey(Key,False) then
     begin
         Reg.WriteString('AgentSrv',dir+'AgentSrv.exe');
         Reg.DeleteValue('AgentConfig');
     end;

end;


end.
