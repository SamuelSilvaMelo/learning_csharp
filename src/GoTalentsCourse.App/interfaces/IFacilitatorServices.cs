using System.Collections.Generic;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.Services
{
    public interface IFacilitatorServices
    {
        public List<FacilitatorModel> FilterByName(string name);
        public List<FacilitatorModel> GetAll(bool crescent = true);
        public FacilitatorModel GetByID(int userID);
        public int Save(FacilitatorModel newStudent);
        public void Delete(int studentID);        
    }
}