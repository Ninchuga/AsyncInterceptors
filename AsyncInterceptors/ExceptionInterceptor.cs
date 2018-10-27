using AsyncInterceptors.Interceptors;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors
{
    public class ExceptionInterceptor : IInterceptor
	{
		private readonly IAmInterceptionFactory _factory;
		public ExceptionInterceptor(IAmInterceptionFactory factory)
		{
			_factory = factory;
		}

		public void Intercept(IInvocation invocation)
		{
			var interceptionClass = _factory.ExecuteInterceptionMethod(invocation);
			interceptionClass.InterceptExceptionMethod(invocation);
		}
		
	}
}
