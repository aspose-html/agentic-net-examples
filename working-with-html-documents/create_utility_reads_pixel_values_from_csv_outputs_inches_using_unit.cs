// Create a utility that reads pixel values from a CSV and outputs corresponding inches using Unit.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixelCount = 1920;
            double inches = pixelCount / 96.0;
            System.Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches:F4} }}");

            // ✔ Use predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

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
            System.Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthCentimeters:F4} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in = {heightCentimeters:F4} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}