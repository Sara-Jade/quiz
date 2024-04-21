using Microsoft.EntityFrameworkCore;
using quiz_backend.Models;

namespace quiz_backend
{
    public class QuizContext: DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
}
