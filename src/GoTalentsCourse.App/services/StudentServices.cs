using System;
using System.Linq;
using System.Collections.Generic;
using GoTalentsCourse.Repository;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;
using GoTalentsCourse.Repository.DataContext;

namespace GoTalentsCourse.Services
{
    public class StudentServices : IStudentServices
    {
        DataContext _studentRepository;

        public StudentServices(DataContext context)
        {
            _studentRepository = context;
        }

        public List<StudentModel> FilterByName(string name)
        {
            return _studentRepository
                    .Students
                    .Where(student => student.UserName.Contains(name))
                    .ToList();
        }

        public List<StudentModel> GetAll(bool crescent = true)
        {
            if (crescent)
                return _studentRepository
                        .Students
                        .OrderBy(student => student.UserName)
                        .ToList();
            else
                return _studentRepository
                        .Students
                        .OrderByDescending(student => student.UserName)
                        .ToList();
        }

        public StudentModel GetByID(int studentId) => _studentRepository.Students.Find(studentId);

        public int Save(StudentModel newStudent)
        {
            if (newStudent.Role != RoleType.ALUNO)
            {
                throw new Exception("Invalid role for student");
            }

            StudentModel registeredStudent = _studentRepository.Students.FirstOrDefault(student => student.Email == newStudent.Email);

            if (registeredStudent != null)
                throw new Exception("User Already Registered");

            _studentRepository.Students.Add(newStudent);
            _studentRepository.SaveChanges();
            return newStudent.Id;
        }
        
        public void Delete(int studentID)
        {
            StudentModel student = GetByID(studentID);
            _studentRepository.Students.Remove(student);
            _studentRepository.SaveChanges();
        }
    }
}
