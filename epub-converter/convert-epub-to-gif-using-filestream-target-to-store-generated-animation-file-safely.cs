// Convert EPUB to GIF using a FileStream target to store the generated animation file safely.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
            string epubPath = "sample.epub";
            string outputPath = "output.gif";

            // Ensure a sample EPUB file exists (placeholder content)
            if (!File.Exists(epubPath))
            {
                using (FileStream fs = File.Create(epubPath))
                {
                    // Write minimal placeholder bytes
                    byte[] placeholder = new byte[] { 0x50, 0x4B, 0x03, 0x04 }; // ZIP header (EPUB is a ZIP)
                    fs.Write(placeholder, 0, placeholder.Length);
                }
            }

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    Stream gifStream = provider.GetFirstStream();
                    if (gifStream != null)
                    {
                        gifStream.Position = 0;
                        using (FileStream outputFile = File.Create(outputPath))
                        {
                            gifStream.CopyTo(outputFile);
                        }
                        Console.WriteLine("EPUB successfully converted to GIF: " + outputPath);
                    }
                    else
                    {
                        Console.WriteLine("Conversion completed, but no GIF stream was generated.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}