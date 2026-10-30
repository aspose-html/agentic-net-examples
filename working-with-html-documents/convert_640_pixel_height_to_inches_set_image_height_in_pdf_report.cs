// Convert 640 pixel height to inches and use the value to set image height in a PDF report.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeters conversion
            double pixels = 200.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Width and height conversion to millimeters
            double widthPixels = 800.0;
            double heightPixels = 600.0;
            double widthMillimeters = widthPixels / 96.0 * 25.4;
            double heightMillimeters = heightPixels / 96.0 * 25.4;
            Console.WriteLine($"Width: {{ {widthMillimeters:F2} }} mm");
            Console.WriteLine($"Height: {{ {heightMillimeters:F2} }} mm");

            // Pixel count to inches conversion
            double pixelCount = 1024.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches:F4} }}");

            // Width and height conversion to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;
            Console.WriteLine($"Width in inches: {{ {widthInches:F4} }}");
            Console.WriteLine($"Height in inches: {{ {heightInches:F4} }}");

            // Length creation from inches using Aspose.Html.Drawing.Length
            double customPixels = 300.0;
            double customPpi = 120.0;
            double customInches = customPixels / customPpi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(customInches);
            Console.WriteLine($"Pixels: {{ {customPixels} }}, PPI: {{ {customPpi} }}, Inches: {{ {customInches:F4} }}, Length object created.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}