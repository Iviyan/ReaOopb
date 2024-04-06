using System.Windows.Controls;
using System.Windows.Media;
using SW = System.Windows;
using SWS = System.Windows.Shapes;

namespace PW3.Shapes;

public abstract class Shape
{
    public Brush Color { get; set; } = null!;

    public abstract void Draw(Canvas canvas);
    
    protected virtual void Configure(SWS.Shape shape)
    {
        shape.Fill = Color;
    }
}

public abstract class Shape2 : Shape
{
    public SW.Point Point1 { get; set; }
    public SW.Point Point2 { get; set; }

    protected void SetPosition(SWS.Shape shape, SW.Point point1, SW.Point point2)
    {
        Canvas.SetTop(shape, point1.Y);
        Canvas.SetLeft(shape, point1.X);
        shape.Width = point2.X - point1.X;
        shape.Height = point2.Y - point1.Y;
        
        // This should work, or so I thought...
        Canvas.SetRight(shape, point2.X);
        Canvas.SetBottom(shape, point2.Y);
    }
    
    protected override void Configure(SWS.Shape shape)
    {
        SetPosition(shape, Point1, Point2);
        shape.Fill = Color;
    }
}

public abstract class Shape2O : Shape2
{
    public bool Filled { get; set; } = false;
    
    protected override void Configure(SWS.Shape shape)
    {
        SetPosition(shape, Point1, Point2);
        if (Filled) shape.Fill = Color;
        else shape.Stroke = Color;
    }
}