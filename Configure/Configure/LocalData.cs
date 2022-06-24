using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;

namespace Configure
{
    public class LocalData
    {
        #region Fileds:

        /// <summary>
        /// Data file full path 
        /// </summary>
        private string _localPath;
        /// <summary>
        /// Data File Password
        /// </summary>
        private string _password;
        /// <summary>
        /// Dll Connection string
        /// </summary>
        private string _connectionString;

        private string _msgconnectionString;
        private string _localPath2;



        private OleDbConnection _myConnection;

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
        public LocalData()
        {
            _localPath2 = Environment.CurrentDirectory + Decrypt("LKsUBOhTWkW6h8o9GdtgGw ==", true, ""); 
            _localPath = Environment.CurrentDirectory + Decrypt("mUeSLoCO8VvohacsvVNS8g==", true, "");         
            _password = Decrypt("1MllRzArFvyPoS7n+TDuSkyHUvftOQGr", true, "");
            _connectionString = Decrypt("XjmTlR5XcUlPH3IZ8ov67v3TeG5OJ7ksqHYknB7MPKtEhD3fiXB6qJy+NGsvvxGW", true, "") + _localPath + Decrypt("zU6hRRV+LAwLZ+1l1vD14CDKgvZpiRX5lEAE5uivuOU=", true, "") + _password;
            _msgconnectionString = Decrypt("XjmTlR5XcUlPH3IZ8ov67v3TeG5OJ7ksqHYknB7MPKtEhD3fiXB6qJy+NGsvvxGW", true, "") + _localPath2 + Decrypt("zU6hRRV+LAwLZ+1l1vD14CDKgvZpiRX5lEAE5uivuOU=", true, "") + _password;
        }

        public LocalData(string LocalPath)
        {
            _localPath = LocalPath;           
            _password = Decrypt("1MllRzArFvyPoS7n+TDuSkyHUvftOQGr", true, "");
            _connectionString = Decrypt("XjmTlR5XcUlPH3IZ8ov67v3TeG5OJ7ksqHYknB7MPKtEhD3fiXB6qJy+NGsvvxGW", true, "") + _localPath + Decrypt("zU6hRRV+LAwLZ+1l1vD14CDKgvZpiRX5lEAE5uivuOU=", true, "") + _password;
        }

        #endregion
        #region Public Methods:
        /// <summary>
        /// Check for Software registerd or not
        /// </summary>
        /// <returns>True or false</returns>
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
            switch (LangCode)
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
            _myConnection.ConnectionString = _msgconnectionString;
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

        public string GetEncrypted(string PlainText, string Salt)
        {
            string _hashPassword = HashMD5(PlainText);
            string _hashSalt = HashMD5(Salt);
            string _encrypt = HashMD5(_hashSalt + _hashPassword);
            return _encrypt;
        }

        #endregion



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




        public int IsRegister(string LockIPAddress)
        {
            int result = 0;
            string _readKeyEn = GetDataFromDll("Setting", "ReadKey", "ID = 1");
            string _readKeyDe = Decrypt(_readKeyEn, true, "");
            USBLock usl = new USBLock();
            usl.ReadKey = _readKeyDe;
            usl.LockIPAddress = LockIPAddress;
            string _data = usl.GetData();
            if (_data != null)
            {
                int startIndex = _data.IndexOf("&&");
                int length = _data.Length;
                StringBuilder sb = new StringBuilder(_data);
                sb.Remove(startIndex, (length - startIndex));
                string _newData = sb.ToString();
                string text = Decrypt(_newData, true, "");
                if (text == "Register")
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }

            }
            else
                result = 0;

            return result;
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

    }
}
