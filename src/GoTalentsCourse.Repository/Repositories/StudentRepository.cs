using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTalentsCourse.Repository
{
    public class StudentRepository : IStandartRepositoryOperations<StudentModel>
    {
        private DataContext _database;
        private DbSet<StudentModel> _student;

        public StudentRepository(DataContext context)
        {
            _database = context;
            _student = context.Students;
        }

        public async Task<List<StudentModel>> GetAllAsync() => await _student.ToListAsync();

        public async Task<StudentModel> GetByIdAsync(int userID)
        {
            var filteredStudent = await _student.FindAsync(userID);

            return filteredStudent;
        }

        public async Task<int> InsertAsync(StudentModel newStudant)
        {
            await _student.AddAsync(newStudant);
            await _database.SaveChangesAsync();
            return newStudant.Id;
        }

        public async Task DeleteAsync(StudentModel Student)
        {
            _student.Remove(Student);
            await _database.SaveChangesAsync();
        }
    }
}
