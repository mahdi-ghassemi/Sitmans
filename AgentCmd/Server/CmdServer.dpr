program CmdServer;

uses
  Vcl.Forms,
  CmdSrv in 'CmdSrv.pas' {frmCmdServer};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmCmdServer, frmCmdServer);
  Application.Run;
end.
