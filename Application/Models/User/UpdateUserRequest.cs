using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.User
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Regional { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
