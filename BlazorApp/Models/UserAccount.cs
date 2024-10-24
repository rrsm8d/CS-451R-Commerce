using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; } // Primary key
        // [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string PasswordHash { get; set; } // Don't store passwords in plaintext!
        [StringLength(100)]
        public string FirstName {  get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
