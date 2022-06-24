unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
with Memo1.Lines do
  begin
    Add('MainBoardBiosName:'+^I+string(Pchar(Ptr($FE061))));
    Add('MainBoardBiosCopyRight:'+^I+string(Pchar(Ptr($FE091))));
    Add('MainBoardBiosDate:'+^I+string(Pchar(Ptr($FFFF5))));
    Add('MainBoardBiosSerialNo:'+^I+string(Pchar(Ptr($FEC71))));
  end;
end;

end.
