// Extract all task list items into a JSON array for external processing or reporting.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskListExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the markdown file containing task list items.
                string inputPath = "input.md";

                // Read all lines from the file.
                string[] lines = File.ReadAllLines(inputPath);

                // Collect task descriptions.
                List<string> tasks = new List<string>();

                foreach (string line in lines)
                {
                    string trimmed = line.TrimStart();

                    // Identify markdown task list items (e.g., "- [ ] Do something" or "- [x] Done").
                    if (trimmed.StartsWith("- ["))
                    {
                        int closingBracket = trimmed.IndexOf(']');
                        if (closingBracket > 0 && trimmed.Length > closingBracket + 1)
                        {
                            string task = trimmed.Substring(closingBracket + 1).Trim();
                            if (!string.IsNullOrEmpty(task))
                            {
                                tasks.Add(task);
                            }
                        }
                    }
                }

                // Serialize the list of tasks to a JSON array.
                string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });

                // Output the JSON to the console.
                Console.WriteLine(json);
            }
            catch (Exception ex)
            {
                // Print any errors that occur during processing.
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}