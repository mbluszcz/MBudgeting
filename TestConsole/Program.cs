using MBudgeting.Core.Modules;
using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using MBudgeting.Core.Models;
using Autofac;
using MBudgeting.Core.Interfaces;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContrainerProvider.GetContainer();

            var expenseModule = container.Resolve<IExpenseModule>();

            var allExpenses = expenseModule.GetAll();

            expenseModule.Save(new BoExpenseCategory() { ExpenseName = "TestExpense" });
            var allExpenses1 = expenseModule.GetAll();

            Console.WriteLine("Hello World!");
        }
    }
}
