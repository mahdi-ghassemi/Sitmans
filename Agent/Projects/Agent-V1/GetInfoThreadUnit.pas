unit GetInfoThreadUnit;

interface

uses
System.Classes,TAgentClass;

type
   TMyThread = class(TThread)
   private
   var
     MyAgent : TMyAgent;

  protected
      procedure Execute; override;

   public
      constructor Create(Suspended: Boolean);
   end;




implementation


constructor TMyThread.Create(Suspended: Boolean);
begin
   Inherited Create(Suspended);
   FreeOnTerminate := True;
end;

procedure TMyThread.Execute;
begin
    if Terminated then Exit;

    MyAgent := TMyAgent.Create;

    MyAgent.GetSystemInfo;

    if Terminated then Exit;

    MyAgent.GetSystemHashCode;

    if Terminated then Exit;

    MyAgent.SaveSystemInfoToDll;

    Terminate;
    WaitFor;
    Exit;
end;


end.
