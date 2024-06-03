namespace quiz_backend.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// Must be nullable so backend doesn't demand an OwnerId before the controller can obtain it.
        /// </summary>
        public string? OwnerId { get; set; }

        public Quiz(string title)
        {
            Title = title;
        }
    }
}
