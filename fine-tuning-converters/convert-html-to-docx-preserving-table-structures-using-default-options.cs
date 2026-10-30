// Convert HTML to DOCX while preserving table structures by using default DocRenderingOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.docx";

            string htmlContent = "<!DOCTYPE html><html><body><h1>Sample Table</h1><table border='1'><tr><th>Name</th><th>Age</th></tr><tr><td>Alice</td><td>30</td></tr><tr><td>Bob</td><td>25</td></tr></table></body></html>";
            File.WriteAllText(sourcePath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);

            document.RenderTo(device);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}