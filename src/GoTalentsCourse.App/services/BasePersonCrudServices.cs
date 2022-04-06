using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using GoTalentsCourse.Types;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Services.Interfaces;

namespace GoTalentsCourse.Services
{
    public class BasePersonCrudServices<TViewModel, TModel> : IStandartServicesOperations<TViewModel, TModel>
    {
        IStandartRepositoryOperations<TModel> _facilitatorRepository;
        private IMapper _mapper;
        
        public BasePersonCrudServices(IStandartRepositoryOperations<TModel> repository, IMapper mapper)
        {
            _facilitatorRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<TViewModel>> FilterByNameAsync(string name)
        {
            List<TModel> allFacilitators = await _facilitatorRepository.GetAllAsync();

            List<TViewModel> studentViewList = _mapper.Map<List<TModel>, List<TViewModel>>(allFacilitators);

            return studentViewList
                        .Where(facilitator => facilitator.UserName.Contains(name))
                        .ToList();
        }

        public async Task<List<TViewModel>> GetAllAsync(bool crescent = true)
        {
            List<TModel> allFacilitators = await _facilitatorRepository.GetAllAsync();

            List<TViewModel> facilitatorViewList = _mapper.Map<List<TModel>, List<TViewModel>>(allFacilitators);

            if (crescent)
                return facilitatorViewList
                        .OrderBy(facilitator => facilitator.UserName)
                        .ToList();
            else
                return facilitatorViewList
                        .OrderByDescending(facilitator => facilitator.UserName)
                        .ToList();
        }

        public async Task<TViewModel> GetByIdAsync(int FacilitatorId)
        {
            TModel facilitator = await _facilitatorRepository.GetByIdAsync(FacilitatorId);

            if (facilitator == null)
                throw new Exception("User not found");

            TViewModel facilitatorView = _mapper.Map<TViewModel>(facilitator);

            return facilitatorView;
        }

        public async Task<TViewModel> SaveAsync(TModel newFacilitator)
        {
            if (newFacilitator.Role != RoleType.FACILITADOR)
                throw new Exception("Invalid role for facilitator");

            List<TModel> allFacilitators = await _facilitatorRepository.GetAllAsync();
            TModel registeredFacilitator = allFacilitators.FirstOrDefault(facilitator => facilitator.Email == newFacilitator.Email);
            
            if (registeredFacilitator != null)
                throw new Exception("User Already Registered");

            await _facilitatorRepository.InsertAsync(newFacilitator);

            TViewModel facilitatorView = _mapper.Map<TViewModel>(newFacilitator);

            return facilitatorView;
        }

        public async Task DeleteAsync(int FacilitatorId)
        {
            TModel facilitator = await _facilitatorRepository.GetByIdAsync(FacilitatorId);

            if (facilitator == null)
                throw new Exception("Could not remove user");

            await _facilitatorRepository.DeleteAsync(facilitator);
        }
    }
}