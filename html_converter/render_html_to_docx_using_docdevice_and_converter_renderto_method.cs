// Render HTML to DOCX by creating a DocDevice instance and invoking Converter.RenderTo method.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            string sourceUrl = "https://example.com";
            string outputPath = "output.docx";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl);
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}