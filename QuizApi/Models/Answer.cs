using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models
{
    public class Answer
    {
        //[Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string Content { get; set; }
    }
}
