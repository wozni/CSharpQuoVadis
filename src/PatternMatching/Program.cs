// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

Colors color = Colors.Black;
var mood = color switch
{
    Colors.Orange or Colors.Blue =>  "warm"
    _ => "undefined" // or whatever
}


string WaterState(int tempInFahrenheit) =>
    tempInFahrenheit switch
    {
        (> 32) and (< 212) => "liquid",
        < 32 => "solid",
        > 212 => "gas",
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
    };

decimal CalculateDiscount(Order order) =>
    order switch
    {
        ( > 10,  > 1000.00m) => 0.10m,
        ( > 5, > 50.00m) => 0.05m,
        Order { Cost: > 250.00m } => 0.02m,
        null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
        var someObject => 0m,
    };
public record Order(int Items, decimal Cost);

public enum Colors
{
    Red, Yellow, Orange, Blue, Black
}
