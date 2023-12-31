﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Models.Entities;
public class Book
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;


    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    public int PublisherId { get; set; }
    public Publisher? Publisher { get; set; }

    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public CountBooks? CountBooks { get; set; }

    public int NumberOfPages { get; set; }
    public DateTime TimeOfPublication { get; set; }
    public int Cost { get; set; }
    public int PriceForSale { get; set; }
    public byte[]? Image { get; set; }
}
