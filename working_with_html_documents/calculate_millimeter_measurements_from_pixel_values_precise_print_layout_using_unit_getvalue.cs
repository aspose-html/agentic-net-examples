// Calculate millimeter measurements from pixel values for precise print layout using Unit.GetValue.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 300;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}