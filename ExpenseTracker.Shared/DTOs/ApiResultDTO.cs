using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Shared.DTOs
{
    public record ApiResultDTO(bool isSuccess, string msg=default)
    {

    }
}
