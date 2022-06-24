unit GetHardDisk;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

TotalHashCode:string;

CaptionArray,SignatureArray,HardSizeArray,PartitionsArray,PNPDeviceIDArray,HashCode:LocalData.TStringArray;

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
      CaptionArray := LocalData.GetWMIstringArray('','Win32_DiskDrive','Caption');
      SignatureArray :=  LocalData.GetWMIstringArray('','Win32_DiskDrive','Signature');
      HardSizeArray := LocalData.GetWMIstringArray('','Win32_DiskDrive','Size');
      PartitionsArray := LocalData.GetWMIstringArray('','Win32_DiskDrive','Partitions');
      PNPDeviceIDArray := LocalData.GetWMIstringArray('','Win32_DiskDrive','PNPDeviceID');

      _HDString := '';
       i := 0;
      len := Length(CaptionArray);
      Setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(CaptionArray[i])+Trim(SignatureArray[i])+
                     Trim(HardSizeArray[i])+ Trim(PartitionsArray[i])
                     + Trim(PNPDeviceIDArray[i]);
       HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;

end;

end.

