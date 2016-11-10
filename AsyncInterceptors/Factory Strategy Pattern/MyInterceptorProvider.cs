using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Ninject;
using Ninject.Activation;

namespace AsyncInterceptors.Factory_Strategy_Pattern
{
	public class MyInterceptorProvider : IProvider
	{
		public object Create(IContext context)
		{
			var logger = context.Kernel.Get<ILogger>();
			//var lllll = context.Kernel.Get<ILoggerFactory>();
			//var logg = lllll.Create(typeof(ILogger));
			return new Dictionary
			<MethodType, IAmInterceptorMethod>
			{
				{ MethodType.Synchronous, new SynchronousMethodInterceptor(logger) },
				{ MethodType.AsyncAction, new AsyncTaskMethodInterceptor(logger) },
				{ MethodType.AsyncFunction, new AsyncGenericTaskMethodInterceptor(logger) }
			};
		}

		public Type Type
		{
			get { return typeof(IDictionary<MethodType, IAmInterceptorMethod>); }
		}
	}
}
