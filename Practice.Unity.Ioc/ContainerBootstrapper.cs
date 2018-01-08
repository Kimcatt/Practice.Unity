using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Diagnostics;
using Practice.Unity.Utility;
using Practice.Unity.Sender;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Practice.Unity.Calculator;

namespace Practice.Unity.Ioc
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypesWithCode(IUnityContainer container)
        {
            Trace.WriteLine("Container Bootstrapper executing type registrations....", "Unity");
            ConsoleHelper.WriteGreenLine("Running Container Code Test: ");

            //默认注册（无命名）,如果后面还有默认注册会覆盖前面的
            container.RegisterType<ISender, MailSender>()
                     .RegisterType<ISender, TelegraphSender>("tel");

            //命名注册
            container.RegisterType<ISender, TelegraphSender>("tel");

            //解析默认对象
            ISender sender = container.Resolve<ISender>();
            sender.Send();

            //指定命名解析对象
            ISender namedSender = container.Resolve<ISender>("tel");
            namedSender.Send();

            //获取容器中所有ISender的注册的已命名对象
            IEnumerable<ISender> classList = container.ResolveAll<ISender>();
            foreach (var item in classList)
            {
                item.Send();
            }
            Console.WriteLine();

        }

        public static void RegisterTypesWithConfiguration(IUnityContainer container)
        {
            ConsoleHelper.WriteGreenLine("Running Container Configuration Test: ");
            string configFile = /*AppDomain.CurrentDomain.BaseDirectory+*/ @"Unity.config";
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };

            //从config文件中读取配置信息
            Configuration configuration =
                ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            //获取指定名称的配置节
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");

            //载入名称为myClass 的container节点
            container.LoadConfiguration(section, "calculator");

            //解析默认对象
            ICalculator calculator = container.Resolve<ICalculator>("simpleCalculator");
            


            //获取容器中所有IStudent的注册的已命名对象
            IEnumerable<ICalculator> calculators = container.ResolveAll<ICalculator>();
            Console.WriteLine(string.Format("{0} calculators found...", calculators.Count()));
            int cnt = 0;
            foreach (var item in calculators)
            {
                Console.WriteLine("Calculator #{0} is running...", ++cnt);
                for (int i = 0; i < 10; i++)
                {
                    item.Calculate(string.Format("{0} {1} {2}", RandomHelper.NextInt(1, 10), "+-*/"[RandomHelper.NextInt(0, 3)], RandomHelper.NextInt(1, 10)));
                }
            }
            Console.WriteLine();
        }
    }
}
