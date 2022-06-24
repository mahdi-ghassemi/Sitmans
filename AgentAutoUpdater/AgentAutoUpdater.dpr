program AgentAutoUpdater;

{$APPTYPE CONSOLE}

{$R *.res}

uses
  System.SysUtils,ShellApi,Windows;

begin
  try
  ShellExecute(0, 'open', 'cmd.exe','/C taskkill /im AgTest.exe' , nil, SW_HIDE);
    { TODO -oUser -cConsole Main : Insert code here }
  except
    on E: Exception do
      Writeln(E.ClassName, ': ', E.Message);
  end;
end.
