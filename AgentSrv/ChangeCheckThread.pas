unit ChangeCheckThread;

interface
uses
System.Classes,TAgentClass,LocalData;

type
   TAgentThread = class(TThread)
   private
   var
     MyAgent2 : TMyAgent;

   protected
      procedure Execute; override;

   public
      constructor Create(Suspended: Boolean);
   end;

implementation


constructor TAgentThread.Create(Suspended: Boolean);
begin
   Inherited Create(Suspended);
   FreeOnTerminate := True;
end;


procedure TAgentThread.Execute;
var
Check : Boolean;
IsSystemChanges : boolean;
begin
    if Terminated then Exit;
    Check := true;
    MyAgent2 := TMyAgent.Create;
    MyAgent2.AgentID := LocalData.GetDataFromDll('AgentDetails','AgentID','1');
    while Check do
    begin
      MyAgent2.SendEventFromDllToSql;
      MyAgent2.GetSystemInfo;
      MyAgent2.GetSystemHashCode;
      IsSystemChanges := MyAgent2.CompareTotalHashCodes;
      if IsSystemChanges = true then
         begin
           MyAgent2.FindChanges;
           MyAgent2.UpdateTotoalSystemHashCode;
         end;
      MyAgent2.GetHashCodesFromDll;
      sleep(10000);
    end;
Terminate;
WaitFor;
Exit;
end;

end.

