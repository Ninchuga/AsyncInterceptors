using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Interceptors
{
	public interface IAmInterceptionFactory
	{
		IAmInterceptorMethod ExecuteInterceptionMethod(IInvocation invocation);
	}
}