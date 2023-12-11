using Microsoft.EntityFrameworkCore;
using QuestionsAnswers_API.Controllers.Models;

namespace QuestionsAnswers_API.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
            
        }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question()
                {
                    Id = 1,
                    Description = "This is the first question?",
                    Creationdate = DateTime.Now,
                },
                new Question()
                {
                    Id = 2,
                    Description = "This is the second question?",
                    Creationdate = DateTime.Now,
                }
            );
        }
    }
}
