using System.Collections.Generic;
using System.Threading.Tasks;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.Services
{
    public interface IStudentServices
    {
        public Task<List<StudentModel>> FilterByNameAsync(string name);
        public Task<List<StudentModel>> GetAllAsync(bool crescent = true);
        public Task<StudentModel> GetByIdAsync(int userID);
        public Task<int> SaveAsync(StudentModel newStudent);
        public Task DeleteAsync(int studentID);        
    }
}