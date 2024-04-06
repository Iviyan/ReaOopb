using System.Windows.Controls;

namespace PW3.Shapes;

public class Point : Shape
{
    public System.Windows.Point Position { get; set; }
    
    public double Size { get; set; } = 1;

    public override void Draw(Canvas canvas)
    {
        double x = Position.X - Size / 2;
        double y = Position.Y - Size / 2;
        System.Windows.Shapes.Ellipse point = new()
        {
            Fill = Color,
            Width = Size, Height = Size
        };
        Canvas.SetTop(point, y);
        Canvas.SetLeft(point, x);
        
        canvas.Children.Add(point);
    }
}