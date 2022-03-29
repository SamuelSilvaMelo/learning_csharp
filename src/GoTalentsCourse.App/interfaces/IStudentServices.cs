using System;
using System.Collections.Generic;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Services
{
    public interface IStudentServices
    {
        public List<StudentModel> FilterByName(string name);
        public List<StudentModel> GetAll(bool crescent = true);
        public StudentModel GetByID(Guid userID);
        public Guid Save(StudentModel newStudent);
        public void Delete(Guid studentID);        
    }
}