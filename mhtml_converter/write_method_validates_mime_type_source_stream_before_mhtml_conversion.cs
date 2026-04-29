// Write a method that validates the MIME type of the source stream before performing MHTML conversion.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.jpg";

            using (Stream stream = File.OpenRead(inputPath))
            {
                ValidateMimeType(stream);
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed.");
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
        stream.Seek(0, SeekOrigin.Begin);
        using (StreamReader reader = new StreamReader(stream, leaveOpen: true))
        {
            char[] buffer = new char[1024];
            int read = reader.Read(buffer, 0, buffer.Length);
            string content = new string(buffer, 0, read);
            if (!content.Contains("multipart/related"))
                throw new InvalidOperationException("Invalid MIME type. Expected multipart/related.");
        }
        stream.Seek(originalPosition, SeekOrigin.Begin);
    }
}