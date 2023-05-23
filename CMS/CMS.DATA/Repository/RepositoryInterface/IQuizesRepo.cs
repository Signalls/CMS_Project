using CMS.DATA.Entities;

namespace CMS.DATA.Repository.RepositoryInterface
{
    public interface IQuizesRepo
    {
        Task<Quiz> AddQuiz(Quiz entity);
        Task<bool> DeleteQuizAsync(Quiz entity);
        Task<Quiz> UpdateQuiz(Quiz entity);
        Task<Quiz> GetQuizById(string Id);
    }
}