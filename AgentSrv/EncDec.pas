unit EncDec;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
TintArray = array of integer;

    function Decrypt(CypherText:string;IKey:string):string;
    function GetIntLength(CypherText:string):integer;
    function GetKey(IKey:string):integer;
    function GetIntMod(CypherText:string;Lenght:integer):TintArray ;
    function GetIntDiv(CypherText:string;Lenght:integer):TintArray ;
    function ConvertToInt(Code:string):integer;
    function GetText(Mood:TintArray ;Diiv:TintArray;Key:integer):string;


implementation

function Decrypt(CypherText:string;IKey:string):string;
var
_lenght,key : integer;
_mod,_div :TintArray ;
_res : string;
begin
_res := '';
_lenght := GetIntLength(CypherText);
key := GetKey(IKey);
SetLength(_mod,_lenght);
SetLength(_div,_lenght);
_mod := GetIntMod(CypherText, _lenght);
_div := GetIntDiv(CypherText, _lenght);
_res := GetText(_mod, _div,key);
Result := _res;
end;

function GetText(Mood:TintArray ;Diiv:TintArray ;Key:integer):string;
var
_len,_code,i:integer;
_res : string;
begin
_res := '';
_len := Length(Mood);
i := 0;
while i < _len do
begin
  _code := ((Diiv[i] * Key) + Mood[i]) div 2;
  _res := _res + char(_code);
  inc(i);
end;
Result := _res;
end;

function GetIntDiv(CypherText:string;Lenght:integer):TintArray ;
var
_code,_b : string;
_block,i : integer;
_res : TintArray;
begin
SetLength(_res,Lenght);
_code := Copy(CypherText,(3+Lenght),Length(CypherText)-(2+Lenght));
_block := Length(_code) div Lenght;
while i < Lenght  do
begin
  _b := Copy(_code,(i * _block)+1,_block);
  _res[i] := ConvertToInt(_b);
  inc(i);
end;
Result := _res;
end;

function ConvertToInt(Code:string):integer;
var
_codeLength,_code,i : integer;
_res : string;
begin
i := 0;
_res := '';
_codeLength := Length(Code);
while i < _codeLength do
begin
  _code := Ord(Code[i+1]);
  if (_code > 47) AND (_code < 58) then  _res := _res + char(_code);
  inc(i);
end;
Result := StrToInt(_res);
end;

function GetIntMod(CypherText:string;Lenght:integer):TintArray ;
var
_res : TintArray;
_mod : string;
i : integer;
begin
i := 0;
SetLength(_res,Lenght);
while i < Lenght do
begin
  _mod := Copy(CypherText,3+i,1);
  _res[i] := StrToInt(_mod);
  inc(i);
end;
Result := _res;
end;


function GetKey(IKey:string):integer;
var
_char : string;
k,mt : integer;
begin
mt := 0;
k := 0;
while mt < 4 do
begin
  _char := Copy(IKey,mt+1,1);
  k := k + StrToInt(_char);
  inc(mt);
end;
Result := k;
end;

function GetIntLength(CypherText:string):integer;
var
_len : string;
_res : integer;
begin
_len := Copy(CypherText,1,2);
if _len = '01' then  _res := 1
else if _len = '02' then  _res := 2
else if _len = '03' then  _res := 3
else if _len = '04' then  _res := 4
else if _len = '05' then  _res := 5
else if _len = '06' then  _res := 6
else if _len = '07' then  _res := 7
else if _len = '08' then  _res := 8
else if _len = '09' then  _res := 9
else if _len = '0A' then  _res := 10
else if _len = '0B' then  _res := 11
else if _len = '0C' then  _res := 12
else if _len = '0D' then  _res := 13
else if _len = '0E' then  _res := 14
else if _len = '0F' then  _res := 15
else if _len = '10' then  _res := 16
else if _len = '11' then  _res := 17
else if _len = '12' then  _res := 18
else if _len = '13' then  _res := 19
else if _len = '14' then  _res := 20
else if _len = '15' then  _res := 21
else if _len = '16' then  _res := 22
else if _len = '17' then  _res := 23
else if _len = '18' then  _res := 24
else if _len = '19' then  _res := 25
else if _len = '1A' then  _res := 26
else if _len = '1B' then  _res := 27
else if _len = '1C' then  _res := 28
else if _len = '1D' then  _res := 29
else if _len = '1E' then  _res := 30
else if _len = '1F' then  _res := 31
else if _len = '20' then  _res := 32;
Result := _res;
end;


end.
