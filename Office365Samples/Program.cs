using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office365Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessToken = "";
            MailCase.GetMessages(accessToken);
            Console.ReadLine();
        }
    }
}
