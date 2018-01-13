using Practice.Unity.Aop.CallHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Practice.Unity.Aop.Attribute.HandlerAttribute
{
    public class LoggingCallHandlerAttribute : global::Unity.Interception.PolicyInjection.Policies.HandlerAttribute
    {
        private readonly int order;
        public LoggingCallHandlerAttribute(int order)
        {
            this.order = order;
        }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LoggingCallHandler() { Order = order };
        }
    }
}
