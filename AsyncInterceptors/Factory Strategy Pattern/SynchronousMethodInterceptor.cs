using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Factory_Strategy_Pattern
{
	public class SynchronousMethodInterceptor : IAmInterceptorMethod
	{
		private readonly ILogger _logger;

		public SynchronousMethodInterceptor(ILogger logger)
		{
			_logger = logger;
		}

		public void InterceptExceptionMethod(IInvocation invocation)
		{
			try
			{
				invocation.Proceed();
			}
			catch (Exception ex)
			{
				_logger.Error("Method execution failed");
				var response = new Response {Message = ex.Message};
				invocation.ReturnValue = response;
				//throw new CustomException(ex.Message);
			}
		}

		public void InterceptLoggerMethod(IInvocation invocation)
		{
			_logger.Info("Method start");
			invocation.Proceed();
			_logger.Info("Method ends");
		}
	}
}
