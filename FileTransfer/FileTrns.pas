unit FileTrns;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls,
  Vcl.ComCtrls, Vcl.DBCtrls, Data.FMTBcd, Data.DB,ShellApi,
  Data.SqlExpr,Vcl.DBLookup,Data.Win.ADODB, IdSocketHandle, IdBaseComponent,
  IdComponent, IdUDPBase, IdContext,IdTCPClient, IdTCPServer,Winsock,
  IdTCPConnection, IdCustomTCPServer, Vcl.ImgList,Unit1;

type
  TfrmFileTrans = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    ComboBox1: TComboBox;
    ComboBox2: TComboBox;
    btnExecute: TButton;
    btnSendR2L: TButton;
    btnSendL2R: TButton;
    btnDelete: TButton;
    btnRename: TButton;
    btnNewF: TButton;
    btnZip: TButton;
    btnUnzip: TButton;
    btnExecute2: TButton;
    btnDelete2: TButton;
    btnRename2: TButton;
    btnNewF2: TButton;
    btnZip2: TButton;
    btnUnzip2: TButton;
    lblComputerName2: TLabel;
    IdTCPServer1: TIdTCPServer;
    IdTCPClient1: TIdTCPClient;
    TreeView2: TTreeView;
    ImageList1: TImageList;
    TreeView1: TTreeView;
    lblComputerName1: TLabel;
    ImageList2: TImageList;
    lblImageIndex1: TLabel;
    lablepath1: TLabel;
    lablepath2: TLabel;
    lableIP1: TLabel;
    lableIP2: TLabel;
    lblImageIndex2: TLabel;
    lblPath1: TEdit;
    lblComputerIP1: TEdit;
    lblPath2: TEdit;
    lblComputerIP2: TEdit;
    procedure ComboBox1Select(Sender: TObject);
    procedure TreeView1Change(Sender: TObject; Node: TTreeNode);
    procedure btnSendL2RClick(Sender: TObject);
    procedure btnExecuteClick(Sender: TObject);
    procedure btnDeleteClick(Sender: TObject);
    procedure btnRenameClick(Sender: TObject);
    procedure btnNewFClick(Sender: TObject);
    procedure btnExecute2Click(Sender: TObject);
    procedure btnDelete2Click(Sender: TObject);
    procedure btnRename2Click(Sender: TObject);
    procedure btnNewF2Click(Sender: TObject);
    procedure btnSendR2LClick(Sender: TObject);

    type
 TStringArray = array of string;

    procedure FormCreate(Sender: TObject);
    procedure GetAgentList;
    procedure GetSqlConnectionFromDll;
    procedure SetConnString;
    procedure FillAgentList;
    procedure StartTCPServer;
    procedure GetDriveList(ComName: string;ComIP: string;ListNumber:string);
    procedure SendCommand(stxt:string;ComName:string;ComIP:string);
    procedure ComboBox2Select(Sender: TObject);
    procedure IdTCPServer1Execute(AContext: TIdContext);
    procedure SetDriveList(RcvTx:string);
    procedure GetDriveContents(TreeviewNumber:string);
    procedure SetDirectoryList(Data : string);
    procedure TreeView2Change(Sender: TObject; Node: TTreeNode);
    procedure GetLocalDriveList(TreeviewNumber:string);
    procedure LocalListFileDir(TreeviewNumber:string;Path:string);
    procedure FillExtList;
    procedure DisableTree1But;
    procedure DisableTree2But;
    procedure EnableButtom(TreeviewNumber:string);

    function GetRowCount:integer;
    function GetDataFromDll(TableName:string;FieldName:string):string;
    function ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
    function GetMessageFromDll(LangCode:string;ControlName:string):string;
    function  GetIPV4(ip : string):string;
    function GetIPAddress():String;
    function MemoryStreamToString(M: TMemoryStream): string;
    function setimage(treenode:string):integer;
    function GetDriveLetters():TStringArray;
    function DiskInDrive(Drive: Char): Boolean;



  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmFileTrans: TfrmFileTrans;
  SqlConS : string;
  AgentName1 : array of string;
  AgentIP1 : array of string;
  AgentName2 : array of string;
  AgentIP2 : array of string;
  ConnS1,ConnS2 : string;
  LangCode : string;
  MyIPAddress : string;
  MyPort : string;
  AgentPort : string;
  SelectedTreeNode : Ttreenode;
  Path1,Path2 : string;
  ExtList : TStringList;

implementation

{$R *.dfm}

procedure TfrmFileTrans.FormCreate(Sender: TObject);
begin
if (FileExists('EditAgent.dll')) = false then
begin
  ShowMessage('Dll file does not exist.');
  Application.Terminate;
  exit;
end;
SetConnString;
GetSqlConnectionFromDll;
if SqlConS = '' then
begin
  ShowMessage('This madule must be run from Control Admin Panel.');
  Application.Terminate;
  exit;
end;
LangCode := GetDataFromDll('FileTransfer','LangCode');
MyPort := GetDataFromDll('FileTransfer','ServerPort');
AgentPort := GetDataFromDll('FileTransfer','AgentPort');

GetAgentList;
FillAgentList;
FillExtList;
StartTCPServer;

lblImageIndex1.Caption := '0';
lblImageIndex2.Caption := '0';

btnExecute.Caption := GetMessageFromDll(LangCode,'Execute');
btnDelete.Caption := GetMessageFromDll(LangCode,'Delete');
btnNewF.Caption :=  GetMessageFromDll(LangCode,'NewFolder');
btnRename.Caption := GetMessageFromDll(LangCode,'Rename');
btnZip.Caption := GetMessageFromDll(LangCode,'Zip');
btnUnzip.Caption := GetMessageFromDll(LangCode,'Unzip');
btnSendR2L.Caption := GetMessageFromDll(LangCode,'Send');

lablepath1.Caption := GetMessageFromDll(LangCode,'CurrentPath');
lablepath2.Caption := lablepath1.Caption;

lableIP1.Caption := GetMessageFromDll(LangCode,'IPAddress');
lableIP2.Caption := lableIP1.Caption;


btnUnzip2.Caption := btnUnzip.Caption;
btnExecute2.Caption := btnExecute.Caption;
btnDelete2.Caption := btnDelete.Caption;
btnNewF2.Caption := btnNewF.Caption;
btnRename2.Caption := btnRename.Caption;
btnZip2.Caption := btnZip.Caption;
btnUnzip2.Caption := btnUnzip.Caption;
btnSendL2R.Caption := btnSendR2L.Caption;

end;

procedure TfrmFileTrans.DisableTree2But;
begin
 btnExecute2.Enabled := false;
 btnDelete2.Enabled := false;
 btnRename2.Enabled := false;
 btnNewF2.Enabled := false;
 btnZip2.Enabled := false;
 btnUnzip2.Enabled := false;
