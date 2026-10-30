// Write a method that validates the MIME type of the source stream before performing MHTML conversion.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: Sample\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent, Encoding.UTF8);
            }

            // Open the source MHTML stream
            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);

            // Validate MIME type
            if (!ValidateMhtmlMimeType(stream))
            {
                throw new InvalidOperationException("The provided stream does not contain a valid MHTML MIME type.");
            }

            // Configure image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Perform conversion
            string outputPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static bool ValidateMhtmlMimeType(System.IO.Stream stream)
    {
        if (stream == null || !stream.CanRead || !stream.CanSeek)
            return false;

        long originalPosition = stream.Position;
        try
        {
            using (var reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8, true, 1024, true))
            {
                char[] buffer = new char[1024];
                int read = reader.ReadBlock(buffer, 0, buffer.Length);
                string header = new string(buffer, 0, read);
                return header.IndexOf("Content-Type: multipart/related", StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }
        finally
        {
            stream.Position = originalPosition;
        }
    }
}