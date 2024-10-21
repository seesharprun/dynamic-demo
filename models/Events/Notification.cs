using Microsoft.Samples.AsyncTask.Models.Interfaces;

namespace Microsoft.Samples.AsyncTask.Models.Events;

public record Notification : IEvent
{
    public string Title { get; init; } = "Background notification";

    public required string Message { get; init; }
}