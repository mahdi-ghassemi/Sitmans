program Agent;

uses
  FMX.Forms,
  frmSplash_R2L in 'frmSplash_R2L.pas' {frmSplash_fa};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmSplash_fa, frmSplash_fa);
  Application.Run;
end.
