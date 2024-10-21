using System.Net.Mail;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Samples.AsyncTask.Models.Events;
using Microsoft.Samples.AsyncTask.Services.Interfaces;

namespace Microsoft.Samples.AsyncTask.Services;

public class PersonProcessorService(ILogger<PersonProcessorService> logger, IEventAggregatorService eventAggregator) : IHostedService
{
    public Task StartAsync(CancellationToken _)
    {
        logger.LogInformation("Processor service is starting...");
        eventAggregator.Subscribe<CreatedPerson>(OnPersonCreatedAsync);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken _)
    {
        logger.LogInformation("Processor service is stopping...");
        eventAggregator.Unsubscribe<CreatedPerson>(OnPersonCreatedAsync);
        return Task.CompletedTask;
    }

    private async Task OnPersonCreatedAsync(CreatedPerson payload)
    {
        logger.LogInformation("Person being processed...");
        await Task.Delay(TimeSpan.FromSeconds(5));
        string message = payload.Person is not null ? $"{payload.Person?.Name ?? "Person"} processed in the background." : "Person processed in the background.";
        await eventAggregator.PublishAsync<Notification>(new Notification { Message = message });
    }
}