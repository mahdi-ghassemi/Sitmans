unit frmSplash_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs,frmMain_RtoL;

type
  TfrmSplash_fa = class(TForm)
    Timer1: TTimer;
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmSplash_fa: TfrmSplash_fa;

implementation

{$R *.fmx}

procedure TfrmSplash_fa.Timer1Timer(Sender: TObject);
begin
   Timer1.Enabled := false;
   frmSplash_fa.Visible := false;
   frmMain_fa.Show;
end;

end.
