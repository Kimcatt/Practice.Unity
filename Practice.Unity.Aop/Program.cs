using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Practice.Unity.Aop
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContainerBootstrapper.InterceptUsingInterfaceInterceptor(new UnityContainer());
            //ContainerBootstrapper.InterceptUsingTransparentProxyInterceptor(new UnityContainer());
            //ContainerBootstrapper.InterceptUsingVirtualMethodInterceptor(new UnityContainer());
            //ContainerBootstrapper.InterceptUsingAdditionalInterface(new UnityContainer());
            //ContainerBootstrapper.InterceptWithoutUnityContainer();
            //ContainerBootstrapper.InterceptWithoutUnityContainer2();
            //ContainerBootstrapper.InterceptUsingPolicyInjection(new UnityContainer());
            ContainerBootstrapper.InterceptUsingPolicyInjectionAttributes(new UnityContainer());

            Console.ReadKey();
        }
    }
}
