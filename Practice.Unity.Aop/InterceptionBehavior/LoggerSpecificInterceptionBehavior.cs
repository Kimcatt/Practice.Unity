using Practice.Unity.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Practice.Unity.Aop.InterceptionBehavior
{
    public class LoggerSpecificInterceptionBehavior : IInterceptionBehavior
    {
        public bool WillExecute
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var methodReturn = CheckForILogger(input);
            if (methodReturn != null)
            {
                return methodReturn;
            }
            return getNext()(input, getNext); //move next
        }
        private IMethodReturn CheckForILogger(IMethodInvocation input)
        {
            if (input.MethodBase.DeclaringType == typeof(ILogger)
            && input.MethodBase.Name == "WriteLogMessage")
            {
                WriteLog(input.Arguments["message"].ToString());
                return input.CreateMethodReturn(null);
            }
            return null;
        }

        private void WriteLog(string v)
        {
            ConsoleHelper.WriteGrayLine(v);
        }
    }
}
