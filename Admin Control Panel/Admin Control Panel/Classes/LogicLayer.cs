using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Persia;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Data.OleDb;
using Admin_Control_Panel.Classes;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using Microsoft.SqlServer.Management.Smo;




namespace Admin_Control_Panel.Classes
{
    /// <summary>
    /// This class contains all methods for program lagics
    /// </summary>

    public class LogicLayer
    {
        #region Fileds:

        /// <summary>
        /// Data file full path 
        /// </summary>
        private string _localPath;

        private string _localPathMsg;
        /// <summary>
        /// Data File Password
        /// </summary>
        private string _password;
        /// <summary>
        /// Dll Connection string
        /// </summary>
        private string _connectionString;

        private string _connectionStringMsg;



        private OleDbConnection _myConnection;

        //private SQLAccess sql;

        private string _langCode;

        private string _onWork;

        private string _minute;

        private string _off;
        private string _standby;

        private string Unclassified;
        private string Restricted;
        private string Confidential;
        private string Secret;
        private string TopSecret;


        #endregion

        #region Properties:

        /// <summary>
        /// Get Data File Path
        /// </summary>
        public string DataFilePath
        {
            get
            {
                return _localPath;
            }
        }
        #endregion

        #region Constructors:

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LogicLayer()
        {
            _langCode = Program.LangCode.ToString();
            //sql = new SQLAccess();
            _localPathMsg = AppDomain.CurrentDomain.BaseDirectory + Decrypt("LKsUBOhTWkW6h8o9GdtgGw==", true, "");
            _localPath = AppDomain.CurrentDomain.BaseDirectory + Decrypt("mUeSLoCO8VvohacsvVNS8g==", true, "");
            _password = Decrypt("1MllRzArFvyPoS7n+TDuSkyHUvftOQGr", true, "");
            _connectionString = Decrypt("XjmTlR5XcUlPH3IZ8ov67v3TeG5OJ7ksqHYknB7MPKtEhD3fiXB6qJy+NGsvvxGW", true, "") + _localPath + Decrypt("zU6hRRV+LAwLZ+1l1vD14CDKgvZpiRX5lEAE5uivuOU=", true, "") + _password;
            _connectionStringMsg = Decrypt("XjmTlR5XcUlPH3IZ8ov67v3TeG5OJ7ksqHYknB7MPKtEhD3fiXB6qJy+NGsvvxGW", true, "") + _localPathMsg + Decrypt("zU6hRRV+LAwLZ+1l1vD14CDKgvZpiRX5lEAE5uivuOU=", true, "") + _password;
        }

        #endregion


        #region Public methods

        public string GetCrc32()
        {
            string _return;
            MD5 md = MD5.Create();
            Stream st = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "\\AdminCPanel.exe");
            _return = BitConverter.ToString(md.ComputeHash(st)).Replace("-", "").ToLower();
            return _return;
        }

        public void UpdateAgentInfoInAgentList(int AgentIndex, string InfoName)
        {
            switch (InfoName)
            {
                case "Asset":
                    {
                        DataTable dtUpdate = new DataTable();
                        dtUpdate = GetAgentAssetNumbers(Program.AgentList[AgentIndex].AgentID);
                        if (dtUpdate.Rows.Count != 0)
                        {
                            for (int i = 0; i < dtUpdate.Rows.Count; i++)
                            {
                                Program.AgentList[AgentIndex].AssetTableId[i] = dtUpdate.Rows[i]["Id"].ToString();
                                Program.AgentList[AgentIndex].DeviceId[i] = Convert.ToInt32(dtUpdate.Rows[i]["DeviceId"].ToString());
                                Program.AgentList[AgentIndex].DeviceAssetNumber[i] = dtUpdate.Rows[i]["Assetnumber"].ToString();
                                Program.AgentList[AgentIndex].DeviceModel[i] = dtUpdate.Rows[i]["DeviceModel"].ToString();
                                Program.AgentList[AgentIndex].DeviceSerialNumber[i] = dtUpdate.Rows[i]["DeviceSerialNumber"].ToString();
                            }
                        }
                        break;
                    }
            }
        }

