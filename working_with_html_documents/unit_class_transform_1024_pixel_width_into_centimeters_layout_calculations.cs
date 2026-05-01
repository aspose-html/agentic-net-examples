// Use the Unit class to transform 1024 pixel width into centimeters for layout calculations.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel width to convert
            double pixels = 1024;

            // Convert pixels to centimeters (96 pixels = 1 inch, 1 inch = 2.54 cm)
            double centimeters = pixels / 96.0 * 2.54;

            // Output the result
            Console.WriteLine($"Width: {pixels} px = {centimeters:F2} cm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}