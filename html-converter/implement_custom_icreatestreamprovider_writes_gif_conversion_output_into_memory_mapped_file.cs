// Implement a custom ICreateStreamProvider that writes GIF conversion output into a memory‑mapped file.

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryMappedFileStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryMappedFile> _files = new List<MemoryMappedFile>();
    private readonly List<Stream> _streams = new List<Stream>();

    public Stream GetStream(string name, string extension)
    {
        // Use a default capacity of 1 MB for the memory‑mapped file
        return GetStream(name, extension, 0);
    }

    public Stream GetStream(string name, string extension, int page)
    {
        const int capacity = 1024 * 1024; // 1 MB
        var mmf = MemoryMappedFile.CreateNew(Guid.NewGuid().ToString(), capacity);
        var stream = mmf.CreateViewStream();
        _files.Add(mmf);
        _streams.Add(stream);
        return stream;
    }

    public void ReleaseStream(Stream stream)
    {
        int index = _streams.IndexOf(stream);
        if (index >= 0)
        {
            _streams[index].Dispose();
            _files[index].Dispose();
            _streams.RemoveAt(index);
            _files.RemoveAt(index);
        }
    }

    public void Dispose()
    {
        foreach (var s in _streams) s.Dispose();
        foreach (var f in _files) f.Dispose();
        _streams.Clear();
        _files.Clear();
    }

    public IReadOnlyList<Stream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            const string inputPath = "sample.epub";
            const string outputPath = "output.gif";

            // Ensure a sample input file exists (empty placeholder)
            if (!File.Exists(inputPath))
            {
                using (File.Create(inputPath)) { }
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                var options = new ImageSaveOptions(ImageFormat.Gif);
                using (var provider = new MemoryMappedFileStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    if (provider.Streams.Count > 0)
                    {
                        Stream gifStream = provider.Streams[0];
                        gifStream.Position = 0;
                        using (FileStream file = File.Create(outputPath))
                        {
                            gifStream.CopyTo(file);
                        }
                        Console.WriteLine($"GIF image saved to: {outputPath}");
                    }
                    else
                    {
                        Console.WriteLine("No output stream was generated.");
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