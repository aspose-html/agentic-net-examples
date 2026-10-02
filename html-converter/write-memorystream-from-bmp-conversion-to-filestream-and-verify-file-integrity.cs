// Write the MemoryStream obtained from BMP conversion to a FileStream and verify file integrity.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
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
        // No action needed for in-memory streams
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                var options = new ImageSaveOptions(ImageFormat.Bmp);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        MemoryStream firstStream = provider.Streams[0];
                        firstStream.Position = 0;

                        string outputPath = "output.bmp";
                        using (FileStream fileStream = File.Create(outputPath))
                        {
                            firstStream.CopyTo(fileStream);
                        }

                        // Verify file integrity
                        firstStream.Position = 0;
                        byte[] originalBytes = firstStream.ToArray();
                        byte[] fileBytes = File.ReadAllBytes(outputPath);
                        bool isEqual = originalBytes.SequenceEqual(fileBytes);
                        Console.WriteLine(isEqual ? "File integrity verified." : "File integrity check failed.");
                    }
                    else
                    {
                        Console.WriteLine("No image streams were generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}