// Create a utility that reads pixel values from a CSV and outputs corresponding inches using Unit.

using System;
using System.IO;

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
                File.WriteAllText(csvPath, "Width,Height\n192,108\n384,216");
            }

            string[] lines = File.ReadAllLines(csvPath);
            // Skip header line
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts.Length < 2)
                    continue;

                double widthPixels = double.Parse(parts[0]);
                double heightPixels = double.Parse(parts[1]);

                double widthInches = Aspose.Html.Drawing.Unit.FromPixels(widthPixels)
                    .GetValue(Aspose.Html.Drawing.UnitType.In);
                double heightInches = Aspose.Html.Drawing.Unit.FromPixels(heightPixels)
                    .GetValue(Aspose.Html.Drawing.UnitType.In);

                System.Console.WriteLine($"Width: {widthPixels} px => {widthInches:F4} in");
                System.Console.WriteLine($"Height: {heightPixels} px => {heightInches:F4} in");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}