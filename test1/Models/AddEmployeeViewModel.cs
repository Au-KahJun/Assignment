using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace test1.Models
{
    public class AddEmployeeViewModel
    {

        [BindProperty]
        [Required(ErrorMessage = "No empty u stupid")]
        [MaxLength(10, ErrorMessage = "must 10  u stupid")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "must in 0-9 u dumb fk")]
        public int UID { get; set; }


        [Required(ErrorMessage = "No empty u stupid")]
        [StringLength(20, ErrorMessage = "must 10  u stupid")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "must in 0-9 u dumb fk")]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [BindProperty]
        [Required, MinLength(6)]
        public string Password { get; set; }

        [BindProperty, Required, Compare(nameof(Password))]
        public string ConfPassword { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Team { get; set; }
        [Required]
        public string Security { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
