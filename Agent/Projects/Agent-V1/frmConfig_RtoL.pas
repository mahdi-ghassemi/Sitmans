unit frmConfig_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs,TAgentClass;


type
  TfrmConfig_fa = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmConfig_fa: TfrmConfig_fa;
  MyAgent1 : TMyAgent;
  //GetInfoTh : TMyThread;
implementation

{$R *.fmx}

procedure TfrmConfig_fa.Button1Click(Sender: TObject);

begin

  MyAgent1 := TMyAgent.Create;

  MyAgent1.GetSystemInfo;

  frmConfig_fa.Label1.Text := MyAgent1.MainboardVersion;

  frmConfig_fa.Label2.Text := MyAgent1.MainboardSerialNumber;

  frmConfig_fa.Label3.Text := MyAgent1.MainboardProduct;

end;

procedure TfrmConfig_fa.FormCreate(Sender: TObject);
begin
   frmConfig_fa.Label1.Visible := true;
end;

end.
