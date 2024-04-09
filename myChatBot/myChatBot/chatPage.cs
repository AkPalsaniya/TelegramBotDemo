using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace myChatBot
{
    public partial class chatPage : Form
    {
        //OpenAI API private key
        private const string OpenAIKey = "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";
        //private const string ApiKey = "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";
        //private const string BaseUrl = "https://api.openai.com/v1";
        //private readonly HttpClient _httpClient;
        // OpenAI API endpoint
        private const string OpenAIEndpoint = "https://api.openai.com/v1/completions";

        public chatPage()
        {
            InitializeComponent();
            //_httpClient = new HttpClient();
            //_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {

            string userInput = txtQuestion.Text.Trim();

            string botResponse = await GenerateOpenAIResponse(userInput);
            // Display the bot's response
            DisplayBotResponse(botResponse);

            txtQuestion.Clear();


            //string question = txtQuestion.Text;
            //string response = await GetResponseFromOpenAI(question);
            //rtxtConvHistory.Text = response;
        }

        //private async Task<string> GetResponseFromOpenAI(string question)
        //{
        //    var requestBody = new
        //    {
        //        prompt = question,
        //        max_tokens = 150,
        //        temperature = 0.7
        //    };

        //    string jsonRequestBody = JsonConvert.SerializeObject(requestBody);
        //    var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

        //    var response = await _httpClient.PostAsync($"{BaseUrl}/engines/davinci-codex/completions", content);
        //    response.EnsureSuccessStatusCode();

        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    // You may need to deserialize the response content based on the structure of the response.
        //    // For simplicity, I'm directly returning the response content here.
        //    return responseContent;
        //}

        private async Task<string> GenerateOpenAIResponse(string userInput)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Set the OpenAI API authorization header
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + OpenAIKey);

                    // Construct the request payload with a different model
                    var requestBody = new
                    {
                        prompt = userInput,
                        max_tokens = 30000, // Adjust as needed (maximum number of tokens in the response)
                        model = "gpt-3.5-turbo-0301" // Use the desired model identifier (e.g., davinci, curie, etc.)
                    };

                    // Serialize the request payload to JSON
                    string jsonRequest = JsonConvert.SerializeObject(requestBody);

                    // Create a StringContent with the JSON payload
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    // Send a POST request to the OpenAI API
                    var response = await httpClient.PostAsync(OpenAIEndpoint, content);

                    // Ensure the request was successful
                    if (!response.IsSuccessStatusCode)
                    {
                        // Read the response content (error message)
                        string errorContent = await response.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"OpenAI API returned status code {response.StatusCode}. Error: {errorContent}");
                    }

                    // Read the response content (generated text)
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<OpenAIResponse>(jsonResponse);

                    // Return the generated text
                    return responseData.choices[0].text;
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request errors
                    Console.WriteLine($"HTTP request error: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
            }
        }

        // Sample method to display the bot's response (replace with your logic)
        private void DisplayBotResponse(string botResponse)
        {
            rtxtConvHistory.AppendText("Bot: " + botResponse + Environment.NewLine);
        }

        // Class to represent the response from the OpenAI API
        private class OpenAIResponse
        {
            public OpenAIChoice[] choices { get; set; }
        }

        // Class to represent a choice in the response from the OpenAI API
        private class OpenAIChoice
        {
            public string text { get; set; }
        }
    }
}