using System;
using System.Collections.Generic;
using Course_API.Models;
using Course_API.Types;

namespace Course_API.Services
{
    public interface IFacilitatorServices
    {
        public List<FacilitatorModel> FilterByName(string name);
        public List<FacilitatorModel> GetAll(bool crescent = true);
        public FacilitatorModel GetByID(Guid userID);
        public Guid Save(FacilitatorModel newStudent);
        public void Delete(Guid studentID);        
    }
}