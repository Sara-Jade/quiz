﻿namespace quiz_backend.Models
{
    public class Quiz
    {
        public string Title { get; set; }

        public Quiz(string title)
        {
            Title = title;
        }
    }
}
