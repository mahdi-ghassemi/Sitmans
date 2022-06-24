unit frmShowInfo_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs,LocalData, FMX.Objects;

 type TFormMessages = record

    lbl1 : string;
    btnOK : string;
  end;

type
  TfrmShowInfo_fa = class(TForm)
    lbl1: TLabel;
    btnOk: TButton;
    StyleBook1: TStyleBook;
    procedure btnOkClick(Sender: TObject);
    procedure FormActivate(Sender: TObject);
  private
    _langCode : string;
    _message : string;
     { Private declarations }
  public
  property PMessage: string read _message write _message;
  property LangCode: string read _langCode write _langCode;
    { Public declarations }
  end;

var
  frmShowInfo_fa: TfrmShowInfo_fa;
  InfoMessage : string;
  SystemMessage : TFormMessages;

implementation

{$R *.fmx}

procedure TfrmShowInfo_fa.btnOkClick(Sender: TObject);
begin
   Close;
end;

procedure TfrmShowInfo_fa.FormActivate(Sender: TObject);
begin

     SystemMessage.btnOK :=  LocalData.GetMessageFromDll(_langCode,'frmMain_fa','btnOK');
     btnOk.Text := SystemMessage.btnOK;
     if _message = 'RegisterFail' then
     begin
        SystemMessage.lbl1 :=  LocalData.GetMessageFromDll(_langCode,'frmShowInfo_fa','lbl1_RegisterFail');
        lbl1.Text := SystemMessage.lbl1;
     end;
     if _message = 'SqlConFail' then
     begin
        SystemMessage.lbl1 :=  LocalData.GetMessageFromDll(_langCode,'frmShowInfo_fa','lbl1_SqlConFail');
        lbl1.Text := SystemMessage.lbl1;
     end;
     if _message = 'ConfigComplete' then
     begin
        SystemMessage.lbl1 :=  LocalData.GetMessageFromDll(_langCode,'frmShowInfo_fa','lbl1_ConfigComplete');
        lbl1.Text := SystemMessage.lbl1;
     end;
     if _message = 'UUID' then
     begin
        SystemMessage.lbl1 :=  LocalData.GetMessageFromDll(_langCode,'frmShowInfo_fa','lbl1_UUID');
        lbl1.Text := SystemMessage.lbl1;
     end;
end;

end.
