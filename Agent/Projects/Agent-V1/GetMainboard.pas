unit GetMainboard;

interface

uses SysUtils,Windows,Generics.Collections,Classes,uSMBIOS,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal;

procedure Start;
//procedure SendToDll();

var
Manufacter,Product,Version,SerialNumber:string;
HashCode:string;


implementation

function GetMD5String(Str: String; ADestEncoding: TIdTextEncoding = nil): String;
var MD5: TIdHashMessageDigest5;
begin
          MD5:= TIdHashMessageDigest5.Create;
          try
          Result:= LowerCase (MD5.HashStringAsHex (Str, ADestEncoding));
          finally FreeAndNil (MD5);
    end;
end;


procedure GetMSSmBios_RawSMBiosTablesInfo;
Var
  SMBios : TSMBios;
  UUID   : Array[0..31] of Char;
  Entry  : TSMBiosTableEntry;
begin
  SMBios:=TSMBios.Create;

  try
    With SMBios do
    begin

      if HasBaseBoardInfo then
      begin
        //WriteLn('BaseBoard Information');
        Manufacter:= GetSMBiosString(BaseBoardInfoIndex + BaseBoardInfo.Header.Length, BaseBoardInfo.Manufacturer);
        Product:= GetSMBiosString(BaseBoardInfoIndex + BaseBoardInfo.Header.Length, BaseBoardInfo.Product);
        Version:= GetSMBiosString(BaseBoardInfoIndex + BaseBoardInfo.Header.Length, BaseBoardInfo.Version);
        SerialNumber:= GetSMBiosString(BaseBoardInfoIndex + BaseBoardInfo.Header.Length, BaseBoardInfo.SerialNumber);

      end;
     end;
  finally
   SMBios.Free;
  end;
end;

procedure Start;
var
 _hashCode : string;
 _mbString : string;
begin

    GetMSSmBios_RawSMBiosTablesInfo;
    _mbString := Trim(Manufacter)+Trim(Product)+Trim(Version)+Trim(SerialNumber);
    _hashCode := GetMD5String(_mbString,TEncoding.Unicode);
    HashCode :=  _hashCode;

end;
end.





