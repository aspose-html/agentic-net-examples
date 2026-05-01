// Use Unit.GetValue to obtain millimeter values from pixel counts for precise cut‑line placement.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Example pixel count for a cut‑line
            double pixels = 300.0;

            // Standard screen resolution: 96 pixels per inch
            const double ppi = 96.0;

            // Convert pixels to millimeters (1 inch = 25.4 mm)
            double millimeters = (pixels / ppi) * 25.4;

            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}