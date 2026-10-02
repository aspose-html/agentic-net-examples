// Use Unit.GetValue to obtain inch measurements from pixel counts for margin calculations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Example pixel count for margin
            double pixelCount = 192.0;

            // Convert pixels to inches (96 pixels per inch)
            double inches = pixelCount / 96.0;

            // Convert inches to points (1 inch = 72 points) for typical PDF margin usage
            double marginPoints = inches * 72.0;

            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");
            Console.WriteLine($"Margin in points: {marginPoints:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}