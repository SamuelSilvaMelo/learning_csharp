using System;
using System.Collections.Generic;

namespace GoTalentsCourse.Interfaces
{
    public interface IStandartRepositoryOperations<T>
    {
        List<T> GetAll();
        T GetByID(int userID);
        int Insert(T Student);
        void Delete(T StudentID);
    }
}
