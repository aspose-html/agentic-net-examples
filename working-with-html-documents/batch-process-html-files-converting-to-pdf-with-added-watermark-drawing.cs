// Batch process HTML files, converting each to PDF with a watermark added via drawing API.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Sample input HTML files
            string[] inputs = new string[] { "input1.html", "input2.html" };

            // Create minimal sample HTML files if they do not exist
            foreach (string inputPath in inputs)
            {
                if (!File.Exists(inputPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Sample Content</h1></body></html>";
                    File.WriteAllText(inputPath, sampleHtml);
                }
            }

            // Process each HTML file
            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, "about:blank"))
                {
                    // Create a watermark element using HTML overlay
                    Aspose.Html.Dom.Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute; top:200px; left:100px; font-size:48px; color:red; opacity:0.2; pointer-events:none;");
                    div.TextContent = "WATERMARK";
                    document.Body.AppendChild(div);

                    // Convert to PDF
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    string outputPath = Path.Combine(outputDir, $"output_{i + 1}.pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}