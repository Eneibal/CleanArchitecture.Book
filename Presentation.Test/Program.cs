using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server.Application.Interfaces;
using Server.Application.Services;
using Server.Domain.Interfaces;
using Server.Domain.Models.Entities;
using Server.Infrastructure.Data;
using Server.Infrastructure.Repositories;

Console.WriteLine("awd");


/*var serProv = new ServiceCollection()
    .AddScoped<IBookRepository, BookRepository>()
    .AddScoped<IBookService, BookService>()
    .BuildServiceProvider() ;

var services = serProv.GetRequiredService<IBookService>();

var topBooks = await services.GetTopBooksAsync();

foreach (var book in topBooks)
{
    Console.WriteLine(book.Name);
}*/




//IBookRepository bookRepository = new BookRepository();

var serviceProvide = ConfigureService();

using (var scope = serviceProvide.CreateScope())
{
    var bookService = scope.ServiceProvider.GetService<IBookService>();


    //add Book
    var newBook = new Book
    {
        TimeOfPublication = DateTime.Now,
        Name = "NAme1"

    };

    await bookService.AddBookAsync(newBook);

    //getBook
    var books = await bookService.GetAllAsync();
}

static IServiceProvider ConfigureService()
{
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsetings.json")
        .Build();

    var connectionSstring = config.GetConnectionString("MainConnectionString");

    var serviceProvide = new ServiceCollection()
        .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionSstring))
        .AddScoped<IBookRepository, BookRepository>()
        .AddScoped<IBookService, BookService>()
        .BuildServiceProvider();

    return serviceProvide;
}