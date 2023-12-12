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
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionTag> QuestionTag { get; set; }
        public DbSet<Vote> Vote { get; set; }

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

            modelBuilder.Entity<Answer>().HasData(
                new Answer()
                {
                    AnswerId = 1,
                    QuestionId = 1,
                    Description = "This is the first answer for question 1?",
                    Creationdate = DateTime.Now,
                },
                new Answer()
                {
                    AnswerId = 2,
                    QuestionId = 2,
                    Description = "This is the second answer for question 2?",
                    Creationdate = DateTime.Now,
                }
            );

            modelBuilder.Entity<QuestionTag>().HasData(
                new QuestionTag()
                {
                    TagId = 1,
                    QuestionId = 1,
                    TagDescription = "Tag1",
                    Creationdate = DateTime.Now,
                },
                new QuestionTag()
                {
                    TagId = 2,
                    QuestionId = 2,
                    TagDescription = "Tag2",
                    Creationdate = DateTime.Now,
                }
            );

            modelBuilder.Entity<Vote>().HasData(
            new Vote()
                {
                    VoteId = 1,
                    QuestionId = 1,
                    QuestionVotes = 3,
                    AnswerId = 1,
                    AnswerVotes = 2
                },
                new Vote()
                {
                    VoteId = 2,
                    QuestionId = 2,
                    QuestionVotes = 4,
                    AnswerId = 2,
                    AnswerVotes = 1
                }
            );
        }
    }
}
