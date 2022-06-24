unit GetSoftwares;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,registry,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;

const REGKEYAPPS = '\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall';


procedure Start;
procedure GetSoftList;
//procedure SendToDll();

var

HashCode:string;
NameList : TStringList;
SoftName : LocalData.TName;


//Name,Version,InstallDate:LocalData.TStringArray;


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

procedure GetSoftList;
var
reg : TRegistry;
j, n : integer;
List1 : TStringList;
List2 : TStringList;

begin
  reg := TRegistry.Create(KEY_READ);
  List1 := TStringList.Create;
  List2 := TStringList.Create;
  NameList := TStringList.Create;

  {Load all the subkeys}
   with reg do
   begin

     RootKey := HKEY_LOCAL_MACHINE;
     OpenKey(REGKEYAPPS, false) ;
     GetKeyNames(List1) ;
   end;
   {Load all the Value Names}
   for j := 0 to List1.Count -1 do
   begin
     reg.OpenKey(REGKEYAPPS + '\' + List1.Strings[j],false) ;
     reg.GetValueNames(List2) ;

     {We will show only if there is 'DisplayName'}
     n := List2.IndexOf('DisplayName') ;


     if (n <> -1) and (List2.IndexOf('UninstallString') <> -1) then
     begin
       NameList.Add((reg.ReadString(List2.Strings[n])));
     end;
   end;

end;


procedure Start;
var
 _hashCode : string;
 _HDString : string;
 len,i : integer;

begin
      GetSoftList;
      i := 0;
      Setlength(SoftName,NameList.Count);
      while i < NameList.Count do
      begin
        SoftName[i] := string(NameList.Strings[i]);
        inc(i);
      end;

      _HDString := '';
       i := 0;
      len := Length(SoftName);
      while i < len do
      begin
        _HDString := _HDString + Trim(SoftName[i]);
       inc(i);
      end;

     _hashCode := GetMD5String(_HDString,TEncoding.Unicode);
     HashCode :=  _hashCode;


end;

end.

