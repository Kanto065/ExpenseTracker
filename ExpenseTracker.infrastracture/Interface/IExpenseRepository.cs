using ExpenseTracker.Shared.DTOs;
using ExpenseTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.infrastracture.Interface
{
    public interface IExpenseRepository
    {
        public Task<ApiResultDTO> AddNewExpense(Expense expense);
        public Task<ApiResultDTO> UpdateExpense(Expense expense);
        public Task<ApiResultDTO> DeleteExpense(int Id);
        public Task<List<Expense>> GetExpenses();
        public Task<Expense> GetExpenseById(int Id);
    }
}
