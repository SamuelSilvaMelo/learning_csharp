using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoTalentsCourse.Interfaces
{
    public interface IStandartRepositoryOperations<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int userID);
        Task<int> InsertAsync(T Student);
        Task DeleteAsync(T StudentID);
    }
}
