namespace Server.Domain.Models.Entities;

public class CountBooks
{
    public int Id { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int Count { get; set; }
}