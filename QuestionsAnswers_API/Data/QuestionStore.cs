using QuestionsAnswers_API.Controllers.Models.Dto;

namespace QuestionsAnswers_API.Data
{
    public static class QuestionStore
    {
        public static List<QuestionDto> questionList = new List<QuestionDto> 
        { 
            new QuestionDto{Id=1, Description="Question 1"},
            new QuestionDto{Id=2, Description="Question 2"}
        };
    }
}
