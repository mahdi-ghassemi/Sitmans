unit GetCPU;

interface

uses
  Windows, Messages, SysUtils, Classes,
  IdHashMessageDigest, IdGlobal; {Controls,StdCtrls, ExtCtrls,}

procedure start();
procedure SendToDll();
//function GetMD5String(Str: String; ADestEncoding: TEncoding): String;


var
vendorid,steppingid,modelnumber,familycode,processortype:string;
extendedModel,extendedfamily,brandid,chunks,count,APICID:string;
serialnumber,MMX,FXSAVE_FXRSTOR_Instructions,SSE,SSE2:string;
extendedCPUID,Largest_Function_Supported,Brand_String:string;
HashCode:string;

implementation

function GetMD5String(Str: String; ADestEncoding: TIdTextEncoding = nil): String;
var MD5: TIdHashMessageDigest5;
begin
          MD5:= TIdHashMessageDigest5.Create;
          try
          Result:= LowerCase (MD5.HashStringAsHex (Str, ADestEncoding));
          finally FreeAndNil (MD5);
    end;
end;

procedure SendToDll();

begin


end;





procedure start();
var

  _hashCode : string;
  _cpuString : string;
  _eax, _ebx, _ecx, _edx: Longword;
  i: Integer;
  b: Byte;
  b1: Word;
  s, s1, s2, s3, s_all: string;
