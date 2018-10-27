using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInterceptors
{
    public class LibraryService : ILibraryService
    {
        private readonly List<Book> _books = new List<Book>();

		public Task AddBook(Book book)
		{
			if (string.IsNullOrEmpty(book.Name))
				throw new ArgumentNullException(nameof(book));

            _books.Add(book);

			return Task.FromResult(true);
		}

        public async Task<Book> GetBook(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var book = _books.FirstOrDefault(b => b.Name.Equals(name));
            if (book == null)
                throw new CustomException($"Book with name: {name} doesn't exist.");

            //return Task.FromResult(book);
            return await Task.Run(() => book);
        }

		public Task<List<Book>> GetBooks()
		{
			if (_books.Count.Equals(0))
				throw new CustomException("There are no books.");

			return Task.FromResult(_books);
		}

	}
}
