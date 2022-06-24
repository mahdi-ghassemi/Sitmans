unit GetChassis;

interface

uses SysUtils,Windows,Generics.Collections,Classes,uSMBIOS,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,LocalData;

procedure Start;
//procedure SendToDll();

var
AssetTagNumber,ChassisType:string;
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
      if HasEnclosureInfo then
      begin
       AssetTagNumber := GetSMBiosString(EnclosureInfoIndex + EnclosureInfo.Header.Length, EnclosureInfo.AssetTagNumber);
      end;
    end;
  finally
   SMBios.Free;
  end;
end;

procedure Start;
var
 _hashCode : string;
 _ChString : string;
 _chassisType : string;
begin
    GetMSSmBios_RawSMBiosTablesInfo;

    ChassisType := LocalData.GetChassisType();
    _chassisType := ChassisType;
    if _chassisType = '2' then
    ChassisType := 'Unknown'
    else if _chassisType = '3' then
    ChassisType := 'Desktop'
    else if _chassisType = '4' then
    ChassisType := 'Low Profile Desktop'
    else if _chassisType = '5' then
    ChassisType := 'Pizza Box'
    else if _chassisType = '6' then
    ChassisType := 'Mini Tower'
    else if _chassisType = '7' then
    ChassisType := 'Tower'
    else if _chassisType = '8' then
    ChassisType := 'Portable'
    else if _chassisType = '9' then
    ChassisType := 'LapTop'
    else if _chassisType = '10' then
    ChassisType := 'Notebook'
    else if _chassisType = '11' then
    ChassisType := 'Hand Held'
    else if _chassisType = '12' then
    ChassisType := 'Docking Station'
    else if _chassisType = '13' then
    ChassisType := 'All in One'
    else if _chassisType = '14' then
    ChassisType := 'Sub Notebook'
    else if _chassisType = '15' then
    ChassisType := 'Space-saving'
    else if _chassisType = '16' then
    ChassisType := 'Lunch Box'
    else if _chassisType = '17' then
    ChassisType := 'Main Server'
    else if _chassisType = '18' then
    ChassisType := 'Expansion '
    else if _chassisType = '19' then
    ChassisType := 'SubChassis'
    else if _chassisType = '20' then
    ChassisType := 'Bus Expansion'
    else if _chassisType = '21' then
    ChassisType := 'Peripheral'
    else if _chassisType = '22' then
    ChassisType := 'RAID'
    else if _chassisType = '23' then
    ChassisType := 'Rack Mount'
    else if _chassisType = '24' then
    ChassisType := 'Sealed-case PC'
    else if _chassisType = '25' then
    ChassisType := 'Multi-system'
    else if _chassisType = '26' then
    ChassisType := 'Compact PCI'
    else if _chassisType = '27' then
    ChassisType := 'Advanced TCA'
    else if _chassisType = '28' then
    ChassisType := 'Blade'
    else if _chassisType = '' then
    ChassisType := 'Unknown';


    _ChString := Trim(AssetTagNumber)+Trim(ChassisType);
    _hashCode := GetMD5String(_ChString,TEncoding.Unicode);
    HashCode :=  _hashCode;
end;


end.





