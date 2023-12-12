using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers_API.Controllers.Models.Dto
{
    public class VoteQuestionDto
    {
        [Required]
        public int VoteId { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }
}
