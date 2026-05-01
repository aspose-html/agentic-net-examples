// Create a console application that accepts pixel values and outputs all unit conversions in JSON.

using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            double pixels = 96.0;
            if (args.Length > 0 && double.TryParse(args[0], out double parsedPixels))
            {
                pixels = parsedPixels;
            }
            double inches = pixels / 96.0;
            double points = pixels * 72.0 / 96.0;
            double centimeters = inches * 2.54;
            double millimeters = centimeters * 10.0;
            var result = new
            {
                pixels = pixels,
                inches = Math.Round(inches, 4),
                points = Math.Round(points, 4),
                centimeters = Math.Round(centimeters, 4),
                millimeters = Math.Round(millimeters, 4)
            };
            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}