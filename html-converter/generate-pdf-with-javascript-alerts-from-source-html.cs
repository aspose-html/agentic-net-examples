// Use Converter.RenderTo with PdfDevice to generate a PDF that includes JavaScript alerts from the source HTML.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script>alert('Hello from JS');</script></head><body><h1>Test</h1></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

            string outputPath = "output.pdf";
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}