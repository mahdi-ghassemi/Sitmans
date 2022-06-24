unit GetLogicDisk;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

TotalHashCode:string;

Caption,Description,FileSystem,VolumeSize,FreeSpace,
        VolumeName,VolumeSerialNumber,HashCode:LocalData.TStringArray;

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
      Caption := LocalData.GetWMIstringArray('','Win32_LogicalDisk','Caption');
      Description :=  LocalData.GetWMIstringArray('','Win32_LogicalDisk','Description');
      FileSystem := LocalData.GetWMIstringArray('','Win32_LogicalDisk','FileSystem');
      VolumeSize := LocalData.GetWMIstringArray('','Win32_LogicalDisk','Size');
      FreeSpace := LocalData.GetWMIstringArray('','Win32_LogicalDisk','FreeSpace');
      VolumeName := LocalData.GetWMIstringArray('','Win32_LogicalDisk','VolumeName');
      VolumeSerialNumber := LocalData.GetWMIstringArray('','Win32_LogicalDisk','VolumeSerialNumber');
      _HDString := '';
       i := 0;
      len := Length(Caption);
      setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(Caption[i])+Trim(Description[i])+
                     Trim(FileSystem[i])+ Trim(VolumeSize[i])
                     +Trim(VolumeName[i])+ Trim(VolumeSerialNumber[i]);
       HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;


end;



end.

