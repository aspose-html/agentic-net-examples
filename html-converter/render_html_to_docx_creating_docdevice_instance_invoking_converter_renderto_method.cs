// Render HTML to DOCX by creating a DocDevice instance and invoking Converter.RenderTo method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            string outputPath = "output.docx";
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);
            document.RenderTo(device);
            System.Console.WriteLine("HTML successfully rendered to DOCX.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}