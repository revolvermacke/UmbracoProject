using System.ComponentModel.DataAnnotations;

namespace UmbracoProjectMax.ViewModels;

public class QuestionRequestViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email")]
    [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "You need to ask a question to submit this form.")]
    public string Question { get; set; } = null!;
}
