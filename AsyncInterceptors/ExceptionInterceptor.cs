using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncInterceptors.Factory_Strategy_Pattern;
using Castle.Core.Logging;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors
{
	public class ExceptionInterceptor : IInterceptor
	{
		private readonly IInterceptionFactory _factory;
		public ExceptionInterceptor(IInterceptionFactory factory)
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
