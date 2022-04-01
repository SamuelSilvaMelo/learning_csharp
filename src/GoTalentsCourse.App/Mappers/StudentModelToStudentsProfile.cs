using AutoMapper;
using GoTalentsCourse.Models;
using GoTalentsCourse.Models.ViewModels;

namespace GoTalentsCourse.Services.Mappers
{
    public class StudentModelToStudentsProfile : Profile
    {
        public StudentModelToStudentsProfile()
        {
            CreateMap<StudentModel, StudentViewModel>();
        }
    }
}