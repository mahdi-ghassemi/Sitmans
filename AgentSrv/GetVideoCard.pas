unit GetVideoCard;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants,LocalData;


procedure Start;
//procedure SendToDll();

var

TotalHashCode:string;

Caption,DriverDate,DriverVersion,VideoProcessor,VideoMode,
        AdapterRam,HashCode:LocalData.TStringArray;

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
      Caption := LocalData.GetWMIstringArray('','Win32_VideoController','Caption');
      DriverDate :=  LocalData.GetWMIstringArray('','Win32_VideoController','DriverDate');
      DriverVersion := LocalData.GetWMIstringArray('','Win32_VideoController','DriverVersion');
      VideoProcessor := LocalData.GetWMIstringArray('','Win32_VideoController','VideoProcessor');
      VideoMode := LocalData.GetWMIstringArray('','Win32_VideoController','VideoModeDescription');
      AdapterRam := LocalData.GetWMIstringArray('','Win32_VideoController','AdapterRam');
      _HDString := '';
       i := 0;
      len := Length(Caption);
      setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(Caption[i])+Trim(DriverDate[i])+
                     Trim(DriverVersion[i])+ Trim(VideoProcessor[i])
                     + Trim(VideoMode[i])+Trim(AdapterRam[i]);

       HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;

end;

end.

