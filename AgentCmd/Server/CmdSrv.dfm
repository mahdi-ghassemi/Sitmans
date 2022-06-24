object frmCmdServer: TfrmCmdServer
  Left = 0
  Top = 0
  Caption = 'frmCmdServer'
  ClientHeight = 82
  ClientWidth = 189
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object IdTCPServer1: TIdTCPServer
    Bindings = <>
    DefaultPort = 0
    OnExecute = IdTCPServer1Execute
    Left = 24
    Top = 16
  end
  object IdTCPClient1: TIdTCPClient
    ConnectTimeout = 0
    IPVersion = Id_IPv4
    Port = 0
    ReadTimeout = -1
    Left = 112
    Top = 16
  end
end
