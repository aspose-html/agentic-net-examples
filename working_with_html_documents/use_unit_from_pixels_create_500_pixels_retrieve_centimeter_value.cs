// Use Unit.FromPixels to create a unit from 500 pixels and retrieve its centimeter value.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 500;
            var length = Unit.FromPixels(pixels);
            const double ppi = 96.0;
            double centimeters = (pixels / ppi) * 2.54;
            Console.WriteLine($"Pixels: {pixels} = {centimeters:F2} cm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}