// Write code to convert MHTML to PDF and then embed a cover page generated from a separate HTML file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string coverHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "cover.html");
            string mhtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "document.mht");
            string coverPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "cover.pdf");
            string contentPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "content.pdf");
            string finalPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "final.pdf");

            // Create a simple cover HTML file if it does not exist
            if (!File.Exists(coverHtmlPath))
            {
                string coverHtml = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>Cover</title></head><body><h1 style='text-align:center;'>Cover Page</h1></body></html>";
                File.WriteAllText(coverHtmlPath, coverHtml);
            }

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(mhtmlPath))
            {
                string mhtmlContent = 
@"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h2>MHTML Document Content</h2></body></html>
------=_NextPart_000_0000--";
                File.WriteAllText(mhtmlPath, mhtmlContent);
            }

            // Convert cover HTML to PDF
            Aspose.Html.HTMLDocument coverDoc = new Aspose.Html.HTMLDocument(coverHtmlPath);
            Aspose.Html.Saving.PdfSaveOptions coverOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(coverDoc, coverOptions, coverPdfPath);

            // Convert MHTML to PDF
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions contentOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, contentOptions, contentPdfPath);
            }

            // Simple concatenation of PDFs to create a final document with cover page followed by content
            byte[] coverBytes = File.ReadAllBytes(coverPdfPath);
            byte[] contentBytes = File.ReadAllBytes(contentPdfPath);
            using (FileStream finalStream = File.Create(finalPdfPath))
            {
                finalStream.Write(coverBytes, 0, coverBytes.Length);
                finalStream.Write(contentBytes, 0, contentBytes.Length);
            }

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Cover PDF: " + coverPdfPath);
            Console.WriteLine("Content PDF: " + contentPdfPath);
            Console.WriteLine("Final PDF with cover page: " + finalPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}