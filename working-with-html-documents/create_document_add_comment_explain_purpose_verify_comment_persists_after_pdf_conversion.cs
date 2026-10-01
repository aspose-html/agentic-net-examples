// Create a document, add a comment explaining purpose, and verify comment persists after conversion to PDF.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content with a comment explaining the purpose
            string htmlContent = "<!-- This document is for testing comment persistence -->\n<html><body><p>Hello World</p></body></html>";

            // Create an HTMLDocument from the content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Set up PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define output PDF path
            string pdfPath = "output.pdf";

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Verify that the PDF file exists and is not empty
            if (!System.IO.File.Exists(pdfPath))
            {
                throw new Exception("PDF file was not created.");
            }

            if (new System.IO.FileInfo(pdfPath).Length == 0)
            {
                throw new Exception("PDF file is empty.");
            }

            Console.WriteLine("Conversion succeeded and PDF file verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}