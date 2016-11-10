using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncInterceptors.Factory_Strategy_Pattern;
using Castle.Core.Logging;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace AsyncInterceptors
{
    public class Ninject : NinjectModule
    {
        public override void Load()
        {
			var libraryService = Bind<ILibraryService>().To<LibraryService>();
			libraryService.Intercept().With<ExceptionInterceptor>().InOrder(1);
			libraryService.Intercept().With<LoggerInterceptor>().InOrder(2);

			Bind<IInterceptionFactory>().To<InterceptionFactory>();
	        Bind<ILogger>().To<LoggerClass>();
	        Bind<IDictionary<MethodType, IAmInterceptorMethod>>().ToProvider<MyInterceptorProvider>();
        }
    }
}
