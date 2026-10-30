// Use a custom ICreateStreamProvider to store GIF output directly into a cloud storage bucket.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private List<MemoryStream> _streams = new List<MemoryStream>();

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

    public Stream GetFirstStream()
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
            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                Stream gifStream = provider.GetFirstStream();
                if (gifStream != null)
                {
                    gifStream.Position = 0;
                    string outputPath = "output.gif";
                    using (FileStream file = File.Create(outputPath))
                    {
                        gifStream.CopyTo(file);
                    }
                    Console.WriteLine($"GIF saved to {outputPath}");
                }
                else
                {
                    Console.WriteLine("No GIF stream was generated.");
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