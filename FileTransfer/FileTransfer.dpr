program FileTransfer;

uses
  Vcl.Forms,
  FileTrns in 'FileTrns.pas' {frmFileTrans},
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TfrmFileTrans, frmFileTrans);
 // Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
