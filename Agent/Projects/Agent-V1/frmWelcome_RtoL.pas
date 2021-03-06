unit frmWelcome_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs, FMX.Layouts, FMX.Memo,
  GetInfoThreadUnit,frmMain_RtoL,LocalData, FMX.Objects;

type TFormMessages = record
    frmCaption : string;
    lbl1 : string;
    btnExit : string;
    btnOK : string;
    lbl2 : string;
    lbl3 : string;
    lbl4 : string;
    lbl5 : string;
    lbl6 : string;
    lbl7 : string;
  end;

type
  TfrmWelcome_fa = class(TForm)
    btnOk: TButton;
    btnExit: TButton;
    Panel1: TPanel;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    lbl4: TLabel;
    lbl5: TLabel;
    lbl6: TLabel;
    img1: TImage;
    img2: TImage;
    img3: TImage;
    img4: TImage;
    lbl7: TLabel;
    StyleBook1: TStyleBook;
    procedure btnExitClick(Sender: TObject);
    procedure btnOkClick(Sender: TObject);
   // procedure FormCreate(Sender: TObject);
    procedure GetFormMessageFromDll();
    procedure FillForm;

  private
    { Private declarations }
  public
    constructor Create(AOwner: TComponent); reintroduce; overload;
    constructor Create(FormTitle:string); reintroduce; overload;
    { Public declarations }
  end;

var
  frmWelcome_fa: TfrmWelcome_fa;
  SystemMessages : TFormMessages;
  LanguageCode : string;
  frmMain : TfrmMain_fa;
implementation

{$R *.fmx}

constructor TfrmWelcome_fa.Create(AOwner: TComponent);
begin
inherited;

end;

constructor TfrmWelcome_fa.Create(FormTitle:string);
begin
inherited Create(Application);
LanguageCode := LocalData.GetDataFromDll('AgentSetting','LanguageCode','1');
FillForm;
end;

procedure TfrmWelcome_fa.btnExitClick(Sender: TObject);
begin
   Application.Terminate;
end;

procedure TfrmWelcome_fa.btnOkClick(Sender: TObject);
begin
   frmMain := TfrmMain_fa.Create('');
   Visible := false;
   //frmMain.TimerActive.Enabled := true;
   frmMain.ShowModal;
end;

{procedure TfrmWelcome_fa.FormCreate(Sender: TObject);
begin
 LanguageCode := LocalData.GetDataFromDll('AgentSetting','LanguageCode','1');
 FillForm;

end;
 }
procedure TfrmWelcome_fa.FillForm;
begin
  GetFormMessageFromDll;

  Caption := SystemMessages.frmCaption;
  btnOk.Text := SystemMessages.btnOk;
  btnExit.Text := SystemMessages.btnExit;
  lbl1.Text := SystemMessages.lbl1;
  lbl2.Text := SystemMessages.lbl2;
  lbl3.Text := SystemMessages.lbl3;
  lbl4.Text := SystemMessages.lbl4;
  lbl5.Text := SystemMessages.lbl5;
  lbl6.Text := SystemMessages.lbl6;
  lbl7.Text := SystemMessages.lbl7;
end;

procedure TfrmWelcome_fa.GetFormMessageFromDll();
begin
  SystemMessages.frmCaption := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','frmCaption');
  SystemMessages.btnOk := LocalData.GetMessageFromDll(LanguageCode,'frmMain_fa','btnOk');
  SystemMessages.btnExit := LocalData.GetMessageFromDll(LanguageCode,'frmMain_fa','btnExit');
  SystemMessages.lbl1 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl1');
  SystemMessages.lbl2 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl2');
  SystemMessages.lbl3 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl3');
  SystemMessages.lbl4 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl4');
  SystemMessages.lbl5 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl5');
  SystemMessages.lbl6 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl6');
  SystemMessages.lbl7 := LocalData.GetMessageFromDll(LanguageCode,'frmWelcome_fa','lbl7');
end;

end.
