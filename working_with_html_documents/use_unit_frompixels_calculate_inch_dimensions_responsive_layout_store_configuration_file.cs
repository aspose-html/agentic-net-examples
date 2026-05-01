// Use Unit.FromPixels to calculate inch dimensions for a responsive layout and store them in a configuration file.

using System;
using System.IO;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double widthPixels = 800;
            double heightPixels = 600;
            const double ppi = 96.0;

            // Create Length objects from pixel values
            Length widthLength = Unit.FromPixels(widthPixels);
            Length heightLength = Unit.FromPixels(heightPixels);

            // Convert pixel dimensions to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Store the inch dimensions in a simple configuration file
            string configPath = "layoutConfig.txt";
            string[] lines = {
                $"WidthInches={widthInches}",
                $"HeightInches={heightInches}"
            };
            File.WriteAllLines(configPath, lines);

            Console.WriteLine($"Inch dimensions saved to {configPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}