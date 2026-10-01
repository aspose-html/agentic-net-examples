// Clean up temporary files after conversion completes using a cleanup handler.

using System;

class Program
{
    static void Main()
    {
        string tempHtmlPath = null;
        try
        {
            // Create a temporary HTML file
            tempHtmlPath = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllText(tempHtmlPath, "<html><body><h1>Hello World</h1></body></html>");

            // Define output PDF path
            string outputPdfPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

            // Load HTML document and convert to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempHtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);
            }

            System.Console.WriteLine("Conversion completed: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Cleanup temporary HTML file
            if (!string.IsNullOrEmpty(tempHtmlPath) && System.IO.File.Exists(tempHtmlPath))
            {
                try
                {
                    System.IO.File.Delete(tempHtmlPath);
                }
                catch (Exception cleanupEx)
                {
                    System.Console.Error.WriteLine("Cleanup error: " + cleanupEx.Message);
                }
            }
        }
    }
}