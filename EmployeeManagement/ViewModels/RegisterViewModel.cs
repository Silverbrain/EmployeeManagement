using System;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
	public class RegisterViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "password values do not match.")]
        public string ConfirmPassword { get; set; }
    }
}