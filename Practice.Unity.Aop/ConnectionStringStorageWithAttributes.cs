using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Unity.Aop.Attribute.HandlerAttribute;
namespace Practice.Unity.Aop
{
    public class ConnectionStringStorageWithAttributes : Storage.IConnectionStringStorage
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        [LoggingCallHandler(1)]
        [ConnectionStringCachingCallHandler(2)]
        public string GetConnectionString(string key)
        {
            Utility.ConsoleHelper.WriteYellowLine(string.Format("{0} istance is working on get...", nameof(ConnectionStringStorageWithAttributes)));
            return string.Format("Connection string #{0}", random.Next(100));
        }

        public void SaveConnectionString(string key, string val)
        {
            Console.WriteLine("{0} istance is working on save...", nameof(ConnectionStringStorageWithAttributes));
        }
    }
}
