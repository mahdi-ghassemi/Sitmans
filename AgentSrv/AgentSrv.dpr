program AgentSrv;

uses
  Vcl.Forms,
  frmMain in 'frmMain.pas' {Form4},
  TextTrayIcon in 'TextTrayIcon.pas',
  CoolTrayIcon in 'CoolTrayIcon.pas',
  RegisterTrayIcons in 'RegisterTrayIcons.pas',
  SimpleTimer in 'SimpleTimer.pas',
  TAgentClass in 'TAgentClass.pas',
  GetActiveNetworkSetting in 'GetActiveNetworkSetting.pas',
  GetAgentProperties in 'GetAgentProperties.pas',
  GetBios in 'GetBios.pas',
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
  GetSys in 'GetSys.pas',
  GetUserAccount in 'GetUserAccount.pas',
  GetVideoCard in 'GetVideoCard.pas',
  LocalData in 'LocalData.pas',
  SQLData in 'SQLData.pas',
  uSMBIOS in 'uSMBIOS.pas',
  U_usb in 'U_usb.pas',
  WbemScripting_TLB in 'C:\Documents and Settings\Mehdi\My Documents\RAD Studio\9.0\Imports\WbemScripting_TLB.pas',
  frmChat_RtoL in 'frmChat_RtoL.pas' {frmChat},
  frmPm_RtoL in 'frmPm_RtoL.pas' {frmPm},
  ChangeCheckThread in 'ChangeCheckThread.pas',
  EZCrypt in 'EZCrypt.pas',
  EncDec in 'EncDec.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := true;
  Application.CreateForm(TForm4, Form4);
  //Application.CreateForm(TfrmPm, frmPm);
  //Application.CreateForm(TfrmChat, frmChat);
  Application.Run;
end.
