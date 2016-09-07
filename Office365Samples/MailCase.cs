using Microsoft.Office365.OutlookServices;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static async void CreateItemAttachment(string accessToken, string messageId)
        {
            OutlookServicesClient client = new OutlookServicesClient(new Uri("https://outlook.office.com/api/v2.0/"), () =>
            {
                return Task.Delay(10).ContinueWith(t => accessToken);
            });

            var Messages = client.Me.Messages.GetById(messageId);
            ItemAttachment attach = new ItemAttachment();
            attach.Name = "reportImte.msg";

            FileAttachment fileAttach = new FileAttachment();
            fileAttach.ContentBytes = File.ReadAllBytes(@"C:\users\v-fexue\desktop\report.msg");
            fileAttach.Name = "report.msg";

            await Messages.Attachments.AddAttachmentAsync(fileAttach);
        }
    }
}
