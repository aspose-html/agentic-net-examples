// Create a console application that accepts pixel values and outputs all unit conversions in JSON.

using System;

public class Program
{
    public static void Main(string[] args)
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
                inches = System.Math.Round(inches, 4),
                points = System.Math.Round(points, 4),
                centimeters = System.Math.Round(centimeters, 4),
                millimeters = System.Math.Round(millimeters, 4)
            };

            string json = System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            System.Console.WriteLine(json);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}