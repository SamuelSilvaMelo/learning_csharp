using AutoMapper;
using GoTalentsCourse.Models;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Models.ViewModels;

namespace GoTalentsCourse.Services
{
    public class FacilitatorServices : BasePersonCrudServices<FacilitatorViewModel, FacilitatorModel>
    {
        public FacilitatorServices(IStandartRepositoryOperations<FacilitatorModel> repository, IMapper mapper) : base(repository, mapper) {}
    }
}
