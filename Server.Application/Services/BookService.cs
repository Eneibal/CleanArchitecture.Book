using Server.Application.Interfaces;
using Server.Domain.Interfaces;
using Server.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Application.Services;
public class BookService : IBookService
{
    public readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
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
        var books = await _bookRepository.GetAllAsync();
        return books;
    }

    public Task UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }
}
