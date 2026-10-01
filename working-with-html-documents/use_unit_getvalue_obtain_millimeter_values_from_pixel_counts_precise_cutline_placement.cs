// Use Unit.GetValue to obtain millimeter values from pixel counts for precise cut‑line placement.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeters
            double pixels = 300;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            // Pixel count to inches
            double pixelCount = 500;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            // Use predefined pixel values for width and height
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
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Pixel to points
            double pixels2 = 150;
            double points = pixels2 * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {pixels2} => {points:F2} points");

            // Width/Height millimeters using direct formula
            double widthPixels2 = 1024;
            double heightPixels2 = 768;
            double widthMillimeters2 = widthPixels2 / 96.0 * 25.4;
            double heightMillimeters2 = heightPixels2 / 96.0 * 25.4;
            Console.WriteLine($"Width: {widthMillimeters2:F2} mm");
            Console.WriteLine($"Height: {heightMillimeters2:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}