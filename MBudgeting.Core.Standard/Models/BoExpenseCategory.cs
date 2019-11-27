using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBudgeting.Core.Standard.Models
{
    public class BoExpenseCategory
    {
        [PrimaryKey, AutoIncrement]
        public int IdExpenseCategory { get; set; }
        public string ExpenseName { get; set; }
    }
}
