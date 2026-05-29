using System.ComponentModel.DataAnnotations;
using MvcAsyncDemo.CustomValidation;

namespace MvcAsyncDemo.Models
{
    public class EmployeeContact
    {
        [NumericOnly]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}