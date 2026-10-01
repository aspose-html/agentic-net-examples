// Use Unit.GetValue to retrieve point values from pixel counts for precise typographic scaling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to points conversion
            double pixels = 200.0;
            double points = pixels * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {pixels} => {points:F2} points");

            // Pixel count to inches conversion
            double pixelCount = 300.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            // Pixels to millimeters conversion
            double pixelsMm = 150.0;
            const double ppi = 96.0;
            double millimeters = (pixelsMm / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixelsMm} = {millimeters:F2} mm");

            // Width and height conversions
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
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthCentimeters:F4} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in = {heightCentimeters:F4} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Additional width/height to points conversion
            double widthPixels2 = 1024.0;
            double heightPixels2 = 768.0;
            double widthPoints2 = widthPixels2 * 72.0 / 96.0;
            double heightPoints2 = heightPixels2 * 72.0 / 96.0;
            Console.WriteLine($"Width in points: {widthPoints2:F2}");
            Console.WriteLine($"Height in points: {heightPoints2:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}