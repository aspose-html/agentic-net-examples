// Count the number of headings at each level and output the statistics as a comment.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Title</h1><h2>Section</h2><h2>Another Section</h2><h3>Subsection</h3></body></html>";
                File.WriteAllText(samplePath, sampleContent);
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                int[] levelCounts = new int[7]; // indices 1-6 used

                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement element = (HTMLElement)headings[i];
                    string tag = element.TagName.ToLower();
                    int level = int.Parse(tag.Substring(1));
                    if (level >= 1 && level <= 6)
                        levelCounts[level]++;
                }

                // Build comment text with statistics
                List<string> parts = new List<string>();
                for (int lvl = 1; lvl <= 6; lvl++)
                {
                    if (levelCounts[lvl] > 0)
                        parts.Add($"h{lvl}={levelCounts[lvl]}");
                }
                string commentText = "Heading statistics: " + string.Join(", ", parts);

                var commentNode = document.CreateComment(commentText);
                document.InsertBefore(commentNode, document.DocumentElement);

                string jsonPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".html");
                document.Save(jsonPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}