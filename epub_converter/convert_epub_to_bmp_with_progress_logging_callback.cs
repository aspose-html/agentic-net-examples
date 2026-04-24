// Convert EPUB to BMP while logging conversion progress through a callback function supplied to the Converter.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class LoggingStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _outputPath;

    public LoggingStreamProvider(string outputPath)
    {
        _outputPath = outputPath;
    }

    public Stream GetStream(string name, string extension)
    {
        Console.WriteLine($"[Log] Creating output stream for {name}{extension}");
        return new FileStream(_outputPath, FileMode.Create, FileAccess.Write);
    }

    public Stream GetStream(string name, string extension, int index)
    {
        Console.WriteLine($"[Log] Creating output stream for {name}{extension} (index {index})");
        return new FileStream(_outputPath, FileMode.Create, FileAccess.Write);
    }

    public void ReleaseStream(Stream stream)
    {
        Console.WriteLine("[Log] Releasing output stream");
        stream?.Dispose();
    }

    public void Dispose()
    {
        Console.WriteLine("[Log] Disposing stream provider");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputBmpPath = "output.bmp";

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                using (LoggingStreamProvider provider = new LoggingStreamProvider(outputBmpPath))
                {
                    Converter.ConvertEPUB(epubStream, options, provider);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}