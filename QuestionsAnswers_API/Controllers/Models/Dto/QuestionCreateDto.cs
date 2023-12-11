using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers_API.Controllers.Models.Dto
{
    public class QuestionCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

    }
}
