program Project2;

uses
  FMX.Forms,
  Unit4 in 'Unit4.pas' {Form4},
  TAgent_Class in 'TAgent_Class.pas',
  LocalData in 'LocalData.pas',
  WbemScripting_TLB in '..\9.0\Imports\WbemScripting_TLB.pas',
  GetActiveNetworkSetting in 'GetActiveNetworkSetting.pas',
  GetBios in 'GetBios.pas',
  uSMBIOS in 'uSMBIOS.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm4, Form4);
  Application.Run;
end.
