using System;
using System.Linq;
using System.Collections.Generic;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;
using GoTalentsCourse.Interfaces;

namespace GoTalentsCourse.Services
{
    public class FacilitatorServices : IFacilitatorServices
    {
        IStandartRepositoryOperations<FacilitatorModel> _facilitatorRepository;

        public FacilitatorServices(IStandartRepositoryOperations<FacilitatorModel> repository)
        {
            _facilitatorRepository = repository;
        }

        public List<FacilitatorModel> FilterByName(string name)
        {
            List<FacilitatorModel> allFacilitators = _facilitatorRepository.GetAll();

            return allFacilitators
                        .Where(facilitator => facilitator.UserName.Contains(name))
                        .ToList();
        }

        public List<FacilitatorModel> GetAll(bool crescent = true)
        {
            List<FacilitatorModel> allFacilitators = _facilitatorRepository.GetAll();

            if (crescent)
                return allFacilitators
                        .OrderBy(facilitator => facilitator.UserName)
                        .ToList();
            else
                return allFacilitators
                        .OrderByDescending(facilitator => facilitator.UserName)
                        .ToList();
        }

        public FacilitatorModel GetByID(int FacilitatorId)
        {
            return _facilitatorRepository.GetByID(FacilitatorId);
        }

        public int Save(FacilitatorModel newFacilitator)
        {
            if (newFacilitator.Role != RoleType.FACILITADOR)
                throw new Exception("Invalid role for facilitator");

            List<FacilitatorModel> allFacilitators = GetAll();
            FacilitatorModel registeredFacilitator = allFacilitators.Find(facilitator => facilitator.Email == newFacilitator.Email);
            
            if (registeredFacilitator != null)
                throw new Exception("User Already Registered");

            _facilitatorRepository.Insert(newFacilitator);
            return newFacilitator.Id;
        }

        public void Delete(int FacilitatorId)
        {
            FacilitatorModel facilitator = GetByID(FacilitatorId);

            if (facilitator == null)
                throw new Exception("Could not remove user");

            _facilitatorRepository.Delete(facilitator);
        }
    }
}
