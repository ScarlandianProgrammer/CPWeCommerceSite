using System.ComponentModel.DataAnnotations;

namespace CPWeCommerceSite.Models
{
    /// <summary>
    /// The main class that represents a <see cref="Member"/> of the site.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The unique identifier for each member
        /// </summary>
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// The <see cref="Email"/> of the member.
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;

        /// <summary>
        /// The <see cref="Password"/> of the member.
        /// </summary>
        [Required]
        public string Password { get; set; } = null!;

        /// <summary>
        /// The <see cref="PhoneNumber"/> of the member.
        /// </summary>
		public string? PhoneNumber { get; set; }

        /// <summary>
        /// The <see cref="Username"/> of the member.
        /// </summary>
        public string? Username { get; set; }
    }

    /// <summary>
    /// The view model for the register page.
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// The Email address of the user registering.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// The Email address of the user registering.
        /// Should be the same as the Email property.
        /// </summary>
        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        /// <summary>
        /// The password of the user registering.
        /// </summary>
        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// The password of the user registering.
        /// Should be the same as the Password property.
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set;}
    }

    /// <summary>
    /// The view model for the login page.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// The email address of the user logging in.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// The password of the user logging in.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
