﻿using System.ComponentModel.DataAnnotations;

namespace CPWeCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Username { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set;}
    }
}
