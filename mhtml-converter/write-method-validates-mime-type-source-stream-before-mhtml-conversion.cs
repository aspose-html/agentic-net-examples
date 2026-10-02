// Write a method that validates the MIME type of the source stream before performing MHTML conversion.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.jpg";

            // Ensure a minimal MHTML file exists with correct MIME type header
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><p>Sample MHTML content.</p></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml, Encoding.UTF8);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                ValidateMimeType(stream);

                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ValidateMimeType(Stream stream)
    {
        if (!stream.CanSeek)
            throw new InvalidOperationException("Stream must support seeking.");

        long originalPosition = stream.Position;
        try
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, true))
            {
                string firstLine = reader.ReadLine();
                if (firstLine == null || !firstLine.Contains("multipart/related", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidDataException("The provided stream does not contain a valid MHTML MIME type.");
                }
            }
        }
        finally
        {
            stream.Position = originalPosition;
        }
    }
}