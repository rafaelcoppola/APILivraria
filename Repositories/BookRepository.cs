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
		string[] authorBook = { "J.R.R. Tolkien. Gênero", " J.K. Rowling", "C.S. Lewis", " Antoine de Saint-Exupéry", "Dan Brown", " Dante Alighieri", ": Ozzy Osbourne (com colaboração de Chris Ayres)" };
		string[] genre = { "Fantasia épica", "Fantasia juvenil", "Fantasia juvenil", "Fábula / Literatura infantil", " Suspense / Mistério", "Poesia épica / Alegoria", "Biografia / Autobiografia." };
		string[] price = { "R$80,00", "R$90,00", "R$50,00", "R$30,00", "R$50,00", "R$70,00", "R$50,00" };
		int[] quantitie = { 2, 5, 10, 3, 7, 2, 1 };

		int idx = 1;

		_books = new Dictionary<int, Dictionary<string, string>>();

		for (int i = 0; i <= 6; i++)
		{
			var book = setBook(idx, titleBook[i], authorBook[i], genre[i], price[i], quantitie[i]);

			_books.Add(idx, new Dictionary<string, string> {
				{
					"id", book.Id.ToString()
				},
				{
					"title", book.Title
				},
				{
					"genre", book.Genre
				},
				{
					"author", book.Author
				},
				{
					"quantitie", book.Quantitie.ToString()
				},
				{
					"price", book.Price
				}

			});

			idx++;
		};
	}
	private Book setBook(int idx, string title, string author, string genre, string price, int quantitie)
	{
		var book = new Book
		{
			Id = idx,
			Title = title,
			Author = author,
			Genre = genre,
			Price = price,
			Quantitie = quantitie
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

	public void SetNewBook(int id, string title, string author, string genre, string price, int quantitie)
	{
		var book = setBook(id, title, author, genre, price, quantitie);

		_books.Add(id, new Dictionary<string, string>{
			{
				"id", book.Id.ToString()
			},
			{
				"title", book.Title
			},
			{
				"genre", book.Genre
			},
			{
				"author", book.Author
			},
			{
				"quantitie", book.Quantitie.ToString()
			},
			{
				"price", book.Price
			}
		});
	}
}
