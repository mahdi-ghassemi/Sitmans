unit frmMain_RtoL;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Dialogs, FMX.TabControl;

type
  TfrmMain_fa = class(TForm)
    TabControl1: TTabControl;
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmMain_fa: TfrmMain_fa;

implementation

{$R *.fmx}

procedure TfrmMain_fa.FormCreate(Sender: TObject);
var
SqlSettingItem : TTabItem;
AgentSettingItem : TTabItem;
LanguageSetting : TTabItem;
ActiveSoftwareItem : TTabItem;
PublicSettingItem :TTabItem;
AboutSettingItem : TTabItem;

begin
 TabControl1 := TTabControl.Create(nil);
 TabControl1.Tabs[0].Text := 'ActiveSoftware';
 {
 SqlSettingItem := TTabItem.Create(TabControl1);
 SqlSettingItem.Parent := TabControl1;
 SqlSettingItem.Text := 'SQL Setting';
 SqlSettingItem.Enabled := true;
 SqlSettingItem.Index := 2;


 AgentSettingItem := TTabItem.Create(TabControl1);
 AgentSettingItem.Parent := TabControl1;
 AgentSettingItem.Text := 'Agent Setting';
 AgentSettingItem.Enabled := true;
 AgentSettingItem.Index := 1;

 LanguageSetting := TTabItem.Create(TabControl1);
 LanguageSetting.Parent := TabControl1;
 LanguageSetting.Text := 'Language Setting';
 LanguageSetting.Enabled := true;
 LanguageSetting.Index := 4;

 ActiveSoftwareItem := TTabItem.Create(TabControl1);
 ActiveSoftwareItem.Parent := TabControl1;
 ActiveSoftwareItem.Text := 'ActiveSoftware';
 ActiveSoftwareItem.Enabled := true;
 ActiveSoftwareItem.Index := 0;

 PublicSettingItem := TTabItem.Create(TabControl1);
 PublicSettingItem.Parent := TabControl1;
 PublicSettingItem.Text := 'Public Setting';
 PublicSettingItem.Enabled := true;
 PublicSettingItem.Index := 3;

 AboutSettingItem := TTabItem.Create(TabControl1);
 AboutSettingItem.Parent := TabControl1;
 AboutSettingItem.Text := 'About';
 AboutSettingItem.Enabled := true;
 AboutSettingItem.Index := 5;
 }
end;

end.
