using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Sender
{
    public class TelegraphSender : ISender
    {
        public TelegraphSender()
        {
            Console.WriteLine($">>> A telegraph sender ({GetHashCode()}) is under construction....");
        }

        public void Send()
        {
            Console.WriteLine($">>> A telegraph sender ({GetHashCode()}) is sending...");
        }


    }
}
