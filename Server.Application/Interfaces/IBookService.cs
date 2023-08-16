using Server.Domain.Models.Entities;

namespace Server.Application.Interfaces;
public interface IBookService
{
    Task<List<Book>> GetAllAsync();
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int bookId);
}
