using System;
using System.Collections.Generic;
using System.Linq;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.Repository
{
    public class StudentRepository : IStandartRepositoryOperations<StudentModel>
    {
        private static readonly List<StudentModel> _student;

        static StudentRepository()
        {
            _student = new List<StudentModel>();
        }

        public List<StudentModel> GetAll() => _student;

        public StudentModel GetByID(int userID)
        {
            var filteredStudent = _student
                .Where(student => student != null)
                .Where(student => student.Id == userID)
                .First();

            return filteredStudent;
        }

        public int Insert(StudentModel newStudant)
        {
            _student.Add(newStudant);
            return newStudant.Id;
        }

        public void Delete(StudentModel Student) => _student.Remove(Student);
    }
}
