using System.Collections;
using System.Windows.Controls;
using PW3.Shapes;

namespace PW3;

public class CanvasWrapper : IList<Shape>
{
    private readonly List<Shape> _shapes = new();
    
    public CanvasWrapper(Canvas canvas) {
        Canvas = canvas;
    }
    
    public Canvas Canvas { get; } 
    
    public void Draw() {
        Canvas.Children.Clear();
        foreach (var shape in _shapes) {
            shape.Draw(Canvas);
        }
    }
    
    public Shape this[int index]
    {
        get => _shapes[index];
        set
        {
            _shapes[index] = value;
            Draw();
        }
    }

    public int Count => _shapes.Count;

    public bool IsReadOnly => false;

    public void Add(Shape item)
    {
        _shapes.Add(item);
        Draw();
    }

    public void Clear()
    {
        _shapes.Clear();
        Draw();
    }

    public bool Contains(Shape item) => _shapes.Contains(item);

    public void CopyTo(Shape[] array, int arrayIndex) => _shapes.CopyTo(array, arrayIndex);

    public IEnumerator<Shape> GetEnumerator() => _shapes.GetEnumerator();

    public int IndexOf(Shape item) => _shapes.IndexOf(item);

    public void Insert(int index, Shape item)
    {
        _shapes.Insert(index, item);
        Draw();
    }

    public bool Remove(Shape item)
    {
        var r = _shapes.Remove(item);
        Draw();
        return r;
    }

    public void RemoveAt(int index)
    {
        _shapes.RemoveAt(index);
        Draw();
    }

    IEnumerator IEnumerable.GetEnumerator() => _shapes.GetEnumerator();
}