end;

procedure TfrmFileTrans.DisableTree1But;
begin
 btnExecute.Enabled := false;
 btnDelete.Enabled := false;
 btnRename.Enabled := false;
 btnNewF.Enabled := false;
 btnZip.Enabled := false;
 btnUnzip.Enabled := false;
end;

procedure TfrmFileTrans.StartTCPServer;
begin
MyIPAddress := GetIPAddress;
IdTCPServer1.Bindings.Add.IP := MyIPAddress;
IdTCPServer1.Bindings.Add.Port := StrToInt(MyPort);
IdTCPServer1.Active := true;
end;

procedure TfrmFileTrans.TreeView1Change(Sender: TObject; Node: TTreeNode);
var
i,index,loopindex : integer;
TreeString : array of string;
CurrentItem: TTreeNode;
begin
if Assigned(Node) then
begin
DisableTree2But;
i := Node.AbsoluteIndex;
Node.SelectedIndex := Node.ImageIndex;
SelectedTreeNode := TreeView1.Items[i];
Path1 := SelectedTreeNode.Text;
lblImageIndex1.Caption := IntToStr(SelectedTreeNode.ImageIndex);
if (SelectedTreeNode.Level = 0) AND (SelectedTreeNode.Count = 0) then
begin
  if SelectedTreeNode.ImageIndex = 0 then   //Drive
  begin
     btnExecute.Enabled := false;
     btnSendL2R.Enabled := false;
     btnDelete.Enabled := false;
     btnRename.Enabled := false;
     btnZip.Enabled := true;
     btnNewF.Enabled := true;
     btnUnZip.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 1 then  //Folder
  begin
     btnExecute.Enabled := false;
     btnSendL2R.Enabled := false;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := true;
     btnNewF.Enabled := true;
     btnUnZip.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 11 then   // Zip or rar file
  begin
     btnExecute.Enabled := false;
    // btnSendL2R.Enabled := true;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := false;
     btnNewF.Enabled := false;
     btnUnZip.Enabled := true;
  end else                               // other file
  begin
     btnExecute.Enabled := true;
     //btnSendL2R.Enabled := true;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := true;
     btnNewF.Enabled := false;
     btnUnZip.Enabled := false;
  end;

  if TreeView2.Items.Count = 0 then btnSendL2R.Enabled := false;
  if (SelectedTreeNode.ImageIndex > 1) AND (StrToInt(lblImageIndex2.Caption) < 2) AND (TreeView2.Items.Count <> 0) then btnSendL2R.Enabled := true;


  if lblComputerName1.Caption <> 'Local Computer' then GetDriveContents('1');
  if lblComputerName1.Caption = 'Local Computer' then LocalListFileDir('1',Path1);

end;
if (SelectedTreeNode.Level <> 0) AND (SelectedTreeNode.Count = 0) then
begin
   Path1 := '';

  if SelectedTreeNode.ImageIndex = 0 then   //Drive
  begin
     btnExecute.Enabled := false;
     btnSendL2R.Enabled := false;
     btnDelete.Enabled := false;
     btnRename.Enabled := false;
     btnZip.Enabled := true;
     btnNewF.Enabled := true;
     btnUnZip.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 1 then  //Folder
  begin
     btnExecute.Enabled := false;
     btnSendL2R.Enabled := false;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := true;
     btnNewF.Enabled := true;
     btnUnZip.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 11 then   // Zip or rar file
  begin
     btnExecute.Enabled := false;
   //  btnSendL2R.Enabled := true;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := false;
     btnNewF.Enabled := false;
     btnUnZip.Enabled := true;
  end else                               // other file
  begin
     btnExecute.Enabled := true;
   //  btnSendL2R.Enabled := true;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := true;
     btnNewF.Enabled := false;
     btnUnZip.Enabled := false;
  end;

  if TreeView2.Items.Count = 0 then btnSendL2R.Enabled := false;
  if (SelectedTreeNode.ImageIndex > 1) AND (StrToInt(lblImageIndex2.Caption) < 2) AND (TreeView2.Items.Count <> 0) then btnSendL2R.Enabled := true;





   SetLength(TreeString,SelectedTreeNode.Level+1);
   index := 0;
   CurrentItem := TreeView1.Selected;
    while index < SelectedTreeNode.Level + 1 do
    Begin
      TreeString[index] := CurrentItem.Text;
      CurrentItem := CurrentItem.Parent;
      inc(index);
    End;
    loopindex := 0;
    index := length(TreeString);
    while index > 0 do
    Begin
      if loopindex = 0 then
      begin
        Path1 := TreeString[index-1];
      end;
      if loopindex = 1 then
      begin
        Path1 := Path1 + TreeString[index-1];
      end;
      if loopindex > 1 then
      begin
        Path1 :=  Path1 + '\' + TreeString[index-1] ;
      end;
      inc(loopindex);
      index := index - 1;
    End;
   lblPath1.Text := Path1;


   if lblComputerName1.Caption <> 'Local Computer' then GetDriveContents('1');
   if lblComputerName1.Caption = 'Local Computer' then LocalListFileDir('1',Path1);

  end;
 end;
    lblPath1.Text := Path1;
    if SelectedTreeNode.ImageIndex = 0 then   //Drive
  begin
     btnExecute.Enabled := false;
     btnSendL2R.Enabled := false;
     btnDelete.Enabled := false;
     btnRename.Enabled := false;
     btnZip.Enabled := true;
     btnNewF.Enabled := true;
     btnUnZip.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 1 then  //Folder
  begin
     btnExecute.Enabled := false;
     btnSendL2R.Enabled := false;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := true;
     btnNewF.Enabled := true;
     btnUnZip.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 11 then   // Zip or rar file
  begin
     btnExecute.Enabled := false;
     //btnSendL2R.Enabled := true;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := false;
     btnNewF.Enabled := false;
     btnUnZip.Enabled := true;
  end else                               // other file
  begin
     btnExecute.Enabled := true;
    // btnSendL2R.Enabled := true;
     btnDelete.Enabled := true;
     btnRename.Enabled := true;
     btnZip.Enabled := true;
     btnNewF.Enabled := false;
     btnUnZip.Enabled := false;
  end;

  if TreeView2.Items.Count = 0 then btnSendL2R.Enabled := false;
  if (SelectedTreeNode.ImageIndex > 1) AND (StrToInt(lblImageIndex2.Caption)< 2) AND (TreeView2.Items.Count <> 0) then btnSendL2R.Enabled := true;




end;


