using System;
using System.Reflection;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Interceptors
{
    public class AsyncGenericTaskMethodInterceptor : IAmInterceptorMethod
	{
		private static readonly MethodInfo StartTaskMethodInfo = typeof(AsyncGenericTaskMethodInterceptor).GetMethod(nameof(GenericTaskReturnValue),
			BindingFlags.Instance | BindingFlags.NonPublic);

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
            catch(CustomException ex)
            {
                var result = (BaseResponse)Activator.CreateInstance(typeof(TResult));
                result.ErrorMessage = ex.Message;
                
                return (TResult)Convert.ChangeType(result, typeof(TResult));
            }
			catch (Exception ex)
			{
                Console.WriteLine("Unhandled Exception occured");
				var response = new BaseResponse { ErrorMessage = ex.Message};
				return (TResult)Convert.ChangeType(response, typeof(TResult));
			}
		}
	}
}
