// Convert pixel dimensions to centimeters and store the results in a JSON configuration file.

using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Predefined pixel dimensions
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
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthCentimeters:F4} cm = {widthMillimeters:F4} mm = {widthPoints:F4} pt = {widthPicas:F4} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in = {heightCentimeters:F4} cm = {heightMillimeters:F4} mm = {heightPoints:F4} pt = {heightPicas:F4} pc");

            // Optional pixel value from command line
            double pixels = 96.0;
            if (args.Length > 0 && double.TryParse(args[0], out double parsedPixels))
            {
                pixels = parsedPixels;
            }

            double inches = pixels / 96.0;
            double points = pixels * 72.0 / 96.0;
            double centimeters = inches * 2.54;
            double millimeters = centimeters * 10.0;

            var result = new
            {
                pixels,
                inches = Math.Round(inches, 4),
                points = Math.Round(points, 4),
                centimeters = Math.Round(centimeters, 4),
                millimeters = Math.Round(millimeters, 4)
            };

            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);

            // Additional single conversion example
            double singlePixels = 150.0;
            double singleCentimeters = singlePixels / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {singleCentimeters:F2}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}