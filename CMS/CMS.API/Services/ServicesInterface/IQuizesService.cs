using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IQuizesService
    {
        Task<Quiz> AddQuiz(AddQuizDto addQuizDto);
        Task<Quiz> UpdateQuiz(string Id, UpdateDto updateDto);
        Task<bool> DeleteQuiz(string Id);
    }
}