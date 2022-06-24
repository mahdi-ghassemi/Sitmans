unit LocalData;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes,Data.DB, Data.Win.ADODB,WbemScripting_TLB,ActiveX,ComObj,
  IdHashMessageDigest, IdGlobal,GetActiveNetworkSetting,Winsock;



    { Connection string }
//const
//ConnStrings = 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';



Type

TStringArray = array of string;
TName = array of string;



function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
function ExecuteQueryDll(QueryString:string): integer;
function IsRegister():Integer;
function IsFirstRun():Integer;
function FirstRunToOne():Integer;
function GetWMIstringArray (wmiHost, wmiClass, wmiProperty : string):TStringArray;
function GetWMIstring (wmiHost, wmiClass, wmiProperty : string):string;
function GetChassisType ():string;
function GetMD5String(Str: String; ADestEncoding: TIdTextEncoding = nil): String;
function SaveAgentToDll(Values:array of string):integer;
function SaveCPUToDll(Values:array of string):integer;
function SaveMainboardToDll(Values:array of string):integer;
function SaveBiosToDll(Values:array of string):integer;
function SaveChassisToDll(Values:array of string):integer;
function SaveOSToDll(Values:array of string):integer;
function SaveSysToDll(Values:array of string):integer;
function SaveHardDisksToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveVideoCardToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveCDRomToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveLogicDiskToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveMemoryToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveModemToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveNetworkAdapterToDll(Values:array of TStringArray;HashCode:string):integer;
function SavePrinterToDll(Values:array of TStringArray;HashCode:string):integer;
function SavePublicDevicesToDll(Values:array of string):integer;
function FirstSaveSoftwareToDll(Values:array of string;HashCode:string):integer;
function FirstSaveUserAccountToDll(Values:array of TStringArray;HashCode:string):integer;
function FirstSaveGroupNameToDll(Values:array of TStringArray;HashCode:string):integer;
function SaveActiveNetworkSettingToDll(Values:array of GetActiveNetworkSetting.TNewStringArray;HashCode:string):integer;
function GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
procedure SaveEventInDll(AgentId:string;EventID:string;LastValue:string;CurrentValue:string;LevelId:string;SubjectId:string);
function CpuToArray():TStringArray;
function MainboardToArray():TStringArray;
function BIOSToArray():TStringArray;
function PublicDeviceToArray():TStringArray;
function HashCodesToArray(TableName:string):TStringArray;
function GetRowCount(TableName:string):integer;
function MemoryToArray(Index:string):TStringArray;
function HardDiskToArray(Index:string):TStringArray;
function LogicDiskToArray(Index:string):TStringArray;
function ChassisToArray():TStringArray;
function AgentPropertiesToArray():TStringArray;
function OSToArray() : TStringArray;
function SysToArray() : TStringArray;
function VideoCardToArray(Index:string):TStringArray;
function CDROMToArray(Index:string):TStringArray;
function ModemToArray(Index:string):TStringArray;
function NetworkAdapterToArray(Index:string):TStringArray;
function PrinterToArray(Index:string):TStringArray;
function UserAccountToArray(Index:string):TStringArray;
function GroupAccountToArray(Index:string):TStringArray;
function ActiveNetworkSettingToArray(Index:string):TStringArray;
function SoftwareToArray(): TStringArray;
function GetSystemFingerprint(CpuSerial:string;MbSerial:string;Uuid:string):string;
function GetMessageFromDll(LangCode:string;ParentName:string;ControlName:string):string;
function CheckSQLConnectionString():string;
procedure SetStepNumber(StepNumber:integer);
procedure SaveAgentIdToDll(AgentId:string);
function GetDataArrayFromDll(TableName:string;FieldName:string):TStringArray;
Function GetSoftwaresFromDll:TName;
function GetActiveNetworkArrayFromDll(FieldName:string):GetActiveNetworkSetting.TNewStringArray;
function GetRowCountWithoutCondition(TableName:string):integer;
procedure UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
function GetListFromArray(MyArray : TStringArray):TStringList;
function GetSoftListFromArray(MyArray : TName):TStringList;
function GetListFromTNewstringArray(MyArray : TNewStringArray):TStringList;
procedure CompareLists(var CurrentList:TStringList;var DllList:TStringList);
procedure DeleteDataFromDll(TableName:string);
procedure CreateChatUserList;
Function GetIPAddress():String;


var
ChatUsersList : TStringList;

implementation

procedure CreateChatUserList;
begin
  ChatUsersList := TStringList.Create;
end;

Function GetIPAddress():String;
type
  pu_long = ^u_long;
