using System.ComponentModel.DataAnnotations;

namespace UmbracoProjectMax.ViewModels;

public class SupportRequestViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;
}
