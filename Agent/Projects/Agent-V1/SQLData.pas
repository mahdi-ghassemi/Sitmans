unit SQLData;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes,Data.DB,Data.Win.ADODB,ActiveX,ComObj,IdHashMessageDigest,
  IdGlobal;

type
  SQLAccess = class

    private
    _storedProcedureName : string;
    _sqlConnection : string;

     published
     constructor Create(SqlConnectionString:string);


     property StoredProcedureName : string read _storedProcedureName write _storedProcedureName;
     property SqlConnection : string read _sqlConnection write _sqlConnection;

     function FindAgentId(FingerPrint:string): Integer;
     function GetLastAgentId:Integer;
     function CheckUUID(UUID:string):Integer;
     function IntExcuteSP(SpParamsName:Array of string;SpParamsValue:Array of string):Integer;
  end;


implementation

constructor SQLAccess.Create(SqlConnectionString:string);
begin
   _sqlConnection := SqlConnectionString;
end;

function SQLAccess.FindAgentId(FingerPrint:string): Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;

begin
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

end;

function SQLAccess.GetLastAgentId:Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
begin
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

end;

function SQLAccess.CheckUUID(UUID:string):Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
begin
ADOConn := TADOConnection.Create(nil);
ADOConn.ConnectionString := _sqlConnection;
ADOConn.LoginPrompt := False;
ADOConn.Open();

ADOSP := TADOStoredProc.Create(nil);
ADOSP.Connection := ADOConn;
ADOSP.ProcedureName := 'prcGetUUID';
ADOSP.Parameters.Refresh;

ADOSP.Parameters.ParamByName('@UUID').Value := UUID;

ADOSP.ExecProc;

if ADOSP.Parameters.ParamValues['@Result'] = null then Result := 0
else Result := ADOSP.Parameters.ParamValues['@Result'];

end;



function SQLAccess.IntExcuteSP(SpParamsName:Array of string;SpParamsValue:Array of string):Integer;
var
ADOConn  : TADOConnection;
ADOSP : TADOStoredProc;
_length,_index : integer;
begin

_length := length(SpParamsName);
_index := 0;
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

end;


end.


