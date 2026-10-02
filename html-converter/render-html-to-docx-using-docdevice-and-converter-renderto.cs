// Render HTML to DOCX by creating a DocDevice instance and invoking Converter.RenderTo method.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, DOCX!</h1><p>This is a test.</p></body></html>";
            File.WriteAllText(sourcePath, htmlContent);

            string outputPath = "output.docx";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("HTML has been successfully rendered to DOCX: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}