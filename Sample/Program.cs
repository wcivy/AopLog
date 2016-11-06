using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AopLog;
using AopLog.UnityAop;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    AopLog.Logging.Logger.Instance.Error("test1");
            //    AopLog.Logging.Logger.Instance.Info("test2");
            //    AopLog.Logging.Logger.Instance.Warn("test3");
            //    throw new Exception("haha");
            //}
            //catch (Exception e)
            //{
            //    AopLog.Logging.Logger.Instance.Error("test4", e);
            //}

            try
            {
                //IUnityContainer container = new UnityContainer();
                //container.AddNewExtension<Interception>();

                //container
                //    .RegisterType<IMan, Man>()
                //    .Configure<Interception>()
                //    .SetInterceptorFor<IMan>(new InterfaceInterceptor());

                //IMan man = container.Resolve<IMan>();
                UnityContainerHelper.Instance.Register();
                var man = UnityContainerHelper.Instance.GetServer<IMan>("ManAop");
                man.Say("Hello World!");
                man.Run();

                Console.ReadLine();
            }
            catch{ }
        }
    }
}
