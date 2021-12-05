// https://github.com/SergeyTeplyakov/EduAsync
// https://devblogs.microsoft.com/premier-developer/extending-the-async-methods-in-c/

using System.Runtime.CompilerServices;

var lazy = new Lazy<int>(() => 42);
var result = await lazy;
Console.WriteLine(result);


public readonly struct LazyAwaiter<T> : INotifyCompletion
{
    private readonly Lazy<T> lazy;

    public LazyAwaiter(Lazy<T> lazy) => this.lazy = lazy;

    public T GetResult() => lazy.Value;

    public bool IsCompleted => false;

    public void OnCompleted(Action continuation)
    {
    }
}

public static class LazyAwaiterExtensions
{
    public static LazyAwaiter<T> GetAwaiter<T>(this Lazy<T> lazy)
    {
        return new LazyAwaiter<T>(lazy);
    }
}
