// Batch process HTML files, apply a watermark div overlay, and save each modified file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Prepare sample input HTML files
            string[] inputs = new string[] { "sample1.html", "sample2.html" };
            string[] sampleContents = new string[]
            {
                "<html><body><h1>Sample 1</h1></body></html>",
                "<html><body><h1>Sample 2</h1></body></html>"
            };

            for (int i = 0; i < inputs.Length; i++)
            {
                if (!File.Exists(inputs[i]))
                {
                    File.WriteAllText(inputs[i], sampleContents[i]);
                }
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputs[i], ""))
                {
                    // Create watermark element
                    Aspose.Html.Dom.Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute; top:10px; left:10px; color:red; font-size:24px;");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);

                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputDir, $"output_{i + 1}.jpeg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}