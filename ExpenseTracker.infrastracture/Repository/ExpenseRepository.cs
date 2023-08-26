using ExpenseTracker.infrastracture.Interface;
using ExpenseTracker.Shared.DTOs;
using ExpenseTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.infrastracture.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        readonly ExpenseDbContext context;
        public ExpenseRepository(ExpenseDbContext context) 
        {
            this.context = context;
        }

        public async Task<ApiResultDTO> AddNewExpense(Expense expense)
        {
            try
            {

                context.Expenses.Add(expense);
                await context.SaveChangesAsync();
                return new ApiResultDTO(true, "success");
            }
            catch (Exception ex)
            {

                return new ApiResultDTO(false, ex.Message);

            }
        }

        public Task<ApiResultDTO> DeleteExpense(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetExpenseById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Expense>> GetExpenses()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResultDTO> UpdateExpense(Expense expense)
        {
            throw new NotImplementedException();
        }
    }
}
