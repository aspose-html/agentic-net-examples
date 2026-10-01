// Use the Unit class to transform 1024 pixel width into centimeters for layout calculations.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Use predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

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
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Additional examples
            double pixels = 150.0;
            double centimeters = pixels / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");

            double pixels2 = 200.0;
            double millimeters = (pixels2 / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels2} = {millimeters:F2} mm");

            double columnWidthPixels = 120.0;
            double rowHeightPixels = 30.0;
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;
            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");

            double pixelCount = 1024.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            double widthPx = 1024.0;
            double heightPx = 768.0;
            double widthMm = widthPx / 96.0 * 25.4;
            double heightMm = heightPx / 96.0 * 25.4;
            Console.WriteLine($"Width: {widthMm:F2} mm");
            Console.WriteLine($"Height: {heightMm:F2} mm");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}