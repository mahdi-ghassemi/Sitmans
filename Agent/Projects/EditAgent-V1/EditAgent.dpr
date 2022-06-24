program EditAgent;

uses
  FMX.Forms,
  frmSplash_RtoL in 'frmSplash_RtoL.pas' {frmSplash_fa},
  frmMain_RtoL in 'frmMain_RtoL.pas' {frmMain_fa},
  frmLogin_RtoL in 'frmLogin_RtoL.pas' {frmLogin_fa},
  LocalData in 'LocalData.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmSplash_fa, frmSplash_fa);
  Application.CreateForm(TfrmMain_fa, frmMain_fa);
  Application.CreateForm(TfrmLogin_fa, frmLogin_fa);
  Application.Run;
end.
