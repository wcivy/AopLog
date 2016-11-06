using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;

namespace AopLog.UnityAop
{
    public class LoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var handler = new LoggerCallHandler();
            handler.Order = this.Order;
            return handler;
        }
    }
}
