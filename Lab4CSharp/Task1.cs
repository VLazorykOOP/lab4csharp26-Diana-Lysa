using System;

public class Point
{
    protected int x, y, c;

    public Point() { x = 0; y = 0; c = 0; }
    public Point(int x, int y, int c)
    {
        this.x = x; this.y = y; this.c = c;
    }

    public int X { get => x; set => x = value; }
    public int Y { get => y; set => y = value; }
    public int Color => c;

    // 1. Індексатори
    public int this[int index]
    {
        get
        {
            return index switch
            {
                0 => x,
                1 => y,
                2 => c,
                _ => throw new IndexOutOfRangeException("Помилка: Індекс має бути 0 (x), 1 (y) або 2 (color).")
            };
        }
        set
        {
            switch (index)
            {
                case 0: x = value; break;
                case 1: y = value; break;
                case 2: c = value; break;
                default: Console.WriteLine("Помилка: Неправильний індекс для запису!"); break;
            }
        }
    }

    // 2. Перевантаження ++ та --
    public static Point operator ++(Point p)
    {
        p.x++;
        p.y++;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x--;
        p.y--;
        return p;
    }

    // 3. Перевантаження true та false 
    public static bool operator true(Point p) => p.x == p.y;
    public static bool operator false(Point p) => p.x != p.y;

    // 4. Бінарний + 
    public static Point operator +(Point p, int scalar)
    {
        return new Point(p.x + scalar, p.y + scalar, p.c);
    }

    // 5. Перетворення типів 
    public static implicit operator string(Point p)
    {
        return $"{p.x};{p.y};{p.c}";
    }

    public static explicit operator Point(string s)
    {
        string[] parts = s.Split(';');
        if (parts.Length == 3 &&
            int.TryParse(parts[0], out int nx) &&
            int.TryParse(parts[1], out int ny) &&
            int.TryParse(parts[2], out int nc))
        {
            return new Point(nx, ny, nc);
        }
        return new Point(); 
    }

    public virtual void Display() =>
        Console.WriteLine($"Точка: ({x}, {y}), Колір ID: {c}, Відстань: {GetDistance():F2}");

    public double GetDistance() => Math.Sqrt(x * x + y * y);

    public void Move(int x1, int y1) { x += x1; y += y1; }
}
