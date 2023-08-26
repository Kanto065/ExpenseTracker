using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Shared.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }

        //public List<Category> Categories { get; set; }
    }
}
