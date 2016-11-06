using Microsoft.Practices.Unity;

using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace AopLog.UnityAop
{
    public class UnityContainerHelper
    {
        private IUnityContainer _container;

        public static UnityContainerHelper Instance = new UnityContainerHelper();

        private UnityContainerHelper(){}

        public void Register()
        {
            _container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            _container.LoadConfiguration(section, "AopLog");
        }

        public T GetServer<T>()
        {
            return _container.Resolve<T>();
        }

        public T GetServer<T>(string ConfigName)
        {
            return _container.Resolve<T>(ConfigName);
        }

        /// <summary>
        /// 返回构造函数带参数
        /// </summary>
        /// <typeparam name="T">依赖对象</typeparam>
        /// <param name="parameterList">参数集合（参数名，参数值）</param>
        /// <returns></returns>
        public T GetServer<T>(Dictionary<string, object> parameterList)
        {
            var list = new ParameterOverrides();
            foreach (KeyValuePair<string, object> item in parameterList)
            {
                list.Add(item.Key, item.Value);
            }
            return _container.Resolve<T>(list);
        }

        /// <summary>
        /// 返回构造函数带参数
        /// </summary>
        /// <typeparam name="T">依赖对象</typeparam>
        /// <param name="ConfigName">配置文件中指定的文字(没写会报异常)</param>
        /// <param name="parameterList">参数集合（参数名，参数值）</param>
        /// <returns></returns>
        public T GetServer<T>(string ConfigName, Dictionary<string, object> parameterList)
        {
            var list = new ParameterOverrides();
            foreach (KeyValuePair<string, object> item in parameterList)
            {
                list.Add(item.Key, item.Value);
            }
            return _container.Resolve<T>(ConfigName, list);
        }
    }
}
