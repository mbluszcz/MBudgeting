using Autofac;
using MBudgeting.Core.Standard.Interfaces;
using MBudgeting.Core.Standard.Modules;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBudgeting.WPF
{
    public class ContainerProvider
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
