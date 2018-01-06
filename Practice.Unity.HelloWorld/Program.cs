using Unity.Configuration;
using Practice.Unity.HelloWorld.Service;
using System;
using System.Configuration;
using Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Practice.Unity.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            IProgrammer programmer = null;
            programmer = ApplicationContext.UnityContainer.Resolve<IProgrammer>("CSharper");
            programmer.Work();
            programmer = ApplicationContext.UnityContainer.Resolve<IProgrammer>("VBer");
            programmer.Work();
            programmer = ApplicationContext.UnityContainer.Resolve<IProgrammer>("Pythoner");
            programmer.Work();
            programmer = ApplicationContext.UnityContainer.Resolve<IProgrammer>("Pythoner");
            programmer.Work();

            Console.ReadKey();
        }

        
    }
}
