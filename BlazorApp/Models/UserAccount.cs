using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class UserAccount
    {
        [Required]
        public int UserAccountId { get; set; } // Primary key

        [EmailAddress]
        [Required]
        public string Email { get; set; } // Changes were made to dbContext to require uniqueness to this attribute. Found in Data/BlazorAppContext.cs
        [StringLength(100)]
        public string PasswordHash { get; set; } // Don't store passwords in plaintext!
        [StringLength(100)]
        public string FirstName {  get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
