using System.ComponentModel.DataAnnotations;

namespace _01_07_2025_tutorial_razor_pages.Models;

public class User
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Email { get; set; } = string.Empty;

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "First Name")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Last Name")]
    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
}
