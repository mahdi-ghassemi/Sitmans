unit GetCDRom;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

TotalHashCode:string;

Name,Drive,HashCode:LocalData.TStringArray;

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

procedure Start;
var
 _hashCode : string;
 _HDString : string;
 _TotalhashCode : string;
 len,i : integer;

begin
      Name := LocalData.GetWMIstringArray('','Win32_CDROMDrive','Name');
      Drive := LocalData.GetWMIstringArray('','Win32_CDROMDrive','Drive');

      _HDString := '';
       i := 0;
      len := Length(Name);
      setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(Name[i])+ Trim(Drive[i]);
        HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;


end;



end.

