using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class UserAccount
    {
        public int UserAccountId { get; set; } // Primary key
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Don't store passwords in plaintext!
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
