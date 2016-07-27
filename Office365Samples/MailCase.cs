using Microsoft.Office365.OutlookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office365Samples
{
    class MailCase
    {
        public static async void GetMessages(string accessToken)
        {

            OutlookServicesClient client = new OutlookServicesClient(new Uri("https://outlook.office.com/api/v2.0/"), () =>
            {
                return Task.Delay(10).ContinueWith(t => accessToken);
            });

            var Messages = client.Me.Messages.OrderBy(msg => msg.ReceivedDateTime).Take(20).ExecuteAsync().Result;
            int i = 0;
            foreach (var msg in Messages.CurrentPage)
            {
                Console.WriteLine($"({++i,-3}:){msg.Subject,-50}:\t{msg.ReceivedDateTime,-30}");
            }
        }
    }
}
