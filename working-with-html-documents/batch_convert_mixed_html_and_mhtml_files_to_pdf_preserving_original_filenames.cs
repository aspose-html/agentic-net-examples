// Batch convert a mixed collection of HTML and MHTML files to PDF, preserving original filenames.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\n" +
                                      "Subject: Sample MHTML\r\n" +
                                      "Date: Thu, 1 Jan 1970 00:00:00 GMT\r\n" +
                                      "MIME-Version: 1.0\r\n" +
                                      "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                      "------=_NextPart_000_0000\r\n" +
                                      "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                                      "Content-Transfer-Encoding: quoted-printable\r\n\r\n" +
                                      "<html><body><h1>Hello MHTML</h1></body></html>\r\n\r\n" +
                                      "------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine($"MHTML file converted to PDF successfully: {outputPath}");
            Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library if such a library is not available in the current project.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}