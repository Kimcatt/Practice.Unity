using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Diagnostics;

namespace Practice.Unity.Ioc
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            Trace.WriteLine("Container Bootstrapper executing type registrations....", "Unity");


        }
    }
}
