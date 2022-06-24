using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace Configure
{
    public class Encrypter
    {
        private string _key;
        
        public Encrypter()
        {
            LocalData lg = new LocalData();
            USBLock usbl = new USBLock();
            string _readKeyEn = lg.GetDataFromDll("Setting", "ReadKey", "ID = 1");
            string _readKeyDe = lg.Decrypt(_readKeyEn, true, "");
            string _lockIpAddress = lg.GetDataFromDll("Setting", "LockIPAddress", "ID = 1");
            usbl.ReadKey = _readKeyDe;
            usbl.LockIPAddress = _lockIpAddress;
            _key = usbl.GetSerial();
        }

        public string Encrypt(string PassText)
        {
            string _length = GetLength(PassText);
            int key = GetKey();
            string _mod = GetMod(PassText, key);
            string _div = GetDiv(PassText, key);
            string _res = _length + _mod + _div;
            return _res;
        }

        public string Decrypt(string CypherText)
        {
            int _lenght = GetIntLength(CypherText);
            int key = GetKey();
            int[] _mod = new int[_lenght];
            _mod = GetIntMod(CypherText, _lenght);
            int[] _div = new int[_lenght];
            _div = GetIntDiv(CypherText, _lenght);
            string _res = "";
            _res = GetText(_mod, _div,key);
            return _res;

        }

        private string GetText(int[] Mod, int[] Div,int Key)
        {
            try
            {
                int _len = Mod.Length;
                int _code;
                string _res = "";
                for (int i = 0; i < _len; i++)
                {
                    _code = ((Div[i] * Key) + Mod[i]) / 2;
                    _res = _res + (char)_code;
                }
                return _res;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return "";
            }
        }

        private int[] GetIntDiv(string CypherText, int Lenght)
        {
            try
            {
                string _code = CypherText.Substring(Lenght + 2);
                int _block = _code.Length / Lenght;
                int[] _res = new int[Lenght];
                string _b = "";
                for (int i = 0; i < Lenght; i++)
                {
                    _b = _code.Substring(i * _block, _block);
                    _res[i] = ConvertToInt(_b);
                }

                return _res;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return null; 
            }

        }

        private int ConvertToInt(string Code)
        {
            try
            {
                int _codeLength = Code.Length;
                int _code;
                string _res = "";
                for (int i = 0; i < _codeLength; i++)
                {
                    _code = Code[i];
                    if (_code > 47 && _code < 58)
                    {
                        _res = _res + (char)_code;
                    }
                }

                return Convert.ToInt32(_res);
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return 0; 
            }
        }

        private int[] GetIntMod(string CypherText, int Lenght)
        {
            try
            {
                int[] _res = new int[Lenght];
                string mod = "";
                for (int i = 0; i < Lenght; i++)
                {
                    mod = CypherText.Substring(2 + i, 1);
                    _res[i] = Convert.ToInt32(mod);
                }
                return _res;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return null;
            }
        }

        private string GetDiv(string PassText, int key)
        {
            try
            {
                string _res = "";
                int _code;
                int _len;
                int[] _div = new int[PassText.Length];
                for (int i = 0; i < PassText.Length; i++)
                {
                    _code = PassText[i];
                    _div[i] = (_code * 2) / key;
                }
                string[] _rs = new string[PassText.Length * 2];
                _rs = GetRandom(PassText.Length * 2);
                for (int n = 0; n < PassText.Length; n++)
                {
                    _len = _div[n].ToString().Length;
                    if (_len == 3)
                    {
                        _res = _res + _div[n].ToString();
                    }
                    if (_len == 2)
                    {
                        _res = _res + _rs[n];
                        _res = _res + _div[n].ToString();
                    }
                    if (_len == 1)
                    {
                        _res = _res + _rs[n];
                        _res = _res + _rs[n + 1];
                        _res = _res + _div[n].ToString();
                    }

                }
                return _res;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return null;
            }
        }

        private string[] GetRandom(int len)
        {
            try
            {
                string[] _res = new string[len];

                Random rnd = new Random();
                for (int i = 0; i < len; i++)
                {
                    int unicode = rnd.Next(65, 90);
                    char character = (char)unicode;
                    _res[i] = character.ToString();
                }

                return _res;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return null;
            }
        }

        private string GetMod(string PassText,int Key)
        {
            try
            {
                string _res = "";
                int _code;
                int[] _mode = new int[PassText.Length];
                for (int i = 0; i < PassText.Length; i++)
                {
                    _code = PassText[i];
                    _mode[i] = (_code * 2) % Key;
                    _res = _res + _mode[i].ToString();
                }
                return _res;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return null;
            }
        }

        private int GetKey()
        {
            try
            {
                string _char;
                int k = 0;
                for (int m = 0; m < 4; m++)
                {
                    _char = _key[m].ToString();
                    k = k + Convert.ToInt32(_char);
                }
                return k;
            }
            catch (Exception)
            {
                Environment.Exit(0);
                return 0;
            }
        }

        private int GetIntLength(string CypherText)
        {
            string _len = CypherText.Substring(0, 2);
            int _res = 0;
            _res = int.Parse(_len, System.Globalization.NumberStyles.HexNumber);
            /*
            switch (_len)
            {
                case "01":
                    _res = 1;
                    break;
                case "02":
                    _res = 2;
                    break;
                case "03":
                    _res = 3;
                    break;
                case "04":
                    _res = 4;
                    break;
                case "05":
                    _res = 5;
                    break;
                case "06":
                    _res = 6;
                    break;
                case "07":
                    _res = 7;
                    break;
                case "08":
                    _res = 8;
                    break;
                case "09":
                    _res = 9;
                    break;
                case "0A":
                    _res = 10;
                    break;
                case "0B":
                    _res = 11;
                    break;
                case "0C":
                    _res = 12;
                    break;
                case "0D":
                    _res = 13;
                    break;
                case "0E":
                    _res = 14;
                    break;
                case "0F":
                    _res = 15;
                    break;
                case "10":
                    _res = 16;
                    break;
                case "11":
                    _res = 17;
                    break;
                case "12":
                    _res = 18;
                    break;
                case "13":
                    _res = 19;
                    break;
                case "14":
                    _res = 20;
                    break;
                case "15":
                    _res = 21;
                    break;
                case "16":
                    _res = 22;
                    break;
                case "17":
                    _res = 23;
                    break;
                case "18":
                    _res = 24;
                    break;
                case "19":
                    _res = 25;
                    break;
                case "1A":
                    _res = 26;
                    break;
                case "1B":
                    _res = 27;
                    break;
                case "1C":
                    _res = 28;
                    break;
                case "1D":
                    _res = 29;
                    break;
                case "1E":
                    _res = 30;
                    break;
                case "1F":
                    _res = 31;
                    break;
                case "20":
                    _res = 32;
                    break;
            }
             */ 
            return _res;

        }

        private string GetLength(string PassText)
        {
            int _len = PassText.Length;
            string _res = "";
            _res = _len.ToString("X");

            if (_res.Length < 2)
                _res = "0" + _res;
            /*
            switch(_len)
            {
                case 1:
                    _res = "01";
                    break;
                case 2:
                    _res = "02";
                    break;
                case 3:
                    _res = "03";
                    break;
                case 4:
                    _res = "04";
                    break;
                case 5:
                    _res = "05";
                    break;
                case 6:
                    _res = "06";
                    break;
                case 7:
                    _res = "07";
                    break;
                case 8:
                    _res = "08";
                    break;
                case 9:
                    _res = "09";
                    break;
                case 10:
                    _res = "0A";
                    break;
                case 11:
                    _res = "0B";
                    break;
                case 12:
                    _res = "0C";
                    break;
                case 13:
                    _res = "0D";
                    break;
                case 14:
                    _res = "0E";
                    break;
                case 15:
                    _res = "0F";
                    break;
                case 16:
                    _res = "10";
                    break;
                case 17:
                    _res = "11";
                    break;
                case 18:
                    _res = "12";
                    break;
                case 19:
                    _res = "13";
                    break;
                case 20:
                    _res = "14";
                    break;
                case 21:
                    _res = "15";
                    break;
                case 22:
                    _res = "16";
                    break;
                case 23:
                    _res = "17";
                    break;
                case 24:
                    _res = "18";
                    break;
                case 25:
                    _res = "19";
                    break;
                case 26:
                    _res = "1A";
                    break;
                case 27:
                    _res = "1B";
                    break;
                case 28:
                    _res = "1C";
                    break;
                case 29:
                    _res = "1D";
                    break;
                case 30:
                    _res = "1E";
                    break;
                case 31:
                    _res = "1F";
                    break;
                case 32:
                    _res = "20";
                    break;
            }
             */ 
            return _res;
        }



    }
}
