﻿using System.ComponentModel.DataAnnotations;

namespace FormProject.Application.Models.DTOs
{
    public class RegistorDTO
    {
        [Required(ErrorMessage = "User name cannot be null")]
        [Display(Name = "User Name")]
        [MinLength(4, ErrorMessage = "User name must be more than 4 characters.")]
        [MaxLength(20, ErrorMessage = "User name must be less than 20 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be null")]
        [Display(Name = "Password")]
        [MinLength(4, ErrorMessage = "Password must be more than 4 characters.")]
        [MaxLength(20, ErrorMessage = "Password must be less than 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords are not same.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email cannot be null")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
