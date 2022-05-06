using ServviceInterfaces;

namespace ApiShim
{
    internal class App : IApp
    {
        private readonly ISomeService1 _someService1;
        private readonly ISomeService2 _someService2;

        public App(ISomeService1 someService1, ISomeService2 someService2)
        {
            _someService1 = someService1;
            _someService2 = someService2;
        }

        public void Run()
        {
            var result1 = _someService1.SomeMethod1();
            var result2 = _someService2.SomeMethod2();
        }
    }
}
