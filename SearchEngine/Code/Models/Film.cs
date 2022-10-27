﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchEngine.Code.Models;

public class Film
{
    [Key]
    public Int32 Id { get; set; }
    public String Name { get; set; } = null!;
    public Single Rating { get; set; }
    public Int32 Year { get; set; }
    [Column(TypeName = "text(20000)")] public String Description { get; set; } = null!;
    [Column(TypeName = "blob")] public Byte[] Image { get; set; } = null!;
    public List<FilmCategory> Categories { get; set; } = new();
    public List<FilmActor> Actors { get; set; } = new();
}
