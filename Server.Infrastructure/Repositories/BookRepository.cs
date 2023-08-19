using Microsoft.EntityFrameworkCore;
using Server.Domain.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;

namespace Server.Infrastructure.Repositories;
public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddBookAsync(Book book)
    {
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
    }

    public async Task DeleteBookAsync(int bookId)
    {
        var book = _dbContext.Books.FirstOrDefault(b=>b.Id == bookId);

        if (book is null)
        {
            return;
        }

        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        var updateBook = _dbContext.Books.FirstOrDefault(b=>b.Id==book.Id);

        if(updateBook is null)
        {
            return;
        }

        updateBook.Publisher = book.Publisher;
        updateBook.Author = book.Author;
        updateBook.NumberOfPages = book.NumberOfPages;
        updateBook.Name = book.Name;

        _dbContext.SaveChanges();
    }
}
