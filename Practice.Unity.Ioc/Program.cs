using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Unity.Ioc.Model;

namespace Practice.Unity.Ioc
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInfo userInfo = new UserInfo
            {
                Name = "Kimcatt",
                Birthday = DateTime.Now
            };

            ContainerBootstrapper.RegisterTypesWithCode(new global::Unity.UnityContainer());
            ContainerBootstrapper.RegisterTypesWithConfiguration(new global::Unity.UnityContainer());
            Console.ReadKey();
        }
    }
}
