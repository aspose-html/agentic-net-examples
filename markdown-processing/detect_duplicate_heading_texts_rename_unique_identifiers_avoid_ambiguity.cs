// Detect duplicate heading texts and rename them with unique identifiers to avoid ambiguity.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a sample HTML file with duplicate headings if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<h1>Introduction</h1>
<h2>Overview</h2>
<h2>Overview</h2>
<h3>Details</h3>
<h3>Details</h3>
<h3>Details</h3>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Select all heading elements
            var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

            // Track occurrences of heading texts
            var textCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < headings.Length; i++)
            {
                var element = (Aspose.Html.HTMLElement)headings[i];
                string text = element.TextContent.Trim();

                if (textCounts.ContainsKey(text))
                {
                    textCounts[text]++;
                    string newText = $"{text} ({textCounts[text]})";
                    element.TextContent = newText;
                }
                else
                {
                    textCounts[text] = 1;
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Processed file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}