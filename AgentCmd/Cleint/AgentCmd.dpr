program AgentCmd;

uses
  Vcl.Forms,
  CmdClient in 'CmdClient.pas' {frmAgentCmd};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmAgentCmd, frmAgentCmd);
  Application.Run;
end.
