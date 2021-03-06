program Agent;

uses
  FMX.Forms,
  System.SysUtils,
  FMX.Dialogs,
  frmSplash_RtoL in '..\frmSplash_RtoL.pas' {frmSplash_fa},
  GetActiveNetworkSetting in '..\GetActiveNetworkSetting.pas',
  GetBios in '..\GetBios.pas',
  uSMBIOS in '..\uSMBIOS.pas',
  SQLData in 'SQLData.pas',
  GetAgentProperties in 'GetAgentProperties.pas',
  GetVideoCard in 'GetVideoCard.pas',
  GetCDRom in 'GetCDRom.pas',
  GetChassis in 'GetChassis.pas',
  GetCPU in 'GetCPU.pas',
  GetGroupAccount in 'GetGroupAccount.pas',
  GetHardDisk in 'GetHardDisk.pas',
  GetLogicDisk in 'GetLogicDisk.pas',
  GetMainboard in 'GetMainboard.pas',
  GetMemory in 'GetMemory.pas',
  GetModem in 'GetModem.pas',
  GetNetworkAdapter in 'GetNetworkAdapter.pas',
  GetOS in 'GetOS.pas',
  GetPrinter in 'GetPrinter.pas',
  GetPublicDevices in 'GetPublicDevices.pas',
  GetSoftwares in 'GetSoftwares.pas',
  GetUserAccount in 'GetUserAccount.pas',
  GetSys in 'GetSys.pas',
  frmWelcome_RtoL in 'frmWelcome_RtoL.pas' {frmWelcome_fa},
  TAgentClass in 'TAgentClass.pas',
  frmMain_RtoL in 'frmMain_RtoL.pas' {frmMain_fa},
  GetInfoThreadUnit in 'GetInfoThreadUnit.pas',
  SaveToSqlThread in 'SaveToSqlThread.pas',
  frmShowInfo_RtoL in 'frmShowInfo_RtoL.pas' {frmShowInfo_fa},
  LocalData in '..\LocalData.pas',
  WbemScripting_TLB in 'WbemScripting_TLB.pas';

{$R *.res}
var
  RightToLeft : string;
  dirs,dird,dirm : string;
begin
  Application.Initialize;
  dirs := GetSysDir+'\Agents.dll';
  dird := GetSysDir+'\Agentd.dll';
  dirm := GetSysDir+'\Agentm.dll';
  if FileExists(dirs) OR FileExists(dird)OR FileExists(dirm) then
  begin
     LocalData.SetConnString;
     RightToLeft := LocalData.GetDataFromDll('AgentSetting','RigthToLeft','1');
     if RightToLeft = '1' then
     begin
       Application.CreateForm(TfrmSplash_fa, frmSplash_fa);
  // Application.CreateForm(TfrmWelcome_fa, frmWelcome_fa);
      // Application.CreateForm(TfrmMain_fa, frmMain_fa);
       //Application.CreateForm(TfrmShowInfo_fa, frmShowInfo_fa);
       Application.Run;
     end else if RightToLeft = '0' then
     begin

     end;
  end else
  begin
     ShowMessage('Dll file(s) not exist');
     Application.Terminate;
   end;
end.
