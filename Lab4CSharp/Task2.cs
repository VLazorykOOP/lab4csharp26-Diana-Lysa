using System;

public class VectorInt
{
    protected int[] IntArray;
    protected uint size;
    protected int codeError;
    protected static uint num_vec = 0;

    //  КОНСТРУКТОРИ 

    public VectorInt()
    {
        size = 1;
        IntArray = new int[1] { 0 };
        codeError = 0;
        num_vec++;
    }

    public VectorInt(uint size)
    {
        this.size = size;
        IntArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = 0;
        }
        codeError = 0;
        num_vec++;
    }

    public VectorInt(uint size, int value)
    {
        this.size = size;
        IntArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
        codeError = 0;
        num_vec++;
    }

    // Деструктор
    ~VectorInt()
    {
        Console.WriteLine("Об'єкт VectorInt видалено");
    }

    //  МЕТОДИ ТА ВЛАСТИВОСТІ 

    public void Input()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введіть елемент [{i}]: ");
            IntArray[i] = int.Parse(Console.ReadLine()!);
        }
    }

    public void Display()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(IntArray[i] + " ");
        }
        Console.WriteLine();
    }

    public void AssignValue(int value)
    {
        for (int i = 0; i < size; i++)
        {
            IntArray[i] = value;
        }
    }

    public static uint GetNumVec()
    {
        return num_vec;
    }

    public uint Size
    {
        get { return size; }
    }

    public int CodeError
    {
        get { return codeError; }
        set { codeError = value; }
    }

    // Індексатор
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
            {
                codeError = -1;
                return 0;
            }
            return IntArray[index];
        }
        set
        {
            if (index < 0 || index >= size)
            {
                codeError = -1;
            }
            else
            {
                IntArray[index] = value;
            }
        }
    }

    //  УНАРНІ ОПЕРАЦІЇ 

    public static VectorInt operator ++(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
            v.IntArray[i]++;
        return v;
    }

    public static VectorInt operator --(VectorInt v)
    {
        for (int i = 0; i < v.size; i++)
            v.IntArray[i]--;
        return v;
    }

    public static bool operator true(VectorInt v)
    {
        if (v.size != 0) return true;
        foreach (int x in v.IntArray)
            if (x != 0) return true;
        return false;
    }

    public static bool operator false(VectorInt v)
    {
        if (v.size == 0) return true;
        foreach (int x in v.IntArray)
            if (x != 0) return false;
        return true;
    }

    public static bool operator !(VectorInt v)
    {
        return v.size != 0;
    }

    public static VectorInt operator ~(VectorInt v)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = ~v.IntArray[i];
        return res;
    }

    private static VectorInt OpBase(VectorInt v1, VectorInt v2, out uint minLen)
    {
        uint max = Math.Max(v1.size, v2.size);
        minLen = Math.Min(v1.size, v2.size);
        VectorInt res = new VectorInt(max);
        VectorInt longer = (v1.size >= v2.size) ? v1 : v2;
        for (int i = 0; i < max; i++)
        {
            res.IntArray[i] = longer.IntArray[i];
        }
        return res;
    }

    // АРИФМЕТИЧНІ БІНАРНІ ОПЕРАЦІЇ

    // Додавання
    public static VectorInt operator +(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
            res.IntArray[i] = v1.IntArray[i] + v2.IntArray[i];
        return res;
    }

    public static VectorInt operator +(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] + s;
        return res;
    }

    // Віднімання
    public static VectorInt operator -(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
            res.IntArray[i] = v1.IntArray[i] - v2.IntArray[i];
        return res;
    }

    public static VectorInt operator -(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] - s;
        return res;
    }

    // Множення
    public static VectorInt operator *(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
            res.IntArray[i] = v1.IntArray[i] * v2.IntArray[i];
        return res;
    }

    public static VectorInt operator *(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] * s;
        return res;
    }

    // Ділення
    public static VectorInt operator /(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
        {
            if (v2.IntArray[i] != 0)
                res.IntArray[i] = v1.IntArray[i] / v2.IntArray[i];
        }
        return res;
    }

    public static VectorInt operator /(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        if (s != 0)
        {
            for (int i = 0; i < v.size; i++)
                res.IntArray[i] = v.IntArray[i] / s;
        }
        return res;
    }

    // Остача від ділення
    public static VectorInt operator %(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
        {
            if (v2.IntArray[i] != 0)
                res.IntArray[i] = v1.IntArray[i] % v2.IntArray[i];
        }
        return res;
    }

    public static VectorInt operator %(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        if (s != 0)
        {
            for (int i = 0; i < v.size; i++)
                res.IntArray[i] = v.IntArray[i] % s;
        }
        return res;
    }

    // --- ПОБІТОВІ БІНАРНІ ОПЕРАЦІЇ ---

    public static VectorInt operator |(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
            res.IntArray[i] = v1.IntArray[i] | v2.IntArray[i];
        return res;
    }

    public static VectorInt operator |(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] | s;
        return res;
    }

    public static VectorInt operator &(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
            res.IntArray[i] = v1.IntArray[i] & v2.IntArray[i];
        return res;
    }

    public static VectorInt operator &(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] & s;
        return res;
    }

    public static VectorInt operator ^(VectorInt v1, VectorInt v2)
    {
        VectorInt res = OpBase(v1, v2, out uint m);
        for (int i = 0; i < m; i++)
            res.IntArray[i] = v1.IntArray[i] ^ v2.IntArray[i];
        return res;
    }

    public static VectorInt operator ^(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] ^ s;
        return res;
    }

    public static VectorInt operator <<(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] << s;
        return res;
    }

    public static VectorInt operator >>(VectorInt v, int s)
    {
        VectorInt res = new VectorInt(v.size);
        for (int i = 0; i < v.size; i++)
            res.IntArray[i] = v.IntArray[i] >> s;
        return res;
    }

    // --- ПОРІВНЯННЯ ---

    public static bool operator ==(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size) return false;
        for (int i = 0; i < v1.size; i++)
        {
            if (v1.IntArray[i] != v2.IntArray[i]) return false;
        }
        return true;
    }

    public static bool operator !=(VectorInt v1, VectorInt v2)
    {
        return !(v1 == v2);
    }

    public static bool operator >(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size) return false;
        for (int i = 0; i < v1.size; i++)
        {
            if (!(v1.IntArray[i] > v2.IntArray[i])) return false;
        }
        return true;
    }

    public static bool operator <(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size) return false;
        for (int i = 0; i < v1.size; i++)
        {
            if (!(v1.IntArray[i] < v2.IntArray[i])) return false;
        }
        return true;
    }

    public static bool operator >=(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size) return false;
        for (int i = 0; i < v1.size; i++)
        {
            if (!(v1.IntArray[i] >= v2.IntArray[i])) return false;
        }
        return true;
    }

    public static bool operator <=(VectorInt v1, VectorInt v2)
    {
        if (v1.size != v2.size) return false;
        for (int i = 0; i < v1.size; i++)
        {
            if (!(v1.IntArray[i] <= v2.IntArray[i])) return false;
        }
        return true;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}