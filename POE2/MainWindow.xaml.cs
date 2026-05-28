using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SmartChat.Services;
using SmartChat.Models;

namespace SmartChat
{
    public partial class MainWindow : Window
    {
        private ChatbotEngine chatbot;

        public MainWindow()
        {
            InitializeComponent();
            chatbot = new ChatbotEngine();
            InitializeChat();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void InitializeChat()
        {
            AddBotMessage("👋 Hello! I'm your Cybersecurity Awareness Assistant!");
            AddBotMessage("");
            AddBotMessage("I can help you with:");
            AddBotMessage("  🔐 Password Safety");
            AddBotMessage("  ⚠️ Scam Prevention");
            AddBotMessage("  🔒 Privacy Protection");
            AddBotMessage("  🛡️ Malware Defense");
            AddBotMessage("  🔑 Two-Factor Authentication");
            AddBotMessage("");
            AddBotMessage("Type 'help' to see all commands!");
            AddBotMessage("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void TxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
                e.Handled = true;
            }
        }

        private void SendMessage()
        {
            string userMessage = TxtUserInput.Text.Trim();
            if (string.IsNullOrEmpty(userMessage))
                return;

            AddUserMessage(userMessage);
            TxtUserInput.Clear();

            var response = chatbot.GetResponse(userMessage);

            if (response.IsImage)
            {
                AddBotMessage("🖼️ Cybersecurity Images");
                AddBotMessage("🛡️ Shield: Protects your digital life");
                AddBotMessage("🔐 Lock: Keeps your data secure");
                AddBotMessage("⚠️ Warning: Stay vigilant online");
            }
            else
            {
                AddBotMessage(response.Message);
            }
        }

        private void AddUserMessage(string message)
        {
            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(37, 99, 235)),
                CornerRadius = new CornerRadius(15, 15, 5, 15),
                Padding = new Thickness(12, 8, 12, 8),
                Margin = new Thickness(150, 5, 10, 5),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            var textBlock = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 13,
                MaxWidth = 400
            };

            border.Child = textBlock;
            ChatPanel.Children.Add(border);
            ScrollToBottom();
        }

        private void AddBotMessage(string message)
        {
            var border = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(30, 41, 59)),
                CornerRadius = new CornerRadius(15, 15, 15, 5),
                Padding = new Thickness(12, 8, 12, 8),
                Margin = new Thickness(10, 5, 150, 5),
                HorizontalAlignment = HorizontalAlignment.Left
            };

            var textBlock = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 13,
                MaxWidth = 500
            };

            border.Child = textBlock;
            ChatPanel.Children.Add(border);
            ScrollToBottom();
        }

        private void BtnVoiceGreeting_Click(object sender, RoutedEventArgs e)
        {
            VoiceService.PlayGreeting();
            AddBotMessage("🔊 Voice greeting played!");
        }

        private void BtnClearChat_Click(object sender, RoutedEventArgs e)
        {
            ChatPanel.Children.Clear();
            InitializeChat();
        }

        private void ScrollToBottom()
        {
            ChatScrollViewer.ScrollToBottom();
        }
    }
}