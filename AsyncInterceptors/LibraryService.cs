using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncInterceptors
{
    public class LibraryService : ILibraryService
    {
        private readonly List<Book> books = new List<Book>();
		public async Task AddBook(Book book)
		{
			if (string.IsNullOrEmpty(book.Name))
			{
				throw new CustomException("zveketeeeee!!!");
			}

			await Task.Run(() => books.Add(book));
		}

		//public void AddBook(Book book)
		//{
		//	if (string.IsNullOrEmpty(book.Name))
		//	{
		//		throw new CustomException("zveketeeeee!!!");
		//	}

		//	books.Add(book);
		//}

		//public List<Book> GetBooks()
		//{
		//	var bookssss = books;
		//	if (bookssss.Count.Equals(0))
		//	{
		//		throw new CustomException("nemoz biti jedan care");
		//	}

		//	return bookssss;
		//	//return await Task.Run(() => books);
		//}


		public async Task<List<Book>> GetBooks()
		{
			if (books.Count.Equals(0))
			{
				throw new CustomException("nemoz biti nula care");
			}

			return await Task.Run(() => books);
		}

	}
}
