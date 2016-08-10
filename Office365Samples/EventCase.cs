using Microsoft.Office365.OutlookServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OData.Client;

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

        public static async void UpdateEvent(string accessToken)
        {
            OutlookServicesClient service = new OutlookServicesClient(new Uri("https://outlook.office.com/api/v2.0/"), () =>
            {
                return Task.Delay(10).ContinueWith(t => accessToken);
            });


            string meetingEventId = "AAMkADQyZjE2NzY3LWEyNjEtNGI3Ny05YmE5LWM3Yjk1N2RiZjg2YQBGAAAAAACjfX4Ad-CaQJG0NYun281fBwC90J0GawtZTaVMfIdaQJ8wAAAAAAENAAC90J0GawtZTaVMfIdaQJ8wAAFpdh5RAAA=";
            bool updated;
            try
            {
                var taskUpdateMeeting = Task<bool>.Run(async () =>
                {
                    bool updateStatus = false;
                    IEvent meetingToUpdate = await service.Me.Events.GetById(meetingEventId).ExecuteAsync();
                    if (meetingToUpdate != null)
                    {
                        
                        DateTimeTimeZone newStart = new DateTimeTimeZone();
                        newStart.DateTime= "2016-08-06T19:00:00.0000000";
                        newStart.TimeZone = "Asia/Kolkata";


                        DateTimeTimeZone newEnd = new DateTimeTimeZone();
                        newEnd.DateTime = "2016-08-06T19:30:00.0000000";
                        newEnd.TimeZone = "Asia/Kolkata";

                        meetingToUpdate.Start = newStart;
                        meetingToUpdate.End = newEnd;
                     
                        await meetingToUpdate.UpdateAsync(true);
                        await meetingToUpdate.SaveChangesAsync();

                        updateStatus = true;
                    }
                    return updateStatus;
                });
                Task.WaitAll(taskUpdateMeeting);
                updated = taskUpdateMeeting.Result;
            }
            catch (Exception ex)
            {
                updated = false;
            }
        }
    }

}
