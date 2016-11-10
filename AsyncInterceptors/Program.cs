using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace AsyncInterceptors
{
	class Program
	{
		static void Main(string[] args)
		{
			var modules = new INinjectModule[]
			{
				new Ninject()
			};
			var kernel = new StandardKernel(modules);
			var service = kernel.Get<ILibraryService>();

			Book book = new Book()
			{
				//Name = "C#",
				Author = "C. MArtin"
			};

			service.AddBook(book);

			try
			{
				var books = service.GetBooks().GetAwaiter().GetResult();

				if (books.Count != 0)
				{
					foreach (var item in books)
					{
						Console.WriteLine(item.Name);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				//throw ex;
			}
            

            
            Console.ReadLine();

        }
    }
}
