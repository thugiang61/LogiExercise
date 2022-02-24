using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models
{
    public class QuizItem
    {
        //[Key]
        public int Id { get; set; }
        public string Question { get; set; }
        //public string[] Answers { get; set; }
        public List<Answer> Answers { get; set; }

        public int RightAnswer { get; set; }
    }
}