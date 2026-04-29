// Update specific fields within the YAML front‑matter, such as title or date, programmatically.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output markdown files containing YAML front‑matter
            string inputPath = "input.md";
            string outputPath = "output.md";

            // Read all lines from the input file
            List<string> lines = File.ReadAllLines(inputPath).ToList();

            // Locate the start and end of the YAML front‑matter (delimited by "---")
            int startIndex = lines.FindIndex(l => l.Trim() == "---");
            if (startIndex == -1) throw new InvalidOperationException("YAML front‑matter start delimiter not found.");

            int endIndex = lines.FindIndex(startIndex + 1, l => l.Trim() == "---");
            if (endIndex == -1) throw new InvalidOperationException("YAML front‑matter end delimiter not found.");

            // Update specific fields within the front‑matter
            for (int i = startIndex + 1; i < endIndex; i++)
            {
                string line = lines[i];
                if (line.StartsWith("title:", StringComparison.OrdinalIgnoreCase))
                {
                    lines[i] = "title: Updated Title";
                }
                else if (line.StartsWith("date:", StringComparison.OrdinalIgnoreCase))
                {
                    lines[i] = $"date: {DateTime.UtcNow:yyyy-MM-dd}";
                }
            }

            // Write the modified content back to the output file
            File.WriteAllLines(outputPath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}