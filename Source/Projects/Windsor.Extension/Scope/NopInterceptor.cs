using System;
using Castle.DynamicProxy;

namespace Windsor.Extension.Scope
{
    public class NopInterceptor: IInterceptor
    {
        private readonly Func<IInvocation, bool> applicableFunc;

        public NopInterceptor(Func<IInvocation, bool> applicableFunc)
        {
            this.applicableFunc = applicableFunc;
        }
        public void Intercept(IInvocation invocation)
        {
            var applicable = applicableFunc(invocation);
            if (applicable)
            {
                return;
            }

            invocation.Proceed();
        }
    }
}
