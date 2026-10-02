// Detect and fix inconsistent indentation in nested lists to ensure proper hierarchical rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string inputPath = Path.Combine(inputFolder, "sample.html");
            string outputPath = Path.Combine(outputFolder, "fixed.html");

            // Create a sample HTML file with inconsistent indentation if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<html>
  <body>
    <ul>
      <li>Item 1</li>
      <li>    Item 2 with extra spaces</li>
      <li>
        Item 3 with leading newline
      </li>
      <li>Item 4</li>
    </ul>
  </body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all list item elements
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("li");

            // Trim whitespace in each list item to fix indentation issues
            foreach (Aspose.Html.Dom.Node node in elements)
            {
                var li = (Aspose.Html.HTMLElement)node;
                string originalText = li.TextContent;
                string trimmedText = originalText.Trim();
                if (originalText != trimmedText)
                {
                    li.TextContent = trimmedText;
                }
            }

            // Save the corrected document
            document.Save(outputPath);

            Console.WriteLine($"Fixed HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}