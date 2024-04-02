namespace quiz_backend.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] WrongAnswers { get; set; }
        public Question(string text, string correctAnswer, string[] wrongAnswers)
        {
            Text = text;
            CorrectAnswer = correctAnswer;
            WrongAnswers = wrongAnswers;
        }
    }
}
