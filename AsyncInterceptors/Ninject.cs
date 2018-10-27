using System.Collections.Generic;
using AsyncInterceptors.Interceptors;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace AsyncInterceptors
{
    public class Ninject : NinjectModule
    {
        public override void Load()
        {
			var libraryService = Bind<ILibraryService>().To<LibraryService>();
			libraryService.Intercept().With<ExceptionInterceptor>().InOrder(1);  // if you have multiple interceptors you can specify their order

			Bind<IAmInterceptionFactory>().To<InterceptionFactory>();
	        Bind<IDictionary<MethodType, IAmInterceptorMethod>>().ToProvider<MyInterceptorProvider>();
        }
    }
}
