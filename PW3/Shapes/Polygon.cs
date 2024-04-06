using System.Windows.Controls;

namespace PW3.Shapes;

public class Polygon : Shape
{
    public System.Windows.Point[] Points { get; set; } = [ ];

    public bool Filled { get; set; } = false;
    public double StrokeThickness { get; set; } = 1;

    public override void Draw(Canvas canvas)
    {
        System.Windows.Shapes.Polygon polygon = new() { Points = new(Points) };
        
        if (Filled)
        {
            polygon.Fill = Color;
        }
        else
        {
            polygon.Stroke = Color;
            polygon.StrokeThickness = StrokeThickness;
        }

        canvas.Children.Add(polygon);
    }

    public static System.Windows.Point[] Hexagon(System.Windows.Point start, double size)
    {
        double r = size / 2;
        double x0 = start.X + r;
        double y0 = start.Y + r;

        var points = new System.Windows.Point[6];

        for (int i = 0; i < 6; i++)
        {
            points[i] = new(
                x0 + r * (float)Math.Cos(i * 60 * Math.PI / 180f),
                y0 + r * (float)Math.Sin(i * 60 * Math.PI / 180f));
        }

        return points;
    }
}