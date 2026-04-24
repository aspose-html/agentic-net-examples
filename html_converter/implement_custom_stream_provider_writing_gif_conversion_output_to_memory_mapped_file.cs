// Implement a custom ICreateStreamProvider that writes GIF conversion output into a memory‑mapped file.

using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class MemoryMappedGifProvider : ICreateStreamProvider, IDisposable
{
    // Store created memory‑mapped files and their streams
    private System.Collections.Generic.List<MemoryMappedFile> _files = new System.Collections.Generic.List<MemoryMappedFile>();
    private System.Collections.Generic.List<Stream> _streams = new System.Collections.Generic.List<Stream>();

    // Default GetStream implementation
    public Stream GetStream(string path, string extension)
    {
        // Use a default capacity (1 MB) if not specified
        return GetStream(path, extension, 1024 * 1024);
    }

    // Create a new memory‑mapped file and return its view stream
    public Stream GetStream(string path, string extension, int capacity)
    {
        var mmf = MemoryMappedFile.CreateNew(Guid.NewGuid().ToString(), capacity);
        var stream = mmf.CreateViewStream();
        _files.Add(mmf);
        _streams.Add(stream);
        return stream;
    }

    // Release a specific stream and its associated memory‑mapped file
    public void ReleaseStream(Stream streamParam)
    {
        int index = _streams.IndexOf(streamParam);
        if (index >= 0)
        {
            _streams[index].Dispose();
            _files[index].Dispose();
            _streams.RemoveAt(index);
            _files.RemoveAt(index);
        }
    }

    // Dispose all resources
    public void Dispose()
    {
        foreach (var s in _streams) s.Dispose();
        foreach (var f in _files) f.Dispose();
    }

    // Helper to retrieve the first generated stream
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
            // Open the EPUB source file
            FileStream epubStream = File.OpenRead("input.epub");

            // Configure conversion to GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Instantiate the custom memory‑mapped stream provider
            MemoryMappedGifProvider provider = new MemoryMappedGifProvider();

            // Perform the conversion; output will be written to streams supplied by the provider
            Converter.ConvertEPUB(epubStream, options, provider);

            // Retrieve the first generated GIF stream
            Stream gifStream = provider.GetFirstStream();

            if (gifStream != null)
            {
                // Reset position before reading
                gifStream.Position = 0;

                // Persist the GIF to a file (optional)
                using (FileStream file = File.Create("output.gif"))
                {
                    gifStream.CopyTo(file);
                }
            }
        }
        catch (Exception ex)
        {
            // Simple error handling
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}