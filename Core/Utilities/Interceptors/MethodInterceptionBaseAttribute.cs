using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        //IInvocation çağrılan metot ile ilgili tüm bilgileri içerisinde barındırır
        public virtual void Intercept(IInvocation invocation)
        {
           
        }
    }
}
