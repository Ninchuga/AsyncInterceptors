using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInterceptors
{
    public interface ILibraryService
    {
		Task AddBook(Book book);
		Task<List<Book>> GetBooks();
        Task<Book> GetBook(string name);
	}
}