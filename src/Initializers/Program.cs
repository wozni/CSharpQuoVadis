// See https://aka.ms/new-console-template for more information

using System.Collections;
var names = new List<string>
{
    "Marcin",
    "Leszek"
};

var blog = new Blog
{
    Title = "Przykładowy blog",
    Posts =
    {
        "Post 1",
        "Post 2"
    }
};


public class Blog
{
    public Posts Posts { get;  } = new Posts();
    public string Title { get; init; }
}

public class Posts : IEnumerable<string>
{
    public void Add(string item)
    {

    }

    public string Title { get; set; }

    public IEnumerator<string> GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
