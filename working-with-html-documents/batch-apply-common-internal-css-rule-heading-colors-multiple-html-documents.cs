// Batch apply a common internal CSS rule for heading colors across multiple HTML documents.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create sample HTML files
            string[] inputFiles = new string[] { "sample1.html", "sample2.html" };
            string sampleContent1 = "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><h1>Heading 1</h1><p>Paragraph.</p></body></html>";
            string sampleContent2 = "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><h2>Heading 2</h2><p>Another paragraph.</p></body></html>";
            File.WriteAllText(inputFiles[0], sampleContent1);
            File.WriteAllText(inputFiles[1], sampleContent2);

            foreach (string inputPath in inputFiles)
            {
                string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), Path.GetFileNameWithoutExtension(inputPath) + "_styled.html");
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.Dom.Element style = document.CreateElement("style");
                style.TextContent = "h1, h2, h3 { color: #ff0000; }";
                Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head")[0];
                head.AppendChild(style);
                document.Save(outputPath);
                Console.WriteLine("Processed " + inputPath + " -> " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}