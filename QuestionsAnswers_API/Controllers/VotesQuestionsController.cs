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
    public class VotesQuestionsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public VotesQuestionsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Vote for a question
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VoteQuestionDto>> VoteAnswer([FromBody] VoteQuestionDto voteQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (voteQuestionDto == null)
            {
                return BadRequest(voteQuestionDto);
            }

            var findQuestion = await _dbContext.Vote.AsNoTracking().FirstOrDefaultAsync(a => a.QuestionId == voteQuestionDto.QuestionId);

            if (findQuestion == null)
            {
                Vote model = new()
                {
                    QuestionId = voteQuestionDto.QuestionId,
                    QuestionVotes = 1
                };

                await _dbContext.AddAsync(model);
            }
            else
            {
                Vote modelupdate = new()
                {
                    VoteId = findQuestion.VoteId,
                    AnswerId = voteQuestionDto.QuestionId,
                    AnswerVotes = findQuestion.QuestionVotes + 1
                };

                _dbContext.Update(modelupdate);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtRoute("GetAnswer", new { Id = voteQuestionDto.QuestionId }, voteQuestionDto);
        }
    }
}
