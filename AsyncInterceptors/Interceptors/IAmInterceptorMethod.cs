using Ninject.Extensions.Interception;


namespace AsyncInterceptors.Interceptors
{
    public interface IAmInterceptorMethod
	{
		void InterceptExceptionMethod(IInvocation invocation);
	}
}
