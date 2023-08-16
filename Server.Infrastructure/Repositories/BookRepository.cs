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

    public Task AddBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBookAsync(int bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public Task UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
