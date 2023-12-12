using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionsAnswers_API.Controllers.Models;
using QuestionsAnswers_API.Controllers.Models.Dto;
using QuestionsAnswers_API.Data;

namespace QuestionsAnswers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public QuestionsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get all questions
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            return Ok(await _dbContext.Questions.ToListAsync());
        }

        //Get questions by tag 
        [HttpGet("id:int", Name ="GetQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<QuestionDto>> GetQuestionByTag(string tag)
        {
            if(tag == "")
            {
                return BadRequest();
            }

            var question = await (from q in _dbContext.Questions
                            join t in _dbContext.QuestionTag
                            on q.Id equals t.QuestionId
                            where t.TagDescription.Contains(tag)
                            select new {q.Id, q.Description, t.TagDescription}).ToListAsync();

            if(question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        //Create a new question
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuestionDto>>  CreateQuestion([FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (questionDto == null)
            {
                return BadRequest(questionDto);
            }

            Question model = new()
            {
                Description = questionDto.Description,
                Creationdate = DateTime.Now   
            };

            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            QuestionTag modelTag = new()
            {
                TagDescription = questionDto.TagDescription,
                QuestionId = model.Id,
                Creationdate = DateTime.Now
            };

            await _dbContext.AddAsync(modelTag);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetQuestion", new {Id= questionDto.Id}, questionDto);
        }

    }
}
