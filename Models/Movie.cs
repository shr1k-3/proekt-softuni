using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.Models;

public class Movie
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Range(1888, 2100)]
    public int Year { get; set; }

    [Range(1, 10)]
    public decimal Rating { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Display(Name = "Genre")]
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }

    [Display(Name = "Director")]
    public int DirectorId { get; set; }
    public Director? Director { get; set; }
}
