using System;
using System.Collections.Generic;

namespace GoTalentsCourse.Interfaces
{
    public interface IStandartRepositoryOperations<T>
    {
        List<T> GetAll();
        T GetByID(Guid userID);
        Guid Insert(T Student);
        void Delete(T StudentID);
    }
}
