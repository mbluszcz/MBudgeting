using MBudgeting.Core.Interfaces;
using MBudgeting.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBudgeting.Core.Modules
{
    public class ExpenseModule : IExpenseModule
    {
        private readonly SQLiteConnection _connection;

        public ExpenseModule(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void Init()
        {
            _connection.CreateTable<BoExpenseCategory>(CreateFlags.None);
        }


        public void Delete(BoExpenseCategory entity)
        {
            _connection.Delete<BoExpenseCategory>(entity.IdExpenseCategory);
        }

        public BoExpenseCategory Get(int id)
        {
            var result = _connection.Get<BoExpenseCategory>(id);
            return result;
        }

        public List<BoExpenseCategory> GetAll()
        {
            var result = _connection.Table<BoExpenseCategory>().ToList();
            return result;
        }

        public BoExpenseCategory Save(BoExpenseCategory entity)
        {
            int id;

            if (entity.IdExpenseCategory == 0)
            {
                id = _connection.Insert(entity, typeof(BoExpenseCategory));
            }
            else
            {
                id = _connection.Update(entity, typeof(BoExpenseCategory));
            }

            var result = _connection.Get<BoExpenseCategory>(id);
            return result;
        }

    }
}
