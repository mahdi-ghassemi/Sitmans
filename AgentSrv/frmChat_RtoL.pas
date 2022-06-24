unit frmChat_RtoL;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, System.Win.ScktComp;

type
  TfrmChat = class(TForm)
    libAgentList: TListBox;
    MemoLog: TMemo;
    MemoMessage: TMemo;
    btnSend: TButton;
    btnSendAll: TButton;
    lblAgentsName: TLabel;
    srsChat: TServerSocket;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmChat: TfrmChat;

implementation

{$R *.dfm}

end.
