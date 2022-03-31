using System;
using System.Linq;
using System.Collections.Generic;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;
using GoTalentsCourse.Interfaces;
using System.Threading.Tasks;

namespace GoTalentsCourse.Services
{
    public class FacilitatorServices : IFacilitatorServices
    {
        IStandartRepositoryOperations<FacilitatorModel> _facilitatorRepository;

        public FacilitatorServices(IStandartRepositoryOperations<FacilitatorModel> repository)
        {
            _facilitatorRepository = repository;
        }

        public async Task<List<FacilitatorModel>> FilterByNameAsync(string name)
        {
            List<FacilitatorModel> allFacilitators = await _facilitatorRepository.GetAllAsync();

            return allFacilitators
                        .Where(facilitator => facilitator.UserName.Contains(name))
                        .ToList();
        }

        public async Task<List<FacilitatorModel>> GetAllAsync(bool crescent = true)
        {
            List<FacilitatorModel> allFacilitators = await _facilitatorRepository.GetAllAsync();

            if (crescent)
                return allFacilitators
                        .OrderBy(facilitator => facilitator.UserName)
                        .ToList();
            else
                return allFacilitators
                        .OrderByDescending(facilitator => facilitator.UserName)
                        .ToList();
        }

        public async Task<FacilitatorModel> GetByIdAsync(int FacilitatorId)
        {
            FacilitatorModel facilitator = await _facilitatorRepository.GetByIdAsync(FacilitatorId);

            return facilitator;
        }

        public async Task<int> SaveAsync(FacilitatorModel newFacilitator)
        {
            if (newFacilitator.Role != RoleType.FACILITADOR)
                throw new Exception("Invalid role for facilitator");

            List<FacilitatorModel> allFacilitators = await GetAllAsync();
            FacilitatorModel registeredFacilitator = allFacilitators.Find(facilitator => facilitator.Email == newFacilitator.Email);
            
            if (registeredFacilitator != null)
                throw new Exception("User Already Registered");

            await _facilitatorRepository.InsertAsync(newFacilitator);
            return newFacilitator.Id;
        }

        public async Task DeleteAsync(int FacilitatorId)
        {
            FacilitatorModel facilitator = await GetByIdAsync(FacilitatorId);

            if (facilitator == null)
                throw new Exception("Could not remove user");

            await _facilitatorRepository.DeleteAsync(facilitator);
        }
    }
}
