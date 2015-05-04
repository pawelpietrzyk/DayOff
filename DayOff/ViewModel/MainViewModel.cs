using DayOff.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DayOff.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        DayOffView dayOffView;
        
        public MainViewModel()
        {
            dayOffView = new DayOffView();
        }

        
        
        public void DayOffView()
        {
            this.Content = dayOffView;
        }

        public void Launch()
        {
            this.DayOffView();
        }

        
        private ContentControl content;

        public ContentControl Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
