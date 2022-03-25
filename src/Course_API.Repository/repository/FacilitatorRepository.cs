using System;
using System.Collections.Generic;
using System.Linq;
using Course_API.Interfaces;
using Course_API.Models;

namespace Course_API.Repository
{
    public class FacilitatorRepository : IBasicCRUD<FacilitatorModel>
    {
        static readonly List<FacilitatorModel> _facilitators;

        static FacilitatorRepository()
        {
            _facilitators = new List<FacilitatorModel>();
        }

        public List<FacilitatorModel> GetAll() => _facilitators;

        public FacilitatorModel GetByID(Guid userID)
        {
            var filteredFacilitator = _facilitators
                .Where(facilitator => facilitator != null)
                .Where(facilitator => facilitator.FacilitatorId == userID)
                .First();

            return filteredFacilitator;
        }

        public Guid Insert(FacilitatorModel newFacilitator)
        {
            _facilitators.Add(newFacilitator);
            return newFacilitator.FacilitatorId;
        }

        public void Delete(FacilitatorModel facilitator) => _facilitators.Remove(facilitator);
    }
}
