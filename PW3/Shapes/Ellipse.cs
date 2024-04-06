using System.Windows.Controls;

namespace PW3.Shapes;

public class Ellipse : Shape2O
{
    public override void Draw(Canvas canvas)
    {
        System.Windows.Shapes.Ellipse ellipse = new();
        Configure(ellipse);
        canvas.Children.Add(ellipse);
    }
}