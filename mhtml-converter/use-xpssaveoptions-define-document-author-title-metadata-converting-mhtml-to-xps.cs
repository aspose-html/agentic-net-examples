// Use XpsSaveOptions to define document author and title metadata when converting MHTML to XPS.

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
            // Prepare sample MHTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string mhtmlContent = "From: <saved by example>\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello, Aspose.HTML!</h1></body></html>\r\n------=_NextPart_000_0000--";
            File.WriteAllText(inputPath, mhtmlContent);

            // Define output XPS file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Create XpsSaveOptions (metadata properties like Author/Title are not available in this version)
            XpsSaveOptions options = new XpsSaveOptions();

            // Convert MHTML to XPS
            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}