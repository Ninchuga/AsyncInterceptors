using System.Collections.Generic;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;

namespace AsyncInterceptors.Interceptors
{
    public class InterceptionFactory : IAmInterceptionFactory
	{
		private readonly IDictionary<MethodType, IAmInterceptorMethod> _getInterceptorClass;

		public InterceptionFactory(IDictionary<MethodType, IAmInterceptorMethod> getInterceptorClass)
		{
			_getInterceptorClass = getInterceptorClass;
		}

		public IAmInterceptorMethod ExecuteInterceptionMethod(IInvocation invocation)
		{
			var delegateType = GetDelegateType(invocation);
			return _getInterceptorClass[delegateType];
		}

		private static MethodType GetDelegateType(IInvocation invocation)
		{
			var returnType = invocation.Request.Method.ReturnType;
			if (returnType == typeof(Task))
				return MethodType.AsyncAction;
			if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
				return MethodType.AsyncFunction;

			return MethodType.Synchronous;
		}
	}
}
