// Use Unit.GetValue to obtain centimeter values from pixel counts for CSS media queries.

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
            Console.WriteLine($"Width: {widthPixels}px = {widthInches:F4}in = {widthCentimeters:F2}cm = {widthMillimeters:F1}mm = {widthPoints:F1}pt = {widthPicas:F2}pc");
            Console.WriteLine($"Height: {heightPixels}px = {heightInches:F4}in = {heightCentimeters:F2}cm = {heightMillimeters:F1}mm = {heightPoints:F1}pt = {heightPicas:F2}pc");

            double pixelCount = 12345;
            double inchesFromPixels = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inchesFromPixels:F4}");

            double pixels = 200;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            pixels = 300;
            double centimeters = pixels / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");

            double columnWidthPixels = 100;
            double rowHeightPixels = 50;
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;
            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}