var
  varTWSAData : TWSAData;
  varPHostEnt : PHostEnt;
  varTInAddr : TInAddr;
  namebuf : Array[0..255] of AnsiChar;
begin
  If WSAStartup($101,varTWSAData) <> 0 Then
  Result := 'No. IP Address'
  Else Begin
    gethostname(namebuf,sizeof(namebuf));
    varPHostEnt := gethostbyname(namebuf);
    varTInAddr.S_addr := u_long(pu_long(varPHostEnt^.h_addr_list^)^);
    Result := inet_ntoa(varTInAddr);
  End;
  WSACleanup;
end;

procedure DeleteDataFromDll(TableName:string);
var
  SQLStr : string;  { SQL Query }
  res :integer;
begin

  SQLStr:= 'DELETE FROM '+TableName;
  res := ExecuteQueryDll(SQLStr);

end;

procedure CompareLists(var CurrentList:TStringList;var DllList:TStringList);
var
i,m,lenList1,lenList2,findIndex : integer;
curValue : string;
begin

lenList1 := CurrentList.Count;
lenList2 := DllList.Count;


i := 0;
m := 0;
while i < lenList1 do
  begin
    curValue := CurrentList[m];
    findIndex := DllList.IndexOf(curValue);
    if findIndex <> -1 then
    begin
       DllList.Delete(findIndex);
       CurrentList.Delete(m);
      // m := 0;
    end else
    begin
       inc(m);
    end;
    inc(i);
end;

end;

function GetListFromArray(MyArray : TStringArray):TStringList;
var
i,len : integer;
MyList : TStringList;
begin
  MyList := TStringList.Create;
  len := length(MyArray);
  i := 0;
  while i < len do
  begin
    MyList.Add(MyArray[i]);
    inc(i);
  end;
  Result := MyList;
end;

function GetSoftListFromArray(MyArray : TName):TStringList;
var
i,len : integer;
MyList : TStringList;
begin
  MyList := TStringList.Create;
  len := length(MyArray);
  i := 0;
  while i < len do
  begin
    MyList.Add(MyArray[i]);
    inc(i);
  end;
  Result := MyList;
end;

function GetListFromTNewstringArray(MyArray : TNewStringArray):TStringList;
var
i,len : integer;
MyList : TStringList;
begin
  MyList := TStringList.Create;
  len := length(MyArray);
  i := 0;
  while i < len do
  begin
    MyList.Add(MyArray[i]);
    inc(i);
  end;
  Result := MyList;
end;

function GetRowCountWithoutCondition(TableName:string):integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';

SQLStr := 'SELECT COUNT(*) AS Fcount  FROM '+TableName ;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Result := ADOQuery_FRTO.FieldByName('Fcount').AsInteger;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function GetRowCount(TableName:string):integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
SQLStr := 'SELECT COUNT(*) AS Fcount  FROM (SELECT HashCode FROM '+TableName+' WHERE HashCode IS NOT NULL)';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Result := ADOQuery_FRTO.FieldByName('Fcount').AsInteger;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function HashCodesToArray(TableName:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
  arraylen,i : integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  arraylen := GetRowCount(TableName);
  Setlength(Res,arraylen);
  SQLStr := 'SELECT HashCode FROM '+ TableName + ' WHERE HashCode IS NOT NULL' ;

  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }


  i := 0;
  ADOQuery_FRTO.Open;
  ADOQuery_FRTO.First;
  Res[i] := Trim(ADOQuery_FRTO.FieldByName('HashCode').AsString);
  inc(i);
  while i < arraylen  do
  begin
     ADOQuery_FRTO.Next;
     Res[i] := Trim(ADOQuery_FRTO.FieldByName('HashCode').AsString);
     inc(i);
  end;


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;

end;

procedure SaveEventInDll(AgentId:string;EventID:string;LastValue:string;CurrentValue:string;LevelId:string;SubjectId:string);
var
Date_Time : string;
SQLStr : string;
len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'INSERT INTO EventOccur(AgentId,EventId,EventDateTime,LastValue,CurrentValue,LevelId,SubjectId,SendTOSql) VALUES("'+
                 AgentId+'","'+
                 EventID+'","'+
                  Date_Time+'","'+
                   LastValue+'","'+
                    CurrentValue+'","'+
                     LevelId +'","'+
                       SubjectId+'","'
                     +'"0")';
  ExecuteQueryDll(SQLStr);

end;

function SoftwareToArray(): TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
  arraylen,i : integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  arraylen := GetRowCountWithoutCondition('Software');
  Setlength(Res,arraylen);
  SQLStr := 'SELECT SoftwareName FROM Software';


  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }


  i := 0;
  ADOQuery_FRTO.Open;
  ADOQuery_FRTO.First;
  Res[i] := Trim(ADOQuery_FRTO.FieldByName('SoftwareName').AsString);
  inc(i);
  while i < arraylen  do
  begin
     ADOQuery_FRTO.Next;
     Res[i] := Trim(ADOQuery_FRTO.FieldByName('SoftwareName').AsString);
     inc(i);
  end;


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;

