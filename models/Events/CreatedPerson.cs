using Microsoft.Samples.AsyncTask.Models.Interfaces;

namespace Microsoft.Samples.AsyncTask.Models.Events;

public record CreatedPerson : IEvent
{
    public IPerson? Person { get; init; }
}