procedure TfrmFileTrans.EnableButtom(TreeviewNumber:string);
begin
if TreeviewNumber = '2' then
begin
 btnSendR2L.Enabled := true;
 btnExecute2.Enabled := true;
 btnDelete2.Enabled := true;
 btnRename2.Enabled := true;

end;
if TreeviewNumber = '1' then
begin
 btnExecute.Enabled := true;
 btnSendL2R.Enabled := true;
 btnDelete.Enabled := true;
 btnRename.Enabled := true;

 end;

end;

procedure TfrmFileTrans.TreeView2Change(Sender: TObject; Node: TTreeNode);
var
i,index,loopindex : integer;
TreeString : array of string;
CurrentItem: TTreeNode;
begin
if Assigned(Node) then
begin
i := Node.AbsoluteIndex;
Node.SelectedIndex := Node.ImageIndex;
SelectedTreeNode := TreeView2.Items[i];
Path2 := SelectedTreeNode.Text;
lblImageIndex2.Caption := IntToStr(SelectedTreeNode.ImageIndex);
if (SelectedTreeNode.Level = 0) AND (SelectedTreeNode.Count = 0) then
begin
  if SelectedTreeNode.ImageIndex = 0 then   //Drive
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := false;
     btnDelete2.Enabled := false;
     btnRename2.Enabled := false;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := true;
     btnUnZip2.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 1 then  //Folder
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := false;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := true;
     btnUnZip2.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 11 then   // Zip or rar file
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := true;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := false;
     btnNewF2.Enabled := false;
     btnUnZip2.Enabled := true;
  end else                               // other file
  begin
     btnExecute2.Enabled := true;
     btnSendR2L.Enabled := true;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := false;
     btnUnZip2.Enabled := false;
  end;


  if lblComputerName2.Caption <> 'Local Computer' then GetDriveContents('2');
  if lblComputerName2.Caption = 'Local Computer' then LocalListFileDir('2',Path2);

end;
if (SelectedTreeNode.Level <> 0) AND (SelectedTreeNode.Count = 0) then
begin
   Path2 := '';
   SetLength(TreeString,SelectedTreeNode.Level+1);

    if SelectedTreeNode.ImageIndex = 0 then   //Drive
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := false;
     btnDelete2.Enabled := false;
     btnRename2.Enabled := false;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := true;
     btnUnZip2.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 1 then  //Folder
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := false;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := true;
     btnUnZip2.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 11 then   // Zip or rar file
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := true;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := false;
     btnNewF2.Enabled := false;
     btnUnZip2.Enabled := true;
  end else                               // other file
  begin
     btnExecute2.Enabled := true;
     btnSendR2L.Enabled := true;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := false;
     btnUnZip2.Enabled := false;
  end;


   index := 0;
   CurrentItem := TreeView2.Selected;
    while index < SelectedTreeNode.Level + 1 do
    Begin
      TreeString[index] := CurrentItem.Text;
      CurrentItem := CurrentItem.Parent;
      inc(index);
    End;
    loopindex := 0;
    index := length(TreeString);
    while index > 0 do
    Begin
      if loopindex = 0 then
      begin
        Path2 := TreeString[index-1];
      end;
      if loopindex = 1 then
      begin
        Path2 := Path2 + TreeString[index-1];
      end;
      if loopindex > 1 then
      begin
        Path2 :=  Path2 + '\' + TreeString[index-1] ;
      end;
      inc(loopindex);
      index := index - 1;
    End;
   lblPath2.Text := Path2;


   if lblComputerName2.Caption <> 'Local Computer' then GetDriveContents('2');
   if lblComputerName2.Caption = 'Local Computer' then LocalListFileDir('2',Path2);

  end;
 end;
   lblPath2.Text := Path2;
  if SelectedTreeNode.ImageIndex = 0 then   //Drive
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := false;
     btnDelete2.Enabled := false;
     btnRename2.Enabled := false;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := true;
     btnUnZip2.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 1 then  //Folder
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := false;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := true;
     btnUnZip2.Enabled := false;
  end else if SelectedTreeNode.ImageIndex = 11 then   // Zip or rar file
  begin
     btnExecute2.Enabled := false;
     btnSendR2L.Enabled := true;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := false;
     btnNewF2.Enabled := false;
     btnUnZip2.Enabled := true;
  end else                               // other file
  begin
     btnExecute2.Enabled := true;
     btnSendR2L.Enabled := true;
     btnDelete2.Enabled := true;
     btnRename2.Enabled := true;
     btnZip2.Enabled := true;
     btnNewF2.Enabled := false;
     btnUnZip2.Enabled := false;
  end;

end;

procedure TfrmFileTrans.GetDriveContents(TreeviewNumber:string);
var
sendData , senderip : string;

begin
if TreeviewNumber = '1' then
begin
senderip := lblComputerIP1.Text;
sendData := 'GETDI'+ '[' + Path1 + '][' +  IntToStr(SelectedTreeNode.Level) + '][' + IntToStr(SelectedTreeNode.Index) + ']['+ MyPort + '][' + MyIPAddress + '][' + TreeviewNumber + ']';
SendCommand(sendData,lblComputerName2.Caption,senderip);

end;
if TreeviewNumber = '2' then
begin
senderip := lblComputerIP2.Text;
sendData := 'GETDI'+ '[' + Path2 + '][' +  IntToStr(SelectedTreeNode.Level) + '][' + IntToStr(SelectedTreeNode.Index) + ']['+ MyPort + '][' + MyIPAddress + '][' + TreeviewNumber + ']';
SendCommand(sendData,lblComputerName2.Caption,senderip);
end;

end;

Function TfrmFileTrans.GetIPAddress():String;
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

