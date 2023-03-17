using System.ComponentModel.DataAnnotations;

namespace test1.Models
{
    public class AddEmployeeViewModel
    {


        [Required(ErrorMessage = "Please fill this up")]
        [Range(1, 999999, ErrorMessage = "The value of UID must be between {1} and {2}.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Username must be formed with 1-9 numbers")]
        public int UID { get; set; }


        [Required(ErrorMessage = "Please fill this up", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "The Max length is 20 Character "), MinLength(8, ErrorMessage = "minimum Character of the  name must be more than 8")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill this up", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "The Max length is 20 Character "), MinLength(8, ErrorMessage = "minimum of the user name must be more than 8")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Please fill this up"),
         MinLength(6, ErrorMessage = "Minimum Requirement is 6 character"),
            RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "This Should contain letters and numbers")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please fill this up")]
        [Compare(nameof(Password), ErrorMessage = "This password is not the same")]
        public string ConfPassword { get; set; }
        [Required(ErrorMessage = "Date Must not be empty")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Position musn't be empty")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please Select your team")]
        public string Team { get; set; }
        [Required(ErrorMessage = "This shall not be empty")]
        [StringLength(maximumLength: 40, ErrorMessage = "Security Phrase must be within 40 chararcters")]
        public string Security { get; set; }
        [Required(ErrorMessage = "Please fill this up in a correct format")]
        [EmailAddress(ErrorMessage = "This email address is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Select a date")]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "This shall not be empty")]
        public string Status { get; set; }




    }
}
