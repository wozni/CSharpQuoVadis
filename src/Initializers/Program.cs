// See https://aka.ms/new-console-template for more information

// IEnumerable<string>
// public void Add(string)

using System.Collections;

var names = new List<string>
{
    "Marcin",
    "Leszek"
};


var blog = new Blog()
{
    Title = "Nowy blog",
    Posts =
    {
        "Post 1",
        "Post 2"
    }
};






public class Blog
{
    public string Title { get; init; }

    public Posts Posts { get; } = new ();

}



public class Posts : IEnumerable<string>
{

    public IEnumerator<string> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(string post)
    {
    }

}






