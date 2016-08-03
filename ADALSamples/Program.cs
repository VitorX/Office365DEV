using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            CertHelperTest.CreateClientAssertion();
            Console.ReadLine();
        }
    }
}
