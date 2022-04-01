using System.Collections.Generic;
using System.Threading.Tasks;
using GoTalentsCourse.Models;
using GoTalentsCourse.Models.ViewModels;

namespace GoTalentsCourse.Services
{
    public interface IStudentServices
    {
        public Task<List<StudentModel>> FilterByNameAsync(string name);
        public Task<List<StudentViewModel>> GetAllAsync(bool crescent = true);
        public Task<StudentViewModel> GetByIdAsync(int userID);
        public Task<StudentViewModel> SaveAsync(StudentModel newStudent);
        public Task DeleteAsync(int studentID);        
    }
}