using System;
using Ninject;
using Ninject.Modules;

namespace AsyncInterceptors
{
    class Program
	{
		static void Main(string[] args)
		{
            var kernel = CreateKernel();
            var service = kernel.Get<ILibraryService>();

            AddBook(service);

            var book = service.GetBook("Refactoring").GetAwaiter().GetResult();

            Console.WriteLine(book);
            
            Console.ReadLine();
        }

        private static StandardKernel CreateKernel()
        {
            var modules = new INinjectModule[]
            {
                new Ninject()
            };

            var kernel = new StandardKernel(modules);

            return kernel;
        }

        private static void AddBook(ILibraryService service)
        {
            Book book = new Book()
            {
                Name = "Clean Coder",
                Author = "Robert C. Martin"
            };

            service.AddBook(book);
        }
    }
}
