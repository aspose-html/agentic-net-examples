// Use Unit.FromPixels to create units for both width and height, then retrieve their inch equivalents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Use predefined pixel values
            double widthPixels = 1920;
            double heightPixels = 1080;

            const double ppi = 96.0;

            // ✔ Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // ✔ Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // ✔ Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // ✔ Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // ✔ Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // ✔ Output results
            Console.WriteLine($"Width in inches: {widthInches:F4}");
            Console.WriteLine($"Height in inches: {heightInches:F4}");
            Console.WriteLine($"Width in centimeters: {widthCentimeters:F4}");
            Console.WriteLine($"Height in centimeters: {heightCentimeters:F4}");
            Console.WriteLine($"Width in millimeters: {widthMillimeters:F4}");
            Console.WriteLine($"Height in millimeters: {heightMillimeters:F4}");
            Console.WriteLine($"Width in points: {widthPoints:F4}");
            Console.WriteLine($"Height in points: {heightPoints:F4}");
            Console.WriteLine($"Width in picas: {widthPicas:F4}");
            Console.WriteLine($"Height in picas: {heightPicas:F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}