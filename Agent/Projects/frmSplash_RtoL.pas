unit frmSplash_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs,frmWelcome_RtoL,GetInfoThreadUnit,
  LocalData,frmMain_RtoL,Registry,Windows;


type
  TfrmSplash_fa = class(TForm)
    timSplash: TTimer;
    StyleBook1: TStyleBook;
    procedure timSplashTimer(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure CreateReg;

  private

  public
    { Public declarations }
  end;

var
  frmSplash_fa: TfrmSplash_fa;
  MyThread : TMyThread;
  LangCode,Version:string;
  frmCaption : string;
  frmWel: TfrmWelcome_fa;
  frmMain : TfrmMain_fa;




implementation

{$R *.fmx}

procedure TfrmSplash_fa.FormCreate(Sender: TObject);
begin
     LocalData.SetConnString;
     LangCode := LocalData.GetDataFromDll('AgentSetting','LanguageCode','1');
     Version := LocalData.GetDataFromDll('AgentSetting','Version','1');
     frmCaption := LocalData.GetMessageFromDll(LangCode,'frmSplash_fa','frmCaption');
     frmSplash_fa.Caption := frmCaption;
     CreateReg;
     timSplash.Enabled := true;

end;

procedure TfrmSplash_fa.timSplashTimer(Sender: TObject);
var
_stepIndex : integer;
_runOnce : integer;
begin
   timSplash.Enabled := false;
   _stepIndex := StrToInt(LocalData.GetDataFromDll('AgentSetting','StepNumber','1'));
   _runOnce := StrToInt(LocalData.GetDataFromDll('AgentSetting','RunOnce','1'));

   if (_runOnce = 0) AND (_stepIndex = 0) then    //Config run normally
   begin
     frmWel := TfrmWelcome_fa.Create('');
     Visible := false;
     frmWel.ShowModal;

   end else if (_runOnce = 0) AND (_stepIndex > 0) AND (_stepIndex < 3) then   //Config run without welcome form show
   begin
     frmMain := TfrmMain_fa.Create('');
     Visible := false;
     frmMain.TimerActive.Enabled := true;
     frmMain.ShowModal;
   end else if (_runOnce = 0) AND (_stepIndex >= 3)then //config run without thread
   begin
     frmMain := TfrmMain_fa.Create('');
     Visible := false;
     frmMain.TimerActive.Enabled := true;
     frmMain.ShowModal;
   end else if _runOnce <> 0 then
   begin
    Application.Terminate;
   end;
end;

procedure TfrmSplash_fa.CreateReg;
var
key,dir : string;
IsAdmin : boolean;
begin
     reg := TRegistry.Create(KEY_WRITE);

     if localdata.IsWindowsAdministrator then reg.RootKey := HKEY_LOCAL_MACHINE
     else reg.RootKey := HKEY_CURRENT_USER;

     key := '\Software\Microsoft\Windows\CurrentVersion\Run';
     Reg.CreateKey(key);
     dir := LocalData.GetSysDir;
     if Reg.OpenKey(Key,False) then
     begin
         Reg.WriteString('AgentConfig',dir+'Agent.exe');
     end;
end;

end.
