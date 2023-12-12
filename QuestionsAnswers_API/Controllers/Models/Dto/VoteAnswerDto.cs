using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers_API.Controllers.Models.Dto
{
    public class VoteAnswerDto
    {
        [Required]
        public int VoteId { get; set; }
        [Required]
        public int AnswerId { get; set; }
    }
}