begin

  vendorid := '';steppingid := ''; modelnumber := '';familycode :='';processortype :='';
  extendedModel:='';extendedfamily:='';brandid:='';chunks:='';count:='';APICID := '';
  serialnumber:='';MMX:='';FXSAVE_FXRSTOR_Instructions:='';SSE:='';SSE2 := '';
  extendedCPUID:='';Largest_Function_Supported:='';Brand_String := '';



  asm                //asm call to the CPUID inst.
    mov eax,0         //sub. func call
    db $0F,$A2         //db $0F,$A2 = CPUID instruction
    mov _ebx,ebx
    mov _ecx,ecx
    mov _edx,edx
  end;

  for i := 0 to 3 do   //extract vendor id
  begin
    b := lo(_ebx);
    s := s + chr(b);
    b := lo(_ecx);
    s1:= s1 + chr(b);
    b := lo(_edx);
    s2:= s2 + chr(b);
    _ebx := _ebx shr 8;
    _ecx := _ecx shr 8;
    _edx := _edx shr 8;
  end;
  vendorid := Trim(s + s2 + s1);

  asm
    mov eax,1
    db $0F,$A2
    mov _eax,eax
    mov _ebx,ebx
    mov _ecx,ecx
    mov _edx,edx
  end;

  b := lo(_eax) and 15;
  steppingid := IntToStr(b);

  b := lo(_eax) shr 4;
  modelnumber := IntToHex(b, 1);

  b := hi(_eax) and 15;
  familycode := IntToStr(b);

  b := hi(_eax) shr 4;
  processortype := IntToStr(b);

  b := lo((_eax shr 16)) and 15;
  extendedModel := IntToStr(b);

  b := lo((_eax shr 20));
  extendedfamily := IntToStr(b);

  b := lo(_ebx);
  brandid := IntToStr(b);

  b := hi(_ebx);
  chunks := IntToStr(b);

  b := lo(_ebx shr 16);
  count := IntToStr(b);

  b := hi(_ebx shr 16);
  APICID := IntToStr(b);

  s := IntToHex(_eax, 8);
  asm                  //determine the serial number
    mov eax,3
    db $0F,$A2
    mov _ecx,ecx
    mov _edx,edx
  end;
  s1 := IntToHex(_edx, 8);
  s2 := IntToHex(_ecx, 8);
  Insert('-', s, 5);
  Insert('-', s1, 5);
  Insert('-', s2, 5);
  serialnumber := Trim(s + '-' + s1 + '-' + s2);

  asm
    mov eax,1
    db $0F,$A2
    mov _edx,edx
  end;

  //Bit 23 =? 1
  if (_edx and $800000) = $800000 then
    MMX := 'Supported'
  else
    MMX := 'Not Supported';

  //Bit 24 =? 1
  if (_edx and $01000000) = $01000000 then
    FXSAVE_FXRSTOR_Instructions := 'Supported'
  else
    FXSAVE_FXRSTOR_Instructions := 'Not Supported';

  //Bit 25 =? 1
  if (_edx and $02000000) = $02000000 then
    SSE := 'Supported'
  else
    SSE := 'Not Supported';

  //Bit 26 =? 1
  if (_edx and $04000000) = $04000000 then
    SSE2 := 'Supported'
  else
    SSE2 := 'Not Supported';

  asm     //execute the extended CPUID inst.
    mov eax,$80000000   //sub. func call
    db $0F,$A2
    mov _eax,eax
  end;

  if _eax > $80000000 then  //any other sub. funct avail. ?
  begin
    extendedCPUID := 'Supported';
    Largest_Function_Supported := IntToStr(_eax - $80000000);
    asm     //get brand ID
      mov eax,$80000002
      db $0F
      db $A2
      mov _eax,eax
      mov _ebx,ebx
      mov _ecx,ecx
      mov _edx,edx
    end;
    s  := '';
    s1 := '';
    s2 := '';
    s3 := '';
    for i := 0 to 3 do
    begin
      b := lo(_eax);
      s3:= s3 + chr(b);
      b := lo(_ebx);
      s := s + chr(b);
      b := lo(_ecx);
      s1 := s1 + chr(b);
      b := lo(_edx);
      s2 := s2 + chr(b);
      _eax := _eax shr 8;
      _ebx := _ebx shr 8;
      _ecx := _ecx shr 8;
      _edx := _edx shr 8;
    end;

    s_all := s3 + s + s1 + s2;

    asm
      mov eax,$80000003
      db $0F
      db $A2
      mov _eax,eax
      mov _ebx,ebx
      mov _ecx,ecx
    mov _edx,edx
    end;
    s  := '';
    s1 := '';
    s2 := '';
    s3 := '';
    for i := 0 to 3 do
    begin
      b := lo(_eax);
      s3 := s3 + chr(b);
      b := lo(_ebx);
      s := s + chr(b);
      b := lo(_ecx);
      s1 := s1 + chr(b);
      b := lo(_edx);
      s2 := s2 + chr(b);
      _eax := _eax shr 8;
      _ebx := _ebx shr 8;
      _ecx := _ecx shr 8;
      _edx := _edx shr 8;
    end;
    s_all := s_all + s3 + s + s1 + s2;

    asm
      mov eax,$80000004
      db $0F
      db $A2
      mov _eax,eax
      mov _ebx,ebx
      mov _ecx,ecx
      mov _edx,edx
    end;
    s  := '';
    s1 := '';
    s2 := '';
    s3 := '';
    for i := 0 to 3 do
    begin
      b  := lo(_eax);
      s3 := s3 + chr(b);
      b := lo(_ebx);
      s := s + chr(b);
      b := lo(_ecx);
      s1 := s1 + chr(b);
      b  := lo(_edx);
      s2 := s2 + chr(b);
      _eax := _eax shr 8;
      _ebx := _ebx shr 8;
      _ecx := _ecx shr 8;
      _edx := _edx shr 8;
    end;

    if s2[Length(s2)] = #0 then setlength(s2, Length(s2) - 1);
     Brand_String := Trim(s_all + s3 + s + s1 + s2);
  end
  else
    extendedCPUID := 'Not Supported';

    _cpuString := Trim(vendorid)+Trim(steppingid)+Trim(modelnumber)+
                  Trim(familycode)+Trim(processortype)+Trim(extendedModel)+
                  Trim(extendedfamily)+Trim(brandid)+Trim(chunks)+Trim(count)
                  +Trim(serialnumber)+Trim(MMX)+
                  Trim(FXSAVE_FXRSTOR_Instructions)+Trim(SSE)+Trim(SSE2)+
                  Trim(extendedCPUID)+Trim(Largest_Function_Supported)+
                  Trim(Brand_String);

   _hashCode := GetMD5String(_cpuString,TEncoding.Unicode);

   HashCode := _hashCode;



end;

end.


