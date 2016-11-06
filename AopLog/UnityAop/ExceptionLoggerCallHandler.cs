using System;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopLog.UnityAop
{
    internal class ExceptionLoggerCallHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                Logging.AopLogger.Instance.Error(result.Exception.Message, Environment.StackTrace);
            }
            return result;
        }
    }
}