function TfrmFileTrans.GetMessageFromDll(LangCode:string;ControlName:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT * FROM Messages'+
             ' WHERE LangCode = "'+LangCode+
             '" AND ChildObject = "'+ControlName+'"';
   Result := ExecuteQueryDllToString(SQLStr,'Message');
end;

procedure TfrmFileTrans.FillAgentList;
var
len,i :integer;
begin
SetLength(AgentName2,length(AgentName1));
SetLength(AgentIP2,length(AgentIP1));
len := length(AgentName1);
i := 0;
while i < len do
begin
  AgentName2[i] := AgentName1[i];
  AgentIP2[i] := AgentIP1[i];
  ComboBox1.Items.Add(AgentName1[i]);
  ComboBox2.Items.Add(AgentName2[i]);
  inc(i);
end;
ComboBox1.ItemIndex := 0;
ComboBox2.ItemIndex := 0;

end;

procedure TfrmFileTrans.GetAgentList;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  Row,i : Integer;
  ConnString : string;
begin
  ConnString := SqlConS;

  Row := GetRowCount;

  if Row = 0 then
  begin
    Setlength(AgentName1,1);
    Setlength(AgentIP1,1);
    AgentName1[0] := 'Local Computer';
    AgentIP1[0] := GetIPAddress;
    Exit;
  end;
  Setlength(AgentName1,Row);
  Setlength(AgentIP1,Row);
  SQLStr := 'SELECT * FROM Agent.vwAgentListForNetwork';
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
 // AgentName1[0] := 'Local Computer';
 // AgentIP1[0] := GetIPAddress;
  ADOQuery_FRTO.Open;
  ADOQuery_FRTO.First;
  AgentName1[i] := Trim(ADOQuery_FRTO.FieldByName('ComputerName').AsString);
  AgentIP1[i] := Trim(ADOQuery_FRTO.FieldByName('IPAddress').AsString);
  inc(i);
  while i < Row  do
  begin
     ADOQuery_FRTO.Next;
     AgentName1[i] := Trim(ADOQuery_FRTO.FieldByName('ComputerName').AsString);
     AgentIP1[i] := Trim(ADOQuery_FRTO.FieldByName('IPAddress').AsString);
     inc(i);
  end;
  ADOQuery_FRTO.Close;
  ADOConn.Close;
end;

function TfrmFileTrans.GetRowCount:integer;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }
  ConnString : string;
begin
ConnString := SqlConS;
SQLStr := 'SELECT COUNT(*) AS Fcount  FROM Agent.vwAgentListForNetwork';
  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

try

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
except
  showmessage('SQL Connection Failed');
  Application.Terminate;
  Result := 0;
  exit;
end;
end;

procedure TfrmFileTrans.GetSqlConnectionFromDll;
begin
SqlConS := GetDataFromDll('FileTransfer','SqlConString');
end;

procedure TfrmFileTrans.IdTCPServer1Execute(AContext: TIdContext);
var
  RcvTxt,Command: string;
  RcvBuff: TMemoryStream;
begin
  RcvBuff:= TMemoryStream.Create;

  AContext.Connection.IOHandler.ReadStream(RcvBuff, -1, False);
  RcvBuff.Position := 0;

  RcvTxt := MemoryStreamToString(RcvBuff);
  RcvBuff.Free;

  Command := Copy(RcvTxt, 1, 5);

   if (Command = 'SETDR') then begin
      SetDriveList(RcvTxt);
   end;

   if (Command = 'DIRDI') then begin
      SetDirectoryList(RcvTxt);
   end;

end;

procedure TfrmFileTrans.SetDirectoryList(Data : string);
var
eIndex,cIndex : integer;
treeviewNumber,nodeLevel,nodeIndex,childName,childType : string;
tn: TtreeNode;
begin


eIndex := Pos(']',Data);
nodeLevel := Copy(Data,11,eIndex - 11);
Delete(Data,1,eIndex);


eIndex := Pos(']',Data);
nodeIndex := Copy(Data,2,eIndex - 2);
Delete(Data,1,eIndex);


eIndex := Pos(']',Data);
treeviewNumber := Copy(Data,2,eIndex - 2);
Delete(Data,1,eIndex);


eIndex := Pos(']',Data);

while eIndex <> 0 do
begin
  cIndex := Pos(';',Data);
  eIndex := Pos(']',Data);
  childtype := Copy(Data,2,cIndex - 2);
  childName := Copy(Data,cIndex + 1,eIndex - cIndex - 1);
  Delete(Data,1,eIndex);
  if treeviewNumber = '2' then
  begin
    tn := TreeView2.Items.AddChild(SelectedTreeNode,childName);
    if (childtype = '32') OR (childtype = '38') OR (childtype = '8230') then
    begin
      tn.ImageIndex := setimage(childName);
      //tn.ImageIndex := 2; //file image
    end else
    begin
      tn.ImageIndex := 1;  // folder image
    end;

  end;
  if treeviewNumber = '1' then
  begin
    tn := TreeView1.Items.AddChild(SelectedTreeNode,childName);
    if (childtype = '32') OR (childtype = '38') OR (childtype = '8230') then
    begin
      tn.ImageIndex := setimage(childName);
      //tn.ImageIndex := 2; //file image
    end else
    begin
      tn.ImageIndex := 1;  // folder image
    end;

  end;

  eIndex := Pos(']',Data);
end;
if treeviewNumber = '2' then TreeView2.Items.EndUpdate;
if treeviewNumber = '1' then TreeView1.Items.EndUpdate;
end;

procedure TfrmFileTrans.FillExtList;
begin
ExtList := TStringList.Create;
ExtList.Add('doc');
ExtList.Add('docx');
ExtList.Add('bat');
ExtList.Add('dll');
ExtList.Add('ini');
ExtList.Add('txt');
ExtList.Add('log');
ExtList.Add('jpg');
ExtList.Add('jpeg');
ExtList.Add('sys');
ExtList.Add('com');
ExtList.Add('exe');
ExtList.Add('pdf');
ExtList.Add('rar');
ExtList.Add('zip');
ExtList.Add('key');
ExtList.Add('mdf');
ExtList.Add('mds');
ExtList.Add('xls');
ExtList.Add('xlsx');
end;

function TfrmFileTrans.setimage(treenode:string):integer;
var
fileName,fileExtention : string;
iindex,res,ext : integer;
begin
fileName := treenode;
iindex := Pos('.',fileName);
while iindex <> 0 do
begin
  Delete(fileName,1,iindex);
  iindex := Pos('.',fileName);
end;

//fileExtention := Copy(fileName,iindex + 1,length(fileName) - iindex);
ext := ExtList.IndexOf(lowercase(fileName));
case ext of
  0: res := 2;
  1: res := 2;
  2: res := 3;
  3: res := 4;
  4: res := 5;
  5: res := 6;
  6: res := 6;
  7: res := 7;
  8: res := 7;
  9: res := 8;
  10: res := 9;
  11: res := 9;
  12: res := 10;
  13: res := 11;
  14: res := 11;
  15: res := 12;
  16: res := 13;
  17: res := 14;
  18: res := 15;
  19: res := 15;
  else res := 8;
end;
Result := res;
end;



procedure TfrmFileTrans.SetDriveList(RcvTx:string);
var
index,sIndex,eIndex : integer;
ComName,listnumber,DriveName : string;
tn : TtreeNode;
begin
index := Pos(']',RcvTx);
ComName := Copy(RcvTx,7,index-7);
Delete(RcvTx,1,length(ComName)+7);
listnumber := Copy(RcvTx,2,1);
Delete(RcvTx,1,3);
if listnumber = '2' then
begin
  TreeView2.Items.BeginUpdate;
  TreeView2.Items.Clear;
end;
if listnumber = '1' then
begin
  TreeView1.Items.BeginUpdate;
  TreeView1.Items.Clear;
