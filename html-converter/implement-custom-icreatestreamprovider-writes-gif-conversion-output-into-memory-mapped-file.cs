// Implement a custom ICreateStreamProvider that writes GIF conversion output into a memory‑mapped file.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryMappedFileStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryMappedFile> _files = new List<MemoryMappedFile>();
    private readonly List<Stream> _streams = new List<Stream>();

    public Stream GetStream(string name, string extension)
    {
        // Default capacity of 10 MB for each stream
        return GetStream(name, extension, 10 * 1024 * 1024);
    }

    public Stream GetStream(string name, string extension, int capacity)
    {
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
        foreach (var s in _streams)
        {
            s.Dispose();
        }
        foreach (var f in _files)
        {
            f.Dispose();
        }
        _streams.Clear();
        _files.Clear();
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
            string outputPath = "output.gif";

            // Ensure a sample input file exists (empty placeholder)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                using (var provider = new MemoryMappedFileStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    Stream gifStream = provider.GetFirstStream();
                    if (gifStream != null)
                    {
                        gifStream.Position = 0;
                        using (FileStream file = File.Create(outputPath))
                        {
                            gifStream.CopyTo(file);
                        }
                        Console.WriteLine($"GIF image saved to: {outputPath}");
                    }
                    else
                    {
                        Console.WriteLine("No GIF stream was generated.");
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