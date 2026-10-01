// Use Unit.GetValue to obtain inch measurements from pixel counts for margin calculations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Example pixel count conversion to inches
            double pixelCount = 1920;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches:F4} }}");

            // Example pixel to millimeters conversion
            double pixels = 300;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Predefined pixel values for width and height
            double widthPixels = 800;
            double heightPixels = 600;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // Output results
            Console.WriteLine($"Width: {{ {widthPixels} }} px = {{ {widthInches:F4} }} in = {{ {widthCentimeters:F2} }} cm = {{ {widthMillimeters:F1} }} mm = {{ {widthPoints:F1} }} pt = {{ {widthPicas:F2} }} pc");
            Console.WriteLine($"Height: {{ {heightPixels} }} px = {{ {heightInches:F4} }} in = {{ {heightCentimeters:F2} }} cm = {{ {heightMillimeters:F1} }} mm = {{ {heightPoints:F1} }} pt = {{ {heightPicas:F2} }} pc");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}