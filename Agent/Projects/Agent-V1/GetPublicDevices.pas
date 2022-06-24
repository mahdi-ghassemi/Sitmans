unit GetPublicDevices;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

HashCode:string;

Monitor,Keyboard,Mouse,Camera:String;

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
 len,i : integer;
 monitorCap,monitorMan:string;
 mouseCap,mouesMan:string;
 keyboardCap,keyboardMan:string;

begin
      monitorCap := LocalData.GetWMIstring('','Win32_PnPEntity WHERE PNPDeviceID LIKE "DISPLAY%"','Caption');
      monitorMan := LocalData.GetWMIstring('','Win32_PnPEntity WHERE PNPDeviceID LIKE "DISPLAY%"','Manufacturer');
      Monitor := monitorMan + ' ' + monitorCap;

      mouseCap := LocalData.GetWMIstring('','Win32_PnPEntity WHERE Description LIKE "%mouse%" AND Service LIKE "mou%"','Caption');
      mouesMan := LocalData.GetWMIstring('','Win32_PnPEntity WHERE Description LIKE "%mouse%" AND Service LIKE "mou%"','Manufacturer');
      Mouse := mouesMan + ' '+ mouseCap;

      keyboardCap := LocalData.GetWMIstring('','Win32_PnPEntity WHERE Description LIKE "%keyboard%" AND Status = "Ok" AND Service LIKE "kbd%"','Caption');
      keyboardMan := LocalData.GetWMIstring('','Win32_PnPEntity WHERE Description LIKE "%keyboard%" AND Status = "Ok" AND Service LIKE "kbd%"','Manufacturer');
      Keyboard := keyboardCap + ' '+ keyboardMan;

      Camera := LocalData.GetWMIstring('','Win32_PnPEntity WHERE Description LIKE "%Camera%"','Caption');

     _HDString := '';
     _HDString := Trim(Monitor)+Trim(Mouse)+Trim(Keyboard)+Trim(Camera);
     _hashCode := GetMD5String(_HDString,TEncoding.Unicode);
     HashCode :=  _hashCode;


end;



end.


