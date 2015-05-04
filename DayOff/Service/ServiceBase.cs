using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DayOff.Service
{
    public class ServiceBase : INotifyPropertyChanged
    {
        public event EventHandler ReadComplete;

        protected virtual void OnReadComplete()
        {
            if (ReadComplete != null)
            {
                ReadComplete(this, new EventArgs());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
