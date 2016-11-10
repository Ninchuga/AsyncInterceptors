using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Factory_Strategy_Pattern
{
	public class AsyncGenericTaskMethodInterceptor : IAmInterceptorMethod
	{
		private static readonly MethodInfo StartTaskMethodInfo = typeof(AsyncGenericTaskMethodInterceptor).GetMethod(nameof(GenericTaskReturnValue),
			BindingFlags.Instance | BindingFlags.NonPublic);

		private static readonly MethodInfo StartTaskMethodLoggerInfo = typeof(AsyncGenericTaskMethodInterceptor).GetMethod(nameof(GenericTaskLogger),
			BindingFlags.Instance | BindingFlags.NonPublic);

		private readonly ILogger _logger;

		public AsyncGenericTaskMethodInterceptor(ILogger logger)
		{
			_logger = logger;
		}

		public void InterceptExceptionMethod(IInvocation invocation)
		{
			invocation.Proceed();

			var methodArgs = invocation.Request.Method.ReturnType.GetGenericArguments()[0];
			var genericMethod = StartTaskMethodInfo.MakeGenericMethod(methodArgs);

			invocation.ReturnValue = genericMethod.Invoke(this, new[] { invocation.ReturnValue });
		}

		private async Task<TResult> GenericTaskReturnValue<TResult>(Task<TResult> task)
		{
			try
			{
				return await task;
			}
			catch (Exception ex)
			{
				_logger.Error("Method execution failed");
				var response = new Response {Message = ex.Message};
				return (TResult)Convert.ChangeType(response, typeof(TResult));
				//throw new CustomException(ex.Message);
			}
		}

		public void InterceptLoggerMethod(IInvocation invocation)
		{
			invocation.Proceed();

			var methodArgs = invocation.Request.Method.ReturnType.GetGenericArguments()[0];
			var genericMethod = StartTaskMethodLoggerInfo.MakeGenericMethod(methodArgs);

			invocation.ReturnValue = genericMethod.Invoke(this, new[] { invocation.ReturnValue });
		}

		private async Task<TResult> GenericTaskLogger<TResult>(Task<TResult> task)
		{
				_logger.Info("Method start");
				var awaitTask = await task;
				_logger.Info("Method ends successfully");
				return awaitTask;
		}
	}
}
