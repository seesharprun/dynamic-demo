using Microsoft.Samples.AsyncTask.Models;
using Microsoft.Samples.AsyncTask.Services;
using Microsoft.Samples.AsyncTask.Services.Interfaces;
using Microsoft.Samples.AsyncTask.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents().AddInteractiveServerComponents(options => options.DetailedErrors = true);

builder.Services.AddScoped<IGeneratorService<Employee>, EmployeeGeneratorService>();
builder.Services.AddSingleton<IEventAggregatorService, EventAggregatorService>();

builder.Services.AddHostedService<PersonProcessorService>();

var app = builder.Build();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
