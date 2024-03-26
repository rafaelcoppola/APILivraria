namespace LibraryAPI.Request;

public class RequestCreateBook
{
	public string Title { get; set; } = string.Empty;

	public string Author { get; set; } = string.Empty;

	public string Genre { get; set; } = string.Empty;

	public int Quantitie { get; set; }

	public string Price { get; set; } = string.Empty;

}
