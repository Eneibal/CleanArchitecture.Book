﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Domain.Models.Entities;
public class Genre
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = null!;
    public List<Book>? Book { get; set; }
}
