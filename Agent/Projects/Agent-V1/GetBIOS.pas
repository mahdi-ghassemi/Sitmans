unit GetBIOS;

interface

uses SysUtils,Windows,Generics.Collections,Classes,uSMBIOS,ActiveX,
     ComObj,IdHashMessageDigest,IdGlobal;

procedure Start;
//procedure SendToDll();

var
Vendor,StartSegment,Version,ReleaseDate,BiosRomSize:string;
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

procedure GetBIOSInfo;
Var
  SMBios  : TSMBios;
  LBIOS   : TBiosInformation;
  OEMStr  : TOEMStringsInformation;
  i : Integer;
begin
  SMBios:=TSMBios.Create;
  try
    LBIOS:=SMBios.BiosInfo;
    //WriteLn('Bios Information');
    Vendor := LBIOS.VendorStr;
    Version := LBIOS.VersionStr;
    StartSegment := IntToHex(LBIOS.RAWBiosInformation.StartingSegment,4);
    ReleaseDate := LBIOS.ReleaseDateStr;
    BiosRomSize := Format('%d k',[64*(LBIOS.RAWBiosInformation.BiosRomSize+1)]);



    if SMBios.HasOEMStringsInfo then
    begin

    end;

  finally
   SMBios.Free;
  end;
end;

{
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
      if HasBiosInfo then
      begin

        Vendor:= GetSMBiosString(BiosInfoIndex + BiosInfo.Header.Length, BiosInfo.Vendor);
        Version:= GetSMBiosString(BiosInfoIndex + BiosInfo.Header.Length, BiosInfo.Version);
        StartSegment := IntToHex(BiosInfo.StartingSegment,4);
        ReleaseDate := GetSMBiosString(BiosInfoIndex + BiosInfo.Header.Length, BiosInfo.ReleaseDate);
        BiosRomSize:= Format('%d k',[64*(BiosInfo.BiosRomSize+1)]);

      end;
     end;
  finally
   SMBios.Free;
  end;
end;
}
procedure Start;
var
 _hashCode : string;
 _biosString : string;
begin
      GetBIOSInfo;
   // GetMSSmBios_RawSMBiosTablesInfo;
    _biosString := Trim(Vendor)+Trim(Version)+Trim(StartSegment)+Trim(ReleaseDate)+Trim(BiosRomSize);
    _hashCode := GetMD5String(_biosString,TEncoding.Unicode);
   HashCode :=  _hashCode;
end;

end.





