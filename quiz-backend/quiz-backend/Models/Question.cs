namespace quiz_backend.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? CorrectAnswer1 { get; set; } = null!;
        public string? CorrectAnswer2 { get; set; } = null!;
        public string? CorrectAnswer3 { get; set; } = null!;
        public Question(string text, string? correctAnswer1, string? correctAnswer2, string? correctAnswer3)
        {
            Text = text;
            CorrectAnswer1 = correctAnswer1;
            CorrectAnswer2 = correctAnswer2;
            CorrectAnswer3 = correctAnswer3;
        }
    }
}
