using System;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
	public class LoginViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}