using System.Collections.Generic;
using System.Threading.Tasks;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.Services
{
    public interface IFacilitatorServices
    {
        public Task<List<FacilitatorModel>> FilterByNameAsync(string name);
        public Task<List<FacilitatorModel>> GetAllAsync(bool crescent = true);
        public Task<FacilitatorModel> GetByIdAsync(int userID);
        public Task<int> SaveAsync(FacilitatorModel newStudent);
        public Task DeleteAsync(int studentID);        
    }
}