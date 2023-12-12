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
    public class VotesAnswersController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public VotesAnswersController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Vote for an answer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VoteAnswerDto>> VoteAnswer([FromBody] VoteAnswerDto voteAnswerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (voteAnswerDto == null)
            {
                return BadRequest(voteAnswerDto);
            }

            var findAnswer = await _dbContext.Vote.AsNoTracking().FirstOrDefaultAsync(a => a.AnswerId == voteAnswerDto.AnswerId);

            if (findAnswer == null)
            {
                Vote model = new()
                {
                    AnswerId = voteAnswerDto.AnswerId,
                    AnswerVotes = 1
                };

                await _dbContext.AddAsync(model);
            }
            else
            {
                Vote modelupdate = new()
                {
                    VoteId = findAnswer.VoteId,
                    AnswerId = voteAnswerDto.AnswerId,
                    AnswerVotes = findAnswer.AnswerVotes + 1
                };

                _dbContext.Update(modelupdate);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetAnswer", new { Id = voteAnswerDto.AnswerId }, voteAnswerDto);
        }
    }
}
