// Convert pixel dimensions to centimeters and store the results in a JSON configuration file.

using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Predefined pixel values
            double widthPixels = 1920;
            double heightPixels = 1080;

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

            var result = new
            {
                WidthPixels = widthPixels,
                HeightPixels = heightPixels,
                WidthInches = Math.Round(widthInches, 4),
                HeightInches = Math.Round(heightInches, 4),
                WidthCentimeters = Math.Round(widthCentimeters, 4),
                HeightCentimeters = Math.Round(heightCentimeters, 4),
                WidthMillimeters = Math.Round(widthMillimeters, 4),
                HeightMillimeters = Math.Round(heightMillimeters, 4),
                WidthPoints = Math.Round(widthPoints, 4),
                HeightPoints = Math.Round(heightPoints, 4),
                WidthPicas = Math.Round(widthPicas, 4),
                HeightPicas = Math.Round(heightPicas, 4)
            };

            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

            string outputPath = "config.json";
            File.WriteAllText(outputPath, json);

            Console.WriteLine("Conversion results saved to JSON configuration file:");
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}