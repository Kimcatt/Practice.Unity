using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Practice.Unity.HelloWorld
{
    public sealed class ApplicationContext
    {
        private static IUnityContainer unityContainer = null;

        #region Unity Container Register
        private static void RegisterContainer()
        {
            unityContainer = new UnityContainer();
            UnityConfigurationSection config = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            config.Configure(unityContainer, "Programmer");
        }

        public static IUnityContainer UnityContainer
        {
            get { return unityContainer; }
        }

        static ApplicationContext()
        {
            RegisterContainer();
        }
        #endregion

    }
}
