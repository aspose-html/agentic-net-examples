// Use Unit.GetValue to obtain millimeter values from pixel counts for precise cut‑line placement.

using System;

class Program
{
    static void Main()
    {
        try
        {
            const double ppi = 96.0;
            double[] pixelValues = { 100.0, 250.0, 500.0 };

            foreach (double pixels in pixelValues)
            {
                double millimeters = (pixels / ppi) * 25.4;
                Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}