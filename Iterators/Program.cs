// See https://aka.ms/new-console-template for more information

// Program 1
// foreach (var item in new MyGenerator().GetItems())
// {
//     Console.WriteLine(item);
// }

using System.Collections;

using var iterator = new MyGenerator().GetItems().GetEnumerator();
while (iterator.MoveNext())
{
    iterator.Current.Execute();
}


class MyGenerator
{
    // Program 2
    public IEnumerable<IResult> GetItems()
    {
        yield return Write.ToConsole("1234");
        // yield return Send.Email(1234);
    }   
}

public interface IResult
{
    void Execute();
}

public static class Write
{
    public static IResult ToConsole(string content) => new ConsoleWriteResult
    {
        Content = content
    };
}

public class ConsoleWriteResult : IResult
{
    public string Content { get; set; }
    
    public void Execute() => Console.WriteLine(Content);
}

