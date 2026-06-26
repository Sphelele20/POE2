using System.Collections.Generic;

namespace POE2
{
    public class QuizManager
    {
        private List<Question> questions;
        private int currentScore;

        public QuizManager()
        {
            currentScore = 0;
            questions = new List<Question>
            {
                new Question("What does 2FA stand for?", "Two-Factor Authentication", "A"),
                new Question("Which is more secure for 2FA?", "Authenticator App", "A"),
                new Question("Should you share your 2FA code?", "No, never share it", "B"),
                new Question("What happens if someone gets your password but not 2FA code?", "They still cannot login", "A"),
                new Question("Where should you store backup codes?", "Secure offline location", "A")
            };
        }

        public string GetQuizQuestions()
        {
            string quiz = "2FA Quiz - Answer A or B:\n\n";
            for (int i = 0; i < questions.Count; i++)
            {
                quiz += $"{i + 1}. {questions[i].QuestionText}\n";
                quiz += $"A) {questions[i].OptionA}\n";
                quiz += $"B) {questions[i].OptionB}\n\n";
            }
            return quiz;
        }

        public string CheckAnswers(string userAnswers)
        {
            currentScore = 0;
            string[] answers = userAnswers.Split(' ');

            for (int i = 0; i < answers.Length && i < questions.Count; i++)
            {
                if (answers[i].ToUpper() == questions[i].CorrectAnswer)
                    currentScore++;
            }

            return $"Quiz Complete! Score: {currentScore}/{questions.Count}\n" +
                   (currentScore >= 4 ? "Excellent cybersecurity knowledge!" : "Review 2FA safety tips and try again.");
        }

        internal string GetQuizQuestion()
        {
            throw new NotImplementedException();
        }

        private class Question
        {
            public string QuestionText { get; set; }
            public string OptionA { get; set; }
            public string OptionB { get; set; }
            public string CorrectAnswer { get; set; }

            public Question(string text, string a, string b)
            {
                QuestionText = text;
                OptionA = a;
                OptionB = b;
                CorrectAnswer = b;
            }
        }
    }
}