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
    public class FacilitatorServices : IStandartServicesOperations<FacilitatorViewModel, FacilitatorModel>
    {
        IStandartRepositoryOperations<FacilitatorModel> _facilitatorRepository;
        private IMapper _mapper;
        
        public FacilitatorServices(IStandartRepositoryOperations<FacilitatorModel> repository, IMapper mapper)
        {
            _facilitatorRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<FacilitatorViewModel>> FilterByNameAsync(string name)
        {
            List<FacilitatorModel> allFacilitators = await _facilitatorRepository.GetAllAsync();

            List<FacilitatorViewModel> studentViewList = _mapper.Map<List<FacilitatorModel>, List<FacilitatorViewModel>>(allFacilitators);

            return studentViewList
                        .Where(facilitator => facilitator.UserName.Contains(name))
                        .ToList();
        }

        public async Task<List<FacilitatorViewModel>> GetAllAsync(bool crescent = true)
        {
            List<FacilitatorModel> allFacilitators = await _facilitatorRepository.GetAllAsync();

            List<FacilitatorViewModel> facilitatorViewList = _mapper.Map<List<FacilitatorModel>, List<FacilitatorViewModel>>(allFacilitators);

            if (crescent)
                return facilitatorViewList
                        .OrderBy(facilitator => facilitator.UserName)
                        .ToList();
            else
                return facilitatorViewList
                        .OrderByDescending(facilitator => facilitator.UserName)
                        .ToList();
        }

        public async Task<FacilitatorViewModel> GetByIdAsync(int FacilitatorId)
        {
            FacilitatorModel facilitator = await _facilitatorRepository.GetByIdAsync(FacilitatorId);

            if (facilitator == null)
                throw new Exception("User not found");

            FacilitatorViewModel facilitatorView = _mapper.Map<FacilitatorViewModel>(facilitator);

            return facilitatorView;
        }

        public async Task<FacilitatorViewModel> SaveAsync(FacilitatorModel newFacilitator)
        {
            if (newFacilitator.Role != RoleType.FACILITADOR)
                throw new Exception("Invalid role for facilitator");

            List<FacilitatorModel> allFacilitators = await _facilitatorRepository.GetAllAsync();
            FacilitatorModel registeredFacilitator = allFacilitators.FirstOrDefault(facilitator => facilitator.Email == newFacilitator.Email);
            
            if (registeredFacilitator != null)
                throw new Exception("User Already Registered");

            await _facilitatorRepository.InsertAsync(newFacilitator);

            FacilitatorViewModel facilitatorView = _mapper.Map<FacilitatorViewModel>(newFacilitator);

            return facilitatorView;
        }

        public async Task DeleteAsync(int FacilitatorId)
        {
            FacilitatorModel facilitator = await _facilitatorRepository.GetByIdAsync(FacilitatorId);

            if (facilitator == null)
                throw new Exception("Could not remove user");

            await _facilitatorRepository.DeleteAsync(facilitator);
        }
    }
}
