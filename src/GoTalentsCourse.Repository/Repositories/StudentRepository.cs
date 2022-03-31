using System;
using System.Collections.Generic;
using System.Linq;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Models;
using GoTalentsCourse.Repository;
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

        public List<StudentModel> GetAll() => _student.ToList();

        public StudentModel GetByID(int userID)
        {
            var filteredStudent = _student.Find(userID);

            return filteredStudent;
        }

        public int Insert(StudentModel newStudant)
        {
            _student.Add(newStudant);
            _database.SaveChanges();
            return newStudant.Id;
        }

        public void Delete(StudentModel Student)
        {
            _student.Remove(Student);
            _database.SaveChanges();
        }
    }
}
