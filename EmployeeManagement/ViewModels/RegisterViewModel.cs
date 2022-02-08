using System;
using System.ComponentModel.DataAnnotations;
using EmployeeManagement.Models;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.ViewModels
{
	public class RegisterViewModel
	{
        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailInUse", controller: "Account")]
        [ValidEmailDomain(allowedDomain: "sinaataei.ml", ErrorMessage = "Email domain must be sinaataei.ml")]
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