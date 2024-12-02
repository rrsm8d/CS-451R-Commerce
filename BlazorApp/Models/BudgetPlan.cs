using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class BudgetPlan
    {
        public int BudgetPlanId { get; set; } // Primary key
        public int AccountId { get; set; } // Foreign Key
        public string BudgetName { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BudgetAmount { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BudgetExpenditures { get; set; } // Total spent so far
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
