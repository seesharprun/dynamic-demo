using Microsoft.Samples.AsyncTask.Models.Interfaces;

namespace Microsoft.Samples.AsyncTask.Models;

public record Employee : IPerson
{
    public string Id { get; init; } = String.Empty;
    public string Name { get; init; } = String.Empty;
    public string Email { get; init; } = String.Empty;
}