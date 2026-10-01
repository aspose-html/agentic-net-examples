// Set PixelsPerInch to 96 for default conversion, then temporarily change to 144 for specific tasks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeter conversion
            double pixels = 200.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Width and height conversion
            double widthPixels = 800.0;
            double heightPixels = 600.0;
            double widthMillimeters = widthPixels / 96.0 * 25.4;
            double heightMillimeters = heightPixels / 96.0 * 25.4;
            Console.WriteLine($"Width: {{ {widthMillimeters:F2} }} mm");
            Console.WriteLine($"Height: {{ {heightMillimeters:F2} }} mm");

            // Pixels to inches using Aspose.Html.Drawing.Length
            double pixels2 = 300.0;
            double ppi2 = 96.0;
            double inches = pixels2 / ppi2;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Pixels: {{ {pixels2} }}, PPI: {{ {ppi2} }}, Inches: {{ {inches:F4} }}");

            // Pixels to centimeters
            double pixels3 = 150.0;
            double centimeters = pixels3 / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {{ {centimeters:F2} }}");

            // Pixel count to inches
            double pixelCount = 1024.0;
            double inches2 = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches2:F4} }}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}