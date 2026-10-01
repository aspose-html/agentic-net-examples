// Log the count of external SVGs found on each processed page.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create sample HTML files
            string[] sampleFiles = { "page1.html", "page2.html" };
            string[] sampleContents = {
                "<html><body><svg></svg><svg></svg></body></html>",
                "<html><body><div>No SVG here</div></body></html>"
            };

            for (int i = 0; i < sampleFiles.Length; i++)
            {
                string filePath = Path.Combine(inputFolder, sampleFiles[i]);
                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, sampleContents[i]);
            }

            // Process each HTML file and log SVG count
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            foreach (string htmlPath in htmlFiles)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                int count = svgs.Length;
                Console.WriteLine($"File {Path.GetFileName(htmlPath)} contains {count} external SVG(s).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}