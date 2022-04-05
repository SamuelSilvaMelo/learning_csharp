using AutoMapper;
using GoTalentsCourse.Models;
using GoTalentsCourse.Models.ViewModels;

namespace GoTalentsCourse.Services.Mappers
{
    public class FacilitatorModelToStudentsProfile : Profile
    {
        public FacilitatorModelToStudentsProfile()
        {
            CreateMap<FacilitatorModel, FacilitatorViewModel>();
        }
    }
}