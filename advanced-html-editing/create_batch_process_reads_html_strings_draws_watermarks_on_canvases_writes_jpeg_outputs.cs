// Create a batch process that reads HTML strings, draws watermarks on canvases, and writes JPEG outputs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "OutputImages");
            System.IO.Directory.CreateDirectory(outputDir);

            string[] inputs = new string[]
            {
                "<html><body><h1>First Document</h1></body></html>",
                "<html><body><h1>Second Document</h1></body></html>"
            };

            for (int i = 0; i < inputs.Length; i++)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputs[i], "http://example.com"))
                {
                    // Create watermark element
                    Aspose.Html.Dom.Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute; top:10px; left:10px; font-size:24px; color:rgba(255,0,0,0.5);");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);

                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = System.IO.Path.Combine(outputDir, $"output_{i + 1}.jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
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