// Convert MHTML to PDF and then merge the resulting PDF with another document using an external library.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for source MHTML, intermediate PDF, and the PDF to merge with
            string mhtmlPath = "input.mhtml";
            string pdfPath = "output.pdf";
            string otherPdfPath = "other.pdf";
            string mergedPdfPath = "merged.pdf";

            // Convert MHTML to PDF
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                PdfSaveOptions pdfOptions = new PdfSaveOptions();
                Converter.ConvertMHTML(mhtmlStream, pdfOptions, pdfPath);
            }

            // Merge the generated PDF with another PDF using an external library.
            // Note: Actual merging requires a PDF manipulation library (e.g., PdfSharp, iTextSharp).
            // The following is a placeholder to illustrate where merging code would be placed.
            // Replace this block with appropriate library calls.

            /*
            using (var output = new FileStream(mergedPdfPath, FileMode.Create))
            {
                // Example with PdfSharp (if referenced):
                // var document = PdfSharp.Pdf.IO.PdfReader.Open(pdfPath, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import);
                // var other = PdfSharp.Pdf.IO.PdfReader.Open(otherPdfPath, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import);
                // var merged = new PdfSharp.Pdf.PdfDocument();
                // foreach (var page in document.Pages) merged.AddPage(page);
                // foreach (var page in other.Pages) merged.AddPage(page);
                // merged.Save(output);
            }
            */

            Console.WriteLine("MHTML converted to PDF successfully.");
            Console.WriteLine("Merge step requires an external PDF library and is not implemented in this example.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}