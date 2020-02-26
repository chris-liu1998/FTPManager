using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    /// <summary>
    /// 登录、连接状态
    /// </summary>
    public class ConnectionState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isConnecting;  // 是否正在连接
        private bool isConnected;   //是否连接成功
        public bool IsConnecting
        {
            get { return isConnecting; }
            set
            {
                isConnecting = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsConnecting"));
                }
            }
        }
        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsConnected"));
                }
            }
        }
    }
}
