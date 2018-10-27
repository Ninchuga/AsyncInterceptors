using System;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Interceptors
{
    public class SynchronousMethodInterceptor : IAmInterceptorMethod
	{
		public void InterceptExceptionMethod(IInvocation invocation)
		{
			try
			{
				invocation.Proceed();
			}
            catch(CustomException ex)
            {
                var response = new BaseResponse { ErrorMessage = ex.Message };
                invocation.ReturnValue = response;
            }
			catch (Exception ex)
			{
                Console.WriteLine("Unhandled Exception occured");
                var response = new BaseResponse { ErrorMessage = ex.Message};
				invocation.ReturnValue = response;
			}
		}
	}
}
