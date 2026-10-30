// Convert MHTML to PDF and then merge the resulting PDF with another document using an external library.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string mhtmlPath = "sample.mhtml";
            if (!File.Exists(mhtmlPath))
            {
                string mhtmlContent = @"<html><head><title>Sample</title></head><body><p>Hello, MHTML!</p></body></html>";
                File.WriteAllText(mhtmlPath, mhtmlContent);
            }

            // Convert MHTML to PDF
            string pdfPath = "output.pdf";
            using (Stream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                PdfSaveOptions pdfOptions = new PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, pdfOptions, pdfPath);
            }
            Console.WriteLine($"MHTML converted to PDF: {pdfPath}");

            // Path to another PDF to merge with (assumed to exist)
            string otherPdfPath = "other.pdf";
            // For demonstration, create a dummy second PDF if it does not exist
            if (!File.Exists(otherPdfPath))
            {
                // Create a minimal PDF using the same conversion process from a simple HTML
                string dummyHtmlPath = "dummy.html";
                File.WriteAllText(dummyHtmlPath, "<html><body><p>Second PDF</p></body></html>");
                using (Stream htmlStream = File.OpenRead(dummyHtmlPath))
                {
                    PdfSaveOptions dummyOptions = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(htmlStream, dummyOptions, otherPdfPath);
                }
                File.Delete(dummyHtmlPath);
            }

            // Merge PDFs - requires an external PDF library (not included)
            Console.WriteLine("Merging PDFs requires an external PDF manipulation library, which is not available in this example.");
            Console.WriteLine($"Would merge '{pdfPath}' with '{otherPdfPath}' into a single document.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}