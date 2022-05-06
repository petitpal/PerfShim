using Castle.DynamicProxy;

namespace ApiShim.Shim
{
    internal class PerfInterceptor<T> : IInterceptor
    {
        private readonly dynamic _target;
        public PerfInterceptor(T target)
        {
            _target = target;
        }

        public void Intercept(IInvocation invocation)
        {
            var startTime = DateTime.Now;
            invocation.Proceed();
            var duration = DateTime.Now - startTime;
            Console.WriteLine($"{invocation.Method.Name}[{duration.TotalMilliseconds}]");
        }
    }
}
