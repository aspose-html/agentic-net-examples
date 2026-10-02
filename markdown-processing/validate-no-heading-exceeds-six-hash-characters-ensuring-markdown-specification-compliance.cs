// Validate that no heading exceeds six hash characters, ensuring compliance with Markdown specifications.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.md";

            if (!File.Exists(inputPath))
            {
                string[] sampleContent = new string[]
                {
                    "# Heading 1",
                    "## Heading 2",
                    "### Heading 3",
                    "#### Heading 4",
                    "##### Heading 5",
                    "###### Heading 6",
                    "####### Invalid Heading 7",
                    "Normal text line."
                };
                File.WriteAllLines(inputPath, sampleContent);
            }

            string[] lines = File.ReadAllLines(inputPath);
            List<string> errors = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int index = 0;
                while (index < line.Length && line[index] == '#')
                {
                    index++;
                }

                if (index > 0)
                {
                    // Ensure the heading marker is followed by a space or end of line per Markdown spec
                    if (index < line.Length && line[index] != ' ')
                    {
                        // Not a valid heading, ignore for this validation
                        continue;
                    }

                    if (index > 6)
                    {
                        errors.Add($"Line {i + 1}: Heading with {index} hash characters exceeds the maximum of 6.");
                    }
                }
            }

            if (errors.Count == 0)
            {
                Console.WriteLine("All headings are valid (no heading exceeds six hash characters).");
            }
            else
            {
                Console.WriteLine("Heading validation errors found:");
                foreach (string error in errors)
                {
                    Console.WriteLine(error);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}