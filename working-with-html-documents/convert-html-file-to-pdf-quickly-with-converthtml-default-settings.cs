// Convert an HTML file to PDF quickly using the ConvertHTML method with default settings.

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
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}