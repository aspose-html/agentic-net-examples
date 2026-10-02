// Create a utility that reads pixel values from a CSV and outputs corresponding inches using Unit.

using System;
using System.IO;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            const string csvPath = "pixels.csv";

            // Create a sample CSV file if it does not exist
            if (!File.Exists(csvPath))
            {
                File.WriteAllText(csvPath, "120\n240\n360\n480");
            }

            // Read all lines from the CSV
            string[] lines = File.ReadAllLines(csvPath);
            foreach (string line in lines)
            {
                if (double.TryParse(line.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double pixelCount))
                {
                    double inches = pixelCount / 96.0;
                    Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");
                }
                else
                {
                    Console.WriteLine($"Invalid pixel value: '{line}'");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}