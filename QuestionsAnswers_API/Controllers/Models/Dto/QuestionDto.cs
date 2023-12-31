﻿using System.ComponentModel.DataAnnotations;

namespace QuestionsAnswers_API.Controllers.Models.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public string TagDescription { get; set; }
    }
}
