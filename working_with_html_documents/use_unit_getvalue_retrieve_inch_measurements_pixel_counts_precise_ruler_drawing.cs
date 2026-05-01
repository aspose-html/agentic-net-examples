// Use Unit.GetValue to retrieve inch measurements from pixel counts for precise ruler drawing.

using System;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double pixelCount = 192;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}