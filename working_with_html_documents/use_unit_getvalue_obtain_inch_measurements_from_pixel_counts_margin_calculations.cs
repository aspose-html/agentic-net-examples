// Use Unit.GetValue to obtain inch measurements from pixel counts for margin calculations.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                double pixelCount = 300;
                double inches = pixelCount / 96.0;
                Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}