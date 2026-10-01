// Define a CSS variable for border color and reference it in the table border-color rule.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal HTML file with a table if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<table><tr><td>Cell 1</td><td>Cell 2</td></tr></table>
</body>
</html>";
                File.WriteAllText(inputPath, minimalHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Select the first table element
            Aspose.Html.Dom.Element table = document.QuerySelector("table");

            // Define a CSS variable for border color and use it in the border style
            string styleValue = "--border-color:#ff0000; border:2px solid var(--border-color);";

            // Apply the style attribute to the table
            table.SetAttribute("style", styleValue);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}