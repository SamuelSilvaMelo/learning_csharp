using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Services.Interfaces;
using GoTalentsCourse.Models.ViewModels;

namespace GoTalentsCourse.Services
{
    public class StudentServices : IStandartServicesOperations<StudentViewModel, StudentModel>
    {
        private IStandartRepositoryOperations<StudentModel> _studentRepository;
        private IMapper _mapper;

        public StudentServices(IStandartRepositoryOperations<StudentModel> repository, IMapper mapper)
        {
            _studentRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<StudentViewModel>> FilterByNameAsync(string name)
        {
            List<StudentModel> allStudents = await _studentRepository.GetAllAsync();
            
            List<StudentViewModel> studentViewList = _mapper.Map<List<StudentModel>, List<StudentViewModel>>(allStudents);

            return studentViewList
                    .Where(student => student.UserName.Contains(name))
                    .ToList();
        }

        public async Task<List<StudentViewModel>> GetAllAsync(bool crescent = true)
        {
            List<StudentModel> allStudents = await _studentRepository.GetAllAsync();

            List<StudentViewModel> studentViewList = _mapper.Map<List<StudentModel>, List<StudentViewModel>>(allStudents);

            if (crescent)
                return studentViewList
                        .OrderBy(student => student.NickName)
                        .ToList();
            else
                return studentViewList
                        .OrderByDescending(student => student.NickName)
                        .ToList();
        }

        public async Task<StudentViewModel> GetByIdAsync(int studentId)
        {
            StudentModel student = await _studentRepository.GetByIdAsync(studentId);

            if (student == null)
                throw new Exception("User not found");

            StudentViewModel studentView = _mapper.Map<StudentViewModel>(student);

            return studentView;
        }

        public async Task<StudentViewModel> SaveAsync(StudentModel newStudent)
        {
            if (newStudent.Role != RoleType.ALUNO)
                throw new Exception("Invalid role for student");

            List<StudentModel> allStudents = await _studentRepository.GetAllAsync();
            StudentModel registeredStudent = allStudents.FirstOrDefault(student => student.Email == newStudent.Email);

            if (registeredStudent != null)
                throw new Exception("User Already Registered");

            await _studentRepository.InsertAsync(newStudent);

            StudentViewModel studentView = _mapper.Map<StudentViewModel>(newStudent);
            return studentView;
        }
        
        public async Task DeleteAsync(int studentID)
        {
            StudentModel student = await _studentRepository.GetByIdAsync(studentID);

            if (student == null)
                throw new Exception("Could not remove user");

            await _studentRepository.DeleteAsync(student);
        }
    }
}
