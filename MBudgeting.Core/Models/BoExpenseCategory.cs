using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MBudgeting.Core.Models
{
    public class BoExpenseCategory
    {
       [PrimaryKey, AutoIncrement]
        public int IdExpenseCategory { get; set; }
        public string ExpenseName { get; set; }
    }
}
