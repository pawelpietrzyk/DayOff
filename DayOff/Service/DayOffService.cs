using butterfly.com.mongo;
using butterfly.com.rest;
using DayOff.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace DayOff.Service
{
    public class DayOffService : ServiceBase
    {
        protected HttpParams httpParameters;
        protected string httpContentType;
        protected string url;
        protected string apiKey;        
        protected int timeout;
        private MongoDayOffs days;
        private MongoDayOff updatingDay;
        private bool readState;

        public MongoDayOffs Days
        {
            get { return days; }
            set
            {
                days = value;
                OnPropertyChanged("Days");                
            }
        }
        public DayOffService()
        {
            this.Initialize();
        }
        public void Initialize()
        {
            this.days = new MongoDayOffs();
            this.days.CollectionChanged += days_CollectionChanged;
            this.apiKey = Properties.Settings.Default.apiKey;
            this.url = Properties.Settings.Default.url;            
            this.timeout = Properties.Settings.Default.timeout;
            this.httpContentType = "application/json";
            this.httpParameters = new HttpParams();
            this.httpParameters.Add("apiKey", this.apiKey);
        }
        private DateTime currentDay;
        private int currentState;

        public int CurrentState
        {
            get { return currentState; }
            set
            {
                currentState = value;
                OnPropertyChanged("CurrentState");
            }
        }

        public DateTime CurrentDay
        {
            get { return currentDay; }
            set
            {
                currentDay = value;
                OnPropertyChanged("CurrentDay");
            }
        }
        private void CalculateCurrent()
        {
            IEnumerable<DayOffGroup> items = 
                from item in Days
                group item by item.Type into grc
                select new DayOffGroup 
                {
                    Type = grc.Key,
                    State = grc.Sum(p => p.State)
                };
            List<DayOffGroup> groups = items.ToList();
            int balance = 0;
            int state = 0;
            if (groups != null)
            {                
                foreach (DayOffGroup gr in groups)
                {
                    if (gr.Type == DayOffType.Balance)
                    {
                        balance = gr.State;
                    }
                    if (gr.Type == DayOffType.DayOff)
                    {
                        state = gr.State;
                    }
                }                
            }
            this.CurrentState = (balance - state);
            this.CurrentDay = DateTime.Now;            
            
        }
        void days_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!readState)
            {
                string act = e.Action.ToString();
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (object obj in e.NewItems)
                    {
                        MongoDayOff day = obj as MongoDayOff;
                        if (day != null)
                        {
                            this.Update(day);
                        }
                    }
                }
            }
        }        
        public void Edit(MongoDayOff day)
        {
            int idx = this.Days.IndexOf(day);
            day.Edit = !day.Edit;
            this.Days.RemoveAt(idx);
            this.Days.Insert(idx, day);
        }
        public void Delete(MongoDayOff dayOff)
        {
            if (dayOff != null)
            {
                if (dayOff.Id != null)
                {
                    
                    string url = String.Format("{0}/{1}", this.url, dayOff.Id.oid);
                    Http.delete(url, httpParameters, httpContentType).then(this.DeleteCompletedAction).Async();
                }
            }
        }
        public void Read()
        {
            Http.get(this.url, httpParameters, httpContentType, timeout).then(this.PullCompletedAction).Async();
        }
        public void Update(MongoDayOff dayOff)
        {
            updatingDay = dayOff;
            if (dayOff.Id != null)
            {
                string url = String.Format("{0}/{1}", this.url, dayOff.Id.oid);
                //MsgService.AddInfo(String.Format("Update: {0}", mongoInfo));
                Http.put(url, Serializer.SerializeToString(dayOff), httpParameters, httpContentType).then(this.PushCompletedAction).Async();
            }
            else
            {
                //MsgService.AddInfo(String.Format("Create: {0}", mongoInfo));
                Http.post(this.url, Serializer.SerializeToString(dayOff), httpParameters, httpContentType).then(this.PushCompletedAction).Async();
            }
        }
        protected void DeleteCompletedAction(object sender, HttpResponseEventArgs e)
        {
            if (e.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MongoDayOff dayOff = Serializer.Deserialize(e.Content, typeof(MongoDayOff)) as MongoDayOff;
                if (dayOff != null)
                {
                    this.Days.Remove(dayOff);
                    this.CalculateCurrent();
                    this.OnReadComplete();
                }
                
            }
        }
        protected void PushCompletedAction(object sender, HttpResponseEventArgs e)
        {

            if (e.StatusCode == System.Net.HttpStatusCode.OK)
            {

                MongoDayOff dayOff = Serializer.Deserialize(e.Content, typeof(MongoDayOff)) as MongoDayOff;
                if (dayOff != null)
                {
                    if (dayOff.Id != null)
                    {
                        updatingDay.Id = dayOff.Id;
                        this.CalculateCurrent();
                        this.OnReadComplete();
                        //updatingDay = dayOff;
                        //MsgService.AddInfo(String.Format("Updated: {0}", info.ToString()));
                    }                    
                }
            }
            else
            {
                //MsgService.AddInfo(String.Format("Update failed ({0}). {1}", e.StatusCode, e.Content));
            }

        }
        
        protected void PullCompletedAction(object sender, HttpResponseEventArgs e)
        {            
            if (e.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.readState = true;
                this.Days.Clear();
                MongoDayOffs tmp = Serializer.Deserialize(e.Content, typeof(MongoDayOffs)) as MongoDayOffs;
                IEnumerable<MongoDayOff> tmps =
                    from item in tmp
                    orderby item.Date ascending
                    select item;
                List<MongoDayOff> tmpSorted = tmps.ToList();

                foreach (MongoDayOff day in tmpSorted)
                {
                    this.Days.Add(day);
                }
                this.readState = false;
                //this.Days.Clear();
                this.CalculateCurrent();
                this.OnReadComplete();                
            }
            else
            {
                //MsgService.AddInfo(String.Format("Read failed ({0}). {1}", e.StatusCode, e.Content));
            }
        }
    }
}
