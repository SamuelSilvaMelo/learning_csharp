using System;
using System.Collections.Generic;

namespace Course_API.Interfaces
{
    public interface IBasicCRUD<T>
    {
        List<T> GetAll();
        T GetByID(Guid userID);
        Guid Insert(T Student);
        void Delete(T StudentID);
    }
}
