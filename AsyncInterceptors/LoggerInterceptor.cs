using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncInterceptors.Factory_Strategy_Pattern;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors
{
	public class LoggerInterceptor : IInterceptor
	{
		private readonly IInterceptionFactory _factory;
		public LoggerInterceptor(IInterceptionFactory factory)
		{
			_factory = factory;
		}

		public void Intercept(IInvocation invocation)
		{
			var interceptionClass = _factory.ExecuteInterceptionMethod(invocation);
			interceptionClass.InterceptLoggerMethod(invocation);
		}
	}
}
