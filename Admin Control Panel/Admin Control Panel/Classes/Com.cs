using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Globalization;


namespace Admin_Control_Panel.Classes
{
    public class Com
    {
        private string _sourceIp;
        private string _destiniIp;
        private string _sourcePort;
        private string _destiniPort;
        private string _socketType;
        private string _sendText;
        private string _reciveText;
        private Socket _socket;


        public string SourceIp
        {
            get
            {                
                return _sourceIp;
            }
            set
            {                
                _sourceIp = value;
            }
        }

        public string DestiniIp
        {
            get
            {
                return _destiniIp;
            }
            set
            {
                _destiniIp = value;
            }
        }

        public string SourcePort
        {
            get
            {
                return _sourcePort;
            }
            set
            {
                _sourcePort = value;
            }
        }


        public string DestiniPort
        {
            get
            {
                return _destiniPort;
            }
            set
            {
                _destiniPort = value;
            }
        }

        public string SockType
        {
            get
            {
                return _socketType;
            }
            set
            {
                _socketType = value;
            }
        }


        public string SendText
        {
            get
            {
                return _sendText;
            }
            set
            {
                _sendText = value;
            }
        }

        public string ReciveText
        {
            get
            {
                return _reciveText;
            }
            set
            {
                _reciveText = value;
            }
        }

        public Com()
        {

        }

        public void SendData(string Data)
        {

            if (_socketType == "Tcp")
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (_socketType == "Udp")
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress ipAdd = IPAddress.Parse(_destiniIp);
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, Convert.ToInt32(_destiniPort));
            try
            {
                _socket.Connect(remoteEP);
                byte[] byData = Encoding.ASCII.GetBytes(Data);
                _socket.Send(byData);
                _socket.Close();
            }
            catch (Exception)
            {

            }
            //todo : try and ecxeption for not connection

        }

        public void TcpSendData(string Data)
        {
            IPAddress ipAdd = IPAddress.Parse(_destiniIp);
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, Convert.ToInt32(_destiniPort));
            TcpClient tc = new TcpClient(_destiniIp, Convert.ToInt32(_destiniPort));
            tc.NoDelay = true;
            
                  

           NetworkStream NetStream = tc.GetStream();
         
           Byte[] sendBytes = Encoding.ASCII.GetBytes(Data);
           NetStream.Write(sendBytes, 0, sendBytes.Length);

            NetStream.Close();
            tc.Close();

        }

        public void UdpClient(string SendData)
        {
            Socket Udpsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress ipAdd = IPAddress.Parse(_destiniIp);
            IPEndPoint remoteEP = new IPEndPoint(ipAdd, Convert.ToInt32(_destiniPort));

            Udpsocket.Connect(remoteEP);
            byte[] byData = System.Text.Encoding.Unicode.GetBytes(SendData);
            Udpsocket.Send(byData);
            Udpsocket.Close();
        }


        private MemoryStream StringToStream(string S)
        {
            byte[] byteArray;
            MemoryStream stream;

            byteArray = Encoding.UTF8.GetBytes(S);
            stream = new MemoryStream(byteArray);
            return stream;

        }


        public void StartServer()
        {
            LogicLayer ll = new LogicLayer();
            string _localip = ll.LocalIPAddress();
            IPAddress ipAdd = IPAddress.Parse(_localip);
            TcpListener serverSocket = new TcpListener(ipAdd, Convert.ToInt32(_sourcePort));

            int requestCount = 0;
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();

            clientSocket = serverSocket.AcceptTcpClient();
            requestCount = 0;

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[10025];
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    _reciveText = dataFromClient;
                    /*
                    string serverResponse = "Server response " + Convert.ToString(requestCount);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                     */
                }
                catch (Exception)
                {
                    clientSocket.Close();
                    serverSocket.Stop();  
                    //Console.WriteLine(ex.ToString());
                }
            }                  
           
        }
    }
}
