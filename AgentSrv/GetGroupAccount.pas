unit GetGroupAccount;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

TotalHashCode:string;

GroupName,GID,Description,Status,HashCode:LocalData.TStringArray;

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
      GroupName := LocalData.GetWMIstringArray('','Win32_Group','Name');
      GID :=  LocalData.GetWMIstringArray('','Win32_Group','SID');
      Description := LocalData.GetWMIstringArray('','Win32_Group','Description');
      Status := LocalData.GetWMIstringArray('','Win32_Group','Status');

      _HDString := '';
       i := 0;
      len := Length(GroupName);
      setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(GroupName[i])+Trim(GID[i])+
                     Trim(Description[i])+ Trim(Status[i]);
       HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;


end;



end.

