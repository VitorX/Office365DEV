using Newtonsoft.Json.Linq;
using RESTRequsetHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftGraphSamples
{
    class DriveItemCase
    {
        public static void CreateItem(string accessToken)
        {
            string itemCreateUri = "https://graph.microsoft.com/v1.0/me/drive/root/children";
            string itemData = "{\"name\":\"book2.pdf\",\"file\":{}}";
            var itemCreatedResult = RESTRequsetHelper.RESTRequsetHelper.PostAsync(itemCreateUri, itemData, accessToken).Result;
            DriveItem item = new DriveItem(itemCreatedResult);

            string itemUploadUri= $"https://graph.microsoft.com/v1.0/me/drive/items/{item.Id}/content";

            System.IO.FileStream fs = System.IO.File.Open(@"C:\users\v-fexue\desktop\book1.pdf",System.IO.FileMode.Open);
            StreamContent streamContent = new StreamContent(fs);
            var uploadResult= RESTRequsetHelper.RESTRequsetHelper.SendHttpRequest(HttpVerb.PUT, itemUploadUri, streamContent, accessToken).Result;

            fs.Close();

        }


    }

    class DriveItem
    {
        public String Name{get;set;}
        public String Id { get; set; }
        public DriveItem(string jsonDriveItem)
        {
            Id = JObject.Parse(jsonDriveItem)["id"].Value<string>();
            Name = JObject.Parse(jsonDriveItem)["name"].Value<string>();
        }
    }
}
