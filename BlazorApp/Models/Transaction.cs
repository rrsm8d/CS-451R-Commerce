using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; } // Primary key
        public int AccountId { get; set; } // Foreign key
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; } // This attribute is cursed for some reason. I think I squashed all the bugs
        [StringLength(100)]
        public string? Merchant { get; set; } // Question mark makes the attribute nullable.
    }
}
