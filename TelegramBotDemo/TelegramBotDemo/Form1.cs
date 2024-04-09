using System;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Polling;

namespace TelegramBotDemo
{
    public partial class Form1 : Form
    {
        private TelegramBotClient Botclient;

        public Form1()
        {
            //InitializeComponent();
            Botclient = new TelegramBotClient("7124925789:AAEmhUJcNn7WSP45EaneltiiGEHvkvzb5zk");
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    // Provide a dummy error handler as pollingErrorHandler
        //    Func<ITelegramBotClient, Exception, CancellationToken, Task> pollingErrorHandler = (client, exception, token) =>
        //    {
        //        // Handle errors here
        //        return Task.CompletedTask;
        //    };

        //    // Start receiving updates with a dummy error handler
        //    Botclient.StartReceiving(HandleUpdateAsync, pollingErrorHandler);
        //}

        //private async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        //{
        //    var message = update.Message;

        //    if (message == null || message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
        //        return;

        //    // Process incoming text message
        //    string response = ProcessMessage(message.Text);

        //    // Send response back to the user
        //    await botClient.SendTextMessageAsync(message.Chat.Id, response);
        //}


        //private void  btnStart_Click(object sender, EventArgs e)
        //{
        //    // You may perform additional actions when the "Start" button is clicked
        //    // For example, you can start receiving updates here
        //    Botclient.StartReceiving(HandleUpdateAsync);
        //}

        // Remove the btnStop_Click method since StopReceiving is not available
    }
}
