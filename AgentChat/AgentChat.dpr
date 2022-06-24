program AgentChat;

uses
  Vcl.Forms,
  frmAgentChat in 'frmAgentChat.pas' {frmChat},
  SQLData in 'SQLData.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmChat, frmChat);
  Application.Run;
end.
