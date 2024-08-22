using System.ComponentModel.DataAnnotations;

namespace Validation.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 15 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Roll Number is required.")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Roll Number should be numeric and up to 10 digits.")]
        public string RollNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 60, ErrorMessage = "Age should be between 18 and 60 years.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Address should be between 10 and 50 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        [CustomValidation(typeof(Student), "ValidateDateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public static ValidationResult ValidateDateOfBirth(DateTime dateOfBirth, ValidationContext context)
        {
            if (dateOfBirth > DateTime.Now)
            {
                return new ValidationResult("Date of Birth cannot be in the future.");
            }
            return ValidationResult.Success;
        }
    }
}
