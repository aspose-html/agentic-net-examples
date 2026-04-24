// Create a batch process that reads HTML strings, draws watermarks on canvases, and writes JPEG outputs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            string[] inputs = new string[]
            {
                "<html><body><h1>First</h1></body></html>",
                "<html><body><h1>Second</h1></body></html>"
            };
            for (int i = 0; i < inputs.Length; i++)
            {
                using (HTMLDocument document = new HTMLDocument(inputs[i], "http://example.com"))
                {
                    Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute;top:10px;left:10px;color:red;font-size:24px;");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputDir, $"output_{i}.jpg");
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}