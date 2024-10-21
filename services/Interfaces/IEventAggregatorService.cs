using Microsoft.Samples.AsyncTask.Models.Interfaces;

namespace Microsoft.Samples.AsyncTask.Services.Interfaces;

public interface IEventAggregatorService
{
    void Subscribe<T>(Func<T, Task> handler) where T : IEvent;

    void Subscribe<T>(Action<T> handler) where T : IEvent;

    void Unsubscribe<T>(Func<T, Task> handler) where T : IEvent;

    void Unsubscribe<T>(Action<T> handler) where T : IEvent;

    Task PublishAsync<T>(T payload) where T : IEvent;
}