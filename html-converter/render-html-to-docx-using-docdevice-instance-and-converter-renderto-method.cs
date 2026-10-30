// Render HTML to DOCX by creating a DocDevice instance and invoking Converter.RenderTo method.

using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "sample.html";
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample HTML to DOCX conversion.</p></body></html>";
                System.IO.File.WriteAllText(sourcePath, htmlContent);

                string outputPath = "output.docx";

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
                Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
                Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);

                document.RenderTo(device);

                Console.WriteLine("HTML has been successfully rendered to DOCX: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}