end;

sIndex := Pos('[',RcvTx);
while sIndex <> 0 do
begin
   eIndex := Pos(']',RcvTx);
   DriveName := Copy(RcvTx,2,eIndex-2);
   Delete(RcvTx,1,length(DriveName)+ 2);
   if Listnumber = '2' then
   begin
     tn := TreeView2.Items.Add(nil,DriveName);
     tn.ImageIndex := 0;
   end;
   if Listnumber = '1' then
   begin
     tn := TreeView1.Items.Add(nil,DriveName);
     tn.ImageIndex := 0;
   end;
   sIndex := Pos('[',RcvTx);
end;
if listnumber = '2' then TreeView2.Items.EndUpdate;
if listnumber = '1' then TreeView1.Items.EndUpdate;
end;


function TfrmFileTrans.MemoryStreamToString(M: TMemoryStream): string;
begin
  SetString(Result, PChar(M.Memory), M.Size div SizeOf(Char));
end;

function TfrmFileTrans.GetDataFromDll(TableName:string;FieldName:string):string;
var
   SQLStr : string;
begin
   SQLStr := 'SELECT TOP 1 *  FROM '+TableName;

   Result := ExecuteQueryDllToString(SQLStr,FieldName);
end;

procedure TfrmFileTrans.btnDelete2Click(Sender: TObject);
var
DestinIP,DestiniPath : string;
SelectType : integer;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin
DestinIP := lblComputerIP2.Text;
DestiniPath := lblPath2.Text;
SelectType := StrToInt(lblImageIndex2.Caption);

if (lblComputerName2.Caption = 'Local Computer') then
begin

    if SelectType > 1 then DeleteFile(DestiniPath);
    if SelectType = 1 then RmDir(DestiniPath);
    TreeView1.Items.Clear;
    GetLocalDriveList('1');
end else
begin
    IdTCPClient1.Host := DestinIP;
    IdTCPClient1.Port := StrToInt(AgentPort);
    IdTCPClient1.Connect;

    SndText := 'DELET['+ DestiniPath + '][' + lblImageIndex2.Caption + ']' ;
    StrLen := Length(SndText);
    SndBuff := TMemoryStream.Create;
    SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
    SndBuff.Position := 0;
    IdTCPClient1.IOHandler.Write(SndBuff,0,true);
    IdTCPClient1.Disconnect;
end;


end;

procedure TfrmFileTrans.btnDeleteClick(Sender: TObject);
var
DestinIP,DestiniPath : string;
SelectType : integer;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin
DestinIP := lblComputerIP1.Text;
DestiniPath := lblPath1.Text;
SelectType := StrToInt(lblImageIndex1.Caption);

if (lblComputerName1.Caption = 'Local Computer') then
begin

    if SelectType > 1 then DeleteFile(DestiniPath);
    if SelectType = 1 then RmDir(DestiniPath);
    TreeView1.Items.Clear;
    GetLocalDriveList('1');
end else
begin
    IdTCPClient1.Host := DestinIP;
    IdTCPClient1.Port := StrToInt(AgentPort);
    IdTCPClient1.Connect;

    SndText := 'DELET['+ DestiniPath + '][' + lblImageIndex1.Caption + ']' ;
    StrLen := Length(SndText);
    SndBuff := TMemoryStream.Create;
    SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
    SndBuff.Position := 0;
    IdTCPClient1.IOHandler.Write(SndBuff,0,true);
    IdTCPClient1.Disconnect;
end;


end;

procedure TfrmFileTrans.btnExecute2Click(Sender: TObject);
var
DestinIP,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin
DestinIP := lblComputerIP2.Text;
DestiniPath := lblPath2.Text;


if (lblComputerName2.Caption = 'Local Computer') then
begin
    ShellExecute(Handle, 'open', PWideChar(DestiniPath) , nil, nil, SW_SHOWNORMAL);
end else
begin
    IdTCPClient1.Host := DestinIP;
    IdTCPClient1.Port := StrToInt(AgentPort);
    IdTCPClient1.Connect;

    SndText := 'EXECU['+ DestiniPath + ']';
    StrLen := Length(SndText);
    SndBuff := TMemoryStream.Create;
    SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
    SndBuff.Position := 0;
    IdTCPClient1.IOHandler.Write(SndBuff,0,true);
    IdTCPClient1.Disconnect;
end;

end;

procedure TfrmFileTrans.btnExecuteClick(Sender: TObject);
var
DestinIP,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin
DestinIP := lblComputerIP1.Text;
DestiniPath := lblPath1.Text;


if (lblComputerName1.Caption = 'Local Computer') then
begin
    ShellExecute(Handle, 'open', PWideChar(DestiniPath) , nil, nil, SW_SHOWNORMAL);
end else
begin
    IdTCPClient1.Host := DestinIP;
    IdTCPClient1.Port := StrToInt(AgentPort);
    IdTCPClient1.Connect;

    SndText := 'EXECU['+ DestiniPath + ']';
    StrLen := Length(SndText);
    SndBuff := TMemoryStream.Create;
    SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
    SndBuff.Position := 0;
    IdTCPClient1.IOHandler.Write(SndBuff,0,true);
    IdTCPClient1.Disconnect;
end;
end;

procedure TfrmFileTrans.btnNewF2Click(Sender: TObject);
var
DestinIP,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
frmNewName : TForm1;
FormTitle:string;Title:string;Ok:string;Cancel:string;
NewName,NewPath : string;
Respond : string;

begin
DestinIP := lblComputerIP2.Text;
DestiniPath := lblPath2.Text;
FormTitle :=  GetMessageFromDll(LangCode,'MakeNewFolder');
Title :=  GetMessageFromDll(LangCode,'NewFolderName');
Ok :=  GetMessageFromDll(LangCode,'btnOk');
Cancel :=  GetMessageFromDll(LangCode,'btnExit');


frmNewName := TForm1.Create(FormTitle,Title,Ok,Cancel);
frmNewName.ShowModal;
if frmNewName.ModalResult = mrOk then NewName := frmNewName.txbNewName.Text;
if frmNewName.ModalResult = mrCancel then NewName := '';
if NewName = '' then exit;
if SelectedTreeNode.Level = 0 then NewPath := DestiniPath + NewName;
if SelectedTreeNode.Level > 0 then NewPath := DestiniPath + '\' + NewName;
if (lblComputerName1.Caption = 'Local Computer') then
begin
    MkDir(NewPath);
    TreeView1.Items.Clear;
    GetLocalDriveList('1');
