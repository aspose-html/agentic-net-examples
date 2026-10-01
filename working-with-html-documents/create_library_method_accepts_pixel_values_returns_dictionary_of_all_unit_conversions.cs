// Create a library method that accepts pixel values and returns a dictionary of all unit conversions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeters conversion
            double pixels = 300.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            // Pixel count to inches conversion
            double pixelCount = 1200.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            // Pixels to points conversion
            double pixelsForPoints = 200.0;
            double points = pixelsForPoints * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {pixelsForPoints} => {points:F2} points");

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
            Console.WriteLine($"Size: {widthPixels}×{heightPixels} px");
            Console.WriteLine($"Inches: {widthInches:F2}×{heightInches:F2} in");
            Console.WriteLine($"Centimeters: {widthCentimeters:F2}×{heightCentimeters:F2} cm");
            Console.WriteLine($"Millimeters: {widthMillimeters:F2}×{heightMillimeters:F2} mm");
            Console.WriteLine($"Points: {widthPoints:F2}×{heightPoints:F2} pt");
            Console.WriteLine($"Picas: {widthPicas:F2}×{heightPicas:F2} pc");

            // Additional pixel to centimeters conversion
            double anotherPixels = 500.0;
            double centimeters = anotherPixels / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}