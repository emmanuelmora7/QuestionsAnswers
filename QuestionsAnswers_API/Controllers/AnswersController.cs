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
    public class AnswersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public AnswersController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get answer by question Id
        [HttpGet("questionId:int", Name = "GetAnswer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAnswer(int questionId)
        {
            if (questionId == 0)
            {
                return BadRequest();
            }

            var answer = await _dbContext.Answers.FirstOrDefaultAsync(a => a.QuestionId == questionId);

            if (answer == null)
            {
                return NotFound();
            }

            return Ok(await _dbContext.Answers.ToListAsync());
        }

        //Create a new answer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AnswerDto>> CreateAnswer([FromBody] AnswerDto answerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (answerDto == null)
            {
                return BadRequest(answerDto);
            }

            Answer model = new()
            {
                QuestionId = answerDto.QuestionId,
                Description = answerDto.Description,
                Creationdate = DateTime.Now
            };

            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetAnswer", new { Id = answerDto.Id }, answerDto);
        }
    }
}
