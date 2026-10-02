// Batch process HTML files, apply a watermark div overlay, and save each modified file.

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
            // Prepare input directory and sample HTML files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputDir);
            string samplePath1 = Path.Combine(inputDir, "sample1.html");
            string samplePath2 = Path.Combine(inputDir, "sample2.html");
            if (!File.Exists(samplePath1))
            {
                File.WriteAllText(samplePath1, "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><h1>First Document</h1></body></html>");
            }
            if (!File.Exists(samplePath2))
            {
                File.WriteAllText(samplePath2, "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><h1>Second Document</h1></body></html>");
            }

            // Output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Input files array
            string[] inputs = new string[] { samplePath1, samplePath2 };

            for (int i = 0; i < inputs.Length; i++)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputs[i]))
                {
                    // Create watermark element
                    Aspose.Html.Dom.Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute; top:10px; left:10px; font-size:48px; color:rgba(255,0,0,0.5); pointer-events:none;");
                    div.TextContent = "Watermark";

                    // Append watermark to body
                    document.Body.AppendChild(div);

                    // Save modified HTML
                    string outputPath = Path.Combine(outputDir, $"output{i + 1}.html");
                    document.Save(outputPath);
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}