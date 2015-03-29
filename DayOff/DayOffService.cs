using butterfly.com.rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayOff
{
    public class DayOffService
    {
        protected HttpParams httpParameters;
        protected string httpContentType;
        protected string url;
        protected string apiKey;        
        protected int timeout;

        public void Initialize()
        {
            this.apiKey = Properties.Settings.Default.apiKey;
            this.url = Properties.Settings.Default.url;            
            this.timeout = Properties.Settings.Default.timeout;
            this.httpContentType = "application/json";
            this.httpParameters = new HttpParams();
            this.httpParameters.Add("apiKey", this.apiKey);
        }

        protected void readWeb()
        {
            //MsgService.AddInfo(String.Format("Read from {0}...", this.url));
            Http.get(this.url, httpParameters, httpContentType, timeout).then(this.PullCompletedAction).Async();
        }
        protected void PullCompletedAction(object sender, HttpResponseEventArgs e)
        {            
            if (e.StatusCode == System.Net.HttpStatusCode.OK)
            {
         
            }
            else
            {
                //MsgService.AddInfo(String.Format("Read failed ({0}). {1}", e.StatusCode, e.Content));
            }
        }
    }
}
