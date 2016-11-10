using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Ninject.Extensions.Interception;


namespace AsyncInterceptors.Factory_Strategy_Pattern
{
	public interface IAmInterceptorMethod
	{
		void InterceptExceptionMethod(IInvocation invocation);
		void InterceptLoggerMethod(IInvocation invocation);
	}
}
