using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Factory_Strategy_Pattern
{
	public class AsyncTaskMethodInterceptor : IAmInterceptorMethod
	{
		private readonly ILogger _logger;

		public AsyncTaskMethodInterceptor(ILogger logger)
		{
			_logger = logger;
		}

		public void InterceptExceptionMethod(IInvocation invocation)
		{
			invocation.Proceed();
			var task = (Task)invocation.ReturnValue;
			invocation.ReturnValue = Handle(task, invocation);
		}

		private async Task Handle(Task task, IInvocation invocation)
		{
			try
			{
				await task;
			}
			catch (Exception exception)
			{
				_logger.Error("Method failed");
				var response = new Response() {Message = exception.Message};
				invocation.ReturnValue = response.Message;
				//throw new CustomException(exception.Message);
			}
		}

		public void InterceptLoggerMethod(IInvocation invocation)
		{
			_logger.Info("Method start");
			invocation.Proceed();
			var task = (Task)invocation.ReturnValue;
			invocation.ReturnValue = HandleLog(task);
		}

		private async Task HandleLog(Task task)
		{
				await task;
				_logger.Info("Method ends. Great success!!!");
		}

	}
}

