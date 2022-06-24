unit GetOS;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;

procedure Start;
//procedure SendToDll();

var
SerialNumber,BuildNumber,Caption,FreePhysicalMemory,InstallDate,Version:string;
LastBootupTime,HashCode:string;
OSVer : TOSVersion;


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
 _osString : string;

begin

      SerialNumber := LocalData.GetWMIstring('','Win32_OperatingSystem','SerialNumber');
      BuildNumber :=  LocalData.GetWMIstring('','Win32_OperatingSystem','BuildNumber');
      Caption := OSVer.ToString;
      FreePhysicalMemory := LocalData.GetWMIstring('','Win32_OperatingSystem','FreePhysicalMemory');
      InstallDate := LocalData.GetWMIstring('','Win32_OperatingSystem','InstallDate');
      Version := LocalData.GetWMIstring('','Win32_OperatingSystem','Version');
      LastBootupTime := LocalData.GetWMIstring('','Win32_OperatingSystem','LastBootUpTime');

     _osString :=  Trim(SerialNumber)+Trim(BuildNumber)+ Trim(Caption)+ Trim(InstallDate)+ Trim(Version);

    _hashCode := GetMD5String(_osString,TEncoding.Unicode);

     HashCode :=  _hashCode;

end;



end.

