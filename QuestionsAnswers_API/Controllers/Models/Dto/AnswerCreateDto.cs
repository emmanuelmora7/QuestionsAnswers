using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers_API.Controllers.Models.Dto
{
    public class AnswerCreateDto
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

    }
}
