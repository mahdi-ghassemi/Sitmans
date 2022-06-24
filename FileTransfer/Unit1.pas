unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    lblTitle: TLabel;
    txbNewName: TEdit;
    btnOk: TButton;
    btnCancel: TButton;
    procedure btnOkClick(Sender: TObject);
    procedure btnCancelClick(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
     constructor Create(AOwner: TComponent); reintroduce; overload;
     constructor Create(FormTitle:string;Title:string;Ok:string;Cancel:string); reintroduce; overload;
  end;


var
  Form1: TForm1;

implementation

{$R *.dfm}

constructor TForm1.Create(AOwner: TComponent);
begin
inherited;

end;

constructor TForm1.Create(FormTitle:string;Title:string;Ok:string;Cancel:string);
var
_langCode : string;
begin
inherited Create(Application);
Caption := FormTitle;
lblTitle.Caption := Title;
btnOk.Caption := Ok;
btnCancel.Caption := Cancel;
end;



procedure TForm1.btnCancelClick(Sender: TObject);
begin
ModalResult := mrCancel;
PostMessage(Self.Handle,wm_close,0,0);
end;

procedure TForm1.btnOkClick(Sender: TObject);
begin
ModalResult := mrOk;
PostMessage(Self.Handle,wm_close,0,0);
end;

end.
