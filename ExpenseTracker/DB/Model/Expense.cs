using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.DB.Model
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [NotFutureDate(ErrorMessage = "Expenditure date cannot be a future date.")]
        public DateTime ExpenseDate { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string Description { get; set; }

        public virtual Category Categories { get; set; }
    }

    public class NotFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = (DateTime)value;
            return date <= DateTime.Now;
        }
    }
}
