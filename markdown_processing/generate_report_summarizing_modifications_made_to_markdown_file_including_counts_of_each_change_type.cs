// Generate a report summarizing all modifications made to a Markdown file, including counts of each change type.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Determine input markdown file and output CSV report paths
            string markdownPath = args.Length > 0 ? args[0] : "input.md";
            string reportPath = args.Length > 1 ? args[1] : "modifications_report.csv";

            // Validate that the markdown file exists
            if (!File.Exists(markdownPath))
                throw new FileNotFoundException($"Markdown file not found: {markdownPath}");

            // Initialize counters for each change type
            int addedCount = 0;
            int removedCount = 0;
            int modifiedCount = 0;

            // Simple convention:
            // Lines starting with '+' are additions
            // Lines starting with '-' are deletions
            // Lines starting with '~' are modifications
            foreach (string line in File.ReadLines(markdownPath))
            {
                if (line.StartsWith("+"))
                    addedCount++;
                else if (line.StartsWith("-"))
                    removedCount++;
                else if (line.StartsWith("~"))
                    modifiedCount++;
            }

            // Write the CSV report
            using (var writer = new StreamWriter(reportPath, false))
            {
                writer.WriteLine("ChangeType,Count");
                writer.WriteLine($"Added,{addedCount}");
                writer.WriteLine($"Removed,{removedCount}");
                writer.WriteLine($"Modified,{modifiedCount}");
            }

            Console.WriteLine($"Modification report generated at: {reportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}