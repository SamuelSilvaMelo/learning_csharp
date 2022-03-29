using System;
using System.Collections.Generic;
using GoTalentsCourse.Models;
using GoTalentsCourse.Types;

namespace GoTalentsCourse.Services
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