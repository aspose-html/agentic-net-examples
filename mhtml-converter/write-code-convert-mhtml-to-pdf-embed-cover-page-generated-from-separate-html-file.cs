// Write code to convert MHTML to PDF and then embed a cover page generated from a separate HTML file.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string coverHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "cover.html");
            string mhtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "content.mht");
            string coverPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "cover.pdf");
            string contentPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "content.pdf");
            string finalPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "final.pdf");

            // Create a minimal cover HTML file if it does not exist
            if (!File.Exists(coverHtmlPath))
            {
                File.WriteAllText(coverHtmlPath, "<html><body><h1>Cover Page</h1></body></html>");
            }

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(mhtmlPath))
            {
                // Simple MHTML content with a basic HTML part
                string mhtmlContent = "From: <Saved by WebKit>\r\n" +
                                      "Subject: \r\n" +
                                      "Date: Thu, 1 Jan 1970 00:00:00 GMT\r\n" +
                                      "MIME-Version: 1.0\r\n" +
                                      "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                      "------=_NextPart_000_0000\r\n" +
                                      "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                                      "Content-Transfer-Encoding: quoted-printable\r\n\r\n" +
                                      "<html><body><p>Hello from MHTML content.</p></body></html>\r\n" +
                                      "------=_NextPart_000_0000--";
                File.WriteAllText(mhtmlPath, mhtmlContent);
            }

            // Convert cover HTML to PDF
            Aspose.Html.HTMLDocument coverDoc = new Aspose.Html.HTMLDocument(coverHtmlPath);
            Aspose.Html.Saving.PdfSaveOptions coverPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(coverDoc, coverPdfOptions, coverPdfPath);

            // Convert MHTML to PDF
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions contentPdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, contentPdfOptions, contentPdfPath);
            }

            // Merge cover PDF and content PDF into final PDF
            using (FileStream finalStream = new FileStream(finalPdfPath, FileMode.Create, FileAccess.Write))
            {
                using (FileStream coverStream = new FileStream(coverPdfPath, FileMode.Open, FileAccess.Read))
                {
                    coverStream.CopyTo(finalStream);
                }
                using (FileStream contentStream = new FileStream(contentPdfPath, FileMode.Open, FileAccess.Read))
                {
                    contentStream.CopyTo(finalStream);
                }
            }

            Console.WriteLine("PDF with cover page created successfully at:");
            Console.WriteLine(finalPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}