// Write code to convert MHTML to PDF and then embed a cover page generated from a separate HTML file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string mhtmlPath = Path.Combine(baseDir, "input.mhtml");
            string coverHtmlPath = Path.Combine(baseDir, "cover.html");
            string outputPdfPath = Path.Combine(baseDir, "output.pdf");
            string coverPdfPath = Path.Combine(baseDir, "cover.pdf");

            // Convert the MHTML document to PDF
            FileStream mhtmlStream = File.OpenRead(mhtmlPath);
            PdfSaveOptions pdfOptions = new PdfSaveOptions();
            Converter.ConvertMHTML(mhtmlStream, pdfOptions, outputPdfPath);
            mhtmlStream.Dispose();

            // Convert the cover HTML page to PDF
            HTMLDocument coverDoc = new HTMLDocument(coverHtmlPath);
            PdfSaveOptions coverOptions = new PdfSaveOptions();
            Converter.ConvertHTML(coverDoc, coverOptions, coverPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}