        public bool CheckPermission(int AclCode)
        {
            bool _res = false;
            switch(AclCode)
            {
                case 46:
                    if (User.Acl46 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 47:
                    if (User.Acl47 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 48:
                    if (User.Acl48 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 49:
                    if (User.Acl49 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 50:
                    if (User.Acl50 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 51:
                    if (User.Acl51 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 52:
                    if (User.Acl52 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 53:
                    if (User.Acl53 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 54:
                    if (User.Acl54 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 55:
                    if (User.Acl55 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 56:
                    if (User.Acl56 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 57:
                    if (User.Acl57 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 58:
                    if (User.Acl58 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 59:
                    if (User.Acl59 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 60:
                    if (User.Acl60 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 61:
                    if (User.Acl61 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 62:
                    if (User.Acl62 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 63:
                    if (User.Acl63 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 64:
                    if (User.Acl64 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 65:
                    if (User.Acl65 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 66:
                    if (User.Acl66 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 67:
                    if (User.Acl67 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 68:
                    if (User.Acl68 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 69:
                    if (User.Acl69 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 70:
                    if (User.Acl70 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 71:
                    if (User.Acl71 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 72:
                    if (User.Acl72 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
                case 73:
                    if (User.Acl73 == 1)
                        _res = true;
                    else
                        _res = false;
                    break;
            }


            return _res;
        }

        public List<string> GetListOnDate(DataTable DT)
        {
            int _row = DT.Rows.Count;
            string[] date = new string[_row];
            for (int i = 0; i < _row; i++)
            {
                date[i] = GetEventDateFromSql(DT.Rows[i]["EventDateTime"].ToString());
            }
            var notDublicateDate = date.Distinct();
            List<string> _date = new List<string>();
            foreach (string value in notDublicateDate)
            {
                _date.Add(value);
            }
            return _date;
        }

        public string GetErrorMessage(int ErrorCode)
        {
            string msg = "";
            Program.ErrorCode = ErrorCode;
            switch (ErrorCode)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "Message2");
                    break;
                case 12:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoRegister");
                    break;
                case 13:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoConfig");
                    break;
                case 14:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoChatBoxMadule");
                    break;
                case 15:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoRemoteDesktopMadule");
                    break;
                case 16:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoAgentCmdMadule");
                    break;
                case 17:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoFileTransferMadule");
                    break;
                case 18:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "SQLError");
                    break;
                case 19:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "SaveRecordFail");
                    break;
                case 20:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "DeleteFail");
                    break;
                case 21:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "WrongUsernameOrPassword");
                    break;
                case 22:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "EnterUsernameAndPassword");
                    break;
                case 23:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "SelectSystem");
                    break;
                case 24:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "UndeleteDefaultProfile");
                    break;
                case 25:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "AlertProfileDeleteError");
                    break;
                case 26:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NullFirstAndLastname");
                    break;
                case 27:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "ImageSizeErr");
                    break;
                case 28:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "EnterUsername");
                    break;
                case 29:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "EnterPassword");
                    break;
                case 30:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoAgentSelected");
                    break;
                case 31:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoConnditionForSearch");
                    break;
                case 32:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "UserCanNotDelete");
                    break;
                case 33:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "NoReportFileExist");
                    break;
                case 34:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "UnknownErrorInReport");
                    break;
                case 35:
                    msg = GetMessageFromDll(Program.LangCode.ToString(), "LockNotConfig");
                    break;
                case 36:
                     msg = GetMessageFromDll(Program.LangCode.ToString(), "OCXNotRegister");
                     break;

            }
            return msg;
        }

        public string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        public bool IsRegister(string Data)
        {
            bool result = false;
            string _data = Data;
            if (_data != "")
            {
                int startIndex = _data.IndexOf("&&");



                int length = _data.Length;
                StringBuilder sb = new StringBuilder(_data);
                sb.Remove(startIndex, (length - startIndex));
                string _newData = sb.ToString();
                string text = Decrypt(_newData, true, "");
                if (text == "Register")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            else
                result = false;

            return result;
        }

        public string GetSqlConnectionString(string Data)
        {
            string result = "";
            string _data = Data;

            int startIndex = _data.IndexOf("&&");
            int length = _data.Length;
            StringBuilder sb = new StringBuilder(_data);
            sb.Remove(0, (startIndex + 2));
            string _newData = sb.ToString();
            result = Decrypt(_newData, true, "");
            return result;
        }

        public void InsertChatBoxDataToDll(string AgentId, string ComputerName, string AgentIPAddress, string AgentPortNumber, string MyPortNumber, string LangCode, string IsPrivateChat, string IsDataGetting, string Msg, string SenderUserName, string SqlConS)
        {

            string Query = "INSERT  INTO ActiveChatAgent (AgentId,ComputerName,AgentIPAddress,AgentPortNumber,MyPortNumber,LangCode,IsPrivateChat,IsDataGetting,Msg,SenderUserName,SqlConnString) VALUES ('" + AgentId + "','" + ComputerName + "','" + AgentIPAddress + "','" + AgentPortNumber +
                           "','" + MyPortNumber + "','" + LangCode + "','" + IsPrivateChat + "','" + IsDataGetting + "','" + Msg + "','" + SenderUserName + "','" + SqlConS + "')";

            ExecuteQuery(Query);

        }

        public void InsertRemoteDesktopDataToDll(string AgentPort, string AgentIP, string AgentName, string MyPort, string LangCode)
        {

            string GetData = "No";
            string Query = "INSERT  INTO RemoteDesktop (AgentPort,AgentIP,AgentName,GetData,LangCode,MyPort) VALUES ('" + AgentPort + "','" + AgentIP + "','" + AgentName + "','" + GetData +
                           "','" + LangCode + "','" + MyPort + "')";

            ExecuteQuery(Query);

        }

        public void InsertAgentCmdDataToDll(string Port, string AgentIP, string SqlString, string ComputerName, string AgentPort, string LangCode, string AgentId)
        {
            string GetData = "No";
            string Query = "INSERT  INTO AgentCmd (Port,AgentIP,SqlString,GetData,ComputerName,AgentPort,LangCode,AgentId) VALUES ('" + Port + "','" + AgentIP + "','" + SqlString + "','" + GetData +
                           "','" + ComputerName + "','" + AgentPort + "','" + LangCode + "','" + AgentId + "')";

            ExecuteQuery(Query);

        }

        public void InsertFileTransferDataToDll(string SqlConString, string LangCode, string ServerPort, string AgentPort)
        {
            string Query = "INSERT  INTO FileTransfer (SqlConString,LangCode,ServerPort,AgentPort) VALUES ('" + SqlConString + "','" + LangCode + "','" + ServerPort + "','" + AgentPort + "')";

            ExecuteQuery(Query);

        }

        public void InsertCommandBoxferDataToDll(string SqlConString, string LangCode, string ServerPort, string AgentPort, string ComputerName, string AgentIP)
        {
            string GetData = "No";
            string Query = "INSERT  INTO CommandBox (Port,AgentIP,SqlString,GetData,ComputerName,AgentPort,LangCode) VALUES ('" + ServerPort + "','" + AgentIP + "','" + SqlConString + "','" + GetData +
                          "','" + ComputerName + "','" + AgentPort + "','" + LangCode + "','" + "')";

            ExecuteQuery(Query);

        }



        public string GetMyPort()
        {
            string _p;
            int _LastPort;
            int _newPort;
            _LastPort = Program.ChatPort;
            _newPort = _LastPort + 1;
            if (_newPort > 65500)
                _newPort = 4000;
            Program.ChatPort = _newPort;
            _p = Convert.ToString(_newPort);
            return _p;
        }

        public void ExecuteQuery(string Query)
        {

            string _query = Query;

            //Create Connection to data file
            _myConnection = new OleDbConnection();
            _myConnection.ConnectionString = _connectionString;
            _myConnection.Open();

            //Create and set command 
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = _myConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = Query;

            //Execute read
            OleDbDataReader reader = myCommand.ExecuteReader();
            reader.Read();
            reader.Close();
            _myConnection.Close();



        }

        public string GetDataFromDll(string TableName, string FieldName, string Conndition)
        {

            string result;
            string Query = "SELECT " + FieldName + " FROM " + TableName + " WHERE " + Conndition;

            //Create Connection to data file
            _myConnection = new OleDbConnection();
            _myConnection.ConnectionString = _connectionString;
            _myConnection.Open();

            //Create and set command 
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = _myConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = Query;

            //Execute read
            OleDbDataReader reader = myCommand.ExecuteReader();
            reader.Read();

            result = reader.GetValue(0).ToString();


            reader.Close();
            _myConnection.Close();

            return result;

        }

        public string GetMessageFromDll(string LangCode, string ChildObject)
        {
            string result;
            string tb_name = "";
            switch(LangCode)
            {
                case "1":
                    tb_name = "MessagesFa";
                    break;
                case "2":
                    tb_name = "MessagesEn";
                    break;
            }
            string Query = "SELECT Message FROM " + tb_name + " WHERE LangCode = '" + LangCode + "' AND ChildObject = '" + ChildObject + "'";

            //Create Connection to data file
            _myConnection = new OleDbConnection();
            _myConnection.ConnectionString = _connectionStringMsg;
            _myConnection.Open();

            //Create and set command 
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = _myConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = Query;

            //Execute read
            OleDbDataReader reader = myCommand.ExecuteReader();
            reader.Read();

            result = reader.GetValue(0).ToString();


            reader.Close();
            _myConnection.Close();

            return result;

        }

        public int[] GetTableCoulmnsFromDll(string TableName, int CoulmnsCount)
        {
            int[] result = new int[CoulmnsCount];

            string Query = "SELECT * FROM " + TableName + " WHERE ID = 1";

            //Create Connection to data file
            _myConnection = new OleDbConnection();
            _myConnection.ConnectionString = _connectionString;
            _myConnection.Open();

            //Create and set command 
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = _myConnection;
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = Query;

            //Execute read
            OleDbDataReader reader = myCommand.ExecuteReader();
            reader.Read();
            for (int i = 0; i < CoulmnsCount; i++)
            {
                result[i] = Convert.ToInt32(reader.GetValue(i + 1).ToString());
            }

            reader.Close();
            _myConnection.Close();

            return result;
        }

        public string GetEncrypted(string PlainText, string Salt)
        {
            string _hashPassword = HashMD5(PlainText);
            string _hashSalt = HashMD5(Salt);
            string _encrypt = HashMD5(_hashSalt + _hashPassword);
            return _encrypt;
        }

        public string Encrypt(string toEncrypt, bool useHashing, string key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);



            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Decrypt(string cipherString, bool useHashing, string key)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);


            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                tdes.Clear();
                return "";

            }
            //Release resources held by TripleDes Encryptor                
            //tdes.Clear();
            //return the Clear decrypted TEXT
            // return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public DataView ArrayToDataview(string[,] Arrays, string[] Columns)
        {
            DataTable dt = new DataTable("Table");
            for (int i = 0; i < Columns.Length; i++)
            {
                dt.Columns.Add(Columns[i]);
            }

            for (int outerIndex = 0; outerIndex < (Arrays.Length / Columns.Length); outerIndex++)
            {
                DataRow newRow = dt.NewRow();
                for (int innerIndex = 0; innerIndex < Columns.Length; innerIndex++)
                {

                    newRow[innerIndex] = Arrays[outerIndex, innerIndex];

                }
                dt.Rows.Add(newRow);
            }

            DataView dv = new DataView(dt);
            return dv;
        }


        public int CheckLoginDetails(string Username, string Password)
        {
            int _result = 0;

            if (Username.Trim() == "" && Password.Trim() == "")
            {
                _result = -2;
                return _result;
            }
            if (Username.Trim() == "")
            {
                _result = -3;
                return _result;
            }
            if (Password.Trim() == "")
            {
                _result = -4;
                return _result;
            }

            if (Username.Trim() != "" && Password.Trim() != "")
            {
                SQLAccess sql1 = new SQLAccess();
                string userEncr, passEncr;
                userEncr = Encrypt(Username.Trim(), true, "");
                passEncr = Encrypt(Password.Trim(), true, "");

                sql1.StoredProcedureName = SQLAccess.StoredProcedure.prcCheckLogin.ToString();
                _result = sql1.CheckLogin(userEncr, passEncr);
                if(_result > 0)
                    SetUserAclObjects();
                return _result;
            }


            return _result;
        }

        public void SetUserAclObjects()
        {
            string subjectId = "";
            string acl = "";
            DataTable dt = new DataTable();
            dt = GetAclObjectsDetails(User.AclProfileId.ToString(), "2");
            int r = dt.Rows.Count;
            if (r > 0)
            {
                for (int i = 0; i < r; i++)
                {
                    subjectId = dt.Rows[i]["SubjectId"].ToString();
                    acl = dt.Rows[i]["AclLevel"].ToString();
                    SetCurrentUserAclObjects(subjectId, acl);
                    subjectId = "";
                    acl = "";
                }
            }
        }

        private void SetCurrentUserAclObjects(string SubjectId,string AclLevel)
        {
            switch(SubjectId)
            {
                case "46":
                    User.Acl46 = Convert.ToInt32(AclLevel);
                    break;
                case "47":
                     User.Acl47 = Convert.ToInt32(AclLevel);
                     break;
                case "48":
                     User.Acl48 = Convert.ToInt32(AclLevel);
                     break;
                case "49":
                     User.Acl49 = Convert.ToInt32(AclLevel);
                     break;
                case "50":
                     User.Acl50 = Convert.ToInt32(AclLevel);
                     break;
                case "51":
                     User.Acl51 = Convert.ToInt32(AclLevel);
                     break;
                case "52":
                     User.Acl52 = Convert.ToInt32(AclLevel);
                     break;
                case "53":
                     User.Acl53 = Convert.ToInt32(AclLevel);
                     break;
                case "54":
                     User.Acl54 = Convert.ToInt32(AclLevel);
                     break;
                case "55":
                     User.Acl55 = Convert.ToInt32(AclLevel);
                     break;
                case "56":
                     User.Acl56 = Convert.ToInt32(AclLevel);
                     break;
                case "57":
                     User.Acl57 = Convert.ToInt32(AclLevel);
                     break;
                case "58":
                     User.Acl58 = Convert.ToInt32(AclLevel);
                     break;
                case "59":
                     User.Acl59 = Convert.ToInt32(AclLevel);
                     break;
                case "60":
                     User.Acl60 = Convert.ToInt32(AclLevel);
                     break;
                case "61":
                     User.Acl61 = Convert.ToInt32(AclLevel);
                     break;
                case "62":
                     User.Acl62 = Convert.ToInt32(AclLevel);
                     break;
                case "63":
                     User.Acl63 = Convert.ToInt32(AclLevel);
                     break;
                case "64":
                     User.Acl64 = Convert.ToInt32(AclLevel);
                     break;
                case "65":
                     User.Acl65 = Convert.ToInt32(AclLevel);
                     break;
                case "66":
                     User.Acl66 = Convert.ToInt32(AclLevel);
                     break;
                case "67":
                     User.Acl67 = Convert.ToInt32(AclLevel);
                     break;
                case "68":
                     User.Acl68 = Convert.ToInt32(AclLevel);
                     break;
                case "69":
                     User.Acl69 = Convert.ToInt32(AclLevel);
                     break;
                case "70":
                     User.Acl70 = Convert.ToInt32(AclLevel);
                     break;
                case "71":
                     User.Acl71 = Convert.ToInt32(AclLevel);
                     break;
                case "72":
                     User.Acl72 = Convert.ToInt32(AclLevel);
                     break;
                case "73":
                     User.Acl73 = Convert.ToInt32(AclLevel);
                     break;             
            }
        }

        public void SetUserImage(string Username, string Password)
        {
            SQLAccess sql2 = new SQLAccess();
            DataTable dt = new DataTable();
            sql2.StoredProcedureName = SQLAccess.StoredProcedure.prcCheckLogin2.ToString();
            string userEncr, passEncr;

            userEncr = Encrypt(Username.Trim(), true, "");
            passEncr = Encrypt(Password.Trim(), true, "");

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@Username";
            newparams[1, 0] = "@Password";

            newparams[0, 1] = userEncr;
            newparams[1, 1] = passEncr;

            dt = sql2.ExcecuteQueryToDataTable(newparams);


            if (dt.Rows[0]["UserImage"] != DBNull.Value)
            {
                User.UserImageData = (byte[])dt.Rows[0]["UserImage"];
            }
            else
            {
                User.UserImage = Properties.Resources.unknown;
                User.UserImageData = imageToByteArray(User.UserImage);
            }
        }

        private string HashMD5(string PlainText)
        {
            MD5 md5hash = MD5.Create();
            string hash = GetMd5Hash(md5hash, PlainText);
            return hash;
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public void GetEventList()
        {
            SQLAccess sql3 = new SQLAccess();
            string stp = SQLAccess.StoredProcedure.prcGetNonShownEventList.ToString();
            DataTable dt_events = new DataTable();
            dt_events = sql3.GetNoneShowEventList(stp);
            for (int i = 0; i < dt_events.Rows.Count; i++)
            {
                Program.EventList.Add(new Events());
                Program.EventList[i].AgentId = dt_events.Rows[i]["AgentId"].ToString();
                Program.EventList[i].CurrentValue = dt_events.Rows[i]["CurrentValue"].ToString();
                Program.EventList[i].Date = GetEventDateFromSql(dt_events.Rows[i]["EventDateTime"].ToString());
                // Program.EventList[i].Description = dt.Rows[i]["SubjectDes"].ToString();
                Program.EventList[i].Id = dt_events.Rows[i]["Id"].ToString();
                Program.EventList[i].LastValue = dt_events.Rows[i]["LastValue"].ToString();
                Program.EventList[i].SubjectId = dt_events.Rows[i]["SubjectId"].ToString();
                Program.EventList[i].Time = GetTimeFromSql(dt_events.Rows[i]["EventDateTime"].ToString());
                Program.EventList[i].EventId = dt_events.Rows[i]["EventId"].ToString();
                Program.EventList[i].Shown = dt_events.Rows[i]["Shown"].ToString();
                Program.EventList[i].LevelId = dt_events.Rows[i]["LevelId"].ToString();

            }
        }

        public DataTable GetAlertId(string AgentId, string SubjectId)
        {
            SQLAccess sql4 = new SQLAccess();
            DataTable dt = new DataTable();
            dt = null;
            if (Program.AgentList.Count > 0)
            {

                int index = Program.AgentList.FindIndex(item => item.AgentID == AgentId);
                string AlertProfileId = Program.AgentList[index].AlertProfileId;
                sql4.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAlertId.ToString();

                string[,] newparams = new string[2, 2];

                newparams[0, 0] = "@SubjectId";
                newparams[1, 0] = "@ProfileId";

                newparams[0, 1] = SubjectId;
                newparams[1, 1] = AlertProfileId;

                dt = sql4.GetAlertId(newparams);
            }

            return dt;
        }

        public DataTable GetNonShownAgentEvents(string AgentId)
        {
            SQLAccess sql5 = new SQLAccess();
            sql5.StoredProcedureName = SQLAccess.StoredProcedure.prcGetNonShownAgentEventList.ToString();
            DataTable dt = new DataTable();
            dt = sql5.GetAgentNoneShowEventList(AgentId);
            return dt;
        }

        public DataTable GetUserList()
        {
            SQLAccess sql6 = new SQLAccess();
            DataTable dt = new DataTable();
            DataTable dtFinal = new DataTable();
            sql6.StoredProcedureName = SQLAccess.StoredProcedure.prcGetUserList.ToString();
            dt = sql6.ExcecuteQueryToDataTable();
            dtFinal = FinalUserDataTable(dt);
            return dtFinal;
        }

      
        private DataTable FinalUserDataTable(DataTable DT)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID");
            dt.Columns.Add("Username");
            dt.Columns.Add("PassW");
            dt.Columns.Add("Firstname");
            dt.Columns.Add("Lastname");
            dt.Columns.Add("Email");
            dt.Columns.Add("Number");
            dt.Columns.Add("UserImage", typeof(byte[]));
            dt.Columns.Add("PersonelCode");
            dt.Columns.Add("JobTitle");
            dt.Columns.Add("ClassifyID");
            dt.Columns.Add("TypeID");
            dt.Columns.Add("AclProfileId");
            dt.Columns.Add("AclProfileTitle");


            string UserID;
            string Username;
            string PassW;
            string Firstname;
            string Lastname;
            string Email;
            string Number;
            Image UserImage;
            byte[] imageData;
            string PersonelCode;
            string JobTitle;
            string ClassifyID;
            string Classify_ID;
            string TypeID;
            string AclProfileId;
            string AclProfileTitle;
          

            Unclassified = GetMessageFromDll(_langCode, "Unclassified");
            Restricted = GetMessageFromDll(_langCode, "Restricted");
            Confidential = GetMessageFromDll(_langCode, "Confidential");
            Secret = GetMessageFromDll(_langCode, "Secret");
            TopSecret = GetMessageFromDll(_langCode, "TopSecret");



            for (int i = 0; i < DT.Rows.Count; i++)
            {
                UserID = "";
                Username = "";
                PassW = "";
                Firstname = "";
                Lastname = "";
                Email = "";
                Number = "";
                UserImage = null;
                imageData = null;
                PersonelCode = "";
                JobTitle = "";
                ClassifyID = "";
                Classify_ID = "";
                TypeID = "";
                AclProfileId = "";
                AclProfileTitle = "";
             
            

                UserID = DT.Rows[i]["UserID"].ToString();
                Username = Decrypt(DT.Rows[i]["Username"].ToString(), true, "");
                PassW = Decrypt(DT.Rows[i]["PassW"].ToString(), true, "");
                Firstname = DT.Rows[i]["Firstname"].ToString();
                if (DT.Rows[i]["Lastname"] != DBNull.Value)
                    Lastname = DT.Rows[i]["Lastname"].ToString();
                if (DT.Rows[i]["Email"] != DBNull.Value)
                    Email = DT.Rows[i]["Email"].ToString();
                if (DT.Rows[i]["Number"] != DBNull.Value)
                    Number = DT.Rows[i]["Number"].ToString();
                if (DT.Rows[i]["UserImage"] != DBNull.Value)
                {
                    imageData = (byte[])DT.Rows[i]["UserImage"];
                }
                else
                {
                    UserImage = Properties.Resources.unknown;
                    imageData = imageToByteArray(UserImage);
                }
                if (DT.Rows[i]["PersonelCode"] != DBNull.Value)
                    PersonelCode = DT.Rows[i]["PersonelCode"].ToString();
                if (DT.Rows[i]["JobTitle"] != DBNull.Value)
                    JobTitle = DT.Rows[i]["JobTitle"].ToString();
                Classify_ID = DT.Rows[i]["ClassifyID"].ToString();
                ClassifyID = GetClassifyIDValue(Classify_ID);
                TypeID = DT.Rows[i]["TypeID"].ToString();
                AclProfileId = DT.Rows[i]["AclProfileId"].ToString();
                AclProfileTitle = GetAclObjectsHeaderProfile(AclProfileId);
                if (AclProfileTitle == "Default")
                    AclProfileTitle = GetMessageFromDll(_langCode, "DefaultProfile");



                dt.Rows.Add(UserID, Username, PassW, Firstname, Lastname, Email, Number, imageData, PersonelCode, JobTitle,
                            ClassifyID, TypeID, AclProfileId, AclProfileTitle);

            }

            return dt;
        }

        private string GetClassifyIDValue(string ClassifyID)
        {
            string res = "";

            if (ClassifyID == "1")
                res = Unclassified;
            if (ClassifyID == "2")
                res = Restricted;
            if (ClassifyID == "3")
                res = Confidential;
            if (ClassifyID == "4")
                res = Secret;
            if (ClassifyID == "5")
                res = TopSecret;

            return res;
        }

        public byte[] imageToByteArray2(System.Drawing.Image imageIn2)
        {
            MemoryStream ms2 = new MemoryStream();
            imageIn2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms2.ToArray();
          
        }


        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();       
        }

        public byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        public DataTable GetBuldingList()
        {
            SQLAccess sql7 = new SQLAccess();
            sql7.StoredProcedureName = SQLAccess.StoredProcedure.prcGetBuldingList.ToString();
            DataTable dt = new DataTable();
            dt = sql7.ExcecuteQueryToDataTable();
            return dt;
        }

        public DataTable GetClassList()
        {
            SQLAccess sql8 = new SQLAccess();
            sql8.StoredProcedureName = SQLAccess.StoredProcedure.prcGetClassList.ToString();
            DataTable dt = new DataTable();
            dt = sql8.ExcecuteQueryToDataTable();
            return dt;
        }

        public DataTable GetDepartmentList()
        {
            SQLAccess sql9 = new SQLAccess();
            sql9.StoredProcedureName = SQLAccess.StoredProcedure.prcGetDepartmentList.ToString();
            DataTable dt = new DataTable();
            dt = sql9.ExcecuteQueryToDataTable();
            return dt;
        }

        public DataTable GetRoomList()
        {
            SQLAccess sql10 = new SQLAccess();
            sql10.StoredProcedureName = SQLAccess.StoredProcedure.prcGetRoomList.ToString();
            DataTable dt = new DataTable();
            dt = sql10.ExcecuteQueryToDataTable();
            return dt;
        }

        public DataTable GetAgentOnWork(string AgentId, string FromDate, string ToDate)
        {
            SQLAccess sql11 = new SQLAccess();
            sql11.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentOnWork.ToString();
            DataTable dt = new DataTable();

            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@AgentId";
            newparams[1, 0] = "@FromDate";
            newparams[2, 0] = "@ToDate";

            newparams[0, 1] = AgentId;
            newparams[1, 1] = FromDate;
            newparams[2, 1] = ToDate;

            dt = sql11.ExcecuteQueryToDataTable(newparams);
            return dt;
        }





        public DataTable GetAgentAllEvents(string AgentId, string FromDate, string ToDate)
        {
            SQLAccess sql12 = new SQLAccess();
            sql12.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentAllEvents.ToString();
            DataTable dt = new DataTable();

            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@AgentId";
            newparams[1, 0] = "@FromDate";
            newparams[2, 0] = "@ToDate";

            newparams[0, 1] = AgentId;
            newparams[1, 1] = FromDate;
            newparams[2, 1] = ToDate;

            dt = sql12.ExcecuteQueryToDataTable(newparams);
            return dt;
        }

        public bool HaveEvent(string AgentId)
        {
            SQLAccess sql13 = new SQLAccess();
            bool _result = false;
            sql13.StoredProcedureName = SQLAccess.StoredProcedure.prcGetNonShownAgentEventList.ToString();
            DataTable dt = new DataTable();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            dt = sql13.GetAgentNoneShowEventList(newparams);

            if (dt.Rows.Count > 0)
            {
                _result = true;
            }
            return _result;
        }

        public string[,] GetAgentList()
        {
            SQLAccess sql14 = new SQLAccess();
            string[,] _list;
            sql14.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentList.ToString();
            DataTable _dt = new DataTable();
            _dt = sql14.ExcecuteQueryToDataTable();
            _list = new string[_dt.Rows.Count, 9];

            //Scheme.AgentsCount = _dt.Rows.Count;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                _list[i, 0] = _dt.Rows[i]["AgentId"].ToString();
                _list[i, 1] = _dt.Rows[i]["AgentNumber"].ToString();
                _list[i, 2] = _dt.Rows[i]["ComputerName"].ToString();
                _list[i, 3] = _dt.Rows[i]["Caption"].ToString();
                _list[i, 4] = _dt.Rows[i]["BuildNumber"].ToString();
                _list[i, 5] = _dt.Rows[i]["Uuid"].ToString();
                _list[i, 6] = _dt.Rows[i]["Organization"].ToString();
                _list[i, 7] = _dt.Rows[i]["RegisterCompany"].ToString();
                _list[i, 8] = _dt.Rows[i]["RegisterUser"].ToString();
            }
            return _list;
        }

        public void CheckAgentList()
        {
            SQLAccess sql15 = new SQLAccess();
            sql15.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentMainList.ToString();
            DataTable _dt = new DataTable();
            _dt = sql15.ExcecuteQueryToDataTable();

            if (_dt.Rows.Count > Program.TotalAgentRegistered)
            {
                int _newAgent;

                _newAgent = _dt.Rows.Count - Program.TotalAgentRegistered;
                int t = Program.TotalAgentRegistered;
                for (int i = 0; i < _newAgent; i++)
                {
                    DataRow dr = _dt.Rows[t + i];
                    InsetAgentToAgentList(dr, t + i);
                    SetAgentAlertProfileDetailInfo(t + i);
                    SetAgentAclProfileDetailInfo(t + i);
                    dr = null;
                    Program.TotalAgentRegistered++;
                }
            }
        }

        public void InsetAgentToAgentList(DataRow DR, int Index)
        {
            int i = Index;
            string DefaultProfile = GetMessageFromDll(Program.LangCode.ToString(), "DefaultProfile");
            Program.AgentList.Add(new Agents());

            Program.AgentList[i].AgentMainIndex = i;

            Program.AgentList[i].AgentID = DR["AgentID"].ToString();
            Program.AgentList[i].ComputerName = DR["ComputerName"].ToString();
            Program.AgentList[i].Status = GetAgentStatus(DR["NowStatus"].ToString());
            Program.AgentList[i].AgentType = DR["ChassisType"].ToString();
            if (DR["IdleDuration"] != DBNull.Value)
            {
                Program.AgentList[i].IdleDuration = GetIdleDuration(DR["IdleDuration"].ToString(), DR["NowStatus"].ToString());
            }
            else
                Program.AgentList[i].IdleDuration = null;

            if (DR["RoomTitle"] != DBNull.Value)
            {
                Program.AgentList[i].RoomId = Convert.ToInt32(DR["RoomID"].ToString());
                Program.AgentList[i].RoomTitle = DR["RoomTitle"].ToString();
            }
            else
            {
                Program.AgentList[i].RoomId = 0;
                Program.AgentList[i].RoomTitle = null;
            }

            if (DR["BuildingTitle"] != DBNull.Value)
            {
                Program.AgentList[i].BuildingId = Convert.ToInt32(DR["BuildingID"].ToString());
                Program.AgentList[i].BuildingTitle = DR["BuildingTitle"].ToString();
            }
            else
            {
                Program.AgentList[i].BuildingId = 0;
                Program.AgentList[i].BuildingTitle = null;
            }

            if (DR["DepartmentTitle"] != DBNull.Value)
            {
                Program.AgentList[i].DepartmentId = Convert.ToInt32(DR["DepartmentID"].ToString());
                Program.AgentList[i].DepartmentTitle = DR["DepartmentTitle"].ToString();
            }
            else
            {
                Program.AgentList[i].DepartmentId = 0;
                Program.AgentList[i].DepartmentTitle = null;
            }

            if (DR["ClassTitle"] != DBNull.Value)
            {
                Program.AgentList[i].ClassId = Convert.ToInt32(DR["ClassID"].ToString());
                Program.AgentList[i].ClassTitle = DR["ClassTitle"].ToString();
            }
            else
            {
                Program.AgentList[i].ClassId = 0;
                Program.AgentList[i].ClassTitle = null;
            }

            if (DR["FirstName"] != DBNull.Value)
                Program.AgentList[i].PersonnelFName = DR["FirstName"].ToString();
            else
                Program.AgentList[i].PersonnelFName = "";

            if (DR["LastName"] != DBNull.Value)
                Program.AgentList[i].PersonnelLName = DR["LastName"].ToString();
            else
                Program.AgentList[i].PersonnelLName = "";



            if (DR["AclProfileId"] != DBNull.Value)
            {
                Program.AgentList[i].AclProfileId = DR["AclProfileId"].ToString();
                Program.AgentList[i].AclProfileName = GetAclProfileName(Program.AgentList[i].AclProfileId);
            }
            else
            {
                Program.AgentList[i].AclProfileId = "1";
                Program.AgentList[i].AclProfileName = DefaultProfile;
            }

            if (DR["SettingProfileId"] != DBNull.Value)
            {
                Program.AgentList[i].SettingProfileId = DR["SettingProfileId"].ToString();
                Program.AgentList[i].SettingProfileName = GetSettingProfileName(Program.AgentList[i].SettingProfileId);
            }
            else
            {
                Program.AgentList[i].SettingProfileId = "1";
                Program.AgentList[i].SettingProfileName = DefaultProfile;

            }

            if (DR["AlertProfileId"] != DBNull.Value)
            {
                Program.AgentList[i].AlertProfileId = DR["AlertProfileId"].ToString();
                Program.AgentList[i].AlertProfileName = GetAlertProfileName(Program.AgentList[i].AlertProfileId);
            }
            else
            {
                Program.AgentList[i].AlertProfileId = "1";
                Program.AgentList[i].AlertProfileName = DefaultProfile;
            }
        }

        public void FirstGetAgentMainList()
        {
            SQLAccess sql16 = new SQLAccess();
            _onWork = GetMessageFromDll(_langCode, "OnWork");
            _minute = GetMessageFromDll(_langCode, "Minute");
            _off = GetMessageFromDll(_langCode, "SystemOff");
            _standby = GetMessageFromDll(_langCode, "SystemStandby");
            string _info = GetMessageFromDll(_langCode, "Information");
            string _warning = GetMessageFromDll(_langCode, "Warning");
            string _normal = GetMessageFromDll(_langCode, "Normal");

            sql16.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentMainList.ToString();
            DataTable _dt = new DataTable();
            _dt = sql16.ExcecuteQueryToDataTable();

            Program.TotalAgentRegistered = _dt.Rows.Count;
            Program.AgentList = new List<Agents>(Program.AgentCount);
            Program.dataSource = new BindingList<AgentView>();
            int index = 0;

            if (_dt.Rows.Count > 0 && _dt.Rows.Count <= Program.AgentCount)
            {
                index = _dt.Rows.Count;
            }
            if (_dt.Rows.Count > 0 && _dt.Rows.Count > Program.AgentCount)
            {
                index = Program.AgentCount;
            }

          

            byte[] imageData;
            string DefaultProfile = GetMessageFromDll(Program.LangCode.ToString(), "DefaultProfile");
            string AgentId = "";
            int AgentListIndex = 0;
            string ComputerName = "";
            string Status = "";
            Image UserImage = null;
            string UserFullName = "";
            Image AlertImageIcon = null;
            string AgentIP = "";
            string Room = "";
            string Buildding = "";
            string Department = "";
            string ClassTitle = "";
            string IdleTime = "";
            string Alias = "";
            string SettingProfileName = "";
            string AlertProfileName = "";
            string Alert = "";
            string SystemType = "";
            Image AgentSystemType = null;
            

            System.Windows.Forms.ImageList imlPerssonel = new System.Windows.Forms.ImageList();
            imlPerssonel.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imlPerssonel.ImageSize = new Size(200, 100);
            System.Windows.Forms.ImageList imlLargeImage = new System.Windows.Forms.ImageList();
            System.Windows.Forms.ImageList imlAlert = new System.Windows.Forms.ImageList();
            imlAlert.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            imlAlert.ImageSize = new Size(16, 16);


            imlPerssonel.Images.Add("UnKnown", Properties.Resources.unknown);
            imlLargeImage.Images.Add("Desktop", Properties.Resources.Desktop);
            imlLargeImage.Images.Add("Labtop", Properties.Resources.Laptop);
            imlAlert.Images.Add("RedAlert", Properties.Resources.RedWarning);
            imlAlert.Images.Add("YelloAlert", Properties.Resources.YelloWarning);
            imlAlert.Images.Add("Ok", Properties.Resources.ActionSuccess);


            for (int i = 0; i < index; i++)
            {
                AgentId = "";
                AgentListIndex = 0;
                ComputerName = "";
                Status = "";
                UserImage = null;
                UserFullName = "";
                AlertImageIcon = null;
                AgentIP = "";
                Room = "";
                Buildding = "";
                Department = "";
                ClassTitle = "";
                IdleTime = "";
                Alias = "";
                SettingProfileName = "";
                AlertProfileName = "";
                Alert = "";
                SystemType = "";
                AgentSystemType = null;

                Program.AgentList.Add(new Agents());

                Program.AgentList[i].AgentMainIndex = i;
                AgentListIndex = i;

                Program.AgentList[i].AgentID = _dt.Rows[i]["AgentId"].ToString();
                AgentId = Program.AgentList[i].AgentID;

                Program.AgentList[i].ComputerName = _dt.Rows[i]["ComputerName"].ToString();
                ComputerName = Program.AgentList[i].ComputerName;

                Program.AgentList[i].Status = GetAgentStatus(_dt.Rows[i]["NowStatus"].ToString());
                Status = Program.AgentList[i].Status;

                if (_dt.Rows[i]["UserImage"] != DBNull.Value)
                {
                    imageData = (byte[])_dt.Rows[i]["UserImage"];
                    Image perImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);

                        //Set image variable value using memory stream.
                        perImage = Image.FromStream(ms, true);
                    }

                    Program.AgentList[i].PersonnelImage = perImage;
                    imlPerssonel.Images.Add(Program.AgentList[i].AgentID, Program.AgentList[i].PersonnelImage);
                    UserImage = imlPerssonel.Images[Program.AgentList[i].AgentID];

                }
                else
                {
                    UserImage = imlPerssonel.Images["UnKnown"];
                    Program.AgentList[i].PersonnelImage = null;
                }

                Program.AgentList[i].AgentType = _dt.Rows[i]["ChassisType"].ToString();
                SystemType = Program.AgentList[i].AgentType;
                if (SystemType == "Labtop" || SystemType == "Notebook" || SystemType == "Portable")
                {
                    AgentSystemType = imlLargeImage.Images["Labtop"];

                }
                else
                {
                    AgentSystemType = imlLargeImage.Images["Desktop"];
                }


                if (_dt.Rows[i]["IdleDuration"] != DBNull.Value)
                {
                    Program.AgentList[i].IdleDuration = GetIdleDuration(_dt.Rows[i]["IdleDuration"].ToString(), _dt.Rows[i]["NowStatus"].ToString());
                    IdleTime = Program.AgentList[i].IdleDuration;
                }
                else
                    Program.AgentList[i].IdleDuration = null;




                if (_dt.Rows[i]["RoomTitle"] != DBNull.Value)
                {
                    Program.AgentList[i].RoomId = Convert.ToInt32(_dt.Rows[i]["RoomID"].ToString());
                    Program.AgentList[i].RoomTitle = _dt.Rows[i]["RoomTitle"].ToString();
                    Room = Program.AgentList[i].RoomTitle;
                }
                else
                {
                    Program.AgentList[i].RoomId = 0;
                    Program.AgentList[i].RoomTitle = null;
                }

                if (_dt.Rows[i]["BuildingTitle"] != DBNull.Value)
                {
                    Program.AgentList[i].BuildingId = Convert.ToInt32(_dt.Rows[i]["BuildingID"].ToString());
                    Program.AgentList[i].BuildingTitle = _dt.Rows[i]["BuildingTitle"].ToString();
                    Buildding = Program.AgentList[i].BuildingTitle;
                }
                else
                {
                    Program.AgentList[i].BuildingId = 0;
                    Program.AgentList[i].BuildingTitle = null;
                }

                if (_dt.Rows[i]["DepartmentTitle"] != DBNull.Value)
                {
                    Program.AgentList[i].DepartmentId = Convert.ToInt32(_dt.Rows[i]["DepartmentID"].ToString());
                    Program.AgentList[i].DepartmentTitle = _dt.Rows[i]["DepartmentTitle"].ToString();
                    Department = Program.AgentList[i].DepartmentTitle;
                }
                else
                {
                    Program.AgentList[i].DepartmentId = 0;
                    Program.AgentList[i].DepartmentTitle = null;
                }

                if (_dt.Rows[i]["ClassTitle"] != DBNull.Value)
                {
                    Program.AgentList[i].ClassId = Convert.ToInt32(_dt.Rows[i]["ClassID"].ToString());
                    Program.AgentList[i].ClassTitle = _dt.Rows[i]["ClassTitle"].ToString();
                    ClassTitle = Program.AgentList[i].ClassTitle;
                }
                else
                {
                    Program.AgentList[i].ClassId = 0;
                    Program.AgentList[i].ClassTitle = null;
                }

                if (_dt.Rows[i]["FirstName"] != DBNull.Value)
                    Program.AgentList[i].PersonnelFName = _dt.Rows[i]["FirstName"].ToString();
                else
                    Program.AgentList[i].PersonnelFName = "";

                if (_dt.Rows[i]["LastName"] != DBNull.Value)
                    Program.AgentList[i].PersonnelLName = _dt.Rows[i]["LastName"].ToString();
                else
                    Program.AgentList[i].PersonnelLName = "";

                UserFullName = Program.AgentList[i].PersonnelFName + " " + Program.AgentList[i].PersonnelLName;

                if (_dt.Rows[i]["AclProfileId"] != DBNull.Value)
                {
                    Program.AgentList[i].AclProfileId = _dt.Rows[i]["AclProfileId"].ToString();
                    Program.AgentList[i].AclProfileName = GetAclProfileName(Program.AgentList[i].AclProfileId);
                    
                }
                else
                {
                    Program.AgentList[i].AclProfileId = "1";
                    Program.AgentList[i].AclProfileName = DefaultProfile;
                }

                SetAgentAclProfileDetailInfo(i);

                if (_dt.Rows[i]["SettingProfileId"] != DBNull.Value)
                {
                    Program.AgentList[i].SettingProfileId = _dt.Rows[i]["SettingProfileId"].ToString();
                    Program.AgentList[i].SettingProfileName = GetSettingProfileName(Program.AgentList[i].SettingProfileId);
                    SettingProfileName = Program.AgentList[i].SettingProfileName;
                }
                else
                {
                    Program.AgentList[i].SettingProfileId = "1";
                    Program.AgentList[i].SettingProfileName = DefaultProfile;

                }

                if (_dt.Rows[i]["AlertProfileId"] != DBNull.Value)
                {
                    Program.AgentList[i].AlertProfileId = _dt.Rows[i]["AlertProfileId"].ToString();
                    Program.AgentList[i].AlertProfileName = GetAlertProfileName(Program.AgentList[i].AlertProfileId);
                    AlertProfileName = Program.AgentList[i].AlertProfileName;
                }
                else
                {
                    Program.AgentList[i].AlertProfileId = "1";
                    Program.AgentList[i].AlertProfileName = DefaultProfile;
                }



                AgentIP = GetFirstActiveIPV4(_dt.Rows[i]["IPAddress"].ToString());


                if (Program.AgentList[i].AlertLevelId != null)
                {
                    if (Program.AgentList[i].AlertLevelId == "1")
                    {
                        AlertImageIcon = imlAlert.Images["YelloAlert"];
                        Alert = _info;
                    }
                    if (Program.AgentList[i].AlertLevelId == "2")
                    {
                        AlertImageIcon = imlAlert.Images["RedAlert"];
                        Alert = _warning;
                    }
                    if (Program.AgentList[i].AlertLevelId == "3")
                    {
                        AlertImageIcon = imlAlert.Images["RedAlert"];
                        Alert = _warning;
                    }
                    if (Program.AgentList[i].AlertLevelId == "4")
                    {
                        AlertImageIcon = imlAlert.Images["RedAlert"];
                        Alert = _warning;
                    }
                }
                else
                {
                    AlertImageIcon = imlAlert.Images["Ok"];
                    Alert = _normal;
                }




                Program.dataSource.Add(new AgentView(AgentId, AgentListIndex, ComputerName, UserFullName, Alert, Status, UserImage, AlertImageIcon, AgentSystemType,
                                         AgentIP, Room, Buildding, Department, ClassTitle, IdleTime, Alias, SettingProfileName, AlertProfileName, SystemType));
                // System.Threading.Thread.Sleep(200);

                Program.AgentLoadedDataCount = i + 1;
            }

        }

        public bool HaveEvents(string AgentId, DataTable Dt)
        {
            bool res = false;
            try
            {
                DataTable results = Dt.Select("AgentId = " + AgentId).CopyToDataTable();
                res = true;
            }
            catch
            {
                res = false;
            }

            return res;
        }



        public void FirstGetAgentList()
        {
            SQLAccess sql17 = new SQLAccess();
            sql17.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentList.ToString();
            DataTable _dt = new DataTable();
            _dt = sql17.ExcecuteQueryToDataTable();

            Program.TotalAgentRegistered = _dt.Rows.Count;
            Program.AgentList = new List<Agents>(Program.AgentCount);
            int index = 0;

            if (_dt.Rows.Count > 0 && _dt.Rows.Count <= Program.AgentCount)
            {
                index = _dt.Rows.Count;
            }
            if (_dt.Rows.Count > 0 && _dt.Rows.Count > Program.AgentCount)
            {
                index = Program.AgentCount;
            }

            for (int i = 0; i < index; i++)
            {
                Program.AgentList.Add(new Agents());
                Program.AgentList[i].AgentMainIndex = i;
                Program.AgentList[i].AgentID = _dt.Rows[i]["AgentId"].ToString();
                Program.AgentList[i].AgentNumber = _dt.Rows[i]["AgentNumber"].ToString();
                Program.AgentList[i].ComputerName = _dt.Rows[i]["ComputerName"].ToString();
                Program.AgentList[i].Caption = _dt.Rows[i]["Caption"].ToString();
                Program.AgentList[i].UUID = _dt.Rows[i]["Uuid"].ToString();
                Program.AgentList[i].Organization = _dt.Rows[i]["Organization"].ToString();
                Program.AgentList[i].RegisterCompany = _dt.Rows[i]["RegisterCompany"].ToString();
                Program.AgentList[i].RegisteredUser = _dt.Rows[i]["RegisterUser"].ToString();
            }
        }

        public void RefreshAgentList()
        {
            Program.AgentList.Clear();
            Program.TotalAgentAvailable = 0;
            Program.TotalAgentUnavailable = 0;
            FirstGetAgentList();
            SetAgentGeneralInfo();
        }


        public string GetSubString(string OrginalString, string SubString)
        {
            string _s = "";
            int index = OrginalString.IndexOf(SubString);
            if (index != -1)
            {
                _s = OrginalString.Substring(index + SubString.Length);
            }
            return _s;
        }

        public int GetImageIndex(string AgentType)
        {
            int _index = 0;
            if (AgentType.IndexOf("Notebook") != -1)
            {
                _index = 0;
                return _index;
            }
            if (AgentType.IndexOf("Desktop") != -1)
            {
                _index = 1;
                return _index;
            }
            return _index;
        }

        public int GetImageIndex(string AgentType, string EventLevel)
        {
            int _index = 0;
            if (AgentType.IndexOf("Notebook") != -1)
            {
                if (EventLevel == "")
                {
                    _index = 0;
                    return _index;
                }
                if (EventLevel == "1") //Information
                {
                    _index = 2;
                    return _index;
                }
                if (EventLevel == "2") //Warning
                {
                    _index = 4;
                    return _index;
                }
                if (EventLevel == "3") //Critical
                {

                }
                if (EventLevel == "4") //Security Breach
                {

                }

            }
            if (AgentType.IndexOf("Desktop") != -1)
            {
                if (EventLevel == "")
                {
                    _index = 1;
                    return _index;
                }
                if (EventLevel == "1") //Information
                {
                    _index = 3;
                    return _index;
                }
                if (EventLevel == "2") //Warning
                {
                    _index = 5;
                    return _index;
                }
                if (EventLevel == "3") //Critical
                {

                }
                if (EventLevel == "4") //Security Breach
                {

                }

            }

            return _index;
        }

        public void SetCompanyInfo()
        {
            try
            {
                SQLAccess sql18 = new SQLAccess();
                sql18.StoredProcedureName = SQLAccess.StoredProcedure.prcGetCompanyInfo.ToString();
                DataTable _dt = new DataTable();
                _dt = sql18.ExcecuteQueryToDataTable();


                User.CompanyName = _dt.Rows[0]["CompanyName"].ToString();
                User.CompanyType = _dt.Rows[0]["CompanyType"].ToString();
                User.CompanyRegisterNumber = _dt.Rows[0]["CompanyRegisterNumber"].ToString();
                User.CompanyAddress = _dt.Rows[0]["CompanyAddress"].ToString();
                User.CompanyTelNumber = _dt.Rows[0]["CompanyTelNumber"].ToString();
                User.CompanyFaxNumber = _dt.Rows[0]["CompanyFaxNumber"].ToString();
            }
            catch (Exception)
            {
                User.CompanyName = "";
                User.CompanyType = "";
                User.CompanyRegisterNumber = "";
                User.CompanyAddress = "";
                User.CompanyTelNumber = "";
                User.CompanyFaxNumber = "";
                return;
            }
        }


        public void SetTodayDate()
        {
            User.MilaadyToday = DateTime.Today.Date.ToShortDateString();

            if (Program.LangCode == 1)
            {
                Persia.SunDate shamsi = Persia.Calendar.ConvertToPersian(DateTime.Now);
                User.LocalToday = shamsi.Simple;

            }
            else if (Program.LangCode == 3)
            {
                Persia.MoonDate ghamari = Persia.Calendar.ConvertToIslamic(DateTime.Now);
                User.LocalToday = ghamari.Simple;

            }
            else
            {
                User.LocalToday = DateTime.Today.Date.ToShortDateString();
            }
        }

        public void SetAgentGeneralInfo()
        {
            for (int m = 0; m < Program.AgentList.Count; m++)
            {
                // SetAgentPublicInfo(m);
                //SetAgentCpuInfo(m);
                // SetAgentNetworkInfo(m);
                // SetAgentOsInfo(m);
                // SetAgentMemoryInfo(m);
                //SetAgentMotherboardInfo(m);
                // SetAgentVideocardInfo(m);
                // SetAgentHardDiskInfo(m);
                // SetAgentSettingProfileInfo(m);
                // SetAgentAlertProfileInfo(m);
                // SetAgentAlertProfileDetailInfo(m);
                //SetAgentAclProfileInfo(m);
                SetAgentAclProfileDetailInfo(m);
                //SetAgentEventInfo(m);
                //SetAgentPersonnelInfo(m);
                //SetAgentLocationInfo(m);
            }
        }

        private void SetAgentLocationInfo(int AgentListIndex)
        {
            SQLAccess sql19 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql19.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentLocation.ToString();
            dt = sql19.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            if (dt.Rows.Count > 0)
            {
                Program.AgentList[m].BuildingId = Convert.ToInt32(dt.Rows[0]["BuildingId"].ToString());
                Program.AgentList[m].BuildingTitle = dt.Rows[0]["BuildingTitle"].ToString();
                Program.AgentList[m].ClassId = Convert.ToInt32(dt.Rows[0]["ClassId"].ToString());
                Program.AgentList[m].ClassTitle = dt.Rows[0]["ClassTitle"].ToString();
                Program.AgentList[m].RoomId = Convert.ToInt32(dt.Rows[0]["RoomId"].ToString());
                Program.AgentList[m].RoomTitle = dt.Rows[0]["RoomTitle"].ToString();
                Program.AgentList[m].DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"].ToString());
                Program.AgentList[m].DepartmentTitle = dt.Rows[0]["DepartmentTitle"].ToString();
            }
        }

        public void SetAgentPublicInfo(int AgentListIndex)
        {
            DataTable dt = new DataTable();
            SQLAccess sql20 = new SQLAccess();
            int m = AgentListIndex;
            _onWork = GetMessageFromDll(_langCode, "OnWork");
            _minute = GetMessageFromDll(_langCode, "Minute");
            _off = GetMessageFromDll(_langCode, "SystemOff");
            _standby = GetMessageFromDll(_langCode, "SystemStandby");

            sql20.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentStatus.ToString();
            dt = sql20.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);

            string agentStatus = dt.Rows[0]["NowStatus"].ToString();
            string agentCurrentAccount = dt.Rows[0]["CurrentLogin"].ToString();
            string agentDuration = dt.Rows[0]["StartupDuration"].ToString();
            string agentIdleDuration = dt.Rows[0]["IdleDuration"].ToString();

            Program.AgentList[m].Status = GetAgentStatus(agentStatus);
            Program.AgentList[m].CurrentAccount = GetCurrentAccount(agentCurrentAccount);
            Program.AgentList[m].StartupDate = GetStartupDate(agentDuration);
            Program.AgentList[m].StartupTime = GetStratupTime(agentDuration);
            Program.AgentList[m].IdleDuration = GetIdleDuration(agentIdleDuration, agentStatus);


            sql20.StoredProcedureName = SQLAccess.StoredProcedure.prcGetChassis.ToString();
            dt = sql20.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            string agentType = dt.Rows[0]["ChassisType"].ToString();
            Program.AgentList[m].AssetTagNumber = dt.Rows[0]["AssetTagNumber"].ToString();

            Program.AgentList[m].AgentType = agentType;
        }

        public string GetIdleDuration(string agentIdleDuration, string agentStatus)
        {
            string result = "";
            if (agentIdleDuration == "" || agentIdleDuration == "0")
            {
                if (agentStatus == "1")
                    result = _onWork;
                if (agentStatus == "2")
                    result = _off;
                if (agentStatus == "3")
                    result = _standby;
            }
            else
            {
                result = agentIdleDuration + " " + _minute;
            }
            return result;
        }

        public void SetAgentCpuInfo(int AgentListIndex)
        {
            SQLAccess sql21 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql21.StoredProcedureName = SQLAccess.StoredProcedure.prcGetProcessors.ToString();
            dt = sql21.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            int _rowCount = dt.Rows.Count;
            Program.AgentList[m].CpuBrand = new string[_rowCount];
            Program.AgentList[m].VendorID = new string[_rowCount];
            Program.AgentList[m].BrandID = new string[_rowCount];
            Program.AgentList[m].ProcessorType = new string[_rowCount];
            Program.AgentList[m].CpuSerialNumber = new string[_rowCount];
            Program.AgentList[m].SteppingID = new string[_rowCount];
            Program.AgentList[m].CpuModelNumber = new string[_rowCount];
            Program.AgentList[m].FamilyCode = new string[_rowCount];
            Program.AgentList[m].ExtendedModel = new string[_rowCount];
            Program.AgentList[m].ExtendedFamily = new string[_rowCount];
            Program.AgentList[m].Chunks = new string[_rowCount];
            Program.AgentList[m].Counts = new string[_rowCount];
            Program.AgentList[m].APICID = new string[_rowCount];
            Program.AgentList[m].MMX = new string[_rowCount];
            Program.AgentList[m].FxsaveFxrstorInstructions = new string[_rowCount];
            Program.AgentList[m].SSE = new string[_rowCount];
            Program.AgentList[m].SSE2 = new string[_rowCount];
            Program.AgentList[m].ExtendedCPUID = new string[_rowCount];
            Program.AgentList[m].LargestFunctionSupported = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                Program.AgentList[m].CpuBrand[i] = dt.Rows[i]["Brand"].ToString();
            }

        }

        public void SetAgentNetworkInfo(int AgentListIndex)
        {
            SQLAccess sql22 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql22.StoredProcedureName = SQLAccess.StoredProcedure.prcGetActiveNetworkSetting.ToString();
            dt = sql22.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            int _rowCount = dt.Rows.Count;

            Program.AgentList[m].ActiveNetworkAdapterCaption = new string[_rowCount];
            Program.AgentList[m].IPAddress = new string[_rowCount];
            Program.AgentList[m].MacAddress = new string[_rowCount];
            Program.AgentList[m].DefaultGW = new string[_rowCount];
            Program.AgentList[m].SubnetMask = new string[_rowCount];
            Program.AgentList[m].DNSServer = new string[_rowCount];
            Program.AgentList[m].DHCPEnabled = new string[_rowCount];
            Program.AgentList[m].DHCPServer = new string[_rowCount];


            for (int i = 0; i < _rowCount; i++)
            {
                Program.AgentList[m].ActiveNetworkAdapterCaption[i] = dt.Rows[i]["Caption"].ToString();
                Program.AgentList[m].IPAddress[i] = dt.Rows[i]["IPAddress"].ToString();
                Program.AgentList[m].MacAddress[i] = dt.Rows[i]["MACAddress"].ToString();
                Program.AgentList[m].DefaultGW[i] = dt.Rows[i]["DefaultGateway"].ToString();
                Program.AgentList[m].SubnetMask[i] = dt.Rows[i]["SubnetMask"].ToString();
                Program.AgentList[m].DNSServer[i] = dt.Rows[i]["DNSHostName"].ToString();
                Program.AgentList[m].DHCPEnabled[i] = dt.Rows[i]["DHCPEnable"].ToString();
                Program.AgentList[m].DHCPServer[i] = dt.Rows[i]["DHCPServerIP"].ToString();
            }
        }

        public void SetAgentOsInfo(int AgentListIndex)
        {
            SQLAccess sql23 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql23.StoredProcedureName = SQLAccess.StoredProcedure.prcGetOS.ToString();
            dt = sql23.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            Program.AgentList[m].OSSerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            Program.AgentList[m].OSBuildNumber = dt.Rows[0]["BuildNumber"].ToString();
            Program.AgentList[m].FreePhysicalMemory = dt.Rows[0]["FreePhysicalMemory"].ToString();
            Program.AgentList[m].InstallDate = dt.Rows[0]["InstallDate"].ToString();
            Program.AgentList[m].Caption = dt.Rows[0]["Caption"].ToString();
            Program.AgentList[m].RegisteredUser = dt.Rows[0]["RegisterUser"].ToString();
            Program.AgentList[m].Version = dt.Rows[0]["Versions"].ToString();
        }

        public void SetAgentMemoryInfo(int AgentListIndex)
        {
            SQLAccess sql24 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql24.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMemory.ToString();
            dt = sql24.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            int _rowCount = dt.Rows.Count;

            Program.AgentList[m].Memory = new string[_rowCount];
            Program.AgentList[m].BankLabel = new string[_rowCount];
            Program.AgentList[m].Speed = new string[_rowCount];
            Program.AgentList[m].MemorySerialNumber = new string[_rowCount];
            Program.AgentList[m].MemoryTableId = new string[_rowCount];
            Program.AgentList[m].MemoryModel = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                Program.AgentList[m].Memory[i] = dt.Rows[i]["Capacity"].ToString();
                Program.AgentList[m].MemorySerialNumber[i] = dt.Rows[i]["SerialNumber"].ToString();
                Program.AgentList[m].MemoryTableId[i] = dt.Rows[i]["Id"].ToString();
                Program.AgentList[m].MemoryModel[i] = dt.Rows[i]["Model"].ToString();
                Program.AgentList[m].Speed[i] = dt.Rows[i]["Speed"].ToString();

            }
        }

        public void SetAgentMotherboardInfo(int AgentListIndex)
        {
            SQLAccess sql25 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql25.StoredProcedureName = SQLAccess.StoredProcedure.prcGetMotherboard.ToString();
            dt = sql25.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            Program.AgentList[m].MotherboardCaption = dt.Rows[0]["Manufactorer"].ToString();
            Program.AgentList[m].MotherboardModel = dt.Rows[0]["Product"].ToString();
            Program.AgentList[m].MotherboardSerialNumber = dt.Rows[0]["SerialNumber"].ToString();
            Program.AgentList[m].MotherboardVersion = dt.Rows[0]["Version"].ToString();
        }

        public void SetAgentVideocardInfo(int AgentListIndex)
        {
            SQLAccess sql26 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql26.StoredProcedureName = SQLAccess.StoredProcedure.prcGetVideoCard.ToString();
            dt = sql26.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            int _rowCount = dt.Rows.Count;
            Program.AgentList[m].VideoCard = new string[_rowCount];
            Program.AgentList[m].DriverDate = new string[_rowCount];
            Program.AgentList[m].DriverVersion = new string[_rowCount];
            Program.AgentList[m].VideoModeDescription = new string[_rowCount];
            Program.AgentList[m].VideoProcessor = new string[_rowCount];
            Program.AgentList[m].AdapterRAM = new string[_rowCount];
            Program.AgentList[m].VideoCardSerialNumber = new string[_rowCount];
            Program.AgentList[m].VideoCardTableId = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                Program.AgentList[m].VideoCard[i] = dt.Rows[i]["Caption"].ToString();
            }
        }

        public void SetAgentHardDiskInfo(int AgentListIndex)
        {
            SQLAccess sql27 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql27.StoredProcedureName = SQLAccess.StoredProcedure.prcGetHardDisk.ToString();
            dt = sql27.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            int _rowCount = dt.Rows.Count;
            Program.AgentList[m].HardDisk = new string[_rowCount];
            Program.AgentList[m].HardDiskSignature = new string[_rowCount];
            Program.AgentList[m].HardDiskSize = new string[_rowCount];
            Program.AgentList[m].HardDiskPartitions = new string[_rowCount];
            Program.AgentList[m].HardDiskPNPDeviceID = new string[_rowCount];
            Program.AgentList[m].HardDiskSerialNumber = new string[_rowCount];

            for (int i = 0; i < _rowCount; i++)
            {
                Program.AgentList[m].HardDisk[i] = dt.Rows[i]["Caption"].ToString();
            }
        }

        public void SetAgentSettingProfileInfo(int AgentListIndex)
        {
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            dt = GetAgentSettingProfile(Program.AgentList[m].AgentID);
            if (dt.Rows.Count > 0)
            {
                Program.AgentList[m].SettingProfileId = dt.Rows[0]["SettingProfileId"].ToString();
                Program.AgentList[m].SettingProfileName = GetSettingProfileName(Program.AgentList[m].SettingProfileId);
            }
            else
            {
                Program.AgentList[m].SettingProfileId = "1";
                Program.AgentList[m].SettingProfileName = GetMessageFromDll(Program.LangCode.ToString(), "DefaultProfile");
            }
        }

        public void SetAgentAlertProfileInfo(int AgentListIndex)
        {
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            dt = GetAgentAlertProfile(Program.AgentList[m].AgentID);
            if (dt.Rows.Count > 0)
            {
                Program.AgentList[m].AlertProfileId = dt.Rows[0]["AlertProfileId"].ToString();
                Program.AgentList[m].AlertProfileName = GetAlertProfileName(Program.AgentList[m].AlertProfileId);
            }
            else
            {
                Program.AgentList[m].AlertProfileId = "1";
                Program.AgentList[m].AlertProfileName = GetMessageFromDll(Program.LangCode.ToString(), "DefaultProfile");
            }
        }

        public void SetAgentAclProfileInfo(int AgentListIndex)
        {
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            dt = GetAgentAclProfile(Program.AgentList[m].AgentID);
            if (dt.Rows.Count > 0)
            {
                Program.AgentList[m].AclProfileId = dt.Rows[0]["AlertProfileId"].ToString();
                Program.AgentList[m].AclProfileName = GetAclProfileName(Program.AgentList[m].AlertProfileId);
            }
            else
            {
                Program.AgentList[m].AlertProfileId = "1";
                Program.AgentList[m].AlertProfileName = GetMessageFromDll(Program.LangCode.ToString(), "DefaultProfile");
            }
        }

        public void SetAgentList()
        {
            int lenght;

            Program.AgentList = new List<Agents>(Program.AgentCount);

            string[,] _header = GetAgentList();
            lenght = _header.Length / 9;

            if (lenght <= Program.AgentCount)
            {
                for (int i = 0; i < lenght; i++)
                {
                    Program.AgentList.Add(new Agents());
                    Program.AgentList[i].AgentID = _header[i, 0];
                    Program.AgentList[i].AgentNumber = _header[i, 1];
                    Program.AgentList[i].ComputerName = _header[i, 2];
                    Program.AgentList[i].Caption = _header[i, 3];

                    Program.AgentList[i].UUID = _header[i, 5];
                    Program.AgentList[i].Organization = _header[i, 6];
                    Program.AgentList[i].RegisterCompany = _header[i, 7];
                    Program.AgentList[i].RegisteredUser = _header[i, 8];

                }
            }
            else
            {
                for (int i = 0; i < Program.AgentCount; i++)
                {
                    Program.AgentList.Add(new Agents());
                    Program.AgentList[i].AgentID = _header[i, 0];
                    Program.AgentList[i].AgentNumber = _header[i, 1];
                    Program.AgentList[i].ComputerName = _header[i, 2];
                    Program.AgentList[i].Caption = _header[i, 3];

                    Program.AgentList[i].UUID = _header[i, 5];
                    Program.AgentList[i].Organization = _header[i, 6];
                    Program.AgentList[i].RegisterCompany = _header[i, 7];
                    Program.AgentList[i].RegisteredUser = _header[i, 8];

                }
            }

            SetAgentGeneralInfo();
        }

        public void SetAgentSettingProfileDetailInfo(int AgentListIndex)
        {

        }

        public void SetAgentAlertProfileDetailInfo(int AgentListIndex)
        {
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            dt = GetAgentAlertProfileDetails(Program.AgentList[m].AlertProfileId);
            int _r = dt.Rows.Count;
            Program.AgentList[m].AlertSubjectId = new string[_r];
            Program.AgentList[m].AlertId = new string[_r];
            Program.AgentList[m].Sound = new string[_r];
            Program.AgentList[m].SoundFileLocation = new string[_r];

            for (int i = 0; i < _r; i++)
            {
                Program.AgentList[m].AlertSubjectId[i] = dt.Rows[i]["SubjectId"].ToString();
                Program.AgentList[m].AlertId[i] = dt.Rows[i]["AlertId"].ToString();
                Program.AgentList[m].Sound[i] = dt.Rows[i]["SoundAlert"].ToString();
                if (Program.AgentList[m].SoundFileLocation[i] != null)
                {
                    Program.AgentList[m].SoundFileLocation[i] = dt.Rows[i]["SoundFilePath"].ToString();
                }
                else
                {
                    Program.AgentList[m].SoundFileLocation[i] = "";
                }
            }
        }

        public void SetAgentAclProfileDetailInfo(int AgentListIndex)
        {
            string _subjectId, _aclLevel;
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            dt = GetAgentAclProfileDetails(Program.AgentList[m].AclProfileId);
            int _r = dt.Rows.Count;

            for (int i = 0; i < _r; i++)
            {
                _subjectId = dt.Rows[i]["SubjectId"].ToString();
                _aclLevel = dt.Rows[i]["AclLevel"].ToString();
                SetAgentAcl(m, _subjectId, _aclLevel);
            }
        }

        public void SetAgentAcl(int AgentListIndex, string SubId, string Acl)
        {
            switch (SubId)
            {
                case "1":
                    {
                        Program.AgentList[AgentListIndex].acl1 = Convert.ToInt32(Acl);
                        break;
                    }
                case "2":
                    {
                        Program.AgentList[AgentListIndex].acl2 = Convert.ToInt32(Acl);
                        break;
                    }
                case "3":
                    {
                        Program.AgentList[AgentListIndex].acl3 = Convert.ToInt32(Acl);
                        break;
                    }
                case "4":
                    {
                        Program.AgentList[AgentListIndex].acl4 = Convert.ToInt32(Acl);
                        break;
                    }
                case "5":
                    {
                        Program.AgentList[AgentListIndex].acl5 = Convert.ToInt32(Acl);
                        break;
                    }
                case "6":
                    {
                        Program.AgentList[AgentListIndex].acl6 = Convert.ToInt32(Acl);
                        break;
                    }
                case "7":
                    {
                        Program.AgentList[AgentListIndex].acl7 = Convert.ToInt32(Acl);
                        break;
                    }
                case "8":
                    {
                        Program.AgentList[AgentListIndex].acl8 = Convert.ToInt32(Acl);
                        break;
                    }
                case "9":
                    {
                        Program.AgentList[AgentListIndex].acl9 = Convert.ToInt32(Acl);
                        break;
                    }
                case "10":
                    {
                        Program.AgentList[AgentListIndex].acl10 = Convert.ToInt32(Acl);
                        break;
                    }
                case "11":
                    {
                        Program.AgentList[AgentListIndex].acl11 = Convert.ToInt32(Acl);
                        break;
                    }
                case "12":
                    {
                        Program.AgentList[AgentListIndex].acl12 = Convert.ToInt32(Acl);
                        break;
                    }
                case "13":
                    {
                        Program.AgentList[AgentListIndex].acl13 = Convert.ToInt32(Acl);
                        break;
                    }
                case "14":
                    {
                        Program.AgentList[AgentListIndex].acl14 = Convert.ToInt32(Acl);
                        break;
                    }
                case "15":
                    {
                        Program.AgentList[AgentListIndex].acl15 = Convert.ToInt32(Acl);
                        break;
                    }
                case "16":
                    {
                        Program.AgentList[AgentListIndex].acl16 = Convert.ToInt32(Acl);
                        break;
                    }
                case "17":
                    {
                        Program.AgentList[AgentListIndex].acl17 = Convert.ToInt32(Acl);
                        break;
                    }
                case "18":
                    {
                        Program.AgentList[AgentListIndex].acl18 = Convert.ToInt32(Acl);
                        break;
                    }
                case "19":
                    {
                        Program.AgentList[AgentListIndex].acl19 = Convert.ToInt32(Acl);
                        break;
                    }
                case "20":
                    {
                        Program.AgentList[AgentListIndex].acl20 = Convert.ToInt32(Acl);
                        break;
                    }
                case "21":
                    {
                        Program.AgentList[AgentListIndex].acl21 = Convert.ToInt32(Acl);
                        break;
                    }
                case "22":
                    {
                        Program.AgentList[AgentListIndex].acl22 = Convert.ToInt32(Acl);
                        break;
                    }
                case "23":
                    {
                        Program.AgentList[AgentListIndex].acl23 = Convert.ToInt32(Acl);
                        break;
                    }
                case "24":
                    {
                        Program.AgentList[AgentListIndex].acl24 = Convert.ToInt32(Acl);
                        break;
                    }
                case "42":
                    {
                        Program.AgentList[AgentListIndex].acl42 = Convert.ToInt32(Acl);
                        break;
                    }
                case "43":
                    {
                        Program.AgentList[AgentListIndex].acl43 = Convert.ToInt32(Acl);
                        break;
                    }

            }
        }

        /*
        public void SetAgentEventInfo(int AgentListIndex)
        {
            DataTable dt = new DataTable();           
            int m = AgentListIndex;
            GetEventList();
            if (HaveEvent(Program.AgentList[m].AgentID))
            {

                sql.StoredProcedureName = SQLAccess.StoredProcedure.prcGetEvents.ToString();
                dt = sql.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
                int _rowCount = dt.Rows.Count;
                Program.AgentList[m].EventList = new List<Events>(_rowCount);


                for (int i = 0; i < _rowCount; i++)
                {
                    Program.AgentList[m].EventList.Add(new Events());

                    Program.AgentList[m].EventList[i].AgentId = dt.Rows[i]["AgentId"].ToString();
                    Program.AgentList[m].EventList[i].ComputerName = dt.Rows[i]["ComputerName"].ToString();
                    Program.AgentList[m].EventList[i].AlertId = dt.Rows[i]["AlertId"].ToString();
                    Program.AgentList[m].EventList[i].CurrentValue = dt.Rows[i]["CurrentValue"].ToString();
                    Program.AgentList[m].EventList[i].Date = GetEventDateFromSql(dt.Rows[i]["EventDateTime"].ToString());
                    Program.AgentList[m].EventList[i].Description = dt.Rows[i]["SubjectDes"].ToString();
                    Program.AgentList[m].EventList[i].Id = dt.Rows[i]["Id"].ToString();
                    Program.AgentList[m].EventList[i].LastValue = dt.Rows[i]["LastValue"].ToString();
                    Program.AgentList[m].EventList[i].Level = dt.Rows[i]["LevelId"].ToString();
                    Program.AgentList[m].EventList[i].SubjectId = dt.Rows[i]["SubjectId"].ToString();
                    Program.AgentList[m].EventList[i].Time = GetTimeFromSql(dt.Rows[i]["EventDateTime"].ToString());
                    Program.AgentList[m].EventList[i].EventId = dt.Rows[i]["EventId"].ToString();
                    Program.AgentList[m].EventList[i].Shown = dt.Rows[i]["Shown"].ToString();
                    Program.AgentList[m].EventList[i].SubjectGroup = dt.Rows[i]["SubjectGroup"].ToString();
                    Program.AgentList[m].EventList[i].SoundId = dt.Rows[i]["SoundAlert"].ToString();
                    Program.AgentList[m].EventList[i].SoundPath = dt.Rows[i]["SoundFilePath"].ToString();

                }
                dt = null;
            }
        }
        */
        public void SetAgentPersonnelInfo(int AgentListIndex)
        {
            SQLAccess sql28 = new SQLAccess();
            DataTable dt = new DataTable();
            int m = AgentListIndex;
            sql28.StoredProcedureName = SQLAccess.StoredProcedure.prcGetPersonnelInfo.ToString();
            dt = sql28.ExcecuteQueryToDataTable(Program.AgentList[m].AgentID);
            if (dt.Rows.Count != 0)
            {
                byte[] imageData;
                Program.AgentList[m].PersonnelFName = dt.Rows[0]["FirstName"].ToString();
                Program.AgentList[m].PersonnelLName = dt.Rows[0]["LastName"].ToString();
                Program.AgentList[m].PersonnelGender = dt.Rows[0]["Gender"].ToString();
                Program.AgentList[m].PersonnelCode = dt.Rows[0]["PersonnelCode"].ToString();
                imageData = (byte[])dt.Rows[0]["UserImage"];
                Program.AgentList[m].PersonnelTitle = dt.Rows[0]["UserTitle"].ToString();
                Program.AgentList[m].PersonnelMail = dt.Rows[0]["UserEmail"].ToString();
                Program.AgentList[m].PersonnelInterNum = dt.Rows[0]["UserInterNum"].ToString();
                Program.AgentList[m].PersonnelTellNum = dt.Rows[0]["UserTell"].ToString();
                Program.AgentList[m].PersonnelCellNum = dt.Rows[0]["UserMob"].ToString();
                Program.AgentList[m].PersonnelAddress = dt.Rows[0]["UserAddress"].ToString();

                Image perImage;
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);

                    //Set image variable value using memory stream.
                    perImage = Image.FromStream(ms, true);
                }

                Program.AgentList[m].PersonnelImage = perImage;
            }
            else
            {
                Program.AgentList[m].PersonnelFName = "";
                Program.AgentList[m].PersonnelLName = "";
            }

            dt = null;
        }


