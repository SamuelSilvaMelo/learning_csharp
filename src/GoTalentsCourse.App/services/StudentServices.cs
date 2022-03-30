using System;
using System.Linq;
using System.Collections.Generic;
using GoTalentsCourse.Repository;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Services
{
    public class StudentServices : IStudentServices
    {
        StudentRepository _studentRepository;

        public StudentServices()
        {
            _studentRepository = new StudentRepository();
        }

        public List<StudentModel> FilterByName(string name)
        {
            List<StudentModel> allStudents = _studentRepository.GetAll();
            
            return allStudents
                    .Where(student => student.UserName.Contains(name))
                    .ToList();
        }

        public List<StudentModel> GetAll(bool crescent = true)
        {
            List<StudentModel> allStudents = _studentRepository.GetAll();

            if (crescent)
                return allStudents.OrderBy(student => student.UserName).ToList();
            else
                return allStudents.OrderByDescending(student => student.UserName).ToList();
        }

        public StudentModel GetByID(Guid studentId) => _studentRepository.GetByID(studentId);

        public Guid Save(StudentModel newStudent)
        {
            if (newStudent.Role != RoleType.ALUNO)
            {
                throw new Exception("Invalid role for student");
            }

            List<StudentModel> allStudents = GetAll();
            StudentModel registeredStudent = allStudents.Find(student => student.Email == newStudent.Email);

            if (registeredStudent != null)
                throw new Exception("User Already Registered");

            _studentRepository.Insert(newStudent);
            return newStudent.StudentId;
        }
        
        public void Delete(Guid studentID)
        {
            StudentModel student = GetByID(studentID);
            _studentRepository.Delete(student);
        }
    }
}
