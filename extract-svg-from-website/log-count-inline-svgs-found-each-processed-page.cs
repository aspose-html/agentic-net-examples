// Log the count of inline SVGs found on each processed page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input_html";

            if (!System.IO.Directory.Exists(inputFolder))
                System.IO.Directory.CreateDirectory(inputFolder);

            // Create a sample HTML file if the folder is empty
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<html><body><svg></svg><svg></svg></body></html>";
                System.IO.File.WriteAllText(samplePath, sampleContent);
            }

            string[] htmlFiles = System.IO.Directory.GetFiles(inputFolder, "*.html");

            foreach (string filePath in htmlFiles)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath);
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                int svgCount = svgs.Length;

                Console.WriteLine($"File: {System.IO.Path.GetFileName(filePath)} - Inline SVG count: {svgCount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}