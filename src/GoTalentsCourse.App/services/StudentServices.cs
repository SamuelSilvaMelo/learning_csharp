using System;
using System.Linq;
using System.Collections.Generic;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;
using GoTalentsCourse.Interfaces;
using System.Threading.Tasks;

namespace GoTalentsCourse.Services
{
    public class StudentServices : IStudentServices
    {
        IStandartRepositoryOperations<StudentModel> _studentRepository;

        public StudentServices(IStandartRepositoryOperations<StudentModel> repository)
        {
            _studentRepository = repository;
        }

        public async Task<List<StudentModel>> FilterByNameAsync(string name)
        {
            List<StudentModel> allStudents = await _studentRepository.GetAllAsync();

            return allStudents
                    .Where(student => student.UserName.Contains(name))
                    .ToList();
        }

        public async Task<List<StudentModel>> GetAllAsync(bool crescent = true)
        {
            List<StudentModel> allStudents = await _studentRepository.GetAllAsync();

            if (crescent)
                return allStudents
                        .OrderBy(student => student.UserName)
                        .ToList();
            else
                return allStudents
                        .OrderByDescending(student => student.UserName)
                        .ToList();
        }

        public async Task<StudentModel> GetByIdAsync(int studentId)
        {
            StudentModel student = await _studentRepository.GetByIdAsync(studentId);
            return student;
        }

        public async Task<int> SaveAsync(StudentModel newStudent)
        {
            if (newStudent.Role != RoleType.ALUNO)
                throw new Exception("Invalid role for student");

            List<StudentModel> allStudents = await _studentRepository.GetAllAsync();
            StudentModel registeredStudent = allStudents.FirstOrDefault(student => student.Email == newStudent.Email);

            if (registeredStudent != null)
                throw new Exception("User Already Registered");

            await _studentRepository.InsertAsync(newStudent);
            return newStudent.Id;
        }
        
        public async Task DeleteAsync(int studentID)
        {
            StudentModel student = await GetByIdAsync(studentID);

            if (student == null)
                throw new Exception("Could not remove user");

            await _studentRepository.DeleteAsync(student);
        }
    }
}
