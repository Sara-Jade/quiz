namespace quiz_backend.Models
{
    public class Question
    {
        public string Text { get; set; }
        public Question(string text)
        {
            Text = text;
        }
    }
}
