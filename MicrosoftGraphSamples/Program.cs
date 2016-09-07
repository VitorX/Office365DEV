using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftGraphSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //string accessToken = "";
            //DriveItemCase.CreateItem(accessToken);

            test2();
            Console.ReadLine();
        }

        public static async void test()
        {
            string uri = "https://localhost:44301/API/SignUp/Onboard";
            string jsonBody = @"{ ""name"": ""fx@adfei.onmicrosoft.com""}";
            string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyIsImtpZCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyJ9.eyJhdWQiOiJodHRwczovL2FkZmVpLm9ubWljcm9zb2Z0LmNvbS9Ub2RvTGlzdFNlcnZpY2VNVCIsImlzcyI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0LzA0ZTE0YTJjLTBlOWItNDJmOC04YjIyLTNjNGEyZjFkODgwMC8iLCJpYXQiOjE0NzIxMDU5OTksIm5iZiI6MTQ3MjEwNTk5OSwiZXhwIjoxNDcyMTA5ODk5LCJhY3IiOiIxIiwiYW1yIjpbInB3ZCJdLCJhcHBpZCI6IjMyMDk0YTk2LWMyODItNDU5OC1iMzFkLTBhM2RkZWY2M2RkZSIsImFwcGlkYWNyIjoiMCIsImVfZXhwIjoxMDgwMCwiZmFtaWx5X25hbWUiOiJ4dWUiLCJnaXZlbl9uYW1lIjoiZmVpIiwiaXBhZGRyIjoiMTY3LjIyMC4yNTUuMTciLCJuYW1lIjoiZmVpIHh1ZSIsIm9pZCI6IjYzY2VlY2RhLWQzNzgtNDk4Ni05ZWVlLTMzMTYxMmQ0YzQ2NiIsInNjcCI6InVzZXJfaW1wZXJzb25hdGlvbiIsInN1YiI6IlJKc2pVM0xQcnQ5QW9wRXN5TzZEMWVFQ0g3YU1IbGdjcnYtNlBpTzJjekUiLCJ0aWQiOiIwNGUxNGEyYy0wZTliLTQyZjgtOGIyMi0zYzRhMmYxZDg4MDAiLCJ1bmlxdWVfbmFtZSI6ImZ4QGFkZmVpLm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6ImZ4QGFkZmVpLm9ubWljcm9zb2Z0LmNvbSIsInZlciI6IjEuMCJ9.h8ANTy3OMAV2boAJj2QhfU5_yfUEpRyf1G1yjPLJyChM-7IzyYJ4sAQwqCAI7H_wB5Au6FhYhNdThBgrhi_v-t1xiFNJtXAlmElAYw0VBoZtMiJyClZUqPIqyvLn-f1_T0DWCBViEIwOxfmehZ4jGLrsfAx6whml6qPVhruD3Lc7tJWC6OdDkqJ2S-D7rUMjCKlb8WqJQzp-tewtIfVrnf19KidskwELZJKJx6Y2V2x9KY56ItY0iPDC3Y2RXztnmZdtCk3gdFcV9_Y_NdPUmQJlTncaBVVdbEHGYbXFG2uxXadAMk2kgzzvszfAZJ0m2dMIdi_OqCAHBW6oK1d9ew";
            try
            {
                var ret = await RESTRequsetHelper.RESTRequsetHelper.PostAsync(uri, jsonBody, accessToken);
            }
            catch (Exception ex)
            {

            }
            

            Console.ReadLine();
        }


        public static async void test2()
        {
            string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyIsImtpZCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyJ9.eyJhdWQiOiJodHRwczovL2FkZmVpLm9ubWljcm9zb2Z0LmNvbS9Ub2RvTGlzdFNlcnZpY2UiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8wNGUxNGEyYy0wZTliLTQyZjgtOGIyMi0zYzRhMmYxZDg4MDAvIiwiaWF0IjoxNDcyMTg5MTY1LCJuYmYiOjE0NzIxODkxNjUsImV4cCI6MTQ3MjE5MzA2NSwiYWNyIjoiMSIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiIwZTljZWQ4ZC03Nzk1LTRjMWEtODJmYi1lMDUxZjFmNmVjMGMiLCJhcHBpZGFjciI6IjEiLCJlX2V4cCI6MTA4MDAsImZhbWlseV9uYW1lIjoieHVlIiwiZ2l2ZW5fbmFtZSI6ImZlaSIsImlwYWRkciI6IjE2Ny4yMjAuMjU1LjE3IiwibmFtZSI6ImZlaSB4dWUiLCJvaWQiOiI2M2NlZWNkYS1kMzc4LTQ5ODYtOWVlZS0zMzE2MTJkNGM0NjYiLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzdWIiOiJDU2ZVVmNYVHdlWTRZalZHUDlvYWg0b0dlUk45RTQxUG92VzFONmFWZXVJIiwidGlkIjoiMDRlMTRhMmMtMGU5Yi00MmY4LThiMjItM2M0YTJmMWQ4ODAwIiwidW5pcXVlX25hbWUiOiJmeEBhZGZlaS5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJmeEBhZGZlaS5vbm1pY3Jvc29mdC5jb20iLCJ2ZXIiOiIxLjAifQ.siE4IkWiBPo3CFGSJDMk1Zex6PW9Ku4bP7YdOXuB74ACGuz-J3M1X2tTM_bMqWDXl_b_QL-__S6tkEJtXd2yscud_tm-4ivGoqaHr0nUNrJuYLLGBtqn45XdbA3QhJC9wc6gyJ066khl-nh6GogHhjBOkf3CnOPOdNnzT4Ql5nxdjkCNGz69_6Olt41BocdFabmbDpbrjuHqpCRvb9su1NZoDKQcJ0Wt57lbJ3KWU-x1fi3BhgYDeWxHshFmLvX4YBxI7eZlVvuObqcdRZH0TSxB4dS5Y_5CkmBL0MUjDyR0c8ZWPRhR57dMPCSM-FVfPG1ehdKn5XaFJe6OusdEZw";
            //string todoListBaseAddress = "https://localhost.fiddler:44321";
            string todoListBaseAddress = "https://localhost.fiddler:44321";
            //string todoListBaseAddress = "https://localhost:44321";

            //string todoListBaseAddress = "https://www.baidu.com";
            // Forms encode todo item, to POST to the todo list web api.
            HttpContent content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("Title", "d") });

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, todoListBaseAddress + "/api/todolist");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            request.Headers.Add("customHeader1", "fei");
            request.Content = content;
            HttpResponseMessage response = await client.SendAsync(request);
            var res= await response.Content.ReadAsStringAsync();
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