end;

function MemoryToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,3);
  SQLStr := 'SELECT * FROM Memory WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('BankLabel').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Capacity').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('Speed').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function CpuToArray():TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,18);
  SQLStr := 'SELECT * FROM Processors WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('VendorID').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('SteppingID').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('ModelNumber').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('FamilyCode').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('ProcessorType').AsString);
  Res[5] := Trim(ADOQuery_FRTO.FieldByName('ExtendedModel').AsString);
  Res[6] := Trim(ADOQuery_FRTO.FieldByName('ExtendedFamily').AsString);
  Res[7] := Trim(ADOQuery_FRTO.FieldByName('BrandID').AsString);
  Res[8] := Trim(ADOQuery_FRTO.FieldByName('Chunks').AsString);
  Res[9] := Trim(ADOQuery_FRTO.FieldByName('Counts').AsString);
  Res[10] := Trim(ADOQuery_FRTO.FieldByName('SerialNumber').AsString);
  Res[11] := Trim(ADOQuery_FRTO.FieldByName('MMX').AsString);
  Res[12] := Trim(ADOQuery_FRTO.FieldByName('FxsaveFxrstorInstructions').AsString);
  Res[13] := Trim(ADOQuery_FRTO.FieldByName('SSE').AsString);
  Res[14] := Trim(ADOQuery_FRTO.FieldByName('SSE2').AsString);
  Res[15] := Trim(ADOQuery_FRTO.FieldByName('ExtendedCPUID').AsString);
  Res[16] := Trim(ADOQuery_FRTO.FieldByName('LargestFunctionSupported').AsString);
  Res[17] := Trim(ADOQuery_FRTO.FieldByName('Brand').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function MainboardToArray():TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,4);
  SQLStr := 'SELECT * FROM Motherboard WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Manufacturer').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('SerialNumber').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('Product').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('Version').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function PublicDeviceToArray():TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,5);
  SQLStr := 'SELECT * FROM PublicDevices WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Monitor').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Keyboard').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('Mouse').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('Scanner').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('Camera').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function BIOSToArray():TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,5);
  SQLStr := 'SELECT * FROM BIOS WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Vendor').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Version').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('StartSegment').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('ReleaseDate').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('BiosRomSize').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function ActiveNetworkSettingToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,8);
  SQLStr := 'SELECT * FROM ActiveNetworkSetting WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Caption').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('IPAddress').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('SubnetMask').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('DefaultGateway').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('DNSServer').AsString);
  Res[5] := Trim(ADOQuery_FRTO.FieldByName('DHCPActive').AsString);
  Res[6] := Trim(ADOQuery_FRTO.FieldByName('DHCPServer').AsString);
  Res[7] := Trim(ADOQuery_FRTO.FieldByName('MACAddress').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function HardDiskToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,5);
  SQLStr := 'SELECT * FROM HardDisk WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Caption').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Signature').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('HardSize').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('Partitions').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('PNPDeviceID').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function GroupAccountToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,4);
  SQLStr := 'SELECT * FROM UserGroup WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('GroupName').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('GID').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('Description').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('Status').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function UserAccountToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,4);
  SQLStr := 'SELECT * FROM UserAccount WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('UserName').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('SID').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('Description').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('Status').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function PrinterToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,2);
  SQLStr := 'SELECT * FROM Printer WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('PrinterName').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Network').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function NetworkAdapterToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,6);
  SQLStr := 'SELECT * FROM NetworkAdapter WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Description').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('AdapterType').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('MACAddress').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('Manufacturer').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('NetConnectionID').AsString);
  Res[5] := Trim(ADOQuery_FRTO.FieldByName('PNPDeviceID').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function CDROMToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,2);
  SQLStr := 'SELECT * FROM CDROM WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('CdromName').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('CdromDrive').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function ModemToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,1);
  SQLStr := 'SELECT * FROM Modem WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('ModemName').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function VideoCardToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,6);
  SQLStr := 'SELECT * FROM VideoCard WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Caption').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('DriverDate').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('DriverVersion').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('VideoProcessor').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('VideoMode').AsString);
  Res[5] := Trim(ADOQuery_FRTO.FieldByName('AdapterRam').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;


function LogicDiskToArray(Index:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,7);
  SQLStr := 'SELECT * FROM LogicDisk WHERE ID = '+Index;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('Caption').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Description').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('FileSystem').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('VolumeSize').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('FreeSpace').AsString);
  Res[5] := Trim(ADOQuery_FRTO.FieldByName('VolumeName').AsString);
  Res[6] := Trim(ADOQuery_FRTO.FieldByName('VolumeSerialNumber').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function SysToArray() : TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,1);
  SQLStr := 'SELECT * FROM Sys WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('UUID').AsString);

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;



function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Res := 0;


  SQLStr := QueryString;


  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  try
    ADOQuery_FRTO.Open;
    Result := ADOQuery_FRTO.FieldByName(FieldName).AsString;

  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  Res := 1;
  //Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function ChassisToArray():TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,2);
  SQLStr := 'SELECT * FROM Chassis WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('AssetTagNumber').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('ChassisType').AsString);



  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function AgentPropertiesToArray():TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,4);
  SQLStr := 'SELECT * FROM AgentDetails WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('ComputerName').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('Organization').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('RegisterCompany').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('RegisterUser').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function OSToArray() : TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Setlength(Res,5);
  SQLStr := 'SELECT * FROM OperatingSystem WHERE ID = 1';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  Res[0] := Trim(ADOQuery_FRTO.FieldByName('SerialNumber').AsString);
  Res[1] := Trim(ADOQuery_FRTO.FieldByName('BuildNumber').AsString);
  Res[2] := Trim(ADOQuery_FRTO.FieldByName('Caption').AsString);
  Res[3] := Trim(ADOQuery_FRTO.FieldByName('InstallDate').AsString);
  Res[4] := Trim(ADOQuery_FRTO.FieldByName('Version').AsString);


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;



