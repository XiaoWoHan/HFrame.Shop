using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HFrame.Sockets
{
    public class SocketsClient
    {
        #region 私有属性
        /// <summary>
        /// 服务器地址
        /// </summary>
        private string _IP = "127.0.0.1";
        /// <summary>
        /// 端口号
        /// </summary>
        private int _PORT = 49152;
        /// <summary>
        /// 用于监听
        /// </summary>
        private Socket _SOCKET = null;
        /// <summary>
        /// 用于通信
        /// </summary>
        private Socket _SOCKETSEND = null;
        /// <summary>
        /// 接受消息线程
        /// </summary>
        Thread _THREADReceive;
        #endregion

        #region 构造函数
        public SocketsClient()
        {
        }
        public SocketsClient(string IPAddress)
            => _IP = IPAddress;
        public SocketsClient(string IPAddress, int Port) : this(IPAddress)
            => _PORT = Port;
        #endregion
        /// <summary>
        /// 连接服务器
        /// </summary>
        public void ConnectServer()
        {
            try
            {
                _SOCKETSEND = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(_IP);
                _SOCKETSEND.Connect(ip, Convert.ToInt32(_PORT));

                //开启一个新的线程不停的接收服务器发送消息的线程
                _THREADReceive = new Thread(new ThreadStart(Receive));
                //设置为后台线程
                _THREADReceive.IsBackground = true;
                _THREADReceive.Start();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 监听服务器发送的消息
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

                            //MessageBox.Show("保存文件成功");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Msg"></param>
        public void SendMsg(string Msg)
        {
            try
            {
                byte[] buffer = new byte[2048];
                buffer = Encoding.Default.GetBytes(Msg);
                int receive = _SOCKETSEND.Send(buffer);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
