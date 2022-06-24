unit frmLogin_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs, FMX.Objects, FMX.Edit;

type
  TfrmLogin_fa = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    txbPassword: TEdit;
    btnOk: TButton;
    btnExit: TButton;
    Image1: TImage;
    procedure btnExitClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmLogin_fa: TfrmLogin_fa;

implementation

{$R *.fmx}

procedure TfrmLogin_fa.btnExitClick(Sender: TObject);
begin
  Application.Terminate;
end;

end.
