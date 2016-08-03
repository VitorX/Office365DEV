using Microsoft.Office365.OutlookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office365Samples
{
    class EventCase
    {
        public static async void GetEvents(string accessToken)
        {

            OutlookServicesClient client = new OutlookServicesClient(new Uri("https://outlook.office.com/api/v2.0/"), () =>
            {
                return Task.Delay(10).ContinueWith(t => accessToken);
            });

            var events = await (from i in client.Me.Events where (i.Start.DateTime.CompareTo("2016-07-18")>0 && i.End.DateTime.CompareTo("2016-07-25")<0) select i)
                      .Take(50)
                      .ExecuteAsync();

            foreach (var appointment in events.CurrentPage)
            {
                Console.WriteLine($"{appointment.Subject}:\t{appointment.Start}~{appointment.End}");
            }
        }
    }
}
