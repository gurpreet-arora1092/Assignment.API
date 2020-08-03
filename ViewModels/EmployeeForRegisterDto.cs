using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment.API.ViewModels
{
    public class EmployeeForRegisterDto
    {
        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="Enter First Name between 4 to 8 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Enter Last Name between 4 to 8 characters")]
        public string LastName { get; set; }
    }
}
