// Create a custom ICreateStreamProvider that writes JPEG streams to a network location during conversion.

using System;
using System.IO;
using System.Collections.Generic;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are retained for later use.
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Input EPUB file (ensure this file exists or replace with a valid path)
            string inputPath = "sample.epub";
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Configure JPEG image save options
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                // Create custom stream provider to capture JPEG streams
                var provider = new MemoryStreamProvider();

                // Convert EPUB to JPEG images using the provider
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                // Write each generated JPEG stream to a network location
                for (int i = 0; i < provider.Streams.Count; i++)
                {
                    var memoryStream = provider.Streams[i];
                    memoryStream.Position = 0; // Rewind before reading

                    // Example network share path (replace with actual network location)
                    string outputPath = $@"\\networkshare\output\page_{i + 1}.jpg";

                    // Ensure the directory exists
                    string directory = Path.GetDirectoryName(outputPath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    using (FileStream file = File.Create(outputPath))
                    {
                        memoryStream.CopyTo(file);
                    }

                    Console.WriteLine($"Saved page {i + 1} to {outputPath}");
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}