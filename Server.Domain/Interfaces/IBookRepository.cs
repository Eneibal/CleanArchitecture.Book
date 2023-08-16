using Server.Domain.Models.Entities;

namespace Server.Domain.Interfaces;
public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int bookId);
}
