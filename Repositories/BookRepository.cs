using LibraryAPI.Entities;
using System.Net;

namespace LibraryAPI.Repositories;

public class BookRepository
{
	private Dictionary<int, Dictionary<string, string>> _books;

	public BookRepository()
	{
		createListBook();
	}

	private void createListBook()
	{
		string[] titleBook = { "Senhor dos Anéis", "Harry Potter", "Cronicas de Narnia", "Pequeno Principe", "Código da Vinci", "Divina Cómedia", "Eu sou Ozzy" };
		
		int idx = 1;

		_books = new Dictionary<int, Dictionary<string, string>>();

		for (int i = 0; i <= 6; i++)
		{
			var book = setBook(idx, titleBook[i]);

			_books.Add(idx, new Dictionary<string, string> {
				{
					"id", book.Id.ToString()
				},
				{
					"title", book.Title
				},

			});

			idx++;
		};
	}
	private Book setBook(int idx, string title)
	{
		var book = new Book
		{
			Id = idx,
			Title = title,
		};

		return book;
	}

	public Dictionary<string, string> GetBookForId(int id)
	{
		if (_books.ContainsKey(id))
		{
			return _books[id];
		}

		return null;
	}

	public Dictionary<int, Dictionary<string, string>> GetAllBooks()
	{
		if (_books.Any())
		{
			return _books;
		}

		return null;
	}

	public void SetNewBook(int id, string title)
	{
		var book = setBook(id, title);

		_books.Add(id, new Dictionary<string, string>{
			{ "id", book.Id.ToString()},
			{ "title", book.Title}
		});
	}
}
