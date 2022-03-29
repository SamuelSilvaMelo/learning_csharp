using System;
using System.Linq;
using System.Collections.Generic;
using GoTalentsCourse.Repository;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.Services
{
    public class FacilitatorServices : IFacilitatorServices
    {
        FacilitatorRepository _facilitatorRepository;

        public FacilitatorServices()
        {
            _facilitatorRepository = new FacilitatorRepository();
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
                return allFacilitators.OrderBy(facilitator => facilitator.UserName).ToList();
            else
                return allFacilitators.OrderByDescending(facilitator => facilitator.UserName).ToList();
        }

        public FacilitatorModel GetByID(Guid FacilitatorId) => _facilitatorRepository.GetByID(FacilitatorId);

        public Guid Save(FacilitatorModel newFacilitator)
        {
            List<FacilitatorModel> allFacilitators = GetAll();
            FacilitatorModel registeredFacilitator = allFacilitators.Find(facilitator => facilitator.Email == newFacilitator.Email);
            
            if (registeredFacilitator != null)
                throw new Exception("User Already Registered");

            _facilitatorRepository.Insert(newFacilitator);
            return newFacilitator.FacilitatorId;
        }

        public void Delete(Guid FacilitatorId)
        {
            FacilitatorModel facilitator = GetByID(FacilitatorId);
            _facilitatorRepository.Delete(facilitator);
        }
    }
}