end else
begin

     IdTCPClient1.Host := DestinIP;
     IdTCPClient1.Port := StrToInt(AgentPort);
     IdTCPClient1.Connect;

     SndText := 'MKDIR['+ NewPath + ']' ;
     StrLen := Length(SndText);
     SndBuff := TMemoryStream.Create;
     SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
     SndBuff.Position := 0;
     IdTCPClient1.IOHandler.Write(SndBuff,0,true);
     IdTCPClient1.Disconnect;
end;

end;

procedure TfrmFileTrans.btnNewFClick(Sender: TObject);
var
DestinIP,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
frmNewName : TForm1;
FormTitle:string;Title:string;Ok:string;Cancel:string;
NewName,NewPath : string;
Respond : string;

begin
DestinIP := lblComputerIP1.Text;
DestiniPath := lblPath1.Text;
FormTitle :=  GetMessageFromDll(LangCode,'MakeNewFolder');
Title :=  GetMessageFromDll(LangCode,'NewFolderName');
Ok :=  GetMessageFromDll(LangCode,'btnOk');
Cancel :=  GetMessageFromDll(LangCode,'btnExit');


frmNewName := TForm1.Create(FormTitle,Title,Ok,Cancel);
frmNewName.ShowModal;
if frmNewName.ModalResult = mrOk then NewName := frmNewName.txbNewName.Text;
if frmNewName.ModalResult = mrCancel then NewName := '';
if NewName = '' then exit;
if SelectedTreeNode.Level = 0 then NewPath := DestiniPath + NewName;
if SelectedTreeNode.Level > 0 then NewPath := DestiniPath + '\' + NewName;
if (lblComputerName1.Caption = 'Local Computer') then
begin
    MkDir(NewPath);
    TreeView1.Items.Clear;
    GetLocalDriveList('1');
end else
begin

     IdTCPClient1.Host := DestinIP;
     IdTCPClient1.Port := StrToInt(AgentPort);
     IdTCPClient1.Connect;

     SndText := 'MKDIR['+ NewPath + ']' ;
     StrLen := Length(SndText);
     SndBuff := TMemoryStream.Create;
     SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
     SndBuff.Position := 0;
     IdTCPClient1.IOHandler.Write(SndBuff,0,true);
     IdTCPClient1.Disconnect;
end;
end;

procedure TfrmFileTrans.btnRename2Click(Sender: TObject);
var
DestinIP,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
frmNewName : TForm1;
FormTitle:string;Title:string;Ok:string;Cancel:string;
NewName,OldName : string;
Respond : string;
begin
DestinIP := lblComputerIP2.Text;
DestiniPath := lblPath2.Text;
FormTitle :=  GetMessageFromDll(LangCode,'Rename');
Title :=  GetMessageFromDll(LangCode,'RenameTitle');
Ok :=  GetMessageFromDll(LangCode,'btnOk');
Cancel :=  GetMessageFromDll(LangCode,'btnExit');
OldName := SelectedTreeNode.Text;

frmNewName := TForm1.Create(FormTitle,Title,Ok,Cancel);
frmNewName.ShowModal;
if frmNewName.ModalResult = mrOk then NewName := frmNewName.txbNewName.Text;
if frmNewName.ModalResult = mrCancel then NewName := '';
if NewName = '' then exit;

if (lblComputerName2.Caption = 'Local Computer') then
begin
    if NewName <> OldName then
    begin
     SelectedTreeNode.Text := NewName;
     Path2 := Copy(DestiniPath,1,length(DestiniPath) - length(OldName));
     Path2 := Path2 + NewName;
     lblPath2.Text := Path2;
     if RenameFile(DestiniPath,Path2) = false then
     begin
       SelectedTreeNode.Text := OldName;
       Path2 := DestiniPath;
       lblPath2.Text := Path2;
     end;
    end else exit;
end else
begin
   if NewName <> OldName then
     begin
     SelectedTreeNode.Text := NewName;
     Path2 := Copy(DestiniPath,1,length(DestiniPath) - length(OldName));
     Path2 := Path2 + NewName;
     lblPath2.Text := Path2;


     IdTCPClient1.Host := DestinIP;
     IdTCPClient1.Port := StrToInt(AgentPort);
     IdTCPClient1.Connect;

     SndText := 'RENAM['+ DestiniPath + '][' + Path2 + ']' ;
     StrLen := Length(SndText);
     SndBuff := TMemoryStream.Create;
     SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
     SndBuff.Position := 0;
     IdTCPClient1.IOHandler.Write(SndBuff,0,true);
     IdTCPClient1.Disconnect;

   end else exit;
end;


end;

procedure TfrmFileTrans.btnRenameClick(Sender: TObject);
var
DestinIP,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
frmNewName : TForm1;
FormTitle:string;Title:string;Ok:string;Cancel:string;
NewName,OldName : string;
Respond : string;
begin
DestinIP := lblComputerIP1.Text;
DestiniPath := lblPath1.Text;
FormTitle :=  GetMessageFromDll(LangCode,'Rename');
Title :=  GetMessageFromDll(LangCode,'RenameTitle');
Ok :=  GetMessageFromDll(LangCode,'btnOk');
Cancel :=  GetMessageFromDll(LangCode,'btnExit');
OldName := SelectedTreeNode.Text;

frmNewName := TForm1.Create(FormTitle,Title,Ok,Cancel);
frmNewName.ShowModal;
if frmNewName.ModalResult = mrOk then NewName := frmNewName.txbNewName.Text;
if frmNewName.ModalResult = mrCancel then NewName := '';
if NewName = '' then exit;

if (lblComputerName1.Caption = 'Local Computer') then
begin
    if NewName <> OldName then
    begin
     SelectedTreeNode.Text := NewName;
     Path1 := Copy(DestiniPath,1,length(DestiniPath) - length(OldName));
     Path1 := Path1 + NewName;
     lblPath1.Text := Path1;
     if RenameFile(DestiniPath,Path1) = false then
     begin
       SelectedTreeNode.Text := OldName;
       Path1 := DestiniPath;
       lblPath1.Text := Path1;
     end;
    end else exit;
end else
begin
   if NewName <> OldName then
     begin
     SelectedTreeNode.Text := NewName;
     Path1 := Copy(DestiniPath,1,length(DestiniPath) - length(OldName));
     Path1 := Path1 + NewName;
     lblPath1.Text := Path1;


     IdTCPClient1.Host := DestinIP;
     IdTCPClient1.Port := StrToInt(AgentPort);
     IdTCPClient1.Connect;

     SndText := 'RENAM['+ DestiniPath + '][' + Path1 + ']' ;
     StrLen := Length(SndText);
     SndBuff := TMemoryStream.Create;
     SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
     SndBuff.Position := 0;
     IdTCPClient1.IOHandler.Write(SndBuff,0,true);
     IdTCPClient1.Disconnect;

   end else exit;
end;


end;

