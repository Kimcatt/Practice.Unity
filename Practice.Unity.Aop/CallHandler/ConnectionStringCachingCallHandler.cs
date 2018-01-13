using Practice.Unity.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Practice.Unity.Aop.CallHandler
{
    public class ConnectionStringCachingCallHandler : ICallHandler
    {
        public int Order { get; set; }

        [Dependency]
        public IConnectionStringCache Cache { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            // Before invoking the method on the original target.
            if (input.MethodBase.Name == "GetConnectionString")
            {
                var key = input.Arguments["key"].ToString();
                if (IsInCache(key))
                {
                    return input.CreateMethodReturn(FetchFromCache(key));
                }
                else
                {
                    IMethodReturn routine = getNext()(input, getNext);
                    //Task.Run(() =>
                    //{
                    //    AddToCache(key, routine.ReturnValue.ToString());
                    //});
                    AddToCache(key, routine.ReturnValue.ToString());
                    return /*input.CreateMethodReturn(result.ReturnValue.ToString())*/routine;
                }
            }
            IMethodReturn result = getNext()(input, getNext);
            // After invoking the method on the original target.
            //if (input.MethodBase.Name == "SaveConnectionString")
            //{
            //    AddToCache(input.Arguments["key"].ToString(), input.Arguments["val"].ToString());
            //}
            return result;
        }

        private bool IsInCache(string key)
        {
            return Cache.IsInCache(key);
        }
        private string FetchFromCache(string key)
        {
            Console.WriteLine(string.Format("读取缓存{0}内容...", nameof(SimpleConnectionStringCache)));
            return Cache.GetConnectionString(key);
        }
        private void AddToCache(string key, string val)
        {
            Console.WriteLine(string.Format("写入缓存{0}中...", nameof(SimpleConnectionStringCache)));
            Cache.SaveConnectionString(key, val);
        }
    }
}
