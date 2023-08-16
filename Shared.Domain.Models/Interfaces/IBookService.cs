using Shared.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Models.Interfaces;
public interface IBookService
{
    Task<Book> GetById(int bookId);
    Task<IEnumerable<Book>> GetAllAsync();
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(int bookId);
    bool BookValidator(Book book);
}