        /*

        public string GetDateFromSql(string DateTime)
        {
            string result = "";
            int y = Convert.ToInt32(DateTime.Substring(0, 4));
            int m = Convert.ToInt32(DateTime.Substring(5, 2));
            int d = Convert.ToInt32(DateTime.Substring(8, 2));
            string miladiDate = y.ToString() + "/" + m.ToString() + "/" + d.ToString();

            if (Program.LangCode == 1)
            {
                SunDate sd = Persia.Calendar.ConvertToPersian(new DateTime(y, m, d));
                result = sd.Simple;
            }
            else if (Program.LangCode == 3)
            {
                MoonDate md = Persia.Calendar.ConvertToIslamic(new DateTime(y, m, d));
                result = md.Simple;
            }
            else
            {
                result = miladiDate;
            }
            return result;


        }
        */
        public string GetEventDateFromSql(string DateTime)
        {
            string result = "";
            int indexm, indexd, m, d, y;
            indexm = 0;
            indexd = 0;
            m = 0;
            d = 0;
            y = 0;
            indexm = DateTime.IndexOf("/");
            m = Convert.ToInt32(DateTime.Substring(0, indexm));
            indexd = DateTime.IndexOf("/", indexm + 1);
            d = Convert.ToInt32(DateTime.Substring(indexm + 1, indexd - (indexm + 1)));
            y = Convert.ToInt32(DateTime.Substring(indexd + 1, 4));

            string miladiDate = y.ToString() + "/" + m.ToString() + "/" + d.ToString();

            if (Program.LangCode == 1)
            {
                SunDate sd = Persia.Calendar.ConvertToPersian(new DateTime(y, m, d));
                result = sd.Simple;
            }
            else if (Program.LangCode == 3)
            {
                MoonDate md = Persia.Calendar.ConvertToIslamic(new DateTime(y, m, d));
                result = md.Simple;
            }
            else
            {
                result = miladiDate;
            }
            return result;

        }

