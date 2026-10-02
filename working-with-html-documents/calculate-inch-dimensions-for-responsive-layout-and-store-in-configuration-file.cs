// Use Unit.FromPixels to calculate inch dimensions for a responsive layout and store them in a configuration file.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define pixel dimensions
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

            // Store results in a configuration file
            string configPath = "layout.config";
            using (StreamWriter writer = new StreamWriter(configPath, false))
            {
                writer.WriteLine($"WidthInches={widthInches}");
                writer.WriteLine($"HeightInches={heightInches}");
                writer.WriteLine($"WidthCentimeters={widthCentimeters}");
                writer.WriteLine($"HeightCentimeters={heightCentimeters}");
                writer.WriteLine($"WidthMillimeters={widthMillimeters}");
                writer.WriteLine($"HeightMillimeters={heightMillimeters}");
                writer.WriteLine($"WidthPoints={widthPoints}");
                writer.WriteLine($"HeightPoints={heightPoints}");
                writer.WriteLine($"WidthPicas={widthPicas}");
                writer.WriteLine($"HeightPicas={heightPicas}");
            }

            Console.WriteLine("Configuration saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}