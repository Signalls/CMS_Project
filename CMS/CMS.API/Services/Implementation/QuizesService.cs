using CMS.API.Services.ServicesInterface;
using CMS.DATA.DTO;
using CMS.DATA.Entities;
using CMS.DATA.Repository.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Services
{
    public class QuizesService : IQuizesService
    {
        private readonly IQuizesRepo _quizesRepo;

        public QuizesService(IQuizesRepo quizesRepo)
        {
            _quizesRepo = quizesRepo;
        }

        public async Task<Quiz> AddQuiz(AddQuizDto addQuizDto)
        {
            var NewQuiz = new Quiz
            {
                AddedById = addQuizDto.AddedById,
                AnswerType = addQuizDto.AnswerType,
                Instruction = addQuizDto.Instruction,
                Question = addQuizDto.Question,
                LessonId = addQuizDto.LessonId,
                DateCreated = addQuizDto.DateCreated,
                PreferedAnswer = addQuizDto.PreferedAnswer,

            };

            var QuizResult = await _quizesRepo.AddQuiz(NewQuiz);
            return QuizResult;

        }


        public async Task<Quiz> UpdateQuiz(string Id, [FromBody] UpdateDto updateDto)
        {



            var NewQuiz = await _quizesRepo.GetQuizById(Id);
            if (NewQuiz != null)
            {
                NewQuiz.AnswerType = updateDto.AnswerType;
                NewQuiz.DateUpdated = updateDto.DateUpdated;
                NewQuiz.Instruction = updateDto.Instruction;
                NewQuiz.Question = updateDto.Question;
                NewQuiz.PreferedAnswer = updateDto.PreferedAnswer;
                NewQuiz.IsDeleted = updateDto.IsDeleted;

            };

            var QuizResult = await _quizesRepo.UpdateQuiz(NewQuiz);
            return QuizResult;

        }
        public async Task<bool> DeleteQuiz(string Id)
        {
            var GetQuiz = await _quizesRepo.GetQuizById(Id);
            if (GetQuiz != null)
            {
                var DeleteQuiz = _quizesRepo.DeleteQuizAsync(GetQuiz);
                return true;
            }
            return false;

        }


    }
}