unit LocalData;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes,Data.DB,Data.Win.ADODB,ActiveX,ComObj,
  IdHashMessageDigest,IdGlobal;


const
    { Connection string }
ConnString = 'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=EditAgent.dll;jet OLEDB:Database Password=shayaeel1351&359';


Type
TStringArray = array of string;
TName = array of string;

function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
function ExecuteQueryDll(QueryString:string): integer;
function GetMD5String(Str: String; ADestEncoding: TIdTextEncoding = nil): String;
function GetDataFromDll(TableName:string;FieldName:string;Condition:string):string;
function GetMessageFromDll(LangCode:string;ParentName:string;ControlName:string):string;
function CheckSQLConnectionString():string;
procedure UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);


implementation


function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : integer;

begin
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

function ExecuteQueryDll(QueryString:string): integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : Integer;

begin
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