        /*
        public string GetEventDateFromSql(string DateTime)
        {
            string result = "";
            int index,m,d,y;
            index = 0;
            m = 0;
            d = 0;
            y = 0;
            index = DateTime.IndexOf("/");
            if (index == 2)
            {
                 m = Convert.ToInt32(DateTime.Substring(0, 2));
                 d = Convert.ToInt32(DateTime.Substring(3, 2));
                 y = Convert.ToInt32(DateTime.Substring(6, 4));
            }
            if (index == 4)
            {
                y = Convert.ToInt32(DateTime.Substring(0, 4));
                m = Convert.ToInt32(DateTime.Substring(5, 2));
                d = Convert.ToInt32(DateTime.Substring(8, 2));
            }

            if (index == 1)
            {
                m = Convert.ToInt32(DateTime.Substring(0, 1));
                int mindex = 0;
                mindex = DateTime.IndexOf("/",2);
                if (mindex == 3)
                {
                    d = Convert.ToInt32(DateTime.Substring(2, 1));
                    y = Convert.ToInt32(DateTime.Substring(4, 4));
                }
                else
                {
                    d = Convert.ToInt32(DateTime.Substring(2, 2));
                    y = Convert.ToInt32(DateTime.Substring(5, 4));
                }
            }
            
            
            
            string miladiDate = y.ToString() + "/" + m.ToString() + "/" + d.ToString();

            if (Program.LangCode == 1)
            {
                SunDate sd = Persia.Calendar.ConvertToPersian(new DateTime(y, m, d));
                result = sd.Simple;
            }
            else if (Program.LangCode == 3)
            {
                MoonDate md = Persia.Calendar.ConvertToIslamic(new DateTime(y, m, d));
                result = md.Simple;
            }
            else
            {
                result = miladiDate;
            }
            return result;


        }

       
        */
        public string GetEventDateFromSql2(string DateTime)
        {
            string result = "";
            int m = Convert.ToInt32(DateTime.Substring(0, 2));
            int d = Convert.ToInt32(DateTime.Substring(3, 2));
            int y = Convert.ToInt32(DateTime.Substring(6, 4));


            string miladiDate = y.ToString() + "/" + m.ToString() + "/" + d.ToString();

            if (Program.LangCode == 1)
            {
                SunDate sd = Persia.Calendar.ConvertToPersian(new DateTime(y, m, d));
                string s = sd.Simple;
                string y2 = s.Substring(0, 4);
                string s2 = s.Remove(0, 5);
                int i = s2.IndexOf('/');
                string m1 = s2.Substring(0, i);
                m1 = OneToTwo(m1);
                string d2 = s2.Substring(i + 1);
                d2 = OneToTwo(d2);
                result = y2 + "/" + m1 + "/" + d2;

            }
            else if (Program.LangCode == 3)
            {
                MoonDate md = Persia.Calendar.ConvertToIslamic(new DateTime(y, m, d));
                result = md.Simple;
            }
            else
            {
                result = miladiDate;
            }
            return result;


        }