function ExecuteQueryDll(QueryString:string): integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : Integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Res := 0;


  SQLStr := QueryString;


  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  try
    ADOQuery_FRTO.ExecSQL;

  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  Res := 1;
  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
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

function GetSystemFingerprint(CpuSerial:string;MbSerial:string;Uuid:string):string;
var
_text,_enc : string;
begin
  _text := Trim(CpuSerial)+Trim(MbSerial)+Trim(Uuid);
  _enc := GetMD5String(_text,TEncoding.Unicode);
  Result :=  _enc;

end;

function GetWMIstringArray (wmiHost, wmiClass, wmiProperty : string):TStringArray;
var  // These are all needed for the WMI querying process
  Locator:  ISWbemLocator;
  Services: ISWbemServices;
  SObject:  ISWbemObject;
  ObjSet:   ISWbemObjectSet;
  SProp:    ISWbemProperty;
  Enum:     IEnumVariant;
  Value:    Cardinal;
  TempObj:  OleVariant;
  _Result: Array of string;
  i : Integer;
begin
  try
  Locator := CoSWbemLocator.Create;  // Create the Location object
  // Connect to the WMI service, with the root\cimv2 namespace
   Services :=  Locator.ConnectServer(wmiHost, 'root\cimv2', '', '', '','', 0, nil);
  ObjSet := Services.ExecQuery('SELECT * FROM '+wmiClass, 'WQL',
    wbemFlagReturnImmediately and wbemFlagForwardOnly , nil);
  Enum :=  (ObjSet._NewEnum) as IEnumVariant;
  i := 0;
  while (Enum.Next(1, TempObj, Value) = S_OK) do
  begin
    setLength( result, i+1 );
    SObject := IUnknown(tempObj) as ISWBemObject;
    SProp := SObject.Properties_.Item(wmiProperty, 0);
    if VarIsNull(SProp.Get_Value) then
    begin
      result[i] := '';
      inc( i )

    end else
    begin
      result[i] := SProp.Get_Value;
      inc( i )

    end;
  end;
  except // Trap any exceptions (Not having WMI installed will cause one!)
   on exception do
   begin
     result[i] := '';
      inc( i )

   end;
  end;
end;

function GetWMIstring (wmiHost, wmiClass, wmiProperty : string):string;
var  // These are all needed for the WMI querying process
  Locator:  ISWbemLocator;
  Services: ISWbemServices;
  SObject:  ISWbemObject;
  ObjSet:   ISWbemObjectSet;
  SProp:    ISWbemProperty;
  Enum:     IEnumVariant;
  Value:    Cardinal;
  TempObj:  OleVariant;

