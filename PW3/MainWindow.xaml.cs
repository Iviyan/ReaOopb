using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using S = PW3.Shapes;
using SWS = System.Windows.Shapes;

namespace PW3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CanvasWrapper _canvas;

    public MainWindow()
    {
        InitializeComponent();
        _canvas = new(Canvas);
    }

    private void CommandTbOnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e is not { Key: Key.Enter, IsDown: true }) return;

        string command = CommandTb.Text;
        switch (command)
        {
            case "clear":
            {
                _canvas.Clear();
                break;
            }
            case [ 'r', ' ', .. { } s ] when int.TryParse(s, out int index):
            {
                if (index < 0 || index >= _canvas.Count) break;
                _canvas.RemoveAt(index);
                break;
            }
            case "test":
            {
                _ = Test();
                break;
            }
            case "rect":
            {
                S.Rectangle rect = new()
                {
                    Point1 = new(10, 10), Point2 = new(100, 100),
                    Color = Brushes.Red, Filled = false,
                };
                _canvas.Add(rect);
                break;
            }
            case "line":
            {
                S.Line line = new()
                {
                    Point1 = new(10, 10), Point2 = new(100, 100),
                    Color = Brushes.Blue, StrokeThickness = 5
                };
                _canvas.Add(line);
                break;
            }
        }
    }

    private async Task Test()
    {
        S.Shape[] shapes =
        [
            new S.Point { Position = new(100, 10), Color = Brushes.Red, Size = 10 },
            new S.Line { Point1 = new(10, 10), Point2 = new(100, 100), Color = Brushes.Blue, StrokeThickness = 5 },
            new S.Ellipse { Point1 = new(10, 10), Point2 = new(100, 100), Color = Brushes.Green, Filled = false },
            new S.Ellipse { Point1 = new(20, 20), Point2 = new(80, 80), Color = Brushes.Green, Filled = true },
            new S.Rectangle { Point1 = new(10, 10), Point2 = new(100, 100), Color = Brushes.Red, Filled = false },
            new S.Rectangle { Point1 = new(20, 20), Point2 = new(80, 80), Color = Brushes.Red, Filled = true },
            new S.Polygon
            {
                Filled = false, Color = Brushes.Chocolate, StrokeThickness = 5,
                Points = S.Polygon.Hexagon(new(10, 10), 200)
            },
            new S.Polygon
            {
                Filled = true, Color = Brushes.Lime, StrokeThickness = 5,
                Points = S.Polygon.Hexagon(new(50, 50), 100)
            }
        ];

        Dispatcher.Invoke(() => _canvas.Clear());
        foreach (var shape in shapes)
        {
            Dispatcher.Invoke(() => _canvas.Add(shape));
            await Task.Delay(1000);
        }
    }
}