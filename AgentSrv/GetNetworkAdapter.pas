unit GetNetworkAdapter;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

TotalHashCode:string;

Description,AdapterType,MACAddress,Manufacturer,NetConnectionID,
        PNPDeviceID,TimeOfLastReset,HashCode:LocalData.TStringArray;

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
      Description := LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','Description');
      AdapterType :=  LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','AdapterType');
      MACAddress := LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','MACAddress');
      Manufacturer := LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','Manufacturer');
      NetConnectionID := LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','NetConnectionID');
      PNPDeviceID := LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','PNPDeviceID');
      TimeOfLastReset := LocalData.GetWMIstringArray('','Win32_NetworkAdapter where MACAddress IS NOT NULL AND Manufacturer != "Microsoft" AND NetConnectionID = "Local Area Connection" OR NetConnectionID = "Wireless Network Connection"','TimeOfLastReset');
      _HDString := '';
       i := 0;
      len := Length(Description);
      setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(Description[i])+Trim(AdapterType[i])+
                     Trim(MACAddress[i])+ Trim(Manufacturer[i])
                     + Trim(NetConnectionID[i])+Trim(PNPDeviceID[i]);
       HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;


end;



end.