begin
  try
  Locator := CoSWbemLocator.Create;  // Create the Location object
  // Connect to the WMI service, with the root\cimv2 namespace
   Services :=  Locator.ConnectServer(wmiHost, 'root\cimv2', '', '', '','', 0, nil);
  ObjSet := Services.ExecQuery('SELECT * FROM '+wmiClass, 'WQL',
    wbemFlagReturnImmediately and wbemFlagForwardOnly , nil);
  Enum :=  (ObjSet._NewEnum) as IEnumVariant;

  while (Enum.Next(1, TempObj, Value) = S_OK) do
  begin

    SObject := IUnknown(tempObj) as ISWBemObject;
    SProp := SObject.Properties_.Item(wmiProperty, 0);
    if VarIsNull(SProp.Get_Value) then
    begin
      result := '';

    end else
    begin
      result := SProp.Get_Value;

    end;
  end;
  except // Trap any exceptions (Not having WMI installed will cause one!)
   on exception do
   begin
     result := '';
   end;
  end;
end;

function GetChassisType():string;
const
  wbemFlagForwardOnly = $00000020;
var
  FSWbemLocator : OLEVariant;
  FWMIService   : OLEVariant;
  FWbemObjectSet: OLEVariant;
  FWbemObject   : OLEVariant;
  oEnum         : IEnumvariant;
  iValue        : LongWord;
  i             : integer;
begin;
  FSWbemLocator := CreateOleObject('WbemScripting.SWbemLocator');
  FWMIService   := FSWbemLocator.ConnectServer('localhost', 'root\cimv2', '', '');
  FWbemObjectSet:= FWMIService.ExecQuery('SELECT * FROM  Win32_SystemEnclosure','WQL',wbemFlagForwardOnly);
  oEnum         := IUnknown(FWbemObjectSet._NewEnum) as IEnumVariant;
  if oEnum.Next(1, FWbemObject, iValue) = 0 then
  begin
    for i := VarArrayLowBound(FWbemObject.ChassisTypes, 1) to VarArrayHighBound(FWbemObject.ChassisTypes, 1) do
     result := (Format('%d',[Integer(FWbemObject.ChassisTypes[i])]));
    FWbemObject:=Unassigned;
  end;



end;

function IsRegister: Integer;
var
  isreg : Integer;
  ADOConn  : TADOConnection;
  ADOQuery : TADOQuery;
  SQLStr : string;{ SQL Query }
  Res : Integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  isreg := 0;
  SQLStr:= 'SELECT * FROM AgentSetting';
  ADOConn := TADOConnection.Create(nil);{ Create an ADO connection }
  ADOConn.ConnectionString := ConnString;  { Setup the connection string }
  ADOConn.LoginPrompt := False;   { Disable login prompt }
  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery.Close;
      ADOConn.Close;
      Exit;
    end;
  end;


  ADOQuery := TADOQuery.Create(nil);  { Create the query }
  ADOQuery.Connection := ADOConn;
  ADOQuery.SQL.Add(SQLStr);
  ADOQuery.ParamCheck := false;

  ADOQuery.Prepared := true;  { Set the query to Prepared - will improve performance }

  try
    ADOQuery.Open;

  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  isreg := ADOQuery.FieldByName('IsRegister').AsInteger;

  if isreg = 0 then begin
  Res := 0;
  end else
  if isreg = 1 then begin
  Res := 1;
  end;
  Result := Res;
  ADOQuery.Close;
  ADOConn.Close;
end;

function IsFirstRun: Integer;

var
  isfrun : Integer;
  ADOConn  : TADOConnection;
  ADOQuery : TADOQuery; { SQL Query }
  SQLStr : string;
  Res : Integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  isfrun := 0;
  SQLStr:= 'SELECT * FROM AgentSetting';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  ADOConn.ConnectionString := ConnString;   { Setup the connection string }
  ADOConn.LoginPrompt := False;  { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
     Res := -1;
     ADOQuery.Close;
     ADOConn.Close;
     Exit;
    end;
  end;

  ADOQuery := TADOQuery.Create(nil);  { Create the query }
  ADOQuery.Connection := ADOConn;
  ADOQuery.SQL.Add(SQLStr);
  ADOQuery.ParamCheck := false;
  ADOQuery.Prepared := true;  { Set the query to Prepared - will improve performance }

  try
    ADOQuery.Open;

  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  isfrun := ADOQuery.FieldByName('RunOnce').AsInteger;

  if isfrun = 1 then begin
  Res := 1;
  end else
  if isfrun = 0 then begin
  Res := 0;
  end;
  Result := Res;
  ADOQuery.Close;
  ADOConn.Close;
end;

function FirstRunToOne: Integer;
var

  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : Integer;

 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Res := 0;
  SQLStr:= 'UPDATE AgentSetting SET RunOnce = 1 WHERE ID = 1';

  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  try
    ADOQuery_FRTO.ExecSQL;

  except
    on e: EADOError do
    begin
      Res := -1;
      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  Res := 1;
  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function SaveAgentToDll(Values:array of string):integer;
var
  SQLStr : string;  { SQL Query }
  Date_Time : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE AgentDetails SET ComputerName ="'+Values[0]+
           '",Organization ="'+Values[1]+
           '",CurrentUser = "'+Values[2]+
           '",RegisterCompany = "'+Values[3]+
           '",RegisterUser = "'+Values[4]+
           '",LastBootUpTime = "' +Values[5]+
           '" WHERE ID = 1';
  Result := ExecuteQueryDll(SQLStr);
  SQLStr := '';
  SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[6]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 10';
   Result := ExecuteQueryDll(SQLStr);
  SQLStr := '';
  SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[7]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);

