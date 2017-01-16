using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Handel.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Color type")]
        public string ColorType { get; set; }

        [Required]
        [Display(Name = "MaxPirice")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Made")]
        public string Made { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "Collar")]
        public int Collar { get; set; }

        [Required]
        [Display(Name = "Arms")]
        public int Arms { get; set; }

        [Required]
        [Display(Name = "Sleeve")]
        public int Sleeve { get; set; }

        [Required]
        [Display(Name = "Shirt length")]
        public int ShirtLength { get; set; }

        [Required]
        [Display(Name = "Waist")]
        public int Waist { get; set; }

        [Required]
        [Display(Name = "Chest")]
        public int Chest { get; set; }

        [Required]
        [Display(Name = "Cuff")]
        public int Cuff { get; set; }
    }

    public class ShirtViewModel
    {
        [Required]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Color type")]
        public string ColorType { get; set; }

        [Required]
        [Display(Name = "Pirice")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Made")]
        public string Made { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public string Sex { get; set; }

        [Required]
        [Display(Name = "Collar")]
        public int Collar { get; set; }

        [Required]
        [Display(Name = "Arms")]
        public int Arms { get; set; }

        [Required]
        [Display(Name = "Sleeve")]
        public int Sleeve { get; set; }

        [Required]
        [Display(Name = "Shirt length")]
        public int ShirtLength { get; set; }

        [Required]
        [Display(Name = "Waist")]
        public int Waist { get; set; }

        [Required]
        [Display(Name = "Chest")]
        public int Chest { get; set; }

        [Required]
        [Display(Name = "Cuff")]
        public int Cuff { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Composition")]
        public string Composition { get; set; }

        [Required]
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Required]
        [Display(Name = "Link")]
        public string Link { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
