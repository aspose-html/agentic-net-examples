// Write the MemoryStream obtained from GIF conversion to a FileStream and handle any I/O exceptions.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams in this example
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
        _streams.Clear();
    }

    public MemoryStream GetFirstStream()
    {
        return _streams.Count > 0 ? _streams[0] : null;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Ensure the input file exists (create a placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (var provider = new MemoryStreamProvider())
            using (var epubStream = File.OpenRead(inputPath))
            {
                var options = new ImageSaveOptions(ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                MemoryStream gifStream = provider.GetFirstStream();
                if (gifStream != null)
                {
                    gifStream.Position = 0;
                    try
                    {
                        using (FileStream file = File.Create(outputPath))
                        {
                            gifStream.CopyTo(file);
                        }
                        Console.WriteLine($"GIF saved to '{outputPath}'.");
                    }
                    catch (IOException ioEx)
                    {
                        Console.WriteLine($"I/O error while writing the GIF: {ioEx.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("No GIF stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}