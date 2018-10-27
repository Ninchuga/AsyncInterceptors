using System;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Interceptors
{
    public class AsyncTaskMethodInterceptor : IAmInterceptorMethod
	{
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
            catch(CustomException ex)
            {
                var response = new BaseResponse { ErrorMessage = ex.Message };
                invocation.ReturnValue = response.ErrorMessage;
            }
			catch (Exception exception)
			{
                Console.WriteLine("Unhandled Exception occured");
                var response = new BaseResponse() { ErrorMessage = exception.Message};
				invocation.ReturnValue = response.ErrorMessage;
			}
		}
	}
}

