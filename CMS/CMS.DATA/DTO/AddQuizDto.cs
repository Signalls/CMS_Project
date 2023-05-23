namespace CMS.DATA.DTO
{
    public class AddQuizDto
    {
        public string Question { get; set; }
        public string AnswerType { get; set; }
        public string PreferedAnswer { get; set; }
        public string AddedById { get; set; }
        public string LessonId { get; set; }

        public string Instruction { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool IsDeleted { get; set; }


    }
}
