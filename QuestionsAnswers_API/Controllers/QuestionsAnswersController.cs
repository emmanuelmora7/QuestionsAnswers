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
    public class QuestionsAnswersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public QuestionsAnswersController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            return Ok(await _dbContext.Questions.ToListAsync());
        }

        [HttpGet("id:int", Name ="GetQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var question = await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id);

            if(question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

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
            if(questionDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Question model = new()
            {
                Id = questionDto.Id,
                Description = questionDto.Description,
                Creationdate = DateTime.Now   
            };

            await _dbContext.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetQuestion", new {Id= questionDto.Id}, questionDto);
        }
    }
}
