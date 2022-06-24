object Service3: TService3
  OldCreateOrder = False
  DisplayName = 'Service3'
  Interactive = True
  BeforeInstall = ServiceBeforeInstall
  OnExecute = ServiceExecute
  Height = 150
  Width = 215
end
