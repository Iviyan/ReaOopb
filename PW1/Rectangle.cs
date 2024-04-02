namespace PW1;

public readonly struct Rectangle
{
    public Rectangle(double length, double width)
    {
        if (length <= 0) throw new ArgumentException("The length must be > 0.", nameof(length));
        if (width <= 0) throw new ArgumentException("The width must be > 0.", nameof(width));
        
        Length = length;
        Width = width;
    }
    
    public double Length { get; }
    public double Width { get; }

    public double Area => Length * Width;
}

/*public class Rectangle
{
public Rectangle(double length, double width)
{
    Length = length;
    Width = width;
}

public double Length { get; set; }
public double Width { get; set; }

public double Area => Length * Width;
}*/