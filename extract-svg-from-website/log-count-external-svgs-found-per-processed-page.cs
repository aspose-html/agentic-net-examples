// Log the count of external SVGs found on each processed page.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input";
            string outputFolder = "output";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            if (htmlFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleHtml = "<!DOCTYPE html>\n<html>\n<head><title>Sample</title></head>\n<body>\n    <svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\"/></svg>\n    <svg width=\"50\" height=\"50\"><rect width=\"50\" height=\"50\" style=\"fill:blue;\"/></svg>\n</body>\n</html>";
                File.WriteAllText(samplePath, sampleHtml);
                htmlFiles = new string[] { samplePath };
            }

            foreach (string htmlPath in htmlFiles)
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");
                int count = svgs.Length;
                Console.WriteLine($"File '{Path.GetFileName(htmlPath)}' contains {count} SVG element(s).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}