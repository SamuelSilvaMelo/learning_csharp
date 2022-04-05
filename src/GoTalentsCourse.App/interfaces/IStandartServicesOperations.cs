using System.Threading.Tasks;
using System.Collections.Generic;

namespace GoTalentsCourse.Services.Interfaces
{
    public interface IStandartServicesOperations<TView, TModel>
    {
        public Task<List<TView>> FilterByNameAsync(string name);
        public Task<List<TView>> GetAllAsync(bool crescent = true);
        public Task<TView> GetByIdAsync(int id);
        public Task<TView> SaveAsync(TModel newPerson);
        public Task DeleteAsync(int id);  
    }
}