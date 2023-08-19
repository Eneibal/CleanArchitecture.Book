using Server.Application.Interfaces;
using Server.Domain.Interfaces;
using Server.Domain.Models.Entities;

namespace Server.Application.Services;
public class BookService : IBookService
{
    public readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task AddBookAsync(Book book)
    {
        await _bookRepository.AddBookAsync(book);
    }

    public async Task DeleteBookAsync(int bookId)
    {
        await _bookRepository.DeleteBookAsync(bookId);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();
        return books;
    }

    public async Task UpdateBookAsync(Book book)
    {
        await _bookRepository.UpdateBookAsync(book);
    }
}
