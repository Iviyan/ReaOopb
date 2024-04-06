using System.Windows.Controls;

namespace PW3.Shapes;

public class Rectangle : Shape2O
{
    public override void Draw(Canvas canvas)
    {
        System.Windows.Shapes.Rectangle rect = new();
        Configure(rect);
        canvas.Children.Add(rect);
    }
}