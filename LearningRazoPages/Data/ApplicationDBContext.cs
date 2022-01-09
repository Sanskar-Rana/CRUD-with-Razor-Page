using LearningRazoPages.Model;
using Microsoft.EntityFrameworkCore;

namespace LearningRazoPages.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Student { get; set; }
    

    }
}
