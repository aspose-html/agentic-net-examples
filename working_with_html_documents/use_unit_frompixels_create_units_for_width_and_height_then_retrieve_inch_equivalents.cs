// Use Unit.FromPixels to create units for both width and height, then retrieve their inch equivalents.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;

            // Create Length objects from pixel values
            Length widthLength = Unit.FromPixels(widthPixels);
            Length heightLength = Unit.FromPixels(heightPixels);

            // Retrieve the equivalent values in inches
            double widthInches = widthLength.GetValue(UnitType.In);
            double heightInches = heightLength.GetValue(UnitType.In);

            // Output the results
            Console.WriteLine($"Width in inches: {widthInches:F4}");
            Console.WriteLine($"Height in inches: {heightInches:F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}