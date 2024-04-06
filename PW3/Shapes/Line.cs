using System.Windows.Controls;

namespace PW3.Shapes;

public class Line : Shape2
{
    public double StrokeThickness { get; set; } = 1;

    public override void Draw(Canvas canvas)
    {
        System.Windows.Shapes.Line line = new()
        {
            X1 = Point1.X, Y1 = Point1.Y, X2 = Point2.X, Y2 = Point2.Y,
            StrokeThickness = StrokeThickness,
            Stroke = Color
        };
        canvas.Children.Add(line);
    }
}