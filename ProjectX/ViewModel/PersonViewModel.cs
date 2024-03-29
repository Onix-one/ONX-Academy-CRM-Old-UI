﻿using System.ComponentModel.DataAnnotations;

namespace ProjectX.MVC.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        public string LastName { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 6, ErrorMessage = "Length must be 6-100")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "This field cannot be empty")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [Phone(ErrorMessage = "Invalid Phone number")]
        public string? Phone { get; set; }
        public string FullName => $"{LastName} {FirstName}";
       
    }
}
