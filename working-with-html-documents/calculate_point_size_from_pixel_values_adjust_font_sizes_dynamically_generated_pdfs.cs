// Calculate point size from pixel values to adjust font sizes dynamically in generated PDFs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value for font size
            double pixelValue = 16.0;

            // Pixels per inch (standard)
            const double ppi = 96.0;

            // Convert pixels to inches
            double inches = pixelValue / ppi;

            // Convert inches to points (1 inch = 72 points)
            double points = inches * 72.0;

            System.Console.WriteLine($"Pixel value: {pixelValue} px");
            System.Console.WriteLine($"Equivalent point size: {points:F2} pt");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}