using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Unity.Sender
{
    public class MailSender : ISender
    {

        public MailSender()
        {
            Console.WriteLine($">>> A mail sender ({this.GetHashCode()}) is under construction...");
        }

        public void Send()
        {
            Console.WriteLine($">>> A mail sender ({this.GetHashCode()}) is sending...");
        }

    }
}
