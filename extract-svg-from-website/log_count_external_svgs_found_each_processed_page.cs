// Log the count of external SVGs found on each processed page.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input_html";
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            if (htmlFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><svg></svg><svg></svg></body></html>");
                htmlFiles = new string[] { samplePath };
            }

            foreach (string htmlPath in htmlFiles)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                int count = svgs.Length;
                Console.WriteLine($"File '{Path.GetFileName(htmlPath)}' contains {count} external SVG(s).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}