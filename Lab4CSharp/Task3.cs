using System;
using System.Collections.Generic;

public struct VideoCassetteStruct
{
    public string Title;
    public string Director;
    public int Duration;
    public double Price;

    public VideoCassetteStruct(string t, string d, int dur, double p)
    {
        Title = t; Director = d; Duration = dur; Price = p;
    }
}

public record VideoCassetteRecord(string Title, string Director, int Duration, double Price);

public class Task3
{
    public static void Execute() 
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть граничну ціну (видалити дорожчі за): ");
        if (!double.TryParse(Console.ReadLine(), out double limitPrice)) limitPrice = 200;

        Console.WriteLine("\n ЕТАП 1: СТРУКТУРИ ");
        List<VideoCassetteStruct> structList = new List<VideoCassetteStruct>
        {
            new VideoCassetteStruct("Матриця", "Вачовські", 136, 150),
            new VideoCassetteStruct("Титанік", "Кемерон", 194, 300)
        };

        structList.RemoveAll(s => s.Price > limitPrice);

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Додавання нової касети (структура) {i}/3:");
            Console.Write("Назва: "); string t = Console.ReadLine() ?? "Без назви";
            Console.Write("Ціна: "); double.TryParse(Console.ReadLine(), out double p);
            structList.Add(new VideoCassetteStruct(t, "Режисер", 120, p));
        }

        Console.WriteLine("\nФІНАЛЬНИЙ СПИСОК (СТРУКТУРИ):");
        foreach (var s in structList)
            Console.WriteLine($"-> {s.Title} | Ціна: {s.Price} грн.");


        Console.WriteLine("\n ЕТАП 2: КОРТЕЖІ ");
        var tupleList = new List<(string Title, string Director, int Duration, double Price)>
        {
            ("Початок", "Нолан", 148, 250),
            ("Леон", "Бессон", 110, 100)
        };

        tupleList.RemoveAll(t => t.Price > limitPrice);

        for (int i = 1; i <= 3; i++)
        {
            tupleList.Add(($"Новий фільм (кортеж) {i}", "Режисер", 90, 100 + (i * 20)));
        }

        Console.WriteLine("\nФІНАЛЬНИЙ СПИСОК (КОРТЕЖІ):");
        foreach (var t in tupleList)
            Console.WriteLine($"-> {t.Title} | Ціна: {t.Price} грн.");


        Console.WriteLine("\n ЕТАП 3: ЗАПИСИ ");
        List<VideoCassetteRecord> recordList = new List<VideoCassetteRecord>
        {
            new VideoCassetteRecord("Інтерстеллар", "Нолан", 169, 180),
            new VideoCassetteRecord("Аватар", "Кемерон", 162, 400)
        };

        recordList.RemoveAll(r => r.Price > limitPrice);

        recordList.Add(new VideoCassetteRecord("Дюна", "Вільньов", 155, 190));
        recordList.Add(new VideoCassetteRecord("Бетмен", "Рівз", 176, 150));
        recordList.Add(new VideoCassetteRecord("Шрек", "Адамсон", 90, 80));

        Console.WriteLine("\nФІНАЛЬНИЙ СПИСОК (ЗАПИСИ):");
        foreach (var r in recordList)
            Console.WriteLine($"-> {r.Title} | Ціна: {r.Price} грн.");
    }
}