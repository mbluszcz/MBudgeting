using System;
using System.Collections.Generic;
using System.Text;

namespace MBudgeting.Core.Standard.Interfaces
{
    public interface IBasicEntityModule<T>
    {
        List<T> GetAll();
        T Get(int id);
        T Save(T entity);
        void Delete(T entity);
    }
}