end;

function SaveCPUToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE Processors SET VendorID ="'+Values[0]+
           '",SteppingID ="'+Values[1]+
           '",ModelNumber = "'+Values[2]+
           '",FamilyCode = "'+Values[3]+
           '",ProcessorType = "'+Values[4]+
           '",ExtendedModel = "' +Values[5]+
           '",ExtendedFamily = "'+ Values[6]+
           '",BrandID ="'+Values[7]+
           '",Chunks = "'+Values[8]+
           '",Counts = "'+Values[9]+
           '",APICID = "'+Values[10]+
           '",SerialNumber = "' +Values[11]+
           '",MMX = "'+ Values[12]+
           '",FxsaveFxrstorInstructions ="'+Values[13]+
           '",SSE = "'+Values[14]+
           '",SSE2 = "'+Values[15]+
           '",ExtendedCPUID = "'+Values[16]+
           '",LargestFunctionSupported = "' +Values[17]+
           '",Brand = "'+ Values[18]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := '';
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[19]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 2';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveMainboardToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE Motherboard SET Manufacturer ="'+Values[0]+
           '",SerialNumber ="'+Values[1]+
           '",Product = "'+Values[2]+
           '",Version = "'+Values[3]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := '';
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[4]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 3';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveBiosToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE BIOS SET Vendor ="'+Values[0]+
           '",Version ="'+Values[1]+
           '",StartSegment = "'+Values[2]+
           '",ReleaseDate = "'+Values[3]+
           '",BiosRomSize = "'+Values[4]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := '';
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[5]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 4';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveChassisToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE Chassis SET AssetTagNumber ="'+Values[0]+
           '",ChassisType ="'+Values[1]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := '';
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[2]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 9';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveOSToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE OperatingSystem SET SerialNumber ="'+Values[0]+
           '",BuildNumber ="'+Values[1]+
           '",Caption = "'+Values[2]+
           '",FreePhysicalMemory = "'+Values[3]+
           '",InstallDate ="'+Values[4]+
           '",Version = "'+Values[5]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := '';
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[6]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 11';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveSysToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE Sys SET UUID ="'+Values[0]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := '';
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[1]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 12';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveHardDisksToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE HardDisk SET Caption ="'+Values[0][i]+
           '",Signature ="'+Values[1][i]+
           '",HardSize = "'+Values[2][i]+
           '",Partitions = "'+Values[3][i]+
           '",PNPDeviceID ="'+Values[4][i]+
           '",HashCode = "'+ Values[5][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 6';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveVideoCardToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE VideoCard SET Caption ="'+Values[0][i]+
           '",DriverDate ="'+Values[1][i]+
           '",DriverVersion = "'+Values[2][i]+
           '",VideoProcessor = "'+Values[3][i]+
           '",VideoMode ="'+Values[4][i]+
           '",AdapterRam ="'+Values[5][i]+
           '",HashCode = "'+ Values[6][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 13';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveCDRomToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE CDROM SET CdromName ="'+Values[0][i]+
           '",CdromDrive ="'+Values[1][i]+
           '",HashCode = "'+ Values[2][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 14';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveLogicDiskToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE LogicDisk SET Caption ="'+Values[0][i]+
           '",Description ="'+Values[1][i]+
           '",FileSystem = "'+Values[2][i]+
           '",VolumeSize = "'+Values[3][i]+
           '",FreeSpace ="'+Values[4][i]+
           '",VolumeName ="'+Values[5][i]+
           '",VolumeSerialNumber ="'+Values[6][i]+
           '",HashCode = "'+ Values[7][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 7';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveMemoryToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE Memory SET BankLabel ="'+Values[0][i]+
           '",Capacity ="'+Values[1][i]+
           '",Speed = "'+Values[2][i]+
           '",HashCode = "'+ Values[3][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 5';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveModemToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE Modem SET ModemName ="'+Values[0][i]+
           '",HashCode = "'+ Values[1][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 15';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveNetworkAdapterToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE NetworkAdapter SET Description ="'+Values[0][i]+
           '",AdapterType ="'+Values[1][i]+
           '",MACAddress = "'+Values[2][i]+
           '",Manufacturer = "'+Values[3][i]+
           '",NetConnectionID ="'+Values[4][i]+
           '",PNPDeviceID ="'+Values[5][i]+
           '",TimeOfLastReset ="'+Values[6][i]+
           '",HashCode = "'+ Values[7][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 16';
   Result := ExecuteQueryDll(SQLStr);
end;

function SavePrinterToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE Printer SET PrinterName ="'+Values[0][i]+
           '",Network ="'+Values[1][i]+
           '",HashCode = "'+ Values[2][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 17';
   Result := ExecuteQueryDll(SQLStr);

end;

function SavePublicDevicesToDll(Values:array of string):integer;
var
 Date_Time : string;
 SQLStr : string;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  SQLStr:= 'UPDATE PublicDevices SET Monitor ="'+Values[0]+
           '",Keyboard ="'+Values[1]+
           '",Mouse ="'+Values[2]+
           '",Camera ="'+Values[3]+
           '" WHERE ID = 1';
   Result := ExecuteQueryDll(SQLStr);
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+Values[4]+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 18';
   Result := ExecuteQueryDll(SQLStr);
end;

function FirstSaveSoftwareToDll(Values:array of string;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'INSERT INTO Software(SoftwareName,SendToSql) VALUES("'+Values[i]+'","0")';
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 8';
   Result := ExecuteQueryDll(SQLStr);
end;

function FirstSaveUserAccountToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'INSERT INTO UserAccount(UserName,SID,Description,Status,HashCode,SendToSql) VALUES("'+
                 Values[0][i]+'","'+
                  Values[1][i]+'","'+
                   Values[2][i]+'","'+
                    Values[3][i]+'","'+
                     Values[4][i]+'","0")';
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 19';
   Result := ExecuteQueryDll(SQLStr);
end;

function FirstSaveGroupNameToDll(Values:array of TStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'INSERT INTO UserGroup(GroupName,GID,Description,Status,HashCode,SendToSql) VALUES("'+
                 Values[0][i]+'","'+
                  Values[1][i]+'","'+
                   Values[2][i]+'","'+
                    Values[3][i]+'","'+
                     Values[4][i]+'","0")';
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 20';
   Result := ExecuteQueryDll(SQLStr);
end;

function SaveActiveNetworkSettingToDll(Values:array of GetActiveNetworkSetting.TNewStringArray;HashCode:string):integer;
var
 Date_Time : string;
 SQLStr : string;
 len,i : integer;
begin
  Date_Time := Trim(DateTimeToStr(Now));
  len := Length(Values[0]);
  i := 0;
  while i < len do
  begin
       SQLStr:= 'UPDATE ActiveNetworkSetting SET Caption ="'+Values[0][i]+
           '",IPAddress ="'+Values[1][i]+
           '",SubnetMask = "'+Values[2][i]+
           '",DefaultGateway = "'+Values[3][i]+
           '",DNSServer ="'+Values[4][i]+
           '",DHCPActive ="'+Values[5][i]+
           '",DHCPServer ="'+Values[6][i]+
           '",MACAddress ="'+Values[7][i]+
           '",HashCode = "'+ Values[8][i] +
           '" WHERE ID = '+IntToStr(i+1);
       Result := ExecuteQueryDll(SQLStr);
       SQLStr := '';
       inc(i);
   end;
   SQLStr := 'UPDATE HashCodes SET HashCode ="'+HashCode+
             '",LastUpdateDate = "'+Date_Time+
             '" WHERE ID = 21';
   Result := ExecuteQueryDll(SQLStr);
end;

function GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM '+TableName +
             ' WHERE ID = '+Condition;
   Result := ExecuteQueryDllToString(SQLStr,FieldName);
end;

function GetMessageFromDll(LangCode:string;ParentName:string;ControlName:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM Messages'+
             ' WHERE LanguageCode = "'+LangCode+
             '" AND ControlName = "'+ControlName+
             '" AND ParentName = "'+ParentName+'"';
   Result := ExecuteQueryDllToString(SQLStr,'Message');
end;

function CheckSQLConnectionString():string;
var
SQLServerAddress,SQLUsername,SQLPassword,SQLDatabaseName:string;
ConnectionString:string;
ADOConn  : TADOConnection;
begin
  SQLServerAddress := LocalData.GetDataFromDll('AgentSetting','SQLServerAddress','1');
  SQLUsername := LocalData.GetDataFromDll('AgentSetting','SQLUsername','1');
  SQLPassword := LocalData.GetDataFromDll('AgentSetting','SQLPassword','1');
  SQLDatabaseName := LocalData.GetDataFromDll('AgentSetting','SQLDatabaseName','1');
  ConnectionString := 'Provider=SQLOLEDB;Data Source='+Trim(SQLServerAddress)+
                      ';Initial Catalog='+Trim(SQLDatabaseName)+
                      ';User Id='+Trim(SQLUsername)+
                      ';Password='+Trim(SQLPassword);

 ADOConn := TADOConnection.Create(nil);
 ADOConn.ConnectionString := ConnectionString;
 ADOConn.LoginPrompt := False;
 try
   Result := '1';
   ADOConn.Open();
 Except
   on E: EOleException do
   begin
   Result := '0';
   ADOConn.Close;
   end;
end;
end;

procedure SetStepNumber(StepNumber:integer);
var
 _step : string;
 SQLStr : string;
 _res : integer;
begin
  _step := IntToStr(StepNumber);
   SQLStr:= 'UPDATE AgentSetting SET StepNumber = "'+_step+
            '" WHERE ID = 1';
   _res := ExecuteQueryDll(SQLStr);
end;

procedure SaveAgentIdToDll(AgentId:string);
var
  SQLStr : string;
 _res : integer;
begin
  SQLStr:= 'UPDATE AgentDetails SET AgentID = "'+AgentId+
            '" WHERE ID = 1';
   _res := ExecuteQueryDll(SQLStr);

end;

function GetDataArrayFromDll(TableName:string;FieldName:string):TStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TStringArray;
  Row,i : Integer;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';

  if TableName = 'Software' then Row := GetRowCountWithoutCondition('Software')
  else Row := GetRowCount(TableName);

  if Row = 0 then
  begin
    Setlength(Res,1);
    Res[0] := 'No Exist';
    Result := Res;
    Exit;
  end;
  Setlength(Res,Row);
  SQLStr := 'SELECT '+FieldName+' FROM '+TableName;
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }



  i := 0;
  ADOQuery_FRTO.Open;
  ADOQuery_FRTO.First;
  Res[i] := Trim(ADOQuery_FRTO.FieldByName(FieldName).AsString);
  inc(i);
  while i < Row  do
  begin
     ADOQuery_FRTO.Next;
     Res[i] := Trim(ADOQuery_FRTO.FieldByName(FieldName).AsString);
     inc(i);
  end;


  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;

 end;

Function GetSoftwaresFromDll:TName;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : TName;
  Row,i : Integer;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Row := GetRowCountWithoutCondition('Software');
  Setlength(Res,Row);
  SQLStr := 'SELECT SoftwareName  FROM Software';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  i := 0;

  ADOQuery_FRTO.First;
  Res[i] := Trim(ADOQuery_FRTO.FieldByName('SoftwareName').AsString);
  inc(i);
  while i < Row do
  begin
     ADOQuery_FRTO.Next;
     Res[i] := Trim(ADOQuery_FRTO.FieldByName('SoftwareName').AsString);
     inc(i);
  end;

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;

end;

function GetActiveNetworkArrayFromDll(FieldName:string):GetActiveNetworkSetting.TNewStringArray;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : GetActiveNetworkSetting.TNewStringArray;
  Row,i : Integer;
 ConnString : string;
begin
ConnString := 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source='+GetCurrentDir+'\ITComplexSrv.dll;jet OLEDB:Database Password=shayaeel1351&359';
  Row := GetRowCount('ActiveNetworkSetting');
  Setlength(Res,Row);
  SQLStr := 'SELECT '+FieldName+' FROM ActiveNetworkSetting ';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }


  ADOConn.Connected := True;

  { Create the query }
  ADOQuery_FRTO := TADOQuery.Create(nil);
  ADOQuery_FRTO.Connection := ADOConn;
  ADOQuery_FRTO.SQL.Add(SQLStr);
  ADOQuery_FRTO.ParamCheck := false;

  ADOQuery_FRTO.Prepared := true; { Set the query to Prepared - will improve performance }

  ADOQuery_FRTO.Open;
  i := 0;

  ADOQuery_FRTO.First;
  Res[i] := Trim(ADOQuery_FRTO.FieldByName(FieldName).AsString);
  inc(i);
  while i < Row do
  begin
     ADOQuery_FRTO.Next;
     Res[i] := Trim(ADOQuery_FRTO.FieldByName(FieldName).AsString);
     inc(i);
  end;

  Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

procedure UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
var
  SQLStr : string;  { SQL Query }
  res : integer;
begin

  SQLStr:= 'UPDATE '+TableName+' SET '+FiledName+' = "'+Value+
           '" WHERE '+Condition;
  res := ExecuteQueryDll(SQLStr);

end;

end.

