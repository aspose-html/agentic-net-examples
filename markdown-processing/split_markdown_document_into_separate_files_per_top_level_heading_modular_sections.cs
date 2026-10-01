// Split a Markdown document into separate files for each top‑level heading to create modular sections.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file
            string sourcePath = System.IO.Path.Combine(inputFolder, "sample.md");
            string markdownContent = "# Introduction\nThis is the introduction.\n\n# Chapter One\nContent of chapter one.\n\n# Chapter Two\nContent of chapter two.\n";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to HTMLDocument (demonstration of Aspose.HTML usage)
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);
            // (The HTMLDocument is not used further in this example.)

            // Split markdown into sections by top‑level headings
            string[] lines = System.IO.File.ReadAllLines(sourcePath);
            List<int> headingIndices = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("# "))
                    headingIndices.Add(i);
            }
            headingIndices.Add(lines.Length); // sentinel for last section

            for (int i = 0; i < headingIndices.Count - 1; i++)
            {
                int start = headingIndices[i];
                int end = headingIndices[i + 1];
                string headingLine = lines[start];
                string headingText = headingLine.Substring(2).Trim();

                // Build file name from heading text
                string safeName = System.Text.RegularExpressions.Regex.Replace(headingText, @"[^\w\-]+", "_");
                string outPath = System.IO.Path.Combine(outputFolder, safeName + ".md");

                // Collect lines for this section
                List<string> sectionLines = new List<string>();
                for (int j = start; j < end; j++)
                {
                    sectionLines.Add(lines[j]);
                }
                System.IO.File.WriteAllText(outPath, string.Join(Environment.NewLine, sectionLines));
            }

            Console.WriteLine("Markdown document split into separate files successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}