using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPManager
{
    class LoginState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isLogingin;
        public bool IsLogingin
        {
            get { return isLogingin; }
            set
            {
                isLogingin = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsLogingin"));
                }
            }
        }
    }
}
