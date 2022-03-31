using System.Collections.Generic;
using System.Linq;
using GoTalentsCourse.Interfaces;
using GoTalentsCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace GoTalentsCourse.Repository
{
    public class FacilitatorRepository : IStandartRepositoryOperations<FacilitatorModel>
    {
        private DataContext _database;
        private DbSet<FacilitatorModel> _facilitators;

        public FacilitatorRepository(DataContext context)
        {
            _database = context;
            _facilitators = context.Facilitators;
        }

        public List<FacilitatorModel> GetAll() => _facilitators.ToList();

        public FacilitatorModel GetByID(int userID)
        {
            var filteredFacilitator = _facilitators.Find(userID);

            return filteredFacilitator;
        }

        public int Insert(FacilitatorModel newFacilitator)
        {
            _facilitators.Add(newFacilitator);
            _database.SaveChanges();
            return newFacilitator.Id;
        }

        public void Delete(FacilitatorModel facilitator)
        {
            _facilitators.Remove(facilitator);
            _database.SaveChanges();
        }
    }
}
