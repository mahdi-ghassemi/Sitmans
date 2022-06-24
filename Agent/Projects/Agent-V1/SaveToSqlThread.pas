unit SaveToSqlThread;

interface
uses
System.Classes,TAgentClass,LocalData;

type
   TSqlThread = class(TThread)
   private
   var
     MyAgent : TMyAgent;

  // procedure SetResult;

   protected
      procedure Execute; override;

   public
      constructor Create(Suspended: Boolean);
   end;




implementation

//uses frmMain_RtoL; //Unit of the form that will be updated by thread

constructor TSqlThread.Create(Suspended: Boolean);
begin
   Inherited Create(Suspended);
   FreeOnTerminate := True;
end;



procedure TSqlThread.Execute;
begin
    if Terminated then Exit;

    MyAgent := TMyAgent.Create;

    if Terminated then Exit;

    MyAgent.GetAllPropertiesFromDll;

    if Terminated then Exit;

    MyAgent.SaveAllPropertiesToSql;

    if Terminated then Exit;

    LocalData.UpdateFieldToDll('AgentSetting','SendToSQL','1','ID = 1');

   // Synchronize(SetResult);

    Terminate;
    WaitFor;
    Exit;
end;

end.
