using System;
using System.Collections.Generic;
using Ninject.Activation;

namespace AsyncInterceptors.Interceptors
{
    public class MyInterceptorProvider : IProvider
	{
		public object Create(IContext context)
		{
			return new Dictionary
			<MethodType, IAmInterceptorMethod>
			{
				{ MethodType.Synchronous, new SynchronousMethodInterceptor() },
				{ MethodType.AsyncAction, new AsyncTaskMethodInterceptor() },
				{ MethodType.AsyncFunction, new AsyncGenericTaskMethodInterceptor() }
			};
		}

		public Type Type
		{
			get { return typeof(IDictionary<MethodType, IAmInterceptorMethod>); }
		}
	}
}
