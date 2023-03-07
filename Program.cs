// See https://aka.ms/new-console-template for more information

using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

var ApiKey = "Your API Key here";

var gpt3 = new OpenAIService(new OpenAiOptions
{
    ApiKey = ApiKey
});

Console.WriteLine("Enter your query here : ");
var prompt = Console.ReadLine();

var completionResult = await gpt3.Completions.CreateCompletion(new CompletionCreateRequest
{
    Prompt = prompt, // The prompt is the text that the model will use to generate the completion
    Model = Models.TextDavinciV2, // See https://beta.openai.com/docs/api-reference/models for more models
    Temperature = 0.5F, // 0.0 - 1.0
    MaxTokens = 5 // Max 2048 tokens
});

if (completionResult.Successful)
{
    foreach (var choice in completionResult.Choices)
    {
        Console.WriteLine(choice.Text);
    }
}
else
{
    if (completionResult.Error == null)
    {
        throw new Exception("Unknown Error");
    }

    Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
}