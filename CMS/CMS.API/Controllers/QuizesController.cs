using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizesController : ControllerBase
    {
        private readonly IQuizesService _quizesService;

        public QuizesController(IQuizesService quizesService)
        {
            _quizesService = quizesService;
        }


        [HttpPost("AddQuiz")]
        public async Task<ActionResult> AddQuiz([FromBody] AddQuizDto addQuizDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var addQuiz = await _quizesService.AddQuiz(addQuizDto);
                if (addQuiz != null)
                {
                    return Ok(new
                    {
                        Message = "Quiz was added successfully"
                    });
                }
                return StatusCode(StatusCodes.Status501NotImplemented, "No Quiz Added to Database");
            }
            catch (Exception)
            {


                return StatusCode(StatusCodes.Status501NotImplemented, "Error");
            }

        }


        [HttpPatch("UpdateQuiz")]
        public async Task<IActionResult> UpdateQuiz(string Id, [FromBody] UpdateDto updateDto)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var addQuiz = await _quizesService.UpdateQuiz(Id, updateDto);
                if (addQuiz != null)
                {
                    return Ok(new
                    {
                        Message = "Quiz updated successfully"
                    });
                }
                return StatusCode(StatusCodes.Status501NotImplemented, "Quiz has update is not successful");
            }
            catch (Exception)
            {


                return StatusCode(StatusCodes.Status501NotImplemented, "Error");
            }
        }

        [HttpDelete("DeleteQuiz")]
        public async Task<ActionResult> DeleteQuiz(string Id)
        {
            try
            {

                var DeleteQuiz = await _quizesService.DeleteQuiz(Id);


                if (DeleteQuiz)
                {
                    return Ok($"{DeleteQuiz} has been deleted");

                }

                return NotFound("Failed to delete Quiz");


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status501NotImplemented, "Error");
            }


        }
    }
}