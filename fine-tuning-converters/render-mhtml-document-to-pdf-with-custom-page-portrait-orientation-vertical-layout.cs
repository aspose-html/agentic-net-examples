// Render an MHTML document to PDF with a custom page orientation set to Portrait for vertical layout.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mht";
            string resultPath = "output.pdf";

            // Create a minimal MHTML file
            string mhtmlContent = "From: <Saved by WebKit>\r\n" +
                                  "Subject: \r\n" +
                                  "Date: \r\n" +
                                  "MIME-Version: 1.0\r\n" +
                                  "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                  "------=_NextPart_000_0000\r\n" +
                                  "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                                  "Content-Transfer-Encoding: quoted-printable\r\n\r\n" +
                                  "<html><body><h1>Hello MHTML</h1></body></html>\r\n\r\n" +
                                  "------=_NextPart_000_0000--";
            File.WriteAllText(sourcePath, mhtmlContent);

            // Configure PDF save options with portrait orientation
            PdfSaveOptions options = new PdfSaveOptions();
            options.PageSetup.AnyPage = new Page(new Size(595, 842)); // A4 portrait in points

            // Convert MHTML to PDF
            Aspose.Html.Converters.Converter.ConvertMHTML(sourcePath, options, resultPath);

            Console.WriteLine("MHTML successfully converted to PDF at: " + Path.GetFullPath(resultPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}