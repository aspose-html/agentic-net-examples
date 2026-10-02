// Configure proxy settings to access websites behind corporate firewalls securely during conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://www.example.com";
            string outputPath = "example.pdf";

            var config = new Aspose.Html.Configuration();

            using (var document = new Aspose.Html.HTMLDocument(url, config))
            {
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}