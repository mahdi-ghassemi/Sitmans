unit GetActiveNetworkSetting;

interface

uses SysUtils,Windows,Generics.Collections,Classes,ActiveX,winsock,
     ComObj,IdHashMessageDigest,IdGlobal,WbemScripting_TLB,Variants;

Type
TNewStringArray = array of string;
const
  WINSOCK_VERSION = $0101;

procedure Start;
procedure DoNullIpAddress;
//procedure SendToDll();

var

TotalHashCode:string;


Caption,IPAddress,SubnetMask,DefaultGateway,DNSServer,DHCPActive
,DHCPServer,MACAddress,HashCode:TNewStringArray;


implementation


 function VarArrayToStr(const vArray: variant): string;

    function _VarToStr(const V: variant): string;
    var
    Vt: integer;
    begin
    Vt := VarType(V);
        case Vt of
          varSmallint,
          varInteger  : Result := IntToStr(integer(V));
          varSingle,
          varDouble,
          varCurrency : Result := FloatToStr(Double(V));
          varDate     : Result := VarToStr(V);
          varOleStr   : Result := WideString(V);
          varBoolean  : Result := VarToStr(V);
          varVariant  : Result := VarToStr(Variant(V));
          varByte     : Result := char(byte(V));
          varString   : Result := String(V);
          varArray    : Result := VarArrayToStr(Variant(V));
        end;
    end;

var
i : integer;
begin
    //Result := '[';
     if (VarType(vArray) and VarArray)=0 then
       Result := _VarToStr(vArray)
    else
    for i := VarArrayLowBound(vArray, 1) to VarArrayHighBound(vArray, 1) do
     if i=VarArrayLowBound(vArray, 1)  then
      Result := Result+_VarToStr(vArray[i])
     else
     // Result := Result+'|'+_VarToStr(vArray[i]);
      Result := Result;
   // Result:=Result+']';
end;



function GetMD5String(Str: String; ADestEncoding: TIdTextEncoding = nil): String;
var MD5: TIdHashMessageDigest5;
begin
          MD5:= TIdHashMessageDigest5.Create;
          try
          Result:= LowerCase (MD5.HashStringAsHex (Str, ADestEncoding));
          finally FreeAndNil (MD5);
    end;
end;

procedure  GetWin32_NetworkAdapterConfigurationInfo;
const
  WbemUser            ='';
  WbemPassword        ='';
  WbemComputer        ='localhost';
  wbemFlagForwardOnly = $00000020;
var
  FSWbemLocator : OLEVariant;
  FWMIService   : OLEVariant;
  FWbemObjectSet: OLEVariant;
  FWbemObject   : OLEVariant;
  oEnum         : IEnumvariant;
  iValue        : LongWord;
  i : integer;
begin;
  i := 0;
  FSWbemLocator := CreateOleObject('WbemScripting.SWbemLocator');
  FWMIService   := FSWbemLocator.ConnectServer(WbemComputer, 'root\CIMV2', WbemUser, WbemPassword);
  FWbemObjectSet:= FWMIService.ExecQuery('SELECT * FROM Win32_NetworkAdapterConfiguration','WQL',wbemFlagForwardOnly);
  oEnum         := IUnknown(FWbemObjectSet._NewEnum) as IEnumVariant;
  while oEnum.Next(1, FWbemObject, iValue) = 0 do
  begin
    if (not VarIsNull(FWbemObject.IPAddress)) AND
       (not VarIsNull(FWbemObject.IPSubnet)) AND
      (not VarIsNull(FWbemObject.MACAddress)) AND
      (not VarIsNull(FWbemObject.DefaultIPGateway)) then
    begin

    setLength( Caption, i+1 );
    setLength( DHCPServer, i+1 );
    setLength( IPAddress, i+1 );
    setLength( SubnetMask, i+1 );
    setLength( MACAddress, i+1 );
    setLength( DNSServer, i+1 );
    setLength( DHCPActive, i+1 );
    setLength( DefaultGateway, i+1 );

    Caption[i] := (Format('%s',[String(FWbemObject.Caption)]));// String
    if not VarIsNull(FWbemObject.DHCPServer) then
    DHCPServer[i] := (Format('%s',[String(FWbemObject.DHCPServer)]));// String
    if not VarIsNull(FWbemObject.IPAddress) then
    IPAddress[i] := (Format('%s',[VarArrayToStr(FWbemObject.IPAddress)]));// array String
    if not VarIsNull(FWbemObject.IPSubnet) then
    SubnetMask[i] := (Format('%s',[VarArrayToStr(FWbemObject.IPSubnet)]));// array String
    if not VarIsNull(FWbemObject.MACAddress) then
    MACAddress[i] := (Format('%s',[VarArrayToStr(FWbemObject.MACAddress)]));// array String
    if not VarIsNull(FWbemObject.DNSServerSearchOrder) then
    DNSServer[i] := (Format('%s',[VarArrayToStr(FWbemObject.DNSServerSearchOrder)]));// array String
    if not VarIsNull(FWbemObject.DHCPEnabled) then
    DHCPActive[i] := (Format('%s',[VarArrayToStr(FWbemObject.DHCPEnabled)]));// array String
    if not VarIsNull(FWbemObject.DefaultIPGateway) then
    DefaultGateway[i] := (Format('%s',[VarArrayToStr(FWbemObject.DefaultIPGateway)]));// array String
    inc (i);
    FWbemObject:=Unassigned;
    end
    else  //ip address is null
    begin
      DoNullIpAddress;
      FWbemObject:=Unassigned;
      break;
    end;

  end;
end;

procedure DoNullIpAddress;
begin
    setLength( Caption, 1 );
    setLength( DHCPServer, 1 );
    setLength( IPAddress, 1 );
    setLength( SubnetMask,1 );
    setLength( MACAddress, 1 );
    setLength( DNSServer, 1 );
    setLength( DHCPActive, 1 );
    setLength( DefaultGateway, 1 );

    Caption[0] := 'Not Exist';// String
    DHCPServer[0] := 'Not Exist';
    IPAddress[0] := '127.0.0.1';//  String
    SubnetMask[0] := 'Not Exist';//  String
    MACAddress[0] := 'Not Exist';//  String
    DNSServer[0] := 'Not Exist';//  String
    DHCPActive[0] := 'False';//  String
    DefaultGateway[0] := 'Not Exist';//  String

end;





procedure Start;
var
 _hashCode : string;
 _HDString : string;
 _TotalhashCode : string;
 len,i : integer;

begin

       GetWin32_NetworkAdapterConfigurationInfo;

      _HDString := '';
       i := 0;
      len := Length(IPAddress);
      setlength(HashCode,len);
      while i < len do
      begin
        _HDString := Trim(Caption[i])+ Trim(IPAddress[i])+Trim(SubnetMask[i])+
                     Trim(DefaultGateway[i])+ Trim(DNSServer[i])+
                     Trim(DHCPActive[i])+Trim(DHCPServer[i])+Trim(MACAddress[i]);
       HashCode[i] := GetMD5String(_HDString,TEncoding.Unicode);
       _hashCode := _hashCode + HashCode[i];
       _HDString := '';
       inc(i);
      end;

     _TotalhashCode := GetMD5String(_hashCode,TEncoding.Unicode);
     TotalHashCode :=  _TotalhashCode;

end;

end.

