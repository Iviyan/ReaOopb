﻿using System.Globalization;

namespace Utils;

public static class Utils
{
    public static string ReadString(string text)
    {
        Console.Write(text);
        return Console.ReadLine() ?? string.Empty;
    }

    public static T ReadValue<T>(string text) where T : IParsable<T>
    {
        while (true)
        {
            Console.Write(text);
            string input = Console.ReadLine() ?? string.Empty;
            if (T.TryParse(input, CultureInfo.CurrentCulture, out var value)) return value;
            Console.WriteLine("Invalid input.");
        }
    }

    public static T ReadValue<T>(string text, Func<T, string?> validate) where T : IParsable<T>
    {
        while (true)
        {
            Console.Write(text);
            string input = Console.ReadLine() ?? string.Empty;
            if (T.TryParse(input, CultureInfo.CurrentCulture, out var value))
            {
                if (validate(value) is not { } error) return value;
                Console.WriteLine(error);
                continue;
            }

            Console.WriteLine("Invalid input.");
        }
    }
}