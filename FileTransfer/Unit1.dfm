object Form1: TForm1
  Left = 0
  Top = 0
  BiDiMode = bdRightToLeft
  BorderIcons = []
  ClientHeight = 119
  ClientWidth = 447
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  ParentBiDiMode = False
  Position = poDesktopCenter
  PixelsPerInch = 96
  TextHeight = 13
  object lblTitle: TLabel
    Left = 385
    Top = 16
    Width = 30
    Height = 13
    Caption = 'lblTitle'
  end
  object txbNewName: TEdit
    Left = 40
    Top = 48
    Width = 375
    Height = 21
    BiDiMode = bdLeftToRight
    ParentBiDiMode = False
    TabOrder = 0
  end
  object btnOk: TButton
    Left = 128
    Top = 86
    Width = 78
    Height = 25
    Caption = 'btnOk'
    TabOrder = 1
    OnClick = btnOkClick
  end
  object btnCancel: TButton
    Left = 43
    Top = 86
    Width = 75
    Height = 25
    Caption = 'btnCancel'
    TabOrder = 2
    OnClick = btnCancelClick
  end
end
