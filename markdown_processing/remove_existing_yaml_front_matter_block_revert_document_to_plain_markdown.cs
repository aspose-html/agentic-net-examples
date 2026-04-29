// Remove an existing YAML front‑matter block to revert the document to plain Markdown.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.md";

            if (!File.Exists(inputPath))
                throw new FileNotFoundException("Input file not found.", inputPath);

            string[] lines = File.ReadAllLines(inputPath);
            int start = -1, end = -1;

            if (lines.Length > 0 && lines[0].Trim() == "---")
            {
                start = 0;
                for (int i = 1; i < lines.Length; i++)
                {
                    if (lines[i].Trim() == "---")
                    {
                        end = i;
                        break;
                    }
                }
            }

            string[] result;
            if (start != -1 && end != -1 && end > start)
            {
                List<string> content = new List<string>();
                for (int i = end + 1; i < lines.Length; i++)
                    content.Add(lines[i]);
                result = content.ToArray();
            }
            else
            {
                result = lines;
            }

            File.WriteAllLines(outputPath, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}