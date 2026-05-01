// Use Unit.GetValue to retrieve point values from pixel counts for precise typographic scaling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Example pixel count to be converted
            double pixelCount = 150.0;

            // Convert pixels to points.
            // 1 inch = 96 pixels, 1 inch = 72 points => 1 point = 96/72 pixels
            double points = pixelCount * 72.0 / 96.0;

            Console.WriteLine($"Pixel count: {pixelCount} => {points:F2} points");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}