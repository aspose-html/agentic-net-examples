// Convert pixel dimensions to centimeters and store the results in a JSON configuration file.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;

            // Override defaults with command‑line arguments if provided
            if (args.Length >= 2)
            {
                double.TryParse(args[0], out widthPixels);
                double.TryParse(args[1], out heightPixels);
            }

            // Pixels per inch (standard)
            const double ppi = 96.0;

            // Convert pixels to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert inches to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Create Aspose.Html Length objects (optional demonstration)
            Length widthLength = Unit.FromCentimeters(widthCentimeters);
            Length heightLength = Unit.FromCentimeters(heightCentimeters);

            // Prepare result object for JSON serialization
            var result = new
            {
                widthPixels = Math.Round(widthPixels, 4),
                heightPixels = Math.Round(heightPixels, 4),
                widthCentimeters = Math.Round(widthCentimeters, 4),
                heightCentimeters = Math.Round(heightCentimeters, 4)
            };

            // Serialize to formatted JSON
            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON to configuration file
            File.WriteAllText("dimensions.json", json);

            Console.WriteLine("Conversion results saved to dimensions.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}