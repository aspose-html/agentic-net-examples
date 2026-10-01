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
            // Define input and output paths
            string inputPath = "sample.mht";
            string outputPath = "output.jpg";

            // Ensure a sample MHTML file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n");
            }

            // Open the source MHTML file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Validate MIME type
                if (!IsValidMhtml(stream))
                {
                    throw new InvalidDataException("The provided file is not a valid MHTML document.");
                }

                // Configure image save options
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Validates that the stream contains an MHTML MIME header
    private static bool IsValidMhtml(Stream stream)
    {
        if (!stream.CanSeek)
            return false;

        long originalPosition = stream.Position;
        try
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, leaveOpen: true))
            {
                string firstLine = reader.ReadLine();
                return !string.IsNullOrEmpty(firstLine) && firstLine.IndexOf("Content-Type", StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }
        finally
        {
            // Reset stream position for further processing
            stream.Position = originalPosition;
        }
    }
}