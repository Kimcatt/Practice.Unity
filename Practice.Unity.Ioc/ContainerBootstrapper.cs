using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Diagnostics;
using Practice.Unity.Utility;
using Practice.Unity.Sender;

namespace Practice.Unity.Ioc
{
    public class ContainerBootstrapper
    {
        public static void RegisterTypesWithCode(IUnityContainer container)
        {
            Trace.WriteLine("Container Bootstrapper executing type registrations....", "Unity");
            ConsoleHelper.WriteGreenLine("Running Container Code Test: ");
            container = new UnityContainer();

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
    }
}
