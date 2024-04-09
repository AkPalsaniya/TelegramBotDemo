using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Polling;


namespace TelegramBotDemo
{
    public partial class tgBotDemo : Form
    {
        private TelegramBotClient botClient;
        public tgBotDemo()
        {
            InitializeComponent();
            botClient = new TelegramBotClient("7124925789:AAEmhUJcNn7WSP45EaneltiiGEHvkvzb5zk");
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            // Register event handler for incoming messages
            botClient.StartReceiving(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync), cancellationToken: default);

            // Disable the start button (optional)
            btnStart.Enabled = false;
        }
        private async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;

            if (message == null || message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return;

            // Get the username of the user
            string username = message.From.Username ?? "there"; // Use "there" if username is not available

            // Process incoming text message
            string response = ProcessMessage(message.Text, username);

            // Send response back to the user
            await botClient.SendTextMessageAsync(message.Chat.Id, response);
        }

        private Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Handle polling errors here (if needed)
            return Task.CompletedTask;
        }
        private string ProcessMessage(string message, string username)
        {
            // Check if the user input is "Hello" (case insensitive)
            if (message.Trim().ToLower() == "hello")
            {
                // Return a specific response mentioning the user
                return $"Hi {username}!";
            }
            else
            {
                // Default response for other messages
                return "You said: " + message;
            }
        }


        //private void btnStop_Click(object sender, EventArgs e)
        //{
        //    // Cancel the token to stop receiving updates
        //    cancellationTokenSource.Cancel();

        //    // Enable the start button
        //    btnStart.Enabled = true;
        //}
    }
}