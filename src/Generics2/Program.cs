// See https://aka.ms/new-console-template for more information

// contravariant: type parameters are used only as parameter types in the members of the interfaces
// contravariant: IComparer<Shape> jest generalizacją dla IComparer<Circle>
SortedSet<Circle> circles = new(new ShapeAreaComparer())
    { new Circle(3.2), new Circle(10), new Circle(.01) };

// covariant: type parameters are used only for the return types of the members.
// covariant: IEnumerable<Shape> jest generalizacją dla IEnumerable<Circle>
Print(circles);

void Print(IEnumerable<Shape> shapes)
{
    foreach (var shape in shapes)
    {
        Console.WriteLine($"{shape} with area {shape.Area}");
    }
}

public abstract class Shape
{
    public abstract double Area { get; }
}

public class Circle : Shape
{
    private double radius;

    public Circle(double radius) => this.radius = radius;

    public override double Area => Math.PI * radius * radius;
}

public class ShapeAreaComparer : IComparer<Shape>
{
    public int Compare(Shape? x, Shape? y)
    {
        if (x == null) return y == null ? 0 : -1;
        return x.Area.CompareTo(y.Area);
    }
}




