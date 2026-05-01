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
            string csvPath = "pixels.csv";
            if (!File.Exists(csvPath))
            {
                Console.WriteLine($"CSV file not found: {csvPath}");
                return;
            }
            foreach (var line in File.ReadLines(csvPath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (double.TryParse(line.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double pixelCount))
                {
                    double inches = pixelCount / 96.0;
                    Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");
                }
                else
                {
                    Console.WriteLine($"Invalid pixel value: {line}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}