// Use Unit.GetValue to obtain centimeter values from pixel counts for CSS media queries.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Example pixel count from a CSS media query
            double pixelCount = 300.0;

            // Create a Length object representing the pixel value
            var length = Unit.FromPixels(pixelCount);

            // Retrieve the value in centimeters using GetValue with UnitType.Cm
            double centimeters = length.GetValue(UnitType.Cm);

            Console.WriteLine($"Pixel count: {pixelCount} => Centimeters: {centimeters:F2} cm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}