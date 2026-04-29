// Implement a feature that validates that the converted PDF is not password protected unless explicitly set.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            PdfSaveOptions options = new PdfSaveOptions();

            Converter.ConvertHTML(htmlPath, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}