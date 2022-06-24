unit GetAgentProperties;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,registry,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;

const REGKEYAPPS = '\SOFTWARE\Microsoft\MS Setup (ACME)';

procedure GetRegisterInfo;
procedure Start;
//procedure SendToDll();

var
AgentID,ComputerName,Organization,AgentRemotePassword,CurrentUser:string;
RegisterCompany,RegisterUser,HashCode:string;

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

procedure GetRegisterInfo;
var
reg : TRegistry;
j, n ,m : integer;
List1 : TStringList;
List2 : TStringList;
regCompany, regName : string;
begin
  reg := TRegistry.Create;
  List1 := TStringList.Create;
  List2 := TStringList.Create;


  {Load all the subkeys}
   with reg do
   begin

     RootKey := HKEY_CURRENT_USER;
     OpenKey(REGKEYAPPS, false) ;
     GetKeyNames(List1) ;
   end;
   {Load all the Value Names}
   for j := 0 to List1.Count -1 do
   begin
     reg.OpenKey(REGKEYAPPS + '\' + List1.Strings[j],false) ;
     reg.GetValueNames(List2) ;

     {We will show only if there is 'DisplayName'}
     n := List2.IndexOf('DefCompany') ;
     m := List2.IndexOf('DefName');

     if (n <> -1) and (m <> -1) then
     begin
       RegisterCompany := ((reg.ReadString(List2.Strings[n])));
       RegisterUser := ((reg.ReadString(List2.Strings[m])));
     end;
   end;

end;


procedure Start;
var
 _hashCode : string;
 _osString : string;

begin
      GetRegisterInfo;
      ComputerName := LocalData.GetWMIstring('','Win32_ComputerSystem','Name');
      CurrentUser :=  LocalData.GetWMIstring('','Win32_ComputerSystem','UserName');
      Organization := LocalData.GetWMIstring('','Win32_OperatingSystem','Manufacturer');

     _osString :=  Trim(ComputerName)+Trim(CurrentUser)+ Trim(Organization);                  ;

    _hashCode := GetMD5String(_osString,TEncoding.Unicode);

     HashCode :=  _hashCode;


end;



end.

