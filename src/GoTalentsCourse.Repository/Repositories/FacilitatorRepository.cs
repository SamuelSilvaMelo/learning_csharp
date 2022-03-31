using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<FacilitatorModel>> GetAllAsync() => await _facilitators.ToListAsync();

        public async Task<FacilitatorModel> GetByIdAsync(int userID)
        {
            var filteredFacilitator = await _facilitators.FindAsync(userID);

            return filteredFacilitator;
        }

        public async Task<int> InsertAsync(FacilitatorModel newFacilitator)
        {
            await _facilitators.AddAsync(newFacilitator);
            await _database.SaveChangesAsync();
            return newFacilitator.Id;
        }

        public async Task DeleteAsync(FacilitatorModel facilitator)
        {
            _facilitators.Remove(facilitator);
            await _database.SaveChangesAsync();
        }
    }
}
