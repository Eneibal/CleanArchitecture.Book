using Shared.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Models.Interfaces;
/// <summary>
///  Інтерфейси для репозиторіїв описують методи, які дозволяють взаємодіяти з джерелами даних (наприклад, базою даних) для 
///  отримання, зберігання, оновлення та видалення даних
/// </summary>
public interface IBookRepository
{
    Task<Book> GetById(int bookId);
    Task<IEnumerable<Book>> GetAllAsync();
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(int bookId);
    bool BookValidator(Book book);
    
}
