using System.ComponentModel.DataAnnotations;

namespace OneXBet.Application.Featurs.Users.ViewModels;

public sealed class RegisterUserVM
{
    [Required]
    [MaxLength(256, ErrorMessage = "The User name must be at max 256 characters.")]
    [MinLength(3, ErrorMessage = "The User name must be at least 3 characters.")]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Required]
    [MaxLength(256, ErrorMessage = "The First name must be at max 256 characters.")]
    [MinLength(3, ErrorMessage = "The First name must be at least 3 characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(256, ErrorMessage = "The Last name must be at max 256 characters.")]
    [MinLength(3, ErrorMessage = "The Last name must be at least 3 characters.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Display(Name = "Address")]
    public string? Address { get; set; }


    [Required] // +20 1018856093
    [MaxLength(13, ErrorMessage = "The Phone Number must be at max 13 number after (+20) .")]
    [MinLength(10, ErrorMessage = "The Phone Number must be at min 10 number after (+20) .")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }


    [Required]
    [EmailAddress]
    [Display(Name = "Confirm Email")]
    [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
    public string ConfirmEmail { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
