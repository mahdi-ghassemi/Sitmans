unit Unit3;

interface

uses
  Winapi.Windows,ShellApi, Winapi.Messages, System.SysUtils,Forms,
  System.Classes, Vcl.Graphics, Vcl.Controls, Vcl.SvcMgr, Vcl.Dialogs;

type
  TService3 = class(TService)
    procedure ServiceBeforeInstall(Sender: TService);
    procedure ServiceExecute(Sender: TService);
  private
    { Private declarations }
  public
    function GetServiceController: TServiceController; override;
    { Public declarations }
  end;

var
  Service3: TService3;

implementation

{%CLASSGROUP 'System.Classes.TPersistent'}

{$R *.DFM}

procedure ServiceController(CtrlCode: DWord); stdcall;
begin
  Service3.Controller(CtrlCode);
end;

function TService3.GetServiceController: TServiceController;
begin
  Result := ServiceController;
end;

procedure TService3.ServiceBeforeInstall(Sender: TService);
var _u,_p : string;
begin
 _u := 'Lord-Soft\Mehdi';
 _p := 'shayaeel';
 Service3.ServiceStartName := _u;
 Service3.Password := _p;
end;

procedure TService3.ServiceExecute(Sender: TService);
var handle : HWND;
begin
 ShellExecute(handle, 'open', 'D:\Agent\Win32\Debug\AgentService.exe', nil, nil, SW_SHOWNORMAL);
end;

end.
