using Microsoft.Samples.AsyncTask.Models.Interfaces;

namespace Microsoft.Samples.AsyncTask.Models.Events;

public record Loading : IEvent
{
    public string? Message { get; init; }

    public bool Show { get; init; }
}