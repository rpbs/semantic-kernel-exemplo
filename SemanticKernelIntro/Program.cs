using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SemanticKernelIntro.Components;

var builder = WebApplication.CreateBuilder(args);

// Populate values from your OpenAI deployment
//builder.Services.AddOpenApi();

var kernelBuilder = Kernel.CreateBuilder();
var modelId = "llama3.2";
var endpoint = new Uri("http://localhost:11434");

#pragma warning disable SKEXP0070

kernelBuilder.Services.AddOllamaChatCompletion(modelId, endpoint);
kernelBuilder.Plugins.AddFromType<BookingPlugin>();

#pragma warning restore SKEXP0070

var kernel = kernelBuilder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

#pragma warning disable SKEXP0070
var settings = new OllamaPromptExecutionSettings { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };
#pragma warning restore SKEXP0070








// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton(kernel);
builder.Services.AddSingleton(chatCompletionService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();