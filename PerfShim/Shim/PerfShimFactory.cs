using Castle.DynamicProxy;
using System.ComponentModel;

namespace ApiShim.Shim
{
    internal class PerfShimFactory
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static C CreateProxy<T, C>()
            where T : class
            where C : class
        {
            var proxy = Generator.CreateInterfaceProxyWithTarget<T>(targetInterface, new PerfInterceptor<T>());
            return proxy;
        }
    }
}
