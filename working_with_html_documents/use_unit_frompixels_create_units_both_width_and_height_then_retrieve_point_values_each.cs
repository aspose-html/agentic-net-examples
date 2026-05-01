// Use Unit.FromPixels to create units for both width and height, then retrieve point values for each.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 200;
            double heightPixels = 100;

            // Create Length objects from pixel values
            var widthUnit = Unit.FromPixels(widthPixels);
            var heightUnit = Unit.FromPixels(heightPixels);

            // Convert pixels to points (1 inch = 96 px, 1 inch = 72 pt)
            const double ppi = 96.0;
            double widthPoints = (widthPixels / ppi) * 72.0;
            double heightPoints = (heightPixels / ppi) * 72.0;

            // Output the point values
            Console.WriteLine($"Width in points: {widthPoints}");
            Console.WriteLine($"Height in points: {heightPoints}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}