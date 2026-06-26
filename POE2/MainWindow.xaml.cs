using System.Windows;
using System.Windows.Input;
using System.IO;

namespace POE2
{
    public partial class MainWindow : Window
    {
        private ChatbotEngine bot;
        private TaskManager tasks;
        private QuizManager quiz;
        private ActivityLogger logger;

        public MainWindow()
        {
            InitializeComponent();
            bot = new ChatbotEngine();
            tasks = new TaskManager();
            quiz = new QuizManager();
            logger = new ActivityLogger();

            TaskBox.Text = tasks.GetSecurityTask();
            QuizBox.Text = quiz.GetQuizQuestion();
            LoadLog();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string userInput = InputBox.Text;
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                ChatBox.AppendText($"You: {userInput}\n");
                string reply = bot.GetResponse(userInput);
                ChatBox.AppendText($"Bot: {reply}\n\n");
                logger.LogActivity($"User: {userInput}");
                InputBox.Clear();
                ChatBox.ScrollToEnd();
                LoadLog();
            }
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Send_Click(sender, e);
        }

        private void Hello_Click(object sender, RoutedEventArgs e)
        {
            ChatBox.AppendText("Bot: Hello! Ask me about passwords, phishing, malware, or WiFi safety.\n\n");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ChatBox.Clear();
        }

        private void ShowImages_Click(object sender, RoutedEventArgs e)
        {
            QuizBox.Text = quiz.GetQuizQuestion();
            MessageBox.Show("Switched to 2FA Quiz tab", "Info");
        }

        private void LoadLog()
        {
            string logFile = "chatbot_log.txt";
            if (File.Exists(logFile))
                LogBox.Text = File.ReadAllText(logFile);
        }
    }
}