unit SQLData;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes,Data.DB,Data.Win.ADODB,ActiveX,ComObj,IdHashMessageDigest,
  IdGlobal,DBClient,Dialogs;
type
 TSettingValues = array of string;
type
  SQLAccess = class

    private
    _storedProcedureName : string;
    _sqlConnection : string;


     published
     constructor Create(SqlConnectionString:string);

     procedure DeleteAgentInfo(AgentId:string;SpName:string);

     property StoredProcedureName : string read _storedProcedureName write _storedProcedureName;
     property SqlConnection : string read _sqlConnection write _sqlConnection;
     function GetSettingExcuteSP(SpParamsName:Array of string;SpParamsValue:Array of string):TSettingValues;
     function FindAgentId(FingerPrint:string): Integer;
     function GetLastAgentId:Integer;
     function IntExcuteSP(SpParamsName:Array of string;SpParamsValue:Array of string):Integer;
     function IntExcuteSP2(SpParamsName:Array of string;SpParamsValue:Array of string):Integer;
  end;


implementation

constructor SQLAccess.Create(SqlConnectionString:string);
begin
   _sqlConnection := SqlConnectionString;
end;

procedure SQLAccess.DeleteAgentInfo(AgentId:string;SpName:string);
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
res : integer;

begin
try
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;
ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := SpName;
ADOSP.Parameters.Refresh;

ADOSP.Parameters.ParamByName('@AgentID').Value := AgentId;
ADOSP.ExecProc;

res := ADOSP.Parameters.ParamValues['@Result'];
except
  res := 0;
end;
end;


function SQLAccess.FindAgentId(FingerPrint:string): Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;

begin
try
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;
ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := 'prcFindAgentId';
ADOSP.Parameters.Refresh;

ADOSP.Parameters.ParamByName('@AgentFingerPrint').Value := FingerPrint;
ADOSP.ExecProc;


Result := ADOSP.Parameters.ParamValues['@Result'];
except
  Result := 0;
end;
end;

function SQLAccess.GetLastAgentId:Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
begin
try
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;
ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := 'prcGetLastAgentID';
ADOSP.Parameters.Refresh;

ADOSP.ExecProc;

Result := ADOSP.Parameters.ParamValues['@Result'];
except
  Result := 0;
end;
end;

function SQLAccess.GetSettingExcuteSP(SpParamsName:Array of string;SpParamsValue:Array of string):TSettingValues;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
dataSet : TADODataset;
_length,_index : integer;
res : TSettingValues;
begin
_length := length(SpParamsName);
SetLength(res,23);
_index := 0;
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;
try
ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := _storedProcedureName;
ADOSP.Parameters.Refresh;


while _index < _length do
begin
  ADOSP.Parameters.ParamByName(SpParamsName[_index]).Value := SpParamsValue[_index];
  inc(_index);
end;
_index := 0;

dataset := TADODataset.Create(nil);

ADOSP.Open;
dataset.Recordset := ADOSP.Recordset;
dataset.First;
res[0] := Trim(dataset.FieldByName('AgentPassword').AsString);
res[1] := Trim(ADOSP.FieldByName('SoftwareCtr').AsString);
res[2] := Trim(ADOSP.FieldByName('HardwareCtr').AsString);
res[3] := Trim(ADOSP.FieldByName('NetworkCtr').AsString);
res[4] := Trim(ADOSP.FieldByName('AccountCtr').AsString);
res[5] := Trim(ADOSP.FieldByName('ChatPort').AsString);
res[6] := Trim(ADOSP.FieldByName('ChatWithOther').AsString);
res[7] := Trim(ADOSP.FieldByName('FileTransferWithOther').AsString);
res[8] := Trim(ADOSP.FieldByName('VideoWithOther').AsString);
res[9] := Trim(ADOSP.FieldByName('ImageProcessing').AsString);
res[10] := Trim(ADOSP.FieldByName('RDPort').AsString);
res[11] := Trim(ADOSP.FieldByName('FTPort').AsString);
res[12] := Trim(ADOSP.FieldByName('CMDPort').AsString);
res[13] := Trim(ADOSP.FieldByName('VCPort').AsString);
res[14] := Trim(ADOSP.FieldByName('WebinarPort').AsString);
res[15] := Trim(ADOSP.FieldByName('PublicPort').AsString);
res[16] := Trim(ADOSP.FieldByName('UsbAccessControl').AsString);
res[17] := Trim(ADOSP.FieldByName('UsbDataControl').AsString);
res[18] := Trim(ADOSP.FieldByName('RegAccessControl').AsString);
res[19] := Trim(ADOSP.FieldByName('AppInstallDisable').AsString);
res[20] := Trim(ADOSP.FieldByName('AppDisableRun').AsString);
res[21] := Trim(ADOSP.FieldByName('DisableCtrlAltDel').AsString);
res[22] := Trim(ADOSP.FieldByName('UpdateCounter').AsString);
Result := res;
except
res[0] := 'SQL Exception';
Result := res;
exit;
end;

end;

function SQLAccess.IntExcuteSP(SpParamsName:Array of string;SpParamsValue:Array of string):Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
_length,_index : integer;
begin

_length := length(SpParamsName);
_index := 0;
try
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;

ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := _storedProcedureName;
ADOSP.Parameters.Refresh;


while _index < _length do
begin
  ADOSP.Parameters.ParamByName(SpParamsName[_index]).Value := SpParamsValue[_index];
  inc(_index);
end;

ADOSP.ExecProc;
Result := ADOSP.Parameters.ParamValues['@Result'];

except
on E:Exception do
   begin
    //ShowMessage('Pishgam2 Exception class name = '+E.ClassName + ' Exception message = '+E.Message);
    Result := 0;
   end;
end;
end;

function SQLAccess.IntExcuteSP2(SpParamsName:Array of string;SpParamsValue:Array of string):Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
_length,_index : integer;
begin

_length := length(SpParamsName);
_index := 0;
try
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;

ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := _storedProcedureName;
ADOSP.Parameters.Refresh;


while _index < _length do
begin
  ADOSP.Parameters.ParamByName(SpParamsName[_index]).Value := SpParamsValue[_index];
  inc(_index);
end;

ADOSP.ExecProc;
Result := ADOSP.Parameters.ParamValues['@Result'];

except
on E:Exception do
   begin
    //ShowMessage('Pishgam2 Exception class name = '+E.ClassName + ' Exception message = '+E.Message);
    Result := 0;
   end;
end;
end;



end.


