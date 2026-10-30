// Dispose of HtmlDocument and PdfSaveOptions objects after each conversion to free unmanaged resources promptly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputPath, config);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(doc, options, outputPath);

            doc.Dispose();
            // PdfSaveOptions does not implement IDisposable; no explicit disposal required.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}