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
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Prepare result object
            var result = new
            {
                widthPixels,
                heightPixels,
                widthInches = Math.Round(widthInches, 4),
                heightInches = Math.Round(heightInches, 4),
                widthCentimeters = Math.Round(widthCentimeters, 4),
                heightCentimeters = Math.Round(heightCentimeters, 4)
            };

            // Serialize to JSON
            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON to configuration file
            string configPath = "config.json";
            File.WriteAllText(configPath, json);

            Console.WriteLine("Conversion results saved to " + configPath);
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}