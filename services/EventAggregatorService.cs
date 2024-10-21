using Microsoft.Samples.AsyncTask.Models.Interfaces;
using Microsoft.Samples.AsyncTask.Services.Interfaces;

namespace Microsoft.Samples.AsyncTask.Services;

public class EventAggregatorService : IEventAggregatorService
{
    private readonly Dictionary<Type, List<Delegate>> _subscribers = new();

    public void Subscribe<T>(Func<T, Task> handler) where T : IEvent
    {
        if (!_subscribers.ContainsKey(typeof(T)))
        {
            _subscribers.Add(typeof(T), new List<Delegate>());
        }

        _subscribers[typeof(T)].Add(handler);
    }

    public void Subscribe<T>(Action<T> handler) where T : IEvent
    {
        if (!_subscribers.ContainsKey(typeof(T)))
        {
            _subscribers.Add(typeof(T), new List<Delegate>());
        }

        _subscribers[typeof(T)].Add(handler);
    }

    public void Unsubscribe<T>(Func<T, Task> handler) where T : IEvent
    {
        if (_subscribers.ContainsKey(typeof(T)))
        {
            _subscribers[typeof(T)].Remove(handler);
        }
    }

    public void Unsubscribe<T>(Action<T> handler) where T : IEvent
    {
        if (_subscribers.ContainsKey(typeof(T)))
        {
            _subscribers[typeof(T)].Remove(handler);
        }
    }

    public async Task PublishAsync<T>(T payload) where T : IEvent
    {
        if (_subscribers.ContainsKey(typeof(T)))
        {
            foreach (var handler in _subscribers[typeof(T)])
            {
                if (handler is Func<T, Task> asyncHandler)
                {
                    await asyncHandler(payload);
                }
                else if (handler is Action<T> syncHandler)
                {
                    syncHandler(payload);
                }
            }
        }
    }
}