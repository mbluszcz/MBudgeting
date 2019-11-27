using Autofac;
using MBudgeting.Core.Modules;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MBudgeting.Core.Interfaces;

namespace TestConsole
{
    public class ContrainerProvider
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            var databasePath = Path.Combine(Environment.CurrentDirectory, "MBudgeting.db");

            var sqlConnection = new SQLiteConnection(databasePath);
            builder.RegisterInstance(sqlConnection).As<SQLiteConnection>();

            builder.RegisterType<ExpenseModule>().As<IExpenseModule>().SingleInstance().OnActivated(c => c.Instance.Init());

            return builder.Build();
        }
    }
}
