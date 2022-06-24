unit Unit2;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm2 = class(TForm)
    Memo1: TMemo;
    procedure FormActivate(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
  function GetBiosInfoAsText():string;
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}



procedure TForm2.FormCreate(Sender: TObject);
begin
 Memo1.Lines.Text := GetBiosInfoAsText;
end;

function GetBiosInfoAsText: string;
  var
    p, q: pchar;
  begin
    q := nil;
    p := PChar(Ptr($FE000));
    repeat
      if q  nil then begin
        if not (p^ in [#10, #13, #32..#126, #169, #184]) then begin
          if (p^ = #0) and (p - q = 8) then begin
            Result := Result + TrimRight(String(q)) + #13#10;
          end;
          q := nil;
        end;
      end else
        if p^ in [#33..#126, #169, #184] then
          q := p;
      inc(p);
    until p  PChar(Ptr($FFFFF));
    Result := TrimRight(Result);
  end;

end.
