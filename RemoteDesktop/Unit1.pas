unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, IdBaseComponent, IdComponent, IdTCPConnection, IdTCPClient, ExtCtrls,
  jpeg, StdCtrls, IdGlobal,Data.DB,Data.Win.ADODB,Winsock;

type
  TForm1 = class(TForm)
    IdTCPClient1: TIdTCPClient;
    Timer1: TTimer;
    Panel1: TPanel;
    RadioGroup1: TRadioGroup;
    procedure Timer1Timer(Sender: TObject);
    procedure IdTCPClient1Disconnected(Sender: TObject);
    procedure IdTCPClient1Connected(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure RadioGroup1Click(Sender: TObject);
    procedure FormMouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure FormMouseMove(Sender: TObject; Shift: TShiftState; X, Y: Integer);
    procedure FormMouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure SetConnString;
    procedure GetRdData;
    procedure UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
    function GetMessageFromDll(LangCode:string;ControlName:string):string;
    function GetIPAddress():String;
    function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
    function ExecuteQueryDll(QueryString:string): integer;

  private
    { Private declarations }
  public
    { Public declarations }
  end;

type
  TMyRecord = record
    ButtonLorD: Char;
    ButtonAction: Char;
    ButtonX, ButtonY: Integer;
  end;

var
  Form1: TForm1;
  MyRecClient: TMyRecord;

  AgentIPAddress : string;
  MyIPAddress : string;
  AgentPortNumber : string;
  MyPortNumber : string;
  LangCode : string;
  AgentComputerName : string;
  RecordId : string;
  ConnS1 : string;
  ConnS2 : string;

  // Records holding mouse attributes
implementation

{$R *.dfm}



procedure TForm1.FormClose(Sender: TObject; var Action: TCloseAction);
begin
 if IdTCPClient1.Connected then
  begin
    IdTCPClient1.Disconnect;
    if IdTCPClient1.IOHandler <> nil then
      IdTCPClient1.IOHandler.InputBuffer.Clear;
  end;
  if (FileExists('EditAgent.ldb')) = true then deleteFile('EditAgent.ldb');
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Canvas.Font.Size := 10;
  Canvas.Brush.Style := bsClear;
  Canvas.Font.Color := clBlue;

  if (FileExists('EditAgent.dll')) = false then
begin
  ShowMessage('Dll file does not exist.');
  Application.Terminate;
  exit;
end;

SetConnString;
GetRdData;
if AgentComputerName = '' then
begin
  ShowMessage('This madule must be run from Control Admin Panel.');
  if (FileExists('EditAgent.ldb')) = true then deleteFile('EditAgent.ldb');
  Application.Terminate;
  exit;
end;
UpdateFieldToDll('RemoteDesktop','GetData','Yes',RecordId);
Form1.Caption :=  AgentComputerName ;
RadioGroup1.Caption := GetMessageFromDll(LangCode,'Scale');
MyIPAddress := GetIPAddress;

 try
  IdTCPClient1.Host := AgentIPAddress;
  IdTCPClient1.Port := StrToInt(AgentPortNumber);
  IdTCPClient1.Connect;
 except
  Showmessage('Agent is not avaleible now.Please try later.');
  Application.Terminate;

 end;
end;

procedure TForm1.SetConnString;
begin
ConnS1 := PChar(char(80)+ char(114)+ char(111)+ char(118)+ char(105)+ char(100)+ char(101)+ char(114)+ char(61)+ char(77)+ char(105)+ char(99)+ char(114)+ char(111)+ char(115)+ char(111)+ char(102)+ char(116)+ char(46)+ char(74)+ char(101)+ char(116)+ char(46)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(46)+ char(52)+ char(46)+ char(48)+ char(59)+ char(68)+ char(97)+ char(116)+ char(97)+ char(32)+ char(83)+ char(111)+ char(117)+ char(114)+ char(99)+ char(101)+ char(61));
ConnS2 := PChar(char(92)+ char(69)+ char(100)+ char(105)+ char(116)+ char(65)+ char(103)+ char(101)+ char(110)+ char(116)+ char(46)+ char(100)+ char(108)+ char(108)+ char(59)+ char(106)+ char(101)+ char(116)+ char(32)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(58)+ char(68)+ char(97)+ char(116)+ char(97)+ char(98)+ char(97)+ char(115)+ char(101)+ char(32)+ char(80)+ char(97)+ char(115)+ char(115)+ char(119)+ char(111)+ char(114)+ char(100)+ char(61)+ char(115)+ char(104)+ char(97)+ char(121)+ char(97)+ char(101)+ char(101)+ char(108)+ char(49)+ char(51)+ char(53)+ char(49)+ char(38)+ char(51)+ char(53)+ char(57));

end;

procedure TForm1.FormMouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  if not IdTCPClient1.Connected then
    Exit;
  IdTCPClient1.IOHandler.writeln('mouse');
  case Button of
    mbLeft:
      MyRecClient.ButtonLorD := 'L';
    mbRight:
      MyRecClient.ButtonLorD := 'R';
  end;
  MyRecClient.ButtonAction := 'D';
  MyRecClient.ButtonX := X;
  MyRecClient.ButtonY := Y;
  IdTCPClient1.IOHandler.Write(RawToBytes(MyRecClient, SizeOf(TMyRecord)));
end;

procedure TForm1.FormMouseMove(Sender: TObject; Shift: TShiftState;
  X, Y: Integer);
begin
  if not IdTCPClient1.Connected then
    Exit;
  IdTCPClient1.IOHandler.writeln('mousepos');
  MyRecClient.ButtonLorD := 'N';
  MyRecClient.ButtonAction := 'N';
  case RadioGroup1.ItemIndex of
    0:
      begin
        MyRecClient.ButtonX := X;
        MyRecClient.ButtonY := Y;
      end;
    1:
      begin
        MyRecClient.ButtonX := X * 2;
        MyRecClient.ButtonY := Y * 2;
      end;
    2:
      begin
        MyRecClient.ButtonX := X * 4;
        MyRecClient.ButtonY := Y * 4;
      end;
    3:
      begin
        MyRecClient.ButtonX := X * 8;
        MyRecClient.ButtonY := Y * 8;
      end;
  end;
  IdTCPClient1.IOHandler.Write(RawToBytes(MyRecClient, SizeOf(TMyRecord)));
end;

procedure TForm1.FormMouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
  if not IdTCPClient1.Connected then
    Exit;
  IdTCPClient1.IOHandler.writeln('mouse');
  case Button of
    mbLeft:
      MyRecClient.ButtonLorD := 'L';
    mbRight:
      MyRecClient.ButtonLorD := 'R';
  end;
  MyRecClient.ButtonAction := 'U';
  case RadioGroup1.ItemIndex of
    0:
      begin
        MyRecClient.ButtonX := X;
        MyRecClient.ButtonY := Y;
      end;
    1:
      begin
        MyRecClient.ButtonX := X * 2;
        MyRecClient.ButtonY := Y * 2;
      end;
    2:
      begin
        MyRecClient.ButtonX := X * 4;
        MyRecClient.ButtonY := Y * 4;
      end;
    3:
      begin
        MyRecClient.ButtonX := X * 8;
        MyRecClient.ButtonY := Y * 8;
      end;
  end;
  IdTCPClient1.IOHandler.Write(RawToBytes(MyRecClient, SizeOf(TMyRecord)));

end;

procedure TForm1.IdTCPClient1Connected(Sender: TObject);
begin
  Timer1.Enabled := true;
end;

procedure TForm1.IdTCPClient1Disconnected(Sender: TObject);
begin
  Timer1.Enabled := false;
end;

procedure TForm1.RadioGroup1Click(Sender: TObject);
begin
  Repaint;
end;

procedure TForm1.Timer1Timer(Sender: TObject);
var
  MyStream: TMemoryStream;
  MyImage: TJpegImage;
begin
  if IdTCPClient1.Connected then
  begin
    IdTCPClient1.IOHandler.writeln('jpg');
    MyStream := TMemoryStream.Create;
    MyImage := TJpegImage.Create;
    IdTCPClient1.IOHandler.LargeStream := true;
    IdTCPClient1.IOHandler.ReadStream(MyStream, -1, false);
    MyStream.Position := 0;
    MyImage.LoadFromStream(MyStream);
    // Scale the image
    case RadioGroup1.ItemIndex of
      0:
        MyImage.Scale := jsFullSize;
      1:
        begin
          MyImage.Scale := jsHalf;
          ClientHeight := MyImage.Height;
          ClientWidth := MyImage.Width + Panel1.ClientWidth;
        end;
      2:
        begin
          MyImage.Scale := jsQuarter;
          ClientHeight := MyImage.Height;
          ClientWidth := MyImage.Width + Panel1.ClientWidth;
        end;
      3:
        begin
          MyImage.Scale := jsEighth;
          ClientHeight := MyImage.Height;
          ClientWidth := MyImage.Width + Panel1.ClientWidth;
        end;
    end;
    // Draw remote desktop
    Canvas.Draw(0, 0, MyImage);
    // Free streams and image
    MyStream.Free;
    MyImage.Free;
  end
  else
  begin
     Timer1.Enabled := false;
     Application.Terminate;
     exit;
  end;

end;

procedure TForm1.GetRdData;
var
  query : string;
  ADOConn  : TADOConnection;
  ADOQuery : TADOQuery; { SQL Query }

  ConnString : string;
begin
query := 'SELECT * FROM RemoteDesktop WHERE GetData = "No"';
ConnString := ConnS1 + GetCurrentDir+ ConnS2;

  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  ADOConn.ConnectionString := ConnString;   { Setup the connection string }
  ADOConn.LoginPrompt := False;  { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    on e: EADOError do
    begin

     ADOQuery.Close;
     ADOConn.Close;
     Exit;
    end;
  end;

  ADOQuery := TADOQuery.Create(nil);  { Create the query }
  ADOQuery.Connection := ADOConn;
  ADOQuery.SQL.Add(query);
  ADOQuery.ParamCheck := false;
  ADOQuery.Prepared := true;  { Set the query to Prepared - will improve performance }

  try
    ADOQuery.Open;

  except
    on e: EADOError do
    begin

      ADOQuery.Close;
      ADOConn.Close;
      Exit;
    end;
  end;

  AgentIPAddress := ADOQuery.FieldByName('AgentIP').AsString;
  AgentPortNumber := ADOQuery.FieldByName('AgentPort').AsString;
  MyPortNumber := ADOQuery.FieldByName('MyPort').AsString;
  AgentComputerName := ADOQuery.FieldByName('AgentName').AsString;
  LangCode := ADOQuery.FieldByName('LangCode').AsString;
  RecordId := ADOQuery.FieldByName('Id').AsString;

  ADOQuery.Close;
  ADOConn.Close;
end;

procedure TForm1.UpdateFieldToDll(TableName:string;FiledName:string;Value:string;Condition:string);
var
  SQLStr : string;  { SQL Query }
  res : integer;
begin

  SQLStr:= 'UPDATE '+TableName+' SET '+FiledName+' = "'+Value+
           '" WHERE Id = '+Condition;
  res := ExecuteQueryDll(SQLStr);

end;

function TForm1.GetMessageFromDll(LangCode:string;ControlName:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM Messages'+
             ' WHERE LangCode = "'+LangCode+
             '" AND ChildObject = "'+ControlName+'"';
   Result := ExecuteQueryDllToString(SQLStr,'Message');
end;

function TForm1.GetIPAddress():String;
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

function TForm1.ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }

 ConnString : string;
begin
  ConnString := ConnS1 +GetCurrentDir+ConnS2;


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

      ADOQuery_FRTO.Close;
      ADOConn.Close;
      Exit;
    end;
  end;


  //Result := Res;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function TForm1.ExecuteQueryDll(QueryString:string): integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Res : Integer;

 ConnString : string;
begin
ConnString := ConnS1 + GetCurrentDir+ ConnS2;
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
      Result := Res;
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
      Result := Res;
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




end.
