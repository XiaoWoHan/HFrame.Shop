using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace HFrame.Sockets
{
    public class SocketServer
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string IP = "127.0.0.1";
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port = 49152;
        /// <summary>
        /// 用于监听
        /// </summary>
        private Socket _SOCKET = null;
        /// <summary>
        /// 用于通信
        /// </summary>
        private Socket _SOCKETSEND = null;
        /// <summary>
        /// 客户端链接集合
        /// </summary>
        Dictionary<string, Socket> _DICSOCKET = new Dictionary<string, Socket>();

        #region 构造函数
        public SocketServer()
        {
        }
        public SocketServer(string IPAddress)
            => this.IP = IPAddress;
        public SocketServer(string IPAddress, int Port) : this(IPAddress)
            => this.Port = Port;
        #endregion
        /// <summary>
        /// 开启服务
        /// </summary>
        public void StartServer()
        {
            try
            {
                //初始化一个Socket对象
                _SOCKET = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //创建ip对象
                IPAddress Address = IPAddress.Parse(IP);
                //创建网络节点对象包含ip和port
                IPEndPoint Point = new IPEndPoint(Address, Port);
                //将监听套接字绑定到 对应的IP和端口
                _SOCKET.Bind(Point);
                //开始监听:设置最大可以同时连接多少个请求
                _SOCKET.Listen(int.MaxValue);
                //创建线程
                var AcceptSocketThread = new Thread(new ThreadStart(ListenStock));
                AcceptSocketThread.IsBackground = true;
                AcceptSocketThread.Start();
            }
            catch
            {
            }
        }
        public void ListenStock()
        {
            while (true)
            {
                //等待客户端的连接，并且创建一个用于通信的Socket
                _SOCKETSEND = _SOCKET.Accept();
                //获取远程主机的ip地址和端口号
                string strIp = _SOCKETSEND.RemoteEndPoint.ToString();
                _DICSOCKET.Add(strIp, _SOCKETSEND);
                //定义接收客户端消息的线程
                Thread threadReceive = new Thread(new ThreadStart(Receive));
                threadReceive.IsBackground = true;
                threadReceive.Start();

            }
        }
        /// <summary>
        /// 接口服务器发送的消息
        /// </summary>
        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[2048];
                    //实际接收到的字节数
                    int r = _SOCKETSEND.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    else
                    {
                        //判断发送的数据的类型
                        if (buffer[0] == 0)//表示发送的是文字消息
                        {
                            string str = Encoding.Default.GetString(buffer, 1, r - 1);
                            Console.WriteLine(str);
                        }
                        //表示发送的是文件
                        if (buffer[0] == 1)
                        {
                            //SaveFileDialog sfd = new SaveFileDialog();
                            //sfd.InitialDirectory = @"";
                            //sfd.Title = "请选择要保存的文件";
                            //sfd.Filter = "所有文件|*.*";
                            //sfd.ShowDialog(this);

                            //string strPath = sfd.FileName;
                            //using (FileStream fsWrite = new FileStream(strPath, FileMode.OpenOrCreate, FileAccess.Write))
                            //{
                            //    fsWrite.Write(buffer, 1, r - 1);
                            //}
                        }
                    }


                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