procedure TfrmFileTrans.btnSendL2RClick(Sender: TObject);
var
SourceIP,DestinIP,SourcePath,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin

SourceIP := lblComputerIP1.Text;
DestinIP := lblComputerIP2.Text;
SourcePath := lblPath1.Text;
DestiniPath := lblPath2.Text;

if (lblComputerName1.Caption = 'Local Computer') AND (lblComputerName2.Caption = 'Local Computer') then
begin
   CopyFile(pwidechar(SourcePath),pwidechar(DestiniPath),false);
end else
begin
    IdTCPClient1.Host := SourceIP;
    IdTCPClient1.Port := StrToInt(AgentPort);
    IdTCPClient1.Connect;

    SndText := 'FITRF['+ SourcePath + '][' + DestiniPath + '][' + SourceIP + '][' + DestinIP + ']';
    StrLen := Length(SndText);
    SndBuff := TMemoryStream.Create;
    SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
    SndBuff.Position := 0;
    IdTCPClient1.IOHandler.Write(SndBuff,0,true);
    IdTCPClient1.Disconnect;
end;

end;

procedure TfrmFileTrans.btnSendR2LClick(Sender: TObject);
var
SourceIP,DestinIP,SourcePath,DestiniPath : string;
SndBuff : TMemoryStream;
SndText : string;
StrLen : integer;
begin

SourceIP := lblComputerIP2.Text;
DestinIP := lblComputerIP1.Text;
SourcePath := lblPath2.Text;
DestiniPath := lblPath1.Text;

if (lblComputerName1.Caption = 'Local Computer') AND (lblComputerName2.Caption = 'Local Computer') then
begin
  CopyFile(pwidechar(SourcePath),pwidechar(DestiniPath),false);
end else
begin
    IdTCPClient1.Host := DestinIP;
    IdTCPClient1.Port := StrToInt(AgentPort);
    IdTCPClient1.Connect;

    SndText := 'FITRF['+ SourcePath + '][' + DestiniPath + '][' + SourceIP + '][' + DestinIP + ']';
    StrLen := Length(SndText);
    SndBuff := TMemoryStream.Create;
    SndBuff.Write(SndText[1],StrLen * SizeOf(SndText[1]));
    SndBuff.Position := 0;
    IdTCPClient1.IOHandler.Write(SndBuff,0,true);
    IdTCPClient1.Disconnect;
end;


end;

procedure TfrmFileTrans.ComboBox1Select(Sender: TObject);
var
index : integer;
value : string;
ipv4 : string;
begin
index := ComboBox1.ItemIndex;
value := ComboBox1.Items[index];
lblComputerName1.Caption := value;


if value <> 'Local Computer' then
begin
  ipv4 := GetIPV4(AgentIP1[index]);
  lblComputerIP1.Text := ipv4;
  GetDriveList(AgentName1[index],ipv4,'1');
end;
if value = 'Local Computer' then
begin
  ipv4 := AgentIP1[index];
  lblComputerIP1.Text := ipv4;
  GetLocalDriveList('1');
end;

end;

procedure TfrmFileTrans.ComboBox2Select(Sender: TObject);
var
index : integer;
value : string;
ipv4 : string;
begin
index := ComboBox2.ItemIndex;
value := ComboBox2.Items[index];
lblComputerName2.Caption := value;
lblComputerIP2.Text := AgentIP2[index];
if value <> 'Local Computer' then
begin
  ipv4 := GetIPV4(AgentIP2[index]);
  GetDriveList(AgentName2[index],ipv4,'2');
end;
if value = 'Local Computer' then
begin
  GetLocalDriveList('2');
end;

end;

//'[192.168.1.5|fe80::5cea:2eea:7dc2:bb25]'
function  TfrmFileTrans.GetIPV4(ip : string):string;
var
sIndex : integer;
res : string;
begin
sIndex := Pos('|',ip);
if sIndex <> -1 then
begin
res := Copy(ip,2,sIndex-2);
end else
begin
res := ip;
end;
Result := res;
end;

procedure TfrmFileTrans.GetDriveList(ComName:string;ComIP:string;ListNumber:string);
var
sendtxt : string;
begin
sendtxt := 'GETDR'+ '['+ ListNumber +']['+ MyPort + ']';
SendCommand(sendtxt,ComName,ComIP);
end;

procedure TfrmFileTrans.SendCommand(stxt:string;ComName:string;ComIP:string);
var
StrLen : integer;
SndBuff : TMemoryStream;
begin
try
  IdTCPClient1.Host := ComIP;
  IdTCPClient1.Port := StrToInt(AgentPort);
  IdTCPClient1.Connect;
  StrLen := Length(stxt);
  SndBuff := TMemoryStream.Create;
  SndBuff.Write(stxt[1],StrLen * SizeOf(stxt[1]));
  SndBuff.Position := 0;
  IdTCPClient1.IOHandler.Write(SndBuff,0,true);
  IdTCPClient1.Disconnect;
except
  ShowMessage(ComName + ' is off line');
  exit;
end;
end;


function TfrmFileTrans.ExecuteQueryDllToString(QueryString:string;FieldName:string): string;
var
  ADOConn  : TADOConnection;
  ADOQuery_FRTO : TADOQuery;
  SQLStr : string;  { SQL Query }

 ConnString : string;
begin
ConnString := ConnS1 +GetCurrentDir+ ConnS2;
  SQLStr := QueryString;


  ADOConn := TADOConnection.Create(nil); { Create an ADO connection }
  { Setup the provider engine }
  ADOConn.ConnectionString := ConnString;{ Setup the connection string }
  ADOConn.LoginPrompt := False; { Disable login prompt }

  try
    ADOConn.Connected := True;
  except
    //on e: EADOError do
    begin
    //  ADOQuery_FRTO.Close;
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

procedure TfrmFileTrans.SetConnString;
begin
ConnS1 := PChar(char(80)+ char(114)+ char(111)+ char(118)+ char(105)+ char(100)+ char(101)+ char(114)+ char(61)+ char(77)+ char(105)+ char(99)+ char(114)+ char(111)+ char(115)+ char(111)+ char(102)+ char(116)+ char(46)+ char(74)+ char(101)+ char(116)+ char(46)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(46)+ char(52)+ char(46)+ char(48)+ char(59)+ char(68)+ char(97)+ char(116)+ char(97)+ char(32)+ char(83)+ char(111)+ char(117)+ char(114)+ char(99)+ char(101)+ char(61));
ConnS2 := PChar(char(92)+ char(69)+ char(100)+ char(105)+ char(116)+ char(65)+ char(103)+ char(101)+ char(110)+ char(116)+ char(46)+ char(100)+ char(108)+ char(108)+ char(59)+ char(106)+ char(101)+ char(116)+ char(32)+ char(79)+ char(76)+ char(69)+ char(68)+ char(66)+ char(58)+ char(68)+ char(97)+ char(116)+ char(97)+ char(98)+ char(97)+ char(115)+ char(101)+ char(32)+ char(80)+ char(97)+ char(115)+ char(115)+ char(119)+ char(111)+ char(114)+ char(100)+ char(61)+ char(115)+ char(104)+ char(97)+ char(121)+ char(97)+ char(101)+ char(101)+ char(108)+ char(49)+ char(51)+ char(53)+ char(49)+ char(38)+ char(51)+ char(53)+ char(57));

