using Bogus;
using Microsoft.Samples.AsyncTask.Models;
using Microsoft.Samples.AsyncTask.Services.Interfaces;

namespace Microsoft.Samples.AsyncTask.Services;

public class EmployeeGeneratorService : IGeneratorService<Employee>
{
    private readonly Faker<Employee> faker = new Faker<Employee>()
        .StrictMode(true)
        .RuleFor(e => e.Id, f => $"{f.Random.Guid()}")
        .RuleFor(e => e.Name, f => f.Person.FullName)
        .RuleFor(e => e.Email, f => f.Person.Email);

    public Employee Generate()
    {
        return faker.Generate();
    }

    public IEnumerable<Employee> GenerateMany(int count = 5)
    {
        return faker.Generate(count);
    }
}
