using Microsoft.Practices.Unity.InterceptionExtension;
using System.Text;

namespace AopLog.UnityAop
{
    internal class LoggerCallHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            StringBuilder sb = new StringBuilder();
            Logging.AopLogger.Instance.Info($"方法[{input.MethodBase.Name}]开始执行。");
            for (var i = 0; i < input.Arguments.Count; i++)
            {
                sb.Append($"{input.Arguments.ParameterName(i)}={input.Arguments[i].ToString()},");
            }
            if(sb.Length > 0)Logging.AopLogger.Instance.Info($"参数:{sb.ToString().TrimEnd(',')}");
            IMethodReturn result = getNext()(input, getNext);
            Logging.AopLogger.Instance.Info($"方法[{input.MethodBase.Name}]结束执行。");
            return result;
        }
    }
}
