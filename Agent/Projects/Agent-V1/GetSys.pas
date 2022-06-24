unit GetSys;

interface

uses SysUtils,Windows,Generics.Collections,Classes,uSMBIOS,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal;

procedure Start;
//procedure SendToDll();

var
_UUID:string;
HashCode:string;

implementation

function GetMD5String(Str: String; ADestEncoding: TIdTextEncoding =
nil): String;
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
  Entry  :
TSMBiosTableEntry;
begin
  SMBios:=TSMBios.Create;

  try
    With SMBios
do
    begin
      if HasSysInfo then
      begin
         BinToHex
(@SysInfo.UUID,UUID,SizeOf(SysInfo.UUID));
        _UUID := UUID;

end;
         end;
  finally
   SMBios.Free;
  end;
end;

procedure Start;
var

_hashCode : string;
 _sysString : string;
begin

   GetMSSmBios_RawSMBiosTablesInfo;

    _sysString := Trim(_UUID);    _hashCode := GetMD5String(_sysString,TEncoding.Unicode);   HashCode :=  _hashCode;
end;

end.