        public string OneToTwo(string S)
        {
            string mm = S;
            switch (S)
            {
                case "1":
                    {
                        mm = "01";
                        break;
                    }
                case "2":
                    {
                        mm = "02";
                        break;
                    }
                case "3":
                    {
                        mm = "03";
                        break;
                    }
                case "4":
                    {
                        mm = "04";
                        break;
                    }
                case "5":
                    {
                        mm = "05";
                        break;
                    }
                case "6":
                    {
                        mm = "06";
                        break;
                    }
                case "7":
                    {
                        mm = "07";
                        break;
                    }
                case "8":
                    {
                        mm = "08";
                        break;
                    }
                case "9":
                    {
                        mm = "09";
                        break;
                    }

            }
            return mm;
        }





        public string GetStartupDate(string agentDuration)
        {
            string result = "";


            int y = Convert.ToInt32(agentDuration.Substring(0, 4));
            int m = Convert.ToInt32(agentDuration.Substring(4, 2));
            int d = Convert.ToInt32(agentDuration.Substring(6, 2));
            string miladiDate = y.ToString() + "/" + m.ToString() + "/" + d.ToString();

            if (Program.LangCode == 1)
            {
                SunDate sd = Persia.Calendar.ConvertToPersian(new DateTime(y, m, d));
                result = sd.Simple;
            }
            else if (Program.LangCode == 3)
            {
                MoonDate md = Persia.Calendar.ConvertToIslamic(new DateTime(y, m, d));
                result = md.Simple;
            }
            else
            {
                result = miladiDate;
            }
            return result;
        }

        public string GetTimeFromSql(string DataTime)
        {
            string result = "";
            int index = DataTime.IndexOf(' ');
            int len = DataTime.Length;
            result = DataTime.Substring(index + 1, 8);
            return result;
        }

        public string GetEventTimeFromSql(string DataTime)
        {
            string result = "";
            int index = DataTime.IndexOf(' ');
            int len = DataTime.Length;
            result = DataTime.Substring(index + 1, 8);
            return result;
        }



        public string GetStratupTime(string agentDuration)
        {
            string result = "";
            string h = agentDuration.Substring(8, 2);
            string m = agentDuration.Substring(10, 2);
            string s = agentDuration.Substring(12, 2);
            result = h + ":" + m + ":" + s;
            return result;
        }

