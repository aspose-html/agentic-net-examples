// Use Unit.GetValue to retrieve inch measurements from pixel counts for precise ruler drawing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel count to inches
            double pixelCount = 192.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            // Pixels to millimeters
            double pixels = 300.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            // Predefined pixel dimensions
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
            Console.WriteLine($"Size: {widthPixels}x{heightPixels} px => {widthInches:F2}x{heightInches:F2} in, {widthCentimeters:F2}x{heightCentimeters:F2} cm, {widthMillimeters:F2}x{heightMillimeters:F2} mm, {widthPoints:F2}x{heightPoints:F2} pt, {widthPicas:F2}x{heightPicas:F2} pc");
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}