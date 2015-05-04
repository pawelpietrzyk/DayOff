using butterfly.com.mongo;
using DayOff.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace DayOff.ViewModel
{
    public class DayOffViewModel : INotifyPropertyChanged
    {
        public DayOffViewModel()
        {            
            this.service = new DayOffService();
            this.service.ReadComplete += service_ReadComplete;
            this.Days = this.service.Days;
            
           
            //this.Days = CollectionViewSource.GetDefaultView(this.service.Days);
            //this.Days.CurrentChanged += Days_CurrentChanged;
        }
        private DateTime currentDay;
        public DateTime CurrentDay
        {
            get
            {
                return currentDay;
            }
            set
            {
                this.currentDay = value;
                OnPropertyChanged("CurrentDay");
            }
        }
        private int currentState;
        public int CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                OnPropertyChanged("CurrentState");
            }
        }
        
        private DayOffService service;        
        public MongoDayOffs Days
        {
            get { return this.service.Days; }
            set
            {
                this.service.Days = value;                
            }
        }
        public void Update(MongoDayOff day)
        {
            if (day != null)
            {
                this.service.Update(day);
            }
        }
        public void Add()
        {
            MongoDayOff dayOff = new MongoDayOff();
            dayOff.Edit = true;            
            dayOff.State = 1;
            dayOff.Date = DateTime.Now;           
            this.service.Days.Add(dayOff);
            //this.Days = CollectionViewSource.GetDefaultView(this.service.Days); 
        }
        public void Edit(MongoDayOff day)
        {
            this.service.Edit(day);
        
        }
        public void Delete(MongoDayOff day)
        {
            this.service.Delete(day);
        }
        public void Read()
        {
            this.service.Read();
        }
        void service_ReadComplete(object sender, EventArgs e)
        {
            this.CurrentDay = this.service.CurrentDay;
            this.CurrentState = this.service.CurrentState;
            //this.Days.CurrentChanged += Days_CurrentChanged;
        }

        void Days_CurrentChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
