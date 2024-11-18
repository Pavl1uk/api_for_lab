namespace LibraryApi.Models;

public class Book
{
    public int Id { get; set; } // Унікальний ідентифікатор
    public string Title { get; set; } = string.Empty; // Назва книги
    public string Author { get; set; } = string.Empty; // Автор
    public int PublicationYear { get; set; } // Рік видання
}