﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Domain.Models.Entities;

public class Author
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;
    public List<Book>? Book { get; set; }
}