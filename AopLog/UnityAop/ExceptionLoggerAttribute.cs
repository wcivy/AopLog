using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AopLog.UnityAop
{
    public class ExceptionLoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            var handler = new ExceptionLoggerCallHandler();
            handler.Order = this.Order;
            return handler;
        }
    }
}
