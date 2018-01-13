using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Unity.Storage;
using Practice.Unity.Utility;
using Practice.Unity.Aop.InterceptionBehavior;
using Unity;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;
using Unity.Interception.Interceptors.InstanceInterceptors.TransparentProxyInterception;
using Unity.Interception.Interceptors.TypeInterceptors.VirtualMethodInterception;
using Unity.Interception;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection;
using Unity.Injection;
using Unity.Interception.PolicyInjection.MatchingRules;
using Practice.Unity.Aop.CallHandler;
using Unity.Lifetime;

namespace Practice.Unity.Aop
{
    public static class ContainerBootstrapper
    {
        public static void InterceptUsingInterfaceInterceptor(IUnityContainer unityContainer)
        {
            ConsoleHelper.WriteGreenLine("Interpt using InterfaceInterceptor...");
            Console.WriteLine("注册");
            unityContainer.AddNewExtension<Interception>();
            unityContainer.RegisterType<IConnectionStringCache, SimpleConnectionStringCache>();
            unityContainer.RegisterType<IConnectionStringStorage, SimpleConnectionStringStorage>
            (
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>()
            );
            Console.WriteLine("解析对象");
            var storage = unityContainer.Resolve<IConnectionStringStorage>();
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }

        }

        public static void InterceptUsingTransparentProxyInterceptor(IUnityContainer unityContainer)
        {
            ConsoleHelper.WriteGreenLine("Interption using TransparentProxyInterceptor...");
            Console.WriteLine("注册");
            unityContainer.AddNewExtension<Interception>();
            unityContainer.RegisterType<IConnectionStringCache, SimpleConnectionStringCache>();
            unityContainer.RegisterType<IConnectionStringStorage, SimpleConnectionStringStorage>
            (
                new Interceptor<TransparentProxyInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>()
            );
            Console.WriteLine("解析对象");
            var storage = unityContainer.Resolve<IConnectionStringStorage>();
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }

        }

        public static void InterceptUsingVirtualMethodInterceptor(IUnityContainer unityContainer)
        {
            ConsoleHelper.WriteGreenLine("Interption using VirtualMethodInterceptor...");
            Console.WriteLine("注册");
            unityContainer.AddNewExtension<Interception>();
            unityContainer.RegisterType<IConnectionStringCache, SimpleConnectionStringCache>();
            unityContainer.RegisterType<IConnectionStringStorage, SimpleConnectionStringStorage>
            (
                new Interceptor<VirtualMethodInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>()
            );
            Console.WriteLine("解析对象");
            var storage = unityContainer.Resolve<IConnectionStringStorage>();
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }
        }

        public static void InterceptUsingAdditionalInterface(IUnityContainer unityContainer)
        {
            ConsoleHelper.WriteGreenLine("Interpt using AdditionalInterface...");
            Console.WriteLine("注册");
            unityContainer.AddNewExtension<Interception>();
            unityContainer.RegisterType<IConnectionStringCache, SimpleConnectionStringCache>();
            unityContainer.RegisterType<IConnectionStringStorage, SimpleConnectionStringStorage>
            (
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggerSpecificInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>(),
                new AdditionalInterface<ILogger>()
            );
            Console.WriteLine("解析对象");
            var storage = unityContainer.Resolve<IConnectionStringStorage>();
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                ((ILogger)storage).WriteLogMessage(string.Format("[日志记录] 请求参数为: {0}", key));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }

        }

        public static void InterceptWithoutUnityContainer()
        {
            //var storage = new SimpleConnectionStringStorage();
            IConnectionStringStorage storage = Intercept.ThroughProxy<IConnectionStringStorage>
            (
                new SimpleConnectionStringStorage(),
                new InterfaceInterceptor(),
                new IInterceptionBehavior[]
                {
                    new LoggingInterceptionBehavior(), new CachingInterceptionBehavior { Cache = new SimpleConnectionStringCache() }
                }
            );
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }



        }

        public static void InterceptWithoutUnityContainer2()
        {
            var storage = new SimpleConnectionStringStorage();
            IConnectionStringStorage proxyStorage = Intercept.ThroughProxy<IConnectionStringStorage>
            (
                storage,
                new InterfaceInterceptor(),
                new IInterceptionBehavior[]
                {
                    new LoggingInterceptionBehavior(), new CachingInterceptionBehavior { Cache = new SimpleConnectionStringCache() }
                }
            );
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = proxyStorage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }
        }

        public static void InterceptUsingPolicyInjection(IUnityContainer container)
        {
            ConsoleHelper.WriteGreenLine("Intercept using policy injection...");
            container.AddNewExtension<Interception>();
            container.RegisterType<IConnectionStringCache, SimpleConnectionStringCache>();
            container.RegisterType<IConnectionStringStorage, SimpleConnectionStringStorage>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());

            var first = new InjectionProperty("Order", 1);
            var cache = new InjectionProperty("Cache", container.Resolve<IConnectionStringCache>());
            var second = new InjectionProperty("Order", 2);
            container.Configure<Interception>()
                     .AddPolicy("logging")
                     .AddMatchingRule<AssemblyMatchingRule>(new InjectionConstructor(new InjectionParameter("Practice.Unity.Storage")))
                     .AddCallHandler<LoggingCallHandler>(new ContainerControlledLifetimeManager(), new InjectionConstructor(), first);
            container.Configure<Interception>()
                     .AddPolicy("caching")
                     .AddMatchingRule<MemberNameMatchingRule>(new InjectionConstructor(new[] { "Get*"/*, "Save*"*/ }, true))
                     .AddMatchingRule<NamespaceMatchingRule>(new InjectionConstructor("Practice.Unity.Storage", true))
                     .AddCallHandler<ConnectionStringCachingCallHandler>(new ContainerControlledLifetimeManager(), new InjectionConstructor(), second, cache);

            var storage = container.Resolve<IConnectionStringStorage>();
            Console.WriteLine("执行方法");
            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }
        }

        public static void InterceptUsingPolicyInjectionAttributes(IUnityContainer container)
        {
            ConsoleHelper.WriteGreenLine("Intercept using policy injection attributes...");
            container.AddNewExtension<Interception>();
            container.RegisterType<IConnectionStringStorage, ConnectionStringStorageWithAttributes>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<InterfaceInterceptor>());
            var storage = container.Resolve<IConnectionStringStorage>();

            Console.WriteLine("执行方法");

            Random random = new Random((int)DateTime.Now.Ticks);
            string res;
            for (int i = 0; i < 4; i++)
            {
                string key = string.Format("12{0}", random.Next(3));
                res = storage.GetConnectionString(key);
                Console.WriteLine(string.Format("获取键值为{0}的结果为：{1}", key, res));
            }
        }

    }



}
