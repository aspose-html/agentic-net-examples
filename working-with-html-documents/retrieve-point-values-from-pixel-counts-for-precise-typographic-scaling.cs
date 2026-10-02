// Use Unit.GetValue to retrieve point values from pixel counts for precise typographic scaling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixelCount = 150.0;
            double points = pixelCount * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => {points:F2} points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}