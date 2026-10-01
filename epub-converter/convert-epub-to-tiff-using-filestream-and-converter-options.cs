// Convert EPUB to TIFF by opening a FileStream and passing it to Converter.ConvertEPUB with options.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    private System.Collections.Generic.List<System.IO.MemoryStream> _streams = new System.Collections.Generic.List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }

    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string outputDir = "output";

            // Ensure the input file exists (create an empty placeholder if necessary)
            if (!System.IO.File.Exists(epubPath))
            {
                using (var placeholder = System.IO.File.Create(epubPath))
                {
                    // Empty placeholder EPUB file
                }
            }

            System.IO.Directory.CreateDirectory(outputDir);

            using (System.IO.Stream epubStream = System.IO.File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                using (MemoryStreamProvider provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    int index = 0;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outPath = System.IO.Path.Combine(outputDir, $"page_{index}.tiff");
                        using (System.IO.FileStream file = System.IO.File.Create(outPath))
                        {
                            ms.CopyTo(file);
                        }
                        index++;
                    }
                }
            }

            Console.WriteLine("EPUB conversion to TIFF completed successfully.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}