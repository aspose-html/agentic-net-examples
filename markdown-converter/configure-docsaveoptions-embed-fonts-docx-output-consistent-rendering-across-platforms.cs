// Configure DocSaveOptions to embed fonts in the DOCX output for consistent rendering across platforms.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.docx";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Sample</title></head><body><p>Hello, Aspose.HTML!</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Configure rendering options to embed fonts fully
            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            docOptions.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            // Create a DOCX rendering device
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);

            // Render the document to DOCX
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}