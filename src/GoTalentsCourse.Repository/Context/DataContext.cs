using Microsoft.EntityFrameworkCore;
using GoTalentsCourse.Models;

namespace GoTalentsCourse.Repository.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<FacilitatorModel> Facilitators { get; set; }
    }
}