end;

procedure TfrmFileTrans.GetLocalDriveList(TreeviewNumber:string);
var
DList : TStringArray;
len : integer;
DriveName : string;
tn : TtreeNode;
begin

DList := GetDriveLetters;
len := 0;
if TreeviewNumber = '2' then
begin
  TreeView2.Items.BeginUpdate;
  TreeView2.Items.Clear;
  while len < length(DList) do
  begin
   DriveName := DList[len];
   tn := TreeView2.Items.Add(nil,DriveName);
   tn.ImageIndex := 0;
   inc(len);
  end;
  TreeView2.Items.EndUpdate;
end;
if TreeviewNumber = '1' then
begin
  TreeView1.Items.BeginUpdate;
  TreeView1.Items.Clear;
  while len < length(DList) do
  begin
   DriveName := DList[len];
   tn := TreeView1.Items.Add(nil,DriveName);
   tn.ImageIndex := 0;
   inc(len);
  end;
  TreeView1.Items.EndUpdate;
end;
end;

procedure TfrmFileTrans.LocalListFileDir(TreeviewNumber:string;Path:string);
var
  SR: TSearchRec;
  files_folders : TStringList;
  len,cIndex : integer;
  nullIndex : integer;
  tn : TTreeNode;
  childtype,childName : string;
  DriveS : string;
  Drive : char;
begin
  DriveS := Copy(Path,1,1);
  Drive := DriveS[1];
  files_folders := TStringList.Create;
  if DiskInDrive(Drive) then
  begin
  if FindFirst(Path +'\*.*', faAnyFile, SR) = 0 then
  begin
    repeat
    if (SR.Name <> '.') AND (SR.Name <> '..') AND (Lowercase(SR.Name) <> '$recycle.bin') then
    begin  { Step 1 start }
      if (SR.Attr <> 32) AND (SR.Attr <> 6) AND (SR.Attr <> 39) AND (SR.Attr <> 38) AND (SR.Attr <> 8230) then {Step 2 Start - Folder}
      begin

        if files_folders.IndexOf('') = -1 then
        begin
         files_folders.Add(IntToStr(SR.Attr)+';'+SR.Name);

        end;
        if files_folders.IndexOf('') <> -1 then
        begin
          nullIndex := files_folders.IndexOf('');
          files_folders.Delete(nullIndex);
          files_folders.Insert(nullIndex,IntToStr(SR.Attr)+';'+SR.Name);
          files_folders.Insert(nullIndex+1,'');
        end;
      end else{Step 2 End - Folder}
      begin {Step 3 Start - File}
        if files_folders.IndexOf('') <> -1 then
        begin
         files_folders.Add(IntToStr(SR.Attr)+';'+SR.Name);
        end;
        if files_folders.IndexOf('') = -1 then
        begin
        files_folders.Add('');
        files_folders.Add(IntToStr(SR.Attr)+';'+SR.Name);
        end;
      end; {Step 3 End - File}

    end;  { Step 1 end }
    until FindNext(SR) <> 0;
    FindClose(SR);
  end;
 end;

  nullIndex := files_folders.IndexOf('');
  while nullIndex <> -1 do
  begin
     files_folders.Delete(nullIndex);
     nullIndex := files_folders.IndexOf('');
  end;

  len := 0;


  while len < files_folders.Count do
  begin
     cIndex := Pos(';',files_folders[len]);
     childtype := Copy(files_folders[len],1,cIndex - 1);
     childName := Copy(files_folders[len],cIndex + 1,length(files_folders[len]) - cIndex);
     if treeviewNumber = '2' then
     begin
        tn := TreeView2.Items.AddChild(SelectedTreeNode,childName);
        if (childtype = '32') OR (childtype = '6') OR (childtype = '39') OR (childtype = '38') OR (childtype = '8230') then
        begin
         tn.ImageIndex := setimage(childName);
         //tn.ImageIndex := 2; //file image
        end else
        begin
          tn.ImageIndex := 1;  // folder image
        end;
     end;
     if treeviewNumber = '1' then
     begin
        tn := TreeView1.Items.AddChild(SelectedTreeNode,childName);
        if (childtype = '32') OR (childtype = '39') OR (childtype = '6') OR (childtype = '38') OR (childtype = '8230') then
        begin
         tn.ImageIndex := setimage(childName);
         //tn.ImageIndex := 2; //file image
        end else
        begin
          tn.ImageIndex := 1;  // folder image
        end;
     end;
     inc(len);
  end;
if treeviewNumber = '2' then TreeView2.Items.EndUpdate;
if treeviewNumber = '1' then TreeView1.Items.EndUpdate;

end;

function TfrmFileTrans.GetDriveLetters():TStringArray;
var
  vDrivesSize: Cardinal;
  vDrives	: array[0..128] of Char;
  vDrive	 : PChar;
  DriveList : TStringArray;
  m : integer;
begin
  try
	// clear the list from possible leftover from prior operations
	vDrivesSize := GetLogicalDriveStrings(SizeOf(vDrives), vDrives);
	if vDrivesSize=0 then Exit; // no drive found, no further processing needed
  m := 0;
	vDrive := vDrives;
	while vDrive^ <> #0 do
	begin
    Setlength(DriveList,m+1);
	  DriveList[m] := StrPas(vDrive);
	  Inc(vDrive, SizeOf(vDrive));
    inc(m);
	end;
  finally
	Result := DriveList;
  end;
end;

function TfrmFileTrans.DiskInDrive(Drive: Char): Boolean;
var
  ErrorMode: word;
begin
    {default result}
    Result := False;
    { make it upper case }
    if Drive in ['a'..'z'] then Dec(Drive, $20);
    { make sure it's a letter }
    if not (Drive in ['A'..'Z']) then
      raise EConvertError.Create('Not a valid drive ID');
    { turn off critical errors }
    ErrorMode := SetErrorMode(SEM_FailCriticalErrors);
    try
      { drive 1 = a, 2 = b, 3 = c, etc. }
      if DiskSize(Ord(Drive) - $40) <> -1 then Result := True;
    finally
      { restore old error mode }
      SetErrorMode(ErrorMode);
    end;
end;




end.
