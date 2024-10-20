using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; } // Primary key
        public int UserAccountId { get; set; } // Foreign key
        [StringLength(100)]
        public String AccountType { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AccountBalance { get; set; }


    }
}
