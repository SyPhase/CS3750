using System.ComponentModel.DataAnnotations;

namespace _01_07_2025_tutorial_razor_pages.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; } // Question mark indicates nullable property
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
}