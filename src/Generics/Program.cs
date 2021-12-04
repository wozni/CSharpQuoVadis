#pragma warning disable ASP0000

IServiceCollection services = new ServiceCollection();
services.AddTransient(typeof(IProcessor<>), typeof(GenericProcessor<>));
services.AddTransient(typeof(IProcessor<string>), typeof(StringProcessor));
var locator = services.BuildServiceProvider();


var intProcessor = locator.GetRequiredService<IProcessor<int>>();
var stringProcessor = locator.GetRequiredService<IProcessor<string>>();

intProcessor.Process(12);
stringProcessor.Process("Hello");


interface IProcessor<in TRequest>
{
    void Process(TRequest request);
}

public class StringProcessor : IProcessor<string>
{
    public void Process(string request)
    {
        Console.WriteLine($"String handler: processing {request}");
    }
}

public class GenericProcessor<TRequest> : IProcessor<TRequest>
{
    public void Process(TRequest request)
    {
        Console.WriteLine($"Generic handler: processing {request}");
    }
}
