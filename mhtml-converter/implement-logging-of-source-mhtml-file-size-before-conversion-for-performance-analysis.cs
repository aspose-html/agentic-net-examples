// Implement logging of source MHTML file size before conversion to assist in performance analysis.

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
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.docx");

            // Ensure a minimal MHTML file exists
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000_01D4C8E0.12345678\"\r\n\r\n------=_NextPart_000_0000_01D4C8E0.12345678\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello, MHTML!</h1></body></html>\r\n------=_NextPart_000_0000_01D4C8E0.12345678--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Open the MHTML file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Log the size of the source MHTML file
                Console.WriteLine($"Source MHTML file size: {inputStream.Length} bytes");

                // Set conversion options (e.g., DOCX output)
                DocSaveOptions options = new DocSaveOptions();

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, outputPath);
            }

            Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}