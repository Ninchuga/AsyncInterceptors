using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Factory_Strategy_Pattern
{
	public interface IInterceptionFactory
	{
		IAmInterceptorMethod ExecuteInterceptionMethod(IInvocation invocation);
	}
}