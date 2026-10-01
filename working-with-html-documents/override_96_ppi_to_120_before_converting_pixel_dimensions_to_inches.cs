// Override the default 96 PPI value to 120 before converting pixel dimensions to inches.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Example 1: Pixels to inches and Length
            double pixels = 192.0;
            const double ppi = 96.0;
            double inches = pixels / ppi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Pixels: {{ {pixels} }}, PPI: {{ {ppi} }}, Inches: {{ {inches:F4} }}");
            Console.WriteLine($"Length from inches: {length}");

            // Example 2: Pixels to millimeters
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Example 3: Width and height pixels to inches
            double widthPixels = 800;
            double heightPixels = 600;
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;
            Console.WriteLine($"Width in inches: {{ {widthInches:F4} }}");
            Console.WriteLine($"Height in inches: {{ {heightInches:F4} }}");

            // Example 4: Pixel count to inches
            double pixelCount = 384;
            double inchesFromCount = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inchesFromCount:F4} }}");

            // Example 5: Comprehensive conversions
            double wPixels = 1024;
            double hPixels = 768;
            double wInches = wPixels / ppi;
            double hInches = hPixels / ppi;
            double wCentimeters = wInches * 2.54;
            double hCentimeters = hInches * 2.54;
            double wMillimeters = wCentimeters * 10.0;
            double hMillimeters = hCentimeters * 10.0;
            double wPoints = wInches * 72.0;
            double hPoints = hInches * 72.0;
            double wPicas = wInches * 6.0;
            double hPicas = hInches * 6.0;

            Console.WriteLine($"Width: {wInches:F4} in, {wCentimeters:F4} cm, {wMillimeters:F2} mm, {wPoints:F2} pt, {wPicas:F2} pc");
            Console.WriteLine($"Height: {hInches:F4} in, {hCentimeters:F4} cm, {hMillimeters:F2} mm, {hPoints:F2} pt, {hPicas:F2} pc");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}