        public string GetCurrentAccount(string agentCurrentAccount)
        {
            string result = "";
            int index = agentCurrentAccount.IndexOf(@"\");
            result = agentCurrentAccount.Substring(index + 1);
            return result;
        }

        public string GetAgentStatus(string agentStatus)
        {
            string result = "";
            switch (agentStatus)
            {
                case "1":
                    {
                        result = "On";
                        Program.TotalAgentAvailable++;
                        break;
                    }
                case "2":
                    {
                        result = "Off";
                        Program.TotalAgentUnavailable++;
                        break;
                    }
                case "3":
                    {
                        result = "StandBy";
                        Program.TotalAgentUnavailable++;
                        break;
                    }
                case "4":
                    {
                        result = "Idle";
                        Program.TotalAgentAvailable++;
                        break;
                    }
            }
            return result;
        }

        public void UpdateShownInEvent(int Index)
        {
            SQLAccess sql29 = new SQLAccess();
            sql29.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateEventShown.ToString();
            string[,] newparams = new string[1, 2];
            newparams[0, 0] = "@Id";
            newparams[0, 1] = Program.EventList[Index].Id;
            int res = sql29.IntExcuteSP(newparams);
        }

        public void UpdateShownInEvent(string Id)
        {
            SQLAccess sql30 = new SQLAccess();
            sql30.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateEventShown.ToString();
            string[,] newparams = new string[1, 2];
            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;
            int res = sql30.IntExcuteSP(newparams);
        }

        public int SaveBuildingToSql(string BuildingTitle)
        {
            SQLAccess sql31 = new SQLAccess();
            sql31.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertBuilding.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@BuildingTitle";
            newparams[0, 1] = BuildingTitle;

            int res = sql31.IntExcuteSP(newparams);
            return res;

        }

        public int SaveClassToSql(string ClassTitle)
        {
            SQLAccess sql32 = new SQLAccess();
            sql32.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertClass.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ClassTitle";
            newparams[0, 1] = ClassTitle;

            int res = sql32.IntExcuteSP(newparams);
            return res;

        }

        public int SaveRoomToSql(string RoomTitle)
        {
            SQLAccess sql33 = new SQLAccess();
            sql33.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertRoom.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@RoomTitle";
            newparams[0, 1] = RoomTitle;

            int res = sql33.IntExcuteSP(newparams);
            return res;

        }

        public string GetSettingProfileName(string ProfileId)
        {
            SQLAccess sql34 = new SQLAccess();
            DataTable dt = new DataTable();
            sql34.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSettingProfileName.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            dt = sql34.ExcecuteQueryToDataTable(newparams);
            string res = dt.Rows[0]["ProfileName"].ToString();
            return res;
        }

        public string GetAlertProfileName(string ProfileId)
        {
            SQLAccess sql35 = new SQLAccess();
            DataTable dt = new DataTable();
            sql35.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAlertProfileName.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            dt = sql35.ExcecuteQueryToDataTable(newparams);
            string res = dt.Rows[0]["ProfileName"].ToString();
            return res;
        }

        public string GetAclProfileName(string ProfileId)
        {
            SQLAccess sql36 = new SQLAccess();
            DataTable dt = new DataTable();
            sql36.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclProfileName.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            dt = sql36.ExcecuteQueryToDataTable(newparams);
            string res = dt.Rows[0]["ProfileTitle"].ToString();
            return res;
        }

        public int SaveAgentLocationToSql(string AgentId, string BuildingID, string ClassID, string RoomID, string DepartmentID)
        {
            SQLAccess sql37 = new SQLAccess();
            sql37.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAgentLocation.ToString();
            string[,] newparams = new string[5, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            newparams[1, 0] = "@BuildingID";
            newparams[1, 1] = BuildingID;

            newparams[2, 0] = "@ClassID";
            newparams[2, 1] = ClassID;

            newparams[3, 0] = "@RoomID";
            newparams[3, 1] = RoomID;

            newparams[4, 0] = "@DepartmentID";
            newparams[4, 1] = DepartmentID;

            int res = sql37.IntExcuteSP(newparams);
            return res;

        }

        public int SaveUserToSql(string Username, string Firstname, string Lastname, string PassW, string PersonelCode, byte[] UserImage,
                                 string JobTitle, string Email, string Number, string TypeID, string ClassifyID,string AclProfileId)
        {
            SQLAccess sql38 = new SQLAccess();
            int res;
            sql38.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertUser.ToString();
            string[,] newparams = new string[11, 2];

            newparams[0, 0] = "@Username";
            newparams[1, 0] = "@Firstname";
            newparams[2, 0] = "@Lastname";
            newparams[3, 0] = "@PassW";
            newparams[4, 0] = "@PersonelCode";
            newparams[5, 0] = "@JobTitle";
            newparams[6, 0] = "@Email";
            newparams[7, 0] = "@Number";
            newparams[8, 0] = "@TypeID";
            newparams[9, 0] = "@ClassifyID";
            newparams[10, 0] = "@AclProfileId";


            newparams[0, 1] = Username;
            newparams[1, 1] = Firstname;
            newparams[2, 1] = Lastname;
            newparams[3, 1] = PassW;
            newparams[4, 1] = PersonelCode;
            newparams[5, 1] = JobTitle;
            newparams[6, 1] = Email;
            newparams[7, 1] = Number;
            newparams[8, 1] = TypeID;
            newparams[9, 1] = ClassifyID;
            newparams[10, 1] = AclProfileId;


            res = sql38.IntExcuteSP(newparams, UserImage);
            return res;
        }

        public int UpdateUserInSql(string UserID, string Username, string Firstname, string Lastname, string PassW, string PersonelCode, byte[] UserImage,
                                 string JobTitle, string Email, string Number, string TypeID, string ClassifyID,string AclProfileId)
        {
            SQLAccess sql39 = new SQLAccess();
            int res;
            sql39.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateUser.ToString();
            string[,] newparams = new string[12, 2];


            newparams[0, 0] = "@Username";
            newparams[1, 0] = "@Firstname";
            newparams[2, 0] = "@Lastname";
            newparams[3, 0] = "@PassW";
            newparams[4, 0] = "@PersonelCode";
            newparams[5, 0] = "@JobTitle";
            newparams[6, 0] = "@Email";
            newparams[7, 0] = "@Number";
            newparams[8, 0] = "@TypeID";
            newparams[9, 0] = "@ClassifyID";
            newparams[10, 0] = "@UserId";
            newparams[11, 0] = "@AclProfileId";


            newparams[0, 1] = Username;
            newparams[1, 1] = Firstname;
            newparams[2, 1] = Lastname;
            newparams[3, 1] = PassW;
            newparams[4, 1] = PersonelCode;
            newparams[5, 1] = JobTitle;
            newparams[6, 1] = Email;
            newparams[7, 1] = Number;
            newparams[8, 1] = TypeID;
            newparams[9, 1] = ClassifyID;
            newparams[10, 1] = UserID;
            newparams[11, 1] = AclProfileId;

            if (UserImage == null)
            {
                UserImage = imageToByteArray2(Properties.Resources.unknown);
            }


            res = sql39.IntExcuteSP(newparams, UserImage);
            return res;
        }

        public bool CheckUsername(string Username)
        {
            SQLAccess sql40 = new SQLAccess();
            bool res = false;
            string un = Encrypt(Username, true, "");
            sql40.StoredProcedureName = SQLAccess.StoredProcedure.prcCheckUsername.ToString();

            string[,] newparams = new string[1, 2];
            newparams[0, 0] = "@Username";
            newparams[0, 1] = un;
            int id = sql40.IntExcuteSP(newparams);
            if (id == 0)
                res = false;
            else
                res = true;
            return res;

        }

        public int SaveAgentAssetNumberToSql(string AgentId, string DeviceID, string Model, string SerialNumber, string AssetNumber)
        {
            SQLAccess sql41 = new SQLAccess();
            sql41.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAssetNumber.ToString();
            string[,] newparams = new string[5, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            newparams[1, 0] = "@DeviceId";
            newparams[1, 1] = DeviceID;

            newparams[2, 0] = "@DeviceModel";
            newparams[2, 1] = Model;

            newparams[3, 0] = "@DeviceSerialNumber";
            newparams[3, 1] = SerialNumber;

            newparams[4, 0] = "@Assetnumber";
            newparams[4, 1] = AssetNumber;

            int res = sql41.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateAgentAssetNumberInSql(string Model, string SerialNumber, string AssetNumber, string Id)
        {
            SQLAccess sql42 = new SQLAccess();
            sql42.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAssetNumber.ToString();
            string[,] newparams = new string[4, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;

            newparams[1, 0] = "@DeviceModel";
            newparams[1, 1] = Model;

            newparams[2, 0] = "@DeviceSerialNumber";
            newparams[2, 1] = SerialNumber;

            newparams[3, 0] = "@Assetnumber";
            newparams[3, 1] = AssetNumber;

            int res = sql42.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateMemoryDetailsInSql(string TableId, string Model, string SerialNumber)
        {
            SQLAccess sql43 = new SQLAccess();
            sql43.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateMemoryDetials.ToString();
            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = TableId;

            newparams[1, 0] = "@Model";
            newparams[1, 1] = Model;

            newparams[2, 0] = "@SerialNumber";
            newparams[2, 1] = SerialNumber;

            int res = sql43.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateVideoCardSNInSql(string TableId, string SerialNumber)
        {
            SQLAccess sql44 = new SQLAccess();
            sql44.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateVideoCardSN.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = TableId;

            newparams[1, 0] = "@SerialNumber";
            newparams[1, 1] = SerialNumber;

            int res = sql44.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateModemSNInSql(string TableId, string SerialNumber)
        {
            SQLAccess sql45 = new SQLAccess();
            sql45.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateModemSN.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = TableId;

            newparams[1, 0] = "@SerialNumber";
            newparams[1, 1] = SerialNumber;

            int res = sql45.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateCdromSNInSql(string TableId, string SerialNumber)
        {
            SQLAccess sql46 = new SQLAccess();
            sql46.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateCdromSN.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = TableId;

            newparams[1, 0] = "@SerialNumber";
            newparams[1, 1] = SerialNumber;

            int res = sql46.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateNetSNInSql(string TableId, string SerialNumber)
        {
            SQLAccess sql47 = new SQLAccess();
            sql47.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateNetSN.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = TableId;

            newparams[1, 0] = "@SerialNumber";
            newparams[1, 1] = SerialNumber;

            int res = sql47.IntExcuteSP(newparams);
            return res;

        }



        public int DeleteAssetNumberFromSql(string Id)
        {
            SQLAccess sql48 = new SQLAccess();
            sql48.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAssetNumber.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;


            int res = sql48.IntExcuteSP(newparams);
            return res;

        }
        public int DeleteAgentLocationFromSql(string AgentId)
        {
            SQLAccess sql49 = new SQLAccess();
            sql49.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAgentLocation.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            int res = sql49.IntExcuteSP(newparams);
            return res;

        }

        public int UpdateAgentLocationInSql(string AgentId, string BuildingID, string ClassID, string RoomID, string DepartmentID)
        {
            SQLAccess sql50 = new SQLAccess();
            sql50.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAgentLocation.ToString();
            string[,] newparams = new string[5, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            newparams[1, 0] = "@BuildingID";
            newparams[1, 1] = BuildingID;

            newparams[2, 0] = "@ClassID";
            newparams[2, 1] = ClassID;

            newparams[3, 0] = "@RoomID";
            newparams[3, 1] = RoomID;

            newparams[4, 0] = "@DepartmentID";
            newparams[4, 1] = DepartmentID;

            int res = sql50.IntExcuteSP(newparams);
            return res;
        }


        public int SaveDepartmentToSql(string DepartmentTitle)
        {
            SQLAccess sql51 = new SQLAccess();
            sql51.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertDepartment.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@DepartmentTitle";
            newparams[0, 1] = DepartmentTitle;

            int res = sql51.IntExcuteSP(newparams);
            return res;

        }


        public int DeleteBuildingFromSql(string BuildingID)
        {
            SQLAccess sql52 = new SQLAccess();
            sql52.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteBuilding.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@BuildingID";
            newparams[0, 1] = BuildingID;

            int res = sql52.IntExcuteSP(newparams);
            return res;

        }

        public int DeleteClassFromSql(string ClassID)
        {
            SQLAccess sql53 = new SQLAccess();
            sql53.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteClass.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ClassID";
            newparams[0, 1] = ClassID;

            int res = sql53.IntExcuteSP(newparams);
            return res;

        }

        public int DeleteRoomFromSql(string RoomID)
        {
            SQLAccess sql54 = new SQLAccess();
            sql54.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteRoom.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@RoomID";
            newparams[0, 1] = RoomID;

            int res = sql54.IntExcuteSP(newparams);
            return res;

        }

        public int DeleteDepartmentFromSql(string DepartmentID)
        {
            SQLAccess sql55 = new SQLAccess();
            sql55.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteDepartment.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@DepartmentID";
            newparams[0, 1] = DepartmentID;

            int res = sql55.IntExcuteSP(newparams);
            return res;

        }

        public int DeleteUserFromSql(string UserId)
        {
            SQLAccess sql56 = new SQLAccess();
            sql56.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteUser.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@UserID";
            newparams[0, 1] = UserId;

            int res = sql56.IntExcuteSP(newparams);
            return res;

        }

        public int DeleteGridOrder(string Id)
        {
            SQLAccess sql62 = new SQLAccess();
            sql62.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteGridOrder.ToString();
            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;

            int res = sql62.IntExcuteSP(newparams);
            return res;

        }

        public int InsertGridOrder(string UserId, string ObjectName, string OldIndex, string NewIndex)
        {
            SQLAccess sql58 = new SQLAccess();
            sql58.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertGridOrder.ToString();
            string[,] newparams = new string[4, 2];

            newparams[0, 0] = "@UserId";
            newparams[0, 1] = UserId;

            newparams[1, 0] = "@ObjectName";
            newparams[1, 1] = ObjectName;

            newparams[2, 0] = "@OldIndex";
            newparams[2, 1] = OldIndex;

            newparams[3, 0] = "@NewIndex";
            newparams[3, 1] = NewIndex;


            int res = sql58.IntExcuteSP(newparams);
            return res;

        }

        public DataTable GetAgentLocation(string AgentId)
        {
            SQLAccess sql59 = new SQLAccess();
            DataTable dt = new DataTable();
            sql59.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentLocation.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            dt = sql59.ExcecuteQueryToDataTable(newparams);

            return dt;
        }

        public DataTable GetGridOrder(string UserId, string ObjectName)
        {
            SQLAccess sql60 = new SQLAccess();
            DataTable dt = new DataTable();
            sql60.StoredProcedureName = SQLAccess.StoredProcedure.prcGetGridOrder.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@UserId";
            newparams[0, 1] = UserId;

            newparams[1, 0] = "@ObjectName";
            newparams[1, 1] = ObjectName;

            dt = sql60.ExcecuteQueryToDataTable(newparams);

            return dt;
        }

        public DataTable GetAgentSetting(string AgentId)
        {
            SQLAccess sql61 = new SQLAccess();
            DataTable dt = new DataTable();
            sql61.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSystemSetting.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            dt = sql61.ExcecuteQueryToDataTable(newparams);

            return dt;
        }

        public string SetProfileSettingDataForSendeing(int ProfileListIndex,int AgentListIndex)
        {
            string res = "";
            string[] rawData = new string[23];
            string rawDataPlus = "";

            rawData[0] = "STUPD"; // command
            rawData[1] = "[" + Program.SettingProfileList[ProfileListIndex].AccountCtr + "]";
            rawData[2] = "[" + Program.SettingProfileList[ProfileListIndex].AgentPassword + "]";            
            rawData[3] = "[" + Program.SettingProfileList[ProfileListIndex].AppDisableRun + "]";
            rawData[4] = "[" + Program.SettingProfileList[ProfileListIndex].AppInstallDisable + "]";
            rawData[5] = "[" + Program.SettingProfileList[ProfileListIndex].ChatPort + "]";
            rawData[6] = "[" + Program.SettingProfileList[ProfileListIndex].ChatWithOther + "]";
            rawData[7] = "[" + Program.SettingProfileList[ProfileListIndex].CommandPort + "]";
            rawData[8] = "[" + Program.SettingProfileList[ProfileListIndex].DisableCtrlAltDel + "]";
            rawData[9] = "[" + Program.SettingProfileList[ProfileListIndex].FileTransferWithOther + "]";
            rawData[10] = "[" + Program.SettingProfileList[ProfileListIndex].FTPort + "]";
            rawData[11] = "[" + Program.SettingProfileList[ProfileListIndex].HardwareCtr + "]";
            rawData[12] = "[" + Program.SettingProfileList[ProfileListIndex].ImageProcessing + "]";
            rawData[13] = "[" + Program.SettingProfileList[ProfileListIndex].NetworkCtr + "]";
            rawData[14] = "[" + Program.SettingProfileList[ProfileListIndex].PublicPort + "]";
            rawData[15] = "[" + Program.SettingProfileList[ProfileListIndex].RDPort + "]";
            rawData[16] = "[" + Program.SettingProfileList[ProfileListIndex].RegAccessControl + "]";
            rawData[17] = "[" + Program.SettingProfileList[ProfileListIndex].SoftwareCtr + "]";            
            rawData[18] = "[" + Program.SettingProfileList[ProfileListIndex].UsbAccessControl + "]";
            rawData[19] = "[" + Program.SettingProfileList[ProfileListIndex].UsbDataControl + "]";
            rawData[20] = "[" + Program.SettingProfileList[ProfileListIndex].VCPort + "]";
            rawData[21] = "[" + Program.SettingProfileList[ProfileListIndex].VideoWithOther + "]";
            rawData[22] = "[" + Program.SettingProfileList[ProfileListIndex].WebinarPort + "]";

            foreach (string item in rawData)
            {
                rawDataPlus = rawDataPlus + item;
            }

            Encrypter encr = new Encrypter();
            string encryptData = encr.Encrypt(rawDataPlus);
            return res;
        }

        public int InsertSettingProfile(string ProfileId, string ProfileName, string UsbAccessControl, string UsbDataControl, string RegAccessControl, string AppInstallDisable,
                                        string AliasShow, string Alias, string AgentPassword, string HardwareCtr, string SoftwareCtr, string NetworkCtr,
                                        string AccountCtr, string ChatWithOther, string VideoWithOther, string FileTransferWithOther, string ImageProcessing,
                                        string RDPort, string ChatPort, string FTPort, string VCPort, string CommandPort, string WebinarPort,
                                        string PublicPort, string AppDisableRun, string DisableCtrlAltDel)
        {
            SQLAccess sql63 = new SQLAccess();
            int res;
            sql63.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertSettingProfile.ToString();

            string[,] newparams = new string[27, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@ProfileName";
            newparams[1, 1] = ProfileName;

            newparams[2, 0] = "@UsbAccessControl";
            newparams[2, 1] = UsbAccessControl;

            newparams[3, 0] = "@UsbDataControl";
            newparams[3, 1] = UsbDataControl;

            newparams[4, 0] = "@RegAccessControl";
            newparams[4, 1] = RegAccessControl;

            newparams[5, 0] = "@AppInstallDisable";
            newparams[5, 1] = AppInstallDisable;

            newparams[6, 0] = "@AliasShow";
            newparams[6, 1] = AliasShow;

            newparams[7, 0] = "@Alias";
            newparams[7, 1] = Alias;

            newparams[8, 0] = "@AgentPassword";
            newparams[8, 1] = AgentPassword;

            newparams[9, 0] = "@HardwareCtr";
            newparams[9, 1] = HardwareCtr;

            newparams[10, 0] = "@SoftwareCtr";
            newparams[10, 1] = SoftwareCtr;

            newparams[11, 0] = "@NetworkCtr";
            newparams[11, 1] = NetworkCtr;

            newparams[12, 0] = "@AccountCtr";
            newparams[12, 1] = AccountCtr;

            newparams[13, 0] = "@ChatWithOther";
            newparams[13, 1] = ChatWithOther;

            newparams[14, 0] = "@VideoWithOther";
            newparams[14, 1] = VideoWithOther;

            newparams[15, 0] = "@FileTransferWithOther";
            newparams[15, 1] = FileTransferWithOther;

            newparams[16, 0] = "@ImageProcessing";
            newparams[16, 1] = ImageProcessing;

            newparams[17, 0] = "@RDPort";
            newparams[17, 1] = RDPort;

            newparams[18, 0] = "@ChatPort";
            newparams[18, 1] = ChatPort;

            newparams[19, 0] = "@FTPort";
            newparams[19, 1] = FTPort;

            newparams[20, 0] = "@VCPort";
            newparams[20, 1] = VCPort;

            newparams[21, 0] = "@CMDPort";
            newparams[21, 1] = CommandPort;

            newparams[22, 0] = "@WebinarPort";
            newparams[22, 1] = WebinarPort;

            newparams[23, 0] = "@UpdateCounter";
            newparams[23, 1] = "0";

            newparams[24, 0] = "@PublicPort";
            newparams[24, 1] = PublicPort;

            newparams[25, 0] = "@AppDisableRun";
            newparams[25, 1] = AppDisableRun;

            newparams[26, 0] = "@DisableCtrlAltDel";
            newparams[26, 1] = DisableCtrlAltDel;

            res = sql63.IntExcuteSP(newparams);

            return res;

        }

        public int InsertAlertProfile(string ProfileId, string ProfileName)
        {
            SQLAccess sql64 = new SQLAccess();
            int res;
            sql64.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAlertHeader.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@ProfileName";
            newparams[1, 1] = ProfileName;

            res = sql64.IntExcuteSP(newparams);

            return res;

        }

        public int InsertAclProfile(string ProfileId, string ProfileName)
        {
            SQLAccess sql65 = new SQLAccess();
            int res;
            sql65.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAclHeader.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@ProfileName";
            newparams[1, 1] = ProfileName;

            res = sql65.IntExcuteSP(newparams);

            return res;

        }

        public int InsertAclObjectProfile(string ProfileId, string ProfileName)
        {
            SQLAccess sql66 = new SQLAccess();
            int res;
            sql66.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAclObjectHeader.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@ProfileName";
            newparams[1, 1] = ProfileName;

            res = sql66.IntExcuteSP(newparams);

            return res;

        }


        public int InsertAlertDetails(string ProfileId, string SubjectId, string AlertId, string SubjectGroup, string SubjectDes, string SoundAlert,
                                      string SoundFilePath)
        {
            SQLAccess sql69 = new SQLAccess();
            int res;
            sql69.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAlertDetails.ToString();

            string[,] newparams = new string[7, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@SubjectId";
            newparams[1, 1] = SubjectId;

            newparams[2, 0] = "@AlertId";
            newparams[2, 1] = AlertId;

            newparams[3, 0] = "@SubjectGroup";
            newparams[3, 1] = SubjectGroup;

            newparams[4, 0] = "@SubjectDes";
            newparams[4, 1] = SubjectDes;

            newparams[5, 0] = "@SoundAlert";
            newparams[5, 1] = SoundAlert;

            newparams[6, 0] = "@SoundFilePath";
            newparams[6, 1] = SoundFilePath;

            res = sql69.IntExcuteSP(newparams);

            return res;
        }

        public int InsertAclDetails(string ProfileId, string SubjectId, string AclId, string SubjectGroup)
        {
            SQLAccess sql70 = new SQLAccess();
            int res;
            sql70.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAclDetails.ToString();

            string[,] newparams = new string[4, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@SubjectId";
            newparams[1, 1] = SubjectId;

            newparams[2, 0] = "@AclLevel";
            newparams[2, 1] = AclId;

            newparams[3, 0] = "@GroupId";
            newparams[3, 1] = SubjectGroup;


            res = sql70.IntExcuteSP(newparams);

            return res;
        }

        public int InsertAclObjectDetails(string ProfileId, string SubjectId, string AclId, string SubjectGroup)
        {
            SQLAccess sql71 = new SQLAccess();
            int res;
            sql71.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAclObjectDetails.ToString();

            string[,] newparams = new string[4, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@SubjectId";
            newparams[1, 1] = SubjectId;

            newparams[2, 0] = "@AclLevel";
            newparams[2, 1] = AclId;

            newparams[3, 0] = "@GroupId";
            newparams[3, 1] = SubjectGroup;


            res = sql71.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateAgentSettingProfile(string Id, string ProfileId)
        {
            SQLAccess sql72 = new SQLAccess();
            int res;

            sql72.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAgentSetProfile.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@SettingProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@Id";
            newparams[1, 1] = Id;

            res = sql72.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateAgentAlertProfile(string Id, string ProfileId)
        {
            SQLAccess sql73 = new SQLAccess();
            int res;

            sql73.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAgentAlertProfile.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@AlertProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@Id";
            newparams[1, 1] = Id;

            res = sql73.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateAgentAclProfile(string Id, string ProfileId)
        {
            SQLAccess sql73 = new SQLAccess();
            int res;

            sql73.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAgentAclProfile.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@AclProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@Id";
            newparams[1, 1] = Id;

            res = sql73.IntExcuteSP(newparams);

            return res;
        }

        public int InsertAgentSettingProfile(string AgentId, string ProfileId)
        {
            SQLAccess sql74 = new SQLAccess();
            int res;

            sql74.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAgentSetProfile.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            newparams[1, 0] = "@SettingProfileId";
            newparams[1, 1] = ProfileId;

            res = sql74.IntExcuteSP(newparams);

            return res;
        }

        public int InsertAgentAlertProfile(string AgentId, string ProfileId)
        {
            SQLAccess sql75 = new SQLAccess();
            int res;

            sql75.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAgentAlertProfile.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            newparams[1, 0] = "@AlertProfileId";
            newparams[1, 1] = ProfileId;

            res = sql75.IntExcuteSP(newparams);

            return res;
        }

        public int InsertAgentAclProfile(string AgentId, string ProfileId)
        {
            SQLAccess sql76 = new SQLAccess();
            int res;

            sql76.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertAgentAclProfile.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            newparams[1, 0] = "@AclProfileId";
            newparams[1, 1] = ProfileId;

            res = sql76.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAgentSettingProfile(string Id)
        {
            SQLAccess sql77 = new SQLAccess();
            int res;

            sql77.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAgentSetProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;

            res = sql77.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAgentAlertProfile(string Id)
        {
            SQLAccess sql78 = new SQLAccess();
            int res;

            sql78.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAgentAlertProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;

            res = sql78.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteSettingProfile(string Id)
        {
            SQLAccess sql79 = new SQLAccess();
            int res;

            sql79.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteSettingProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;

            res = sql79.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAlertProfileDetails(string ProfileId)
        {
            SQLAccess sql80 = new SQLAccess();
            int res;

            sql80.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAlertProfileDet.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = ProfileId;

            res = sql80.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAclProfileDetails(string ProfileId)
        {
            SQLAccess sql81 = new SQLAccess();
            int res;

            sql81.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAclProfileDet.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = ProfileId;

            res = sql81.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAclObjectProfileDetails(string ProfileId)
        {
            SQLAccess sql81 = new SQLAccess();
            int res;

            sql81.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAclObjProfileDet.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = ProfileId;

            res = sql81.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAlertProfileHeader(string ProfileId)
        {
            SQLAccess sql82 = new SQLAccess();
            int res;

            sql82.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAlertProfileHed.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = ProfileId;

            res = sql82.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAclProfileHeader(string ProfileId)
        {
            SQLAccess sql83 = new SQLAccess();
            int res;

            sql83.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAclProfileHed.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = ProfileId;

            res = sql83.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAclObjectProfileHeader(string ProfileId)
        {
            SQLAccess sql84 = new SQLAccess();
            int res;

            sql84.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAclObjProfileHed.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = ProfileId;

            res = sql84.IntExcuteSP(newparams);

            return res;
        }

        public int DeleteAgentAclProfile(string Id)
        {
            SQLAccess sql85 = new SQLAccess();
            int res;

            sql85.StoredProcedureName = SQLAccess.StoredProcedure.prcDeleteAgentAclProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = Id;

            res = sql85.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateAclProfile(string ProfileId, string SubjectId, string AclId)
        {
            SQLAccess sql86 = new SQLAccess();
            int res;

            sql86.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAclProfileDetails.ToString();

            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@AclId";
            newparams[1, 1] = AclId;

            newparams[2, 0] = "@SubjectId";
            newparams[2, 1] = SubjectId;

            res = sql86.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateAclObjectProfile(string ProfileId, string SubjectId, string AclId)
        {
            SQLAccess sql87 = new SQLAccess();
            int res;

            sql87.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAclObjectProfileDetails.ToString();

            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@AclId";
            newparams[1, 1] = AclId;

            newparams[2, 0] = "@SubjectId";
            newparams[2, 1] = SubjectId;

            res = sql87.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateAlertProfile(string ProfileId, string SubjectId, string AlertId, string Sound, string SoundFilePath)
        {
            SQLAccess sql88 = new SQLAccess();
            int res;

            sql88.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateAlertProfileDetails.ToString();

            string[,] newparams = new string[5, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@AlertId";
            newparams[1, 1] = AlertId;

            newparams[2, 0] = "@SubjectId";
            newparams[2, 1] = SubjectId;

            newparams[3, 0] = "@SoundId";
            newparams[3, 1] = Sound;

            newparams[4, 0] = "@SoundPath";
            newparams[4, 1] = SoundFilePath;

            res = sql88.IntExcuteSP(newparams);

            return res;
        }

        public int UpdateSettingProfile(string id, string UsbAccessControl, string UsbDataControl, string RegAccessControl, string AppInstallDisable,
                                        string AliasShow, string Alias, string AgentPassword, string HardwareCtr, string SoftwareCtr, string NetworkCtr,
                                        string AccountCtr, string ChatWithOther, string VideoWithOther, string FileTransferWithOther, string ImageProcessing,
                                        string RDPort, string ChatPort, string FTPort, string VCPort, string CommandPort, string WebinarPort,
                                        string UpdateCounter, string PublicPort, string AppDisableRun, string DisableCtrlAltDel)
        {
            int res;
            SQLAccess sql89 = new SQLAccess();
            sql89.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateSettingProfile.ToString();

            string[,] newparams = new string[26, 2];

            newparams[0, 0] = "@Id";
            newparams[0, 1] = id;

            newparams[1, 0] = "@UsbAccessControl";
            newparams[1, 1] = UsbAccessControl;

            newparams[2, 0] = "@UsbDataControl";
            newparams[2, 1] = UsbDataControl;

            newparams[3, 0] = "@RegAccessControl";
            newparams[3, 1] = RegAccessControl;

            newparams[4, 0] = "@AppInstallDisable";
            newparams[4, 1] = AppInstallDisable;

            newparams[5, 0] = "@AliasShow";
            newparams[5, 1] = AliasShow;

            newparams[6, 0] = "@Alias";
            newparams[6, 1] = Alias;

            newparams[7, 0] = "@AgentPassword";
            newparams[7, 1] = AgentPassword;

            newparams[8, 0] = "@HardwareCtr";
            newparams[8, 1] = HardwareCtr;

            newparams[9, 0] = "@SoftwareCtr";
            newparams[9, 1] = SoftwareCtr;

            newparams[10, 0] = "@NetworkCtr";
            newparams[10, 1] = NetworkCtr;

            newparams[11, 0] = "@AccountCtr";
            newparams[11, 1] = AccountCtr;

            newparams[12, 0] = "@ChatWithOther";
            newparams[12, 1] = ChatWithOther;

            newparams[13, 0] = "@VideoWithOther";
            newparams[13, 1] = VideoWithOther;

            newparams[14, 0] = "@FileTransferWithOther";
            newparams[14, 1] = FileTransferWithOther;

            newparams[15, 0] = "@ImageProcessing";
            newparams[15, 1] = ImageProcessing;

            newparams[16, 0] = "@RDPort";
            newparams[16, 1] = RDPort;

            newparams[17, 0] = "@ChatPort";
            newparams[17, 1] = ChatPort;

            newparams[18, 0] = "@FTPort";
            newparams[18, 1] = FTPort;

            newparams[19, 0] = "@VCPort";
            newparams[19, 1] = VCPort;

            newparams[20, 0] = "@CommandPort";
            newparams[20, 1] = CommandPort;

            newparams[21, 0] = "@WebinarPort";
            newparams[21, 1] = WebinarPort;

            newparams[22, 0] = "@UpdateCounter";
            newparams[22, 1] = UpdateCounter;

            newparams[23, 0] = "@PublicPort";
            newparams[23, 1] = PublicPort;

            newparams[24, 0] = "@AppDisableRun";
            newparams[24, 1] = AppDisableRun;

            newparams[25, 0] = "@DisableCtrlAltDel";
            newparams[25, 1] = DisableCtrlAltDel;

            res = sql89.IntExcuteSP(newparams);

            return res;

        }

        public string GetLastSettingProfileId()
        {
            string lpid = "";
            SQLAccess sql90 = new SQLAccess();
            sql90.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLastSettingProfileId.ToString();
            int pid = sql90.IntExcuteSP();
            pid = pid + 1;
            lpid = Convert.ToString(pid);
            return lpid;
        }

        public string GetLastAlertProfileId()
        {
            SQLAccess sql91 = new SQLAccess();
            string lpid = "";

            sql91.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLastAlertProfileId.ToString();
            int pid = sql91.IntExcuteSP();
            pid = pid + 1;
            lpid = Convert.ToString(pid);
            return lpid;
        }

        public string GetLastAclProfileId()
        {
            string lpid = "";
            SQLAccess sql92 = new SQLAccess();
            sql92.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLastAclProfileId.ToString();
            int pid = sql92.IntExcuteSP();
            pid = pid + 1;
            lpid = Convert.ToString(pid);
            return lpid;
        }

        public string GetLastAclObjectProfileId()
        {
            string lpid = "";
            SQLAccess sql920 = new SQLAccess();
            sql920.StoredProcedureName = SQLAccess.StoredProcedure.prcGetLastAclObjProfileId.ToString();
            int pid = sql920.IntExcuteSP();
            pid = pid + 1;
            lpid = Convert.ToString(pid);
            return lpid;
        }

        public DataTable GetAgentSettingProfile(string AgentId)
        {
            SQLAccess sql93 = new SQLAccess();
            DataTable dt = new DataTable();

            sql93.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentSettingProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;


            dt = sql93.ExcecuteQueryToDataTable(newparams);

            return dt;

        }

        public DataTable GetAgentAlertProfile(string AgentId)
        {
            SQLAccess sql94 = new SQLAccess();
            DataTable dt = new DataTable();

            sql94.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentAlertProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;


            dt = sql94.ExcecuteQueryToDataTable(newparams);

            return dt;

        }

        public DataTable GetAgentAclProfile(string AgentId)
        {
            DataTable dt = new DataTable();
            SQLAccess sql95 = new SQLAccess();
            sql95.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentAclProfile.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;


            dt = sql95.ExcecuteQueryToDataTable(newparams);

            return dt;

        }

        public string GetAgentPassword(string SettingProfileId)
        {
            SQLAccess sql96 = new SQLAccess();
            DataTable dt = new DataTable();

            sql96.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAgentPassword.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = SettingProfileId;

            dt = sql96.ExcecuteQueryToDataTable(newparams);

            string cypherPass = dt.Rows[0]["AgentPassword"].ToString();


            return cypherPass;

        }

        public DataTable GetAclDetails(string ProfileId, string GroupId)
        {
            SQLAccess sql97 = new SQLAccess();
            DataTable dt = new DataTable();

            sql97.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclDetails.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@GroupId";
            newparams[1, 1] = GroupId;

            dt = sql97.ExcecuteQueryToDataTable(newparams);

            return dt;
        }

        public DataTable GetAclDetails(string ProfileId, string GroupId, string ParentSubId)
        {
            SQLAccess sql98 = new SQLAccess();
            DataTable dt = new DataTable();

            sql98.StoredProcedureName = SQLAccess.StoredProcedure.prcGetParentAclDetails.ToString();

            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@GroupId";
            newparams[1, 1] = GroupId;

            newparams[2, 0] = "@ParentSubId";
            newparams[2, 1] = ParentSubId;

            dt = sql98.ExcecuteQueryToDataTable(newparams);

            return dt;
        }


        public DataTable GetAclObjectsDetails(string ProfileId, string GroupId)
        {
            SQLAccess sql99 = new SQLAccess();
            DataTable dt = new DataTable();

            sql99.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclObjectsDetails.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@GroupId";
            newparams[1, 1] = GroupId;

            dt = sql99.ExcecuteQueryToDataTable(newparams);

            return dt;
        }

        public DataTable GetAclObjectsDetails(string ProfileId, string GroupId, string ParentSubId)
        {
            SQLAccess sql100 = new SQLAccess();
            DataTable dt = new DataTable();

            sql100.StoredProcedureName = SQLAccess.StoredProcedure.prcGetParentAclObjectsDetails.ToString();

            string[,] newparams = new string[3, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@GroupId";
            newparams[1, 1] = GroupId;

            newparams[2, 0] = "@ParentSubId";
            newparams[2, 1] = ParentSubId;

            dt = sql100.ExcecuteQueryToDataTable(newparams);

            return dt;
        }


        public DataTable GetAgentAlertProfileDetails(string ProfileId)
        {
            SQLAccess sql101 = new SQLAccess();
            DataTable dt = new DataTable();

            sql101.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAlertProfileDetails.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;


            dt = sql101.ExcecuteQueryToDataTable(newparams);

            return dt;

        }

        public DataTable GetAgentAclProfileDetails(string ProfileId)
        {
            SQLAccess sql102 = new SQLAccess();
            DataTable dt = new DataTable();

            sql102.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclProfileDetails.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;


            dt = sql102.ExcecuteQueryToDataTable(newparams);

            return dt;

        }

        public void GetAclHeaderProfile()
        {
            SQLAccess sql103 = new SQLAccess();
            DataTable dt = new DataTable();

            sql103.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclHeaderProfile.ToString();

            dt = sql103.ExcecuteQueryToDataTable();

            int rowCount = dt.Rows.Count;

            string HeaderId, ProfileId, ProfileName;

            if (rowCount > 0)
            {
                if (Program.AclProfileList.Count != 0)
                {
                    Program.AclProfileList.Clear();
                }

                for (int i = 0; i < rowCount; i++)
                {
                    HeaderId = dt.Rows[i]["Id"].ToString();
                    ProfileId = dt.Rows[i]["ProfileId"].ToString();
                    ProfileName = dt.Rows[i]["ProfileTitle"].ToString();

                    Program.AclProfileList.Add(new AclProfile(HeaderId, ProfileId, ProfileName));

                }
            }


        }

        public string GetAclObjectsHeaderProfile(string ProfileId)
        {
            SQLAccess sql104 = new SQLAccess();
            DataTable dt = new DataTable();

            sql104.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclObjectsHeaderTitle.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            dt = sql104.ExcecuteQueryToDataTable(newparams);

            string ProfileName;

            ProfileName = dt.Rows[0]["ProfileTitle"].ToString();

            return ProfileName;
        }

        public void GetAclObjectsHeaderProfile()
        {
            SQLAccess sql105 = new SQLAccess();
            DataTable dt = new DataTable();

            sql105.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAclObjectsHeaderProfile.ToString();

            dt = sql105.ExcecuteQueryToDataTable();

            int rowCount = dt.Rows.Count;

            string HeaderId, ProfileId, ProfileName;

            if (rowCount > 0)
            {
                if (Program.AclObjectsProfileList.Count != 0)
                {
                    Program.AclObjectsProfileList.Clear();
                }

                for (int i = 0; i < rowCount; i++)
                {
                    HeaderId = dt.Rows[i]["Id"].ToString();
                    ProfileId = dt.Rows[i]["ProfileId"].ToString();
                    ProfileName = dt.Rows[i]["ProfileTitle"].ToString();

                    Program.AclObjectsProfileList.Add(new AclObjectProfile(HeaderId, ProfileId, ProfileName));

                }
            }


        }

        public void GetAlertHeaderProfile()
        {
            SQLAccess sql106 = new SQLAccess();
            DataTable dt = new DataTable();

            sql106.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAlertHeaderProfile.ToString();

            dt = sql106.ExcecuteQueryToDataTable();

            int rowCount = dt.Rows.Count;

            string HeaderId, ProfileId, ProfileName;

            if (rowCount > 0)
            {
                if (Program.AlertProfileHeaderList.Count != 0)
                {
                    Program.AlertProfileHeaderList.Clear();
                }

                for (int i = 0; i < rowCount; i++)
                {
                    HeaderId = dt.Rows[i]["Id"].ToString();
                    ProfileId = dt.Rows[i]["ProfileId"].ToString();
                    ProfileName = dt.Rows[i]["ProfileName"].ToString();

                    Program.AlertProfileHeaderList.Add(new AlertProfile(HeaderId, ProfileId, ProfileName));

                }
            }

        }

        public void GetSettingProfile()
        {
            SQLAccess sql107 = new SQLAccess();
            DataTable dt = new DataTable();
            Encrypter enc = new Encrypter();

            sql107.StoredProcedureName = SQLAccess.StoredProcedure.prcGetSettingProfile.ToString();

            dt = sql107.ExcecuteQueryToDataTable();

            int rowCount = dt.Rows.Count;

            string id, ProfileId, ProfileName, UsbAccessControl, UsbDataControl, RegAccessControl, AppInstallDisable, AliasShow, Alias, AgentPassword,
                   HardwareCtr, SoftwareCtr, NetworkCtr, AccountCtr, ChatWithOther, VideoWithOther, FileTransferWithOther, ImageProcessing,
                   RDPort, ChatPort, FTPort, VCPort, CommandPort, WebinarPort, UpdateCounter, PublicPort, AppDisableRun, DisableCtrlAltDel;

            if (rowCount > 0)
            {
                if (Program.SettingProfileList.Count != 0)
                {
                    Program.SettingProfileList.Clear();
                }

                for (int i = 0; i < rowCount; i++)
                {
                    id = dt.Rows[i]["Id"].ToString();
                    ProfileId = dt.Rows[i]["ProfileId"].ToString();
                    ProfileName = dt.Rows[i]["ProfileName"].ToString();
                    UsbAccessControl = dt.Rows[i]["UsbAccessControl"].ToString();
                    UsbDataControl = dt.Rows[i]["UsbDataControl"].ToString();
                    RegAccessControl = dt.Rows[i]["RegAccessControl"].ToString();
                    AppInstallDisable = dt.Rows[i]["AppInstallDisable"].ToString();
                    AliasShow = dt.Rows[i]["AliasShow"].ToString();
                    Alias = dt.Rows[i]["Alias"].ToString();
                    AgentPassword = enc.Decrypt(dt.Rows[i]["AgentPassword"].ToString());
                    HardwareCtr = dt.Rows[i]["HardwareCtr"].ToString();
                    SoftwareCtr = dt.Rows[i]["SoftwareCtr"].ToString();
                    NetworkCtr = dt.Rows[i]["NetworkCtr"].ToString();
                    AccountCtr = dt.Rows[i]["AccountCtr"].ToString();
                    ChatWithOther = dt.Rows[i]["ChatWithOther"].ToString();
                    VideoWithOther = dt.Rows[i]["VideoWithOther"].ToString();
                    FileTransferWithOther = dt.Rows[i]["FileTransferWithOther"].ToString();
                    ImageProcessing = dt.Rows[i]["ImageProcessing"].ToString();
                    RDPort = dt.Rows[i]["RDPort"].ToString();
                    ChatPort = dt.Rows[i]["ChatPort"].ToString();
                    FTPort = dt.Rows[i]["FTPort"].ToString();
                    VCPort = dt.Rows[i]["VCPort"].ToString();
                    CommandPort = dt.Rows[i]["CMDPort"].ToString();
                    WebinarPort = dt.Rows[i]["WebinarPort"].ToString();
                    UpdateCounter = dt.Rows[i]["UpdateCounter"].ToString();
                    PublicPort = dt.Rows[i]["PublicPort"].ToString();
                    AppDisableRun = dt.Rows[i]["AppDisableRun"].ToString();
                    DisableCtrlAltDel = dt.Rows[i]["DisableCtrlAltDel"].ToString();

                    Program.SettingProfileList.Add(new SettingProfile(id, ProfileId, ProfileName, UsbAccessControl, UsbDataControl, RegAccessControl,
                                                   AppInstallDisable, AliasShow, Alias, AgentPassword, HardwareCtr, SoftwareCtr, NetworkCtr,
                                                   AccountCtr, ChatWithOther, VideoWithOther, FileTransferWithOther, ImageProcessing, RDPort,
                                                   ChatPort, FTPort, VCPort, CommandPort, WebinarPort, UpdateCounter, PublicPort, AppDisableRun,
                                                   DisableCtrlAltDel));

                }
            }
        }

        public DataTable GetAlertProfileDetails(string ProfileId, string GroupId)
        {
            SQLAccess sql108 = new SQLAccess();
            DataTable dt = new DataTable();

            sql108.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAlertDetailList.ToString();

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@GroupId";
            newparams[1, 1] = GroupId;

            dt = sql108.ExcecuteQueryToDataTable(newparams);

            return dt;
        }

        public DataTable GetAgentAssetNumbers(string AgentId)
        {
            SQLAccess sql109 = new SQLAccess();
            DataTable dt = new DataTable();

            sql109.StoredProcedureName = SQLAccess.StoredProcedure.prcGetAssetNumbers.ToString();

            string[,] newparams = new string[1, 2];

            newparams[0, 0] = "@AgentId";
            newparams[0, 1] = AgentId;

            dt = sql109.ExcecuteQueryToDataTable(newparams);

            return dt;
        }


        public int EditBuildingInSql(string BuildingID, string BuildingTitle)
        {
            SQLAccess sql110 = new SQLAccess();

            sql110.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateBuilding.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@BuildingID";
            newparams[0, 1] = BuildingID;

            newparams[1, 0] = "@BuildingTitle";
            newparams[1, 1] = BuildingTitle;

            int res = sql110.IntExcuteSP(newparams);
            return res;

        }

        public int EditClassInSql(string ClassID, string ClassTitle)
        {
            SQLAccess sql111 = new SQLAccess();
            sql111.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateClass.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@ClassID";
            newparams[0, 1] = ClassID;

            newparams[1, 0] = "@ClassTitle";
            newparams[1, 1] = ClassTitle;

            int res = sql111.IntExcuteSP(newparams);
            return res;

        }

        public int EditRoomInSql(string RoomID, string RoomTitle)
        {
            SQLAccess sql112 = new SQLAccess();
            sql112.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateRoom.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@RoomID";
            newparams[0, 1] = RoomID;

            newparams[1, 0] = "@RoomTitle";
            newparams[1, 1] = RoomTitle;

            int res = sql112.IntExcuteSP(newparams);
            return res;

        }

        public int EditDepartmentInSql(string DepartmentID, string DepartmentTitle)
        {
            SQLAccess sql113 = new SQLAccess();
            sql113.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdateDepartment.ToString();
            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@DepartmentID";
            newparams[0, 1] = DepartmentID;

            newparams[1, 0] = "@DepartmentTitle";
            newparams[1, 1] = DepartmentTitle;

            int res = sql113.IntExcuteSP(newparams);
            return res;

        }

        public void InsertPersonnelInfo(string[] Param, byte[] ImageData)
        {
            SQLAccess sql114 = new SQLAccess();
            sql114.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertPersonnel.ToString();
            string[,] newparams = new string[11, 2];

            newparams[0, 0] = "@AgentID";
            newparams[1, 0] = "@FirstName";
            newparams[2, 0] = "@LastName";
            newparams[3, 0] = "@Gender";
            newparams[4, 0] = "@PersonnelCode";
            newparams[5, 0] = "@UserTitle";
            newparams[6, 0] = "@UserEmail";
            newparams[7, 0] = "@UserInterNum";
            newparams[8, 0] = "@UserTell";
            newparams[9, 0] = "@UserMob";
            newparams[10, 0] = "@UserAddress";

            newparams[0, 1] = Param[10];
            newparams[1, 1] = Param[2];
            newparams[2, 1] = Param[4];
            newparams[3, 1] = Param[9];
            newparams[4, 1] = Param[6];
            newparams[5, 1] = Param[8];
            newparams[6, 1] = Param[5];
            newparams[7, 1] = Param[3];
            newparams[8, 1] = Param[7];
            newparams[9, 1] = Param[1];
            newparams[10, 1] = Param[0];

            sql114.InsertPersonnelInfo(newparams, ImageData);

        }

        public void UpdatePersonnelInfo(string[] Param, byte[] ImageData)
        {
            SQLAccess sql115 = new SQLAccess();
            if (ImageData != null)
                sql115.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdatePersonnel.ToString();
            else
                sql115.StoredProcedureName = SQLAccess.StoredProcedure.prcUpdatePersonnelNoImage.ToString();

            string[,] newparams = new string[11, 2];

            newparams[0, 0] = "@AgentID";
            newparams[1, 0] = "@FirstName";
            newparams[2, 0] = "@LastName";
            newparams[3, 0] = "@Gender";
            newparams[4, 0] = "@PersonnelCode";
            newparams[5, 0] = "@UserTitle";
            newparams[6, 0] = "@UserEmail";
            newparams[7, 0] = "@UserInterNum";
            newparams[8, 0] = "@UserTell";
            newparams[9, 0] = "@UserMob";
            newparams[10, 0] = "@UserAddress";

            newparams[0, 1] = Param[10];
            newparams[1, 1] = Param[2];
            newparams[2, 1] = Param[4];
            newparams[3, 1] = Param[9];
            newparams[4, 1] = Param[6];
            newparams[5, 1] = Param[8];
            newparams[6, 1] = Param[5];
            newparams[7, 1] = Param[3];
            newparams[8, 1] = Param[7];
            newparams[9, 1] = Param[1];
            newparams[10, 1] = Param[0];

            sql115.UpdatePersonnelInfo(newparams, ImageData);
        }

        public void DeletePersonnelInfo(string AgentID)
        {
            SQLAccess sql116 = new SQLAccess();
            sql116.StoredProcedureName = SQLAccess.StoredProcedure.prcDeletePersonnel.ToString();
            sql116.DeletePersonnelInfo(AgentID);
        }

        public string GetIPv4(string Address)
        {
            string ip = Address; //[192.168.1.3|fe80::8cb6:3db3:7846:24a1]
            int len = 0;
            len = Address.Length;
            ip = ip.Remove(len - 1);
            ip = ip.Remove(0, 1);
            int index = ip.IndexOf('|');
            if (index != -1)
                ip = ip.Remove(index);
            return ip;
        }

        public string GetMemoryDetails(string Bank, string Capacity, string Speed)
        {
            string res;
            double cap;
            cap = Convert.ToDouble(Capacity) / 1000000000;
            cap = Math.Round(cap, 0);
            res = Bank + " - " + Convert.ToString(cap) + " GB - BUS:" + Speed;
            return res;
        }

        public string GetFirstActiveIPV4(string Address)
        {
            string text = Address; // [192.168.1.3|fe80::5cea:2eea:7dc2:bb25]
            int len = 0;
            len = Address.Length;
            int index = Address.IndexOf('|');
            if (index != -1)
                text = text.Remove(index, len - index);
            int index3 = text.IndexOf('[');
            if (index3 != -1)
                text = text.Remove(index3, 1);
            int index2 = text.IndexOf(']');
            if (index2 != -1)
                text = text.Remove(index2, 1);
            return text;

        }

        public string RemoveBracket(string Address)
        {
            string text = Address; //[255.255.255.0|64][192.168.1.1]   [192.168.1.3|fe80::5cea:2eea:7dc2:bb25]
            int len = 0;
            len = Address.Length;
            int index = Address.IndexOf('[');
            if (index != -1)
                text = text.Remove(index, 1);
            index = text.IndexOf(']');
            if (index != -1)
                text = text.Remove(index, 1);
            return text;
        }

        public ArrayList GetActiveIPV4Address(Agents Agent)
        {
            ArrayList _ip = new ArrayList();
            Agents _agent = Agent;
            int _length = _agent.ActiveNetworkAdapterCaption.Length;

            for (int i = 0; i < _length; i++)
            {
                if (_agent.DefaultGW[i] != "")
                {
                    _ip.Add(GetIPv4(_agent.IPAddress[i].Trim()));
                }
            }
            return _ip;
        }

        public string GetActiveSubnetV4(Agents Agent)
        {
            string _address;
            Agents _agent = Agent;
            ArrayList _addressList = new ArrayList();
            int _length = _agent.ActiveNetworkAdapterCaption.Length;

            for (int i = 0; i < _length; i++)
            {
                if (_agent.DefaultGW[i] != "")
                {
                    _addressList.Add(GetIPv4(_agent.SubnetMask[i].Trim()));
                }
            }

            _address = _addressList[0].ToString();
            return _address;
        }

        public string GetActiveGatewayV4(Agents Agent)
        {
            string _address;
            Agents _agent = Agent;
            ArrayList _addressList = new ArrayList();
            int _length = _agent.ActiveNetworkAdapterCaption.Length;

            for (int i = 0; i < _length; i++)
            {
                if (_agent.DefaultGW[i] != "")
                {
                    _addressList.Add(GetIPv4(_agent.DefaultGW[i].Trim()));
                }
            }

            _address = _addressList[0].ToString();
            return _address;
        }

        public string GetActiveDhcpV4(Agents Agent)
        {
            string _address;
            Agents _agent = Agent;
            ArrayList _addressList = new ArrayList();
            int _length = _agent.ActiveNetworkAdapterCaption.Length;

            for (int i = 0; i < _length; i++)
            {
                if (_agent.DefaultGW[i] != "")
                {
                    _addressList.Add(GetIPv4(_agent.DHCPServer[i].Trim()));
                }
            }

            _address = _addressList[0].ToString();
            return _address;
        }

        public string GetActiveDnsV4(Agents Agent)
        {
            string _address;
            Agents _agent = Agent;
            ArrayList _addressList = new ArrayList();
            int _length = _agent.ActiveNetworkAdapterCaption.Length;

            for (int i = 0; i < _length; i++)
            {
                if (_agent.DefaultGW[i] != "")
                {
                    _addressList.Add(GetIPv4(_agent.DNSServer[i].Trim()));
                }
            }

            _address = _addressList[0].ToString();
            return _address;
        }



        public string GetActiveIPV4(Agents Agent)
        {
            string _ip;
            Agents _agent = Agent;
            ArrayList _ipList = new ArrayList();
            _ipList = GetActiveIPV4Address(_agent);
            _ip = _ipList[0].ToString();
            return _ip;

        }

        public void FillAgentListDll()
        {
            int len = Program.AgentList.Count;
            for (int i = 0; i < len; i++)
            {
                string _query = "INSERT INTO AgentList(AgentId,ComputerName,IPAddressV4,SubnetV4,DGatewayV4,DhcpAddressV4,DnsAddressV4) VALUES ('"
                                + Program.AgentList[i].AgentID + "','"
                                + Program.AgentList[i].ComputerName + "','"
                                + GetActiveIPV4(Program.AgentList[i]) + "','"
                                + GetActiveSubnetV4(Program.AgentList[i]) + "','"
                                + GetActiveGatewayV4(Program.AgentList[i]) + "','"
                                + GetActiveDhcpV4(Program.AgentList[i]) + "','"
                                + GetActiveDnsV4(Program.AgentList[i]) + "')";
                ExecuteQuery(_query);
            }

        }

        public string GetSqlConnStringForDel()
        {
            string _sqlcs = Program.SqlConnectionString;

            string[] s = _sqlcs.Split(';');


            string _SQLUsername = s[0].Substring(10);
            string _SQLPassword = s[1].Substring(11);
            string _SQLServerAddress = s[2].Substring(9);
            string _SQLDatabaseName = s[3].Substring(11);



            string cs = "Provider=SQLOLEDB;Data Source=" + _SQLServerAddress +
                    ";Initial Catalog=" + _SQLDatabaseName +
                    ";User Id=" + _SQLUsername +
                    ";Password=" + _SQLPassword;

            return cs;

        }


        #endregion

        public string GetEventDescription(string EventId)
        {
            string _description = "";
            int _eventId = Convert.ToInt32(EventId);
            string _langCode = Convert.ToString(Program.LangCode);
            switch (_eventId)
            {
                case 1000: //cpu change
                    {
                        _description = GetMessageFromDll(_langCode, "CpuCahngeEvent");
                        break;
                    }
                case 2001: //Mainboard Manufacter Change
                    {
                        _description = GetMessageFromDll(_langCode, "MainboardChangeEvent");
                        break;
                    }
                case 2002: //Mainboard Product Change
                    {
                        _description = GetMessageFromDll(_langCode, "MainboardProductChange");
                        break;
                    }

                case 2003: //Mainboard Version Change
                    {
                        _description = GetMessageFromDll(_langCode, "MainboardVersionChange");
                        break;
                    }
                case 2004: //Mainboard SerialNumber Change
                    {
                        _description = GetMessageFromDll(_langCode, "MainboardSerialNumberChange");
                        break;
                    }
                case 3001:  //Bios Vendor Change
                    {
                        _description = GetMessageFromDll(_langCode, "BiosVendorChange");
                        break;
                    }
                case 3002: //Bios Start Segment Change
                    {
                        _description = GetMessageFromDll(_langCode, "BiosStartSegmentChange");
                        break;
                    }
                case 3003: //Bios Version Change
                    {
                        _description = GetMessageFromDll(_langCode, "BiosVersionChange");
                        break;
                    }
                case 3004: //Bios Release Date Change
                    {
                        _description = GetMessageFromDll(_langCode, "BiosReleaseDateChange");
                        break;
                    }
                case 3005: //Bios Rom Size Change
                    {
                        _description = GetMessageFromDll(_langCode, "BiosRomSizeChange");
                        break;
                    }
                case 4001: //New Memory Card Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewMemoryCardInstall");
                        break;
                    }
                case 4002: //UnistallMemoryCard
                    {
                        _description = GetMessageFromDll(_langCode, "UnistallMemoryCard");
                        break;
                    }
                case 4003: //Memory Capacity Change
                    {
                        _description = GetMessageFromDll(_langCode, "MemoryCapacityChange");
                        break;
                    }
                case 4004: //Memory Speed Change
                    {
                        _description = GetMessageFromDll(_langCode, "MemorySpeedChange");
                        break;
                    }
                case 5001: //New Hard Disk Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewHardDiskInstall");
                        break;
                    }
                case 5002: //Uninstall Hard Disk
                    {
                        _description = GetMessageFromDll(_langCode, "UninstallHardDisk");
                        break;
                    }
                case 5003: //Hard Disk Signature Change
                    {
                        _description = GetMessageFromDll(_langCode, "HardDiskSignatureChange");
                        break;
                    }
                case 5004: //Hard Disk Size Change
                    {
                        _description = GetMessageFromDll(_langCode, "HardDiskSizeChange");
                        break;
                    }
                case 5005: //Hard Disk Partitions Change
                    {
                        _description = GetMessageFromDll(_langCode, "HardDiskPartitions");
                        break;
                    }
                case 5006: //Hard Disk PNPDeviceID Change
                    {
                        _description = GetMessageFromDll(_langCode, "HardDiskPNPDeviceID");
                        break;
                    }
                case 6001: //New Logic Disk Create
                    {
                        _description = GetMessageFromDll(_langCode, "NewLogicDiskCreate");
                        break;
                    }
                case 6002: //Logic Disk Remove
                    {
                        _description = GetMessageFromDll(_langCode, "LogicDiskRemove");
                        break;
                    }
                case 6003: //Logic Disk Description Change
                    {
                        _description = GetMessageFromDll(_langCode, "LogicDiskDescriptionChange");
                        break;
                    }
                case 6004: //Logic Disk FileSystem Change
                    {
                        _description = GetMessageFromDll(_langCode, "LogicDiskFileSystemChange");
                        break;
                    }
                case 6005: //Logic Disk VolumeSize Change
                    {
                        _description = GetMessageFromDll(_langCode, "LogicDiskVolumeSizeChange");
                        break;
                    }
                case 6006: //Logic Disk Volume Name Change
                    {
                        _description = GetMessageFromDll(_langCode, "LogicDiskVolumeName");
                        break;
                    }
                case 6007: //Logic Disk Volume Serial Number Change
                    {
                        _description = GetMessageFromDll(_langCode, "LogicDiskVolumeSerialNumberChange");
                        break;
                    }
                case 7001: //Video Card Driver Date Change
                    {
                        _description = GetMessageFromDll(_langCode, "VideoCardDriverDateChange");
                        break;
                    }
                case 7002: //Video Card Driver Version Change
                    {
                        _description = GetMessageFromDll(_langCode, "VideoCardDriveVersion");
                        break;
                    }
                case 7003: //Video Card Video Processor Change
                    {
                        _description = GetMessageFromDll(_langCode, "VideoCardVideoProcessorChange");
                        break;
                    }
                case 7004: //Video Card Video Mode Change
                    {
                        _description = GetMessageFromDll(_langCode, "VideoCardVideoModeChange");
                        break;
                    }
                case 7005: //Video Card Adapter Ram Change
                    {
                        _description = GetMessageFromDll(_langCode, "VideoCardAdapterRamChange");
                        break;
                    }
                case 7006: // New Video Card Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewVideoCardInstall");
                        break;
                    }
                case 7007: //Remove Video Card
                    {
                        _description = GetMessageFromDll(_langCode, "RemoveVideoCard");
                        break;
                    }
                case 8001: //New Network Adapter Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewNetworkAdapterInstall");
                        break;
                    }
                case 8002: //Network Adapter Uninstall
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkAdapterUninstall");
                        break;
                    }
                case 8003: //Network Adapter Type Change
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkAdapterTypeChange");
                        break;
                    }
                case 8004: //Network Adapter MAC Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkAdapterMACAddressChange");
                        break;
                    }
                case 8005: //Network Adapter Manufacturer Change
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkAdapterManufacturerChange");
                        break;
                    }
                case 8006: //NetworkAdapterNetConnectionIDChange
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkAdapterNetConnectionID");
                        break;
                    }
                case 8007: //Network Adapter PNPDeviceID Change
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkAdapterPNPDeviceID");
                        break;
                    }
                case 9000: //Keyboard Change
                    {
                        _description = GetMessageFromDll(_langCode, "KeyboardChange");
                        break;
                    }
                case 10000: //Mouse Change
                    {
                        _description = GetMessageFromDll(_langCode, "MouseChange");
                        break;
                    }
                case 11000: //Monitor Change
                    {
                        _description = GetMessageFromDll(_langCode, "MonitorChange");
                        break;
                    }
                case 12000: //Printer Change
                    {
                        _description = GetMessageFromDll(_langCode, "PrinterChange");
                        break;
                    }
                case 12001: //New Printer Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewPrinterInstall");
                        break;
                    }
                case 12002: //Printer Uninstall
                    {
                        _description = GetMessageFromDll(_langCode, "PrinterUninstall");
                        break;
                    }
                case 12003: //Printer Network Change
                    {
                        _description = GetMessageFromDll(_langCode, "PrinterNetworkChange");
                        break;
                    }
                case 13000: //Webcam Change
                    {
                        _description = GetMessageFromDll(_langCode, "WebcamChange");
                        break;
                    }
                case 14000: //Scanner Change
                    {
                        _description = GetMessageFromDll(_langCode, "ScannerChange");
                        break;
                    }
                case 15001: // New CDRom Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewCDRomInstall");
                        break;
                    }
                case 15002: //CDRom Uninstall
                    {
                        _description = GetMessageFromDll(_langCode, "CDRomUninstall");
                        break;
                    }
                case 15003: //CDRom Drive Change
                    {
                        _description = GetMessageFromDll(_langCode, "CDRomDriveChange");
                        break;
                    }
                case 16001: //New Modem Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewModemInstall");
                        break;
                    }
                case 16002: //Modem Uninstall 
                    {
                        _description = GetMessageFromDll(_langCode, "ModemUninstall");
                        break;
                    }
                case 17001: //New Application Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewApplicationInstall");
                        break;
                    }
                case 17002: //Application Uninstall
                    {
                        _description = GetMessageFromDll(_langCode, "ApplicationUninstall");
                        break;
                    }
                case 18001: //Os Serial Number Change
                    {
                        _description = GetMessageFromDll(_langCode, "OsSerialNumberChange");
                        break;
                    }
                case 18002: //Os Build Number Change
                    {
                        _description = GetMessageFromDll(_langCode, "OsBuildNumberChange");
                        break;
                    }
                case 18003: //Os Caption Change
                    {
                        _description = GetMessageFromDll(_langCode, "OsCaptionChange");
                        break;
                    }
                case 18004: //Os Install Date Change
                    {
                        _description = GetMessageFromDll(_langCode, "OsInstallDateChange");
                        break;
                    }
                case 18005: //Os Version Change 
                    {
                        _description = GetMessageFromDll(_langCode, "OsVersionChange");
                        break;
                    }
                case 19001: //New Security Updates Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewSecurityUpdatesInstall");
                        break;
                    }
                case 19002: // Security Updates Uninstall
                    {
                        _description = GetMessageFromDll(_langCode, "SecurityUpdatesUninstall");
                        break;
                    }
                case 20000: //IP Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "IPAddressChange");
                        break;
                    }
                case 21000: //Subnet Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "SubnetAddressChange");
                        break;
                    }
                case 22000: //Gateway Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "GatewayAddressChange");
                        break;
                    }
                case 23000: //MAC Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "MACAddressChange");
                        break;
                    }
                case 24000: //DNS Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "DNSAddressChange");
                        break;
                    }
                case 25000: //DHCP Address Change
                    {
                        _description = GetMessageFromDll(_langCode, "DHCPAddressChange");
                        break;
                    }
                case 25001: //DHCP Status Change
                    {
                        _description = GetMessageFromDll(_langCode, "DHCPStatusChange");
                        break;
                    }
                case 26001: //Power On
                    {
                        _description = GetMessageFromDll(_langCode, "PowerOn");
                        break;
                    }

                case 26002: //Normal Shutdown
                    {
                        _description = GetMessageFromDll(_langCode, "NormalShutdown");
                        break;
                    }

                case 26003: //Power Suspend
                    {
                        _description = GetMessageFromDll(_langCode, "PowerSuspend");
                        break;
                    }

                case 26004: //Power Resume Suspend
                    {
                        _description = GetMessageFromDll(_langCode, "PowerResumeSuspend");
                        break;
                    }

                case 26005: //Idle in
                    {
                        _description = GetMessageFromDll(_langCode, "IdleinEvent");
                        break;
                    }

                case 26006: //Idle out
                    {
                        _description = GetMessageFromDll(_langCode, "IdleOutEvent");
                        break;
                    }

                case 27001:
                    {
                        _description = GetMessageFromDll(_langCode, "USBCoolDiskInsert");
                        break;
                    }

                case 27002: //Flash Disk Remove
                    {
                        _description = GetMessageFromDll(_langCode, "FlashDiskRemove");
                        break;
                    }

                case 28001: //New User Account Create
                    {
                        _description = GetMessageFromDll(_langCode, "NewUserAccountCreate");
                        break;
                    }

                case 28002: //User Account Delete
                    {
                        _description = GetMessageFromDll(_langCode, "UserAccountDelete");
                        break;
                    }

                case 28003: //User Account UserName Change
                    {
                        _description = GetMessageFromDll(_langCode, "UserAccountUserName");
                        break;
                    }


                case 28004: //User Account Description Change
                    {
                        _description = GetMessageFromDll(_langCode, "UserAccountDescription");
                        break;
                    }

                case 28005: //User Account Status Change
                    {
                        _description = GetMessageFromDll(_langCode, "UserAccountStatusChange");
                        break;
                    }

                case 29001: //New Group Account Create
                    {
                        _description = GetMessageFromDll(_langCode, "NewGroupAccountCreate");
                        break;
                    }

                case 29002: //Group Account Delete
                    {
                        _description = GetMessageFromDll(_langCode, "GroupAccountDelete");
                        break;
                    }

                case 29003: //Group Account GroupName Change
                    {
                        _description = GetMessageFromDll(_langCode, "GroupAccountGroupNameChange");
                        break;
                    }

                case 29004: //Group Account Description Change
                    {
                        _description = GetMessageFromDll(_langCode, "GroupAccountDescriptionChange");
                        break;
                    }

                case 29005: //Group Account Status Cahnge
                    {
                        _description = GetMessageFromDll(_langCode, "GroupAccountStatusCahnge");
                        break;
                    }

                case 30001: //Chassis Asset Tag Number Change
                    {
                        _description = GetMessageFromDll(_langCode, "ChassisAssetTagNumberChange");
                        break;
                    }

                case 30002: //Chassis Type Change
                    {
                        _description = GetMessageFromDll(_langCode, "ChassisTypeChange");
                        break;
                    }

                case 31001: //Computer Name Change
                    {
                        _description = GetMessageFromDll(_langCode, "ComputerNameChange");
                        break;
                    }

                case 31002: //Organization Change
                    {
                        _description = GetMessageFromDll(_langCode, "OrganizationChange");
                        break;
                    }
                case 31003: //Register Company Change
                    {
                        _description = GetMessageFromDll(_langCode, "RegisterCompanyChange");
                        break;
                    }
                case 31004: //Register User Change
                    {
                        _description = GetMessageFromDll(_langCode, "RegisterCompanyChange");
                        break;
                    }

                case 32000: //UUID Change
                    {
                        _description = GetMessageFromDll(_langCode, "UUIDChange");
                        break;
                    }

                case 33000: //New Network Setting Install
                    {
                        _description = GetMessageFromDll(_langCode, "NewNetworkSettingInstall");
                        break;
                    }

                case 33001: //Network Setting Uninstall
                    {
                        _description = GetMessageFromDll(_langCode, "NetworkSettingUninstall");
                        break;
                    }
            }
            return _description;

        }

        public string GetEventDetails(string EventId, string LastValue, string CurrentValue)
        {
            string _langCode = Convert.ToString(Program.LangCode);
            string _details = "";
            int _eventId = Convert.ToInt32(EventId);
            switch (_eventId)
            {
                case 1000: //cpu change
                    {
                        _details = CurrentValue;
                        break;
                    }

                case 4001: //New Memory Card Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 4002: //UnistallMemoryCard
                    {
                        _details = LastValue;
                        break;
                    }

                case 5001: //New Hard Disk Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 5002: //Uninstall Hard Disk
                    {
                        _details = LastValue;
                        break;
                    }

                case 6001: //New Logic Disk Create
                    {
                        _details = GetMessageFromDll(_langCode, "DriveName") + " : " + CurrentValue;
                        break;
                    }
                case 6002: //Logic Disk Remove
                    {
                        _details = GetMessageFromDll(_langCode, "DriveName") + " : " + LastValue;
                        break;
                    }

                case 7006: // New Video Card Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 7007: //Remove Video Card
                    {
                        _details = LastValue;
                        break;
                    }
                case 8001: //New Network Adapter Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 8002: //Network Adapter Uninstall
                    {
                        _details = LastValue;
                        break;
                    }

                case 9000: //Keyboard Change
                    {
                        if (LastValue == null)
                            _details = CurrentValue;
                        if (CurrentValue == null)
                            _details = LastValue;
                        break;
                    }
                case 10000: //Mouse Change
                    {
                        if (LastValue == null)
                            _details = CurrentValue;
                        if (CurrentValue == null)
                            _details = LastValue;
                        break;
                    }
                case 11000: //Monitor Change
                    {
                        if (LastValue == null)
                            _details = CurrentValue;
                        if (CurrentValue == null)
                            _details = LastValue;
                        break;
                    }
                case 12000: //Printer Change
                    {
                        if (LastValue == null)
                            _details = CurrentValue;
                        if (CurrentValue == null)
                            _details = LastValue;
                        break;
                    }
                case 12001: //New Printer Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 12002: //Printer Uninstall
                    {
                        _details = LastValue;
                        break;
                    }

                case 13000: //Webcam Change
                    {
                        if (LastValue == null)
                            _details = CurrentValue;
                        if (CurrentValue == null)
                            _details = LastValue;
                        break;
                    }
                case 14000: //Scanner Change
                    {
                        if (LastValue == null)
                            _details = CurrentValue;
                        if (CurrentValue == null)
                            _details = LastValue;
                        break;
                    }
                case 15001: // New CDRom Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 15002: //CDRom Uninstall
                    {
                        _details = LastValue;
                        break;
                    }
                case 16001: //New Modem Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 16002: //Modem Uninstall 
                    {
                        _details = LastValue;
                        break;
                    }
                case 17001: //New Application Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 17002: //Application Uninstall
                    {
                        _details = LastValue;
                        break;
                    }

                case 19001: //New Security Updates Install
                    {
                        _details = CurrentValue;
                        break;
                    }
                case 19002: // Security Updates Uninstall
                    {
                        _details = LastValue;
                        break;
                    }

                case 26001: //Power On
                    {
                        _details = "";
                        break;
                    }

                case 26002: //Normal Shutdown
                    {
                        _details = "";
                        break;
                    }

                case 26003: //Power Suspend
                    {
                        _details = "";
                        break;
                    }

                case 26004: //Power Resume Suspend
                    {
                        _details = "";
                        break;
                    }

                case 26005: //IdleIn
                    {
                        _details = CurrentValue;
                        break;
                    }

                case 26006: //IdleOut
                    {
                        _details = CurrentValue;
                        break;
                    }

                case 27001:
                    {
                        _details = CurrentValue;
                        break;
                    }

                case 27002: //Flash Disk Remove
                    {
                        _details = LastValue;
                        break;
                    }

                case 28001: //New User Account Create
                    {
                        _details = GetMessageFromDll(_langCode, "lblSqlUsername") + " : " + CurrentValue;
                        break;
                    }

                case 28002: //User Account Delete
                    {
                        _details = GetMessageFromDll(_langCode, "lblSqlUsername") + " : " + LastValue;
                        break;
                    }

                case 29001: //New Group Account Create
                    {
                        _details = GetMessageFromDll(_langCode, "UserGroupName") + " : " + CurrentValue;
                        break;
                    }

                case 29002: //Group Account Delete
                    {
                        _details = GetMessageFromDll(_langCode, "UserGroupName") + " : " + LastValue;
                        break;
                    }


                case 33000: //New Network Setting Install
                    {
                        _details = CurrentValue;
                        break;
                    }

                case 33001: //Network Setting Uninstall
                    {
                        _details = LastValue;
                        break;
                    }
                default:
                    {
                       // _details = CurrentValue + " : " + GetMessageFromDll(_langCode, "To") + LastValue + " : " + GetMessageFromDll(_langCode, "From");
                        _details = LastValue + " --> " + CurrentValue;
                        break;
                    }
            }
            return _details;
        }

        public string GetBackupFileName()
        {
            string _filename = "";
            string year, month, day, hour, minute, second;
            string[] date  = User.LocalToday.Split('/');
            year = date[0];
            month = date[1];
            day = date[2];
            hour = DateTime.Now.Hour.ToString();
            minute = DateTime.Now.Minute.ToString();
            second = DateTime.Now.Second.ToString();
            _filename = year + month + day + hour + minute + second + ".bak";
            return _filename;

        }

        public void SendSettingDataToRemoteAgent(string DataToSend, int LastProfileIndex,int AgentIndex)
        {
            Com mycom = new Com();
            mycom.DestiniPort = Program.SettingProfileList[LastProfileIndex].PublicPort;
            mycom.DestiniIp = Program.dataSource[AgentIndex].AgentIP;
            mycom.SockType = "Tcp";
            mycom.SendData(DataToSend);
        }

        public void LogoutFromRemoteAgent(string DataToSend, int ProfileIndex,int AgentIndex)
        {
            Com mycom = new Com();
            mycom.DestiniPort = Program.SettingProfileList[ProfileIndex].PublicPort;
            mycom.DestiniIp = Program.dataSource[AgentIndex].AgentIP;
            mycom.SockType = "Tcp";
            mycom.SendData(DataToSend);            
        }

        public int InsertAgentSettingUpdateToSql(string AgentId,string ProfileId)
        {
            int res = 0;
            SQLAccess sql117 = new SQLAccess();
            sql117.StoredProcedureName = SQLAccess.StoredProcedure.prcInsertUpdateStatus.ToString();

            string[,] newparams = new string[4, 2];

            newparams[0, 0] = "@ProfileId";
            newparams[0, 1] = ProfileId;

            newparams[1, 0] = "@AgentId";
            newparams[1, 1] = AgentId;

            newparams[2, 0] = "@UpdateId";
            newparams[2, 1] = "1";

            newparams[3, 0] = "@UpdateStatusId";
            newparams[3, 1] = "0";       

            res = sql117.IntExcuteSP(newparams);

            return res;
        }
    }
}
