namespace Microsoft.Samples.AsyncTask.Services.Interfaces;

public interface IGeneratorService<T>
{
    T Generate();
    IEnumerable<T> GenerateMany(int count);
}