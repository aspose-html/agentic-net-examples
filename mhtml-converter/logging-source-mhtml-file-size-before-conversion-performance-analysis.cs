// Implement logging of source MHTML file size before conversion to assist in performance analysis.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello, MHTML!</h1></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                long size = inputStream.Length;
                Console.WriteLine($"Source MHTML size: {size} bytes");

                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}