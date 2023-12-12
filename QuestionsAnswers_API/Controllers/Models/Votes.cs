using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionsAnswers_API.Controllers.Models
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteId { get; set; }
        public int QuestionVotes { get; set; }
        public int QuestionId { get; set; }
        public int AnswerVotes { get; set; }
        public int AnswerId { get; set; }
    }
}
