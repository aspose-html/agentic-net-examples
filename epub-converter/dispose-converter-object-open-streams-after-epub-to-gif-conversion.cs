// Dispose of the Converter object and any open streams after completing EPUB to GIF conversion.

using System;

class MemoryMappedStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    private System.Collections.Generic.List<System.IO.MemoryMappedFiles.MemoryMappedFile> files = new System.Collections.Generic.List<System.IO.MemoryMappedFiles.MemoryMappedFile>();
    private System.Collections.Generic.List<System.IO.Stream> streams = new System.Collections.Generic.List<System.IO.Stream>();

    public System.IO.Stream GetStream(string path, string extension)
    {
        return GetStream(path, extension, 0);
    }

    public System.IO.Stream GetStream(string path, string extension, int capacity)
    {
        int size = capacity > 0 ? capacity : 1024 * 1024;
        var mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateNew(System.Guid.NewGuid().ToString(), size);
        var stream = mmf.CreateViewStream();
        files.Add(mmf);
        streams.Add(stream);
        return stream;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        int index = streams.IndexOf(stream);
        if (index >= 0)
        {
            streams[index].Dispose();
            files[index].Dispose();
            streams.RemoveAt(index);
            files.RemoveAt(index);
        }
    }

    public void Dispose()
    {
        foreach (var s in streams)
        {
            s.Dispose();
        }
        foreach (var f in files)
        {
            f.Dispose();
        }
    }

    public System.IO.Stream GetFirstStream()
    {
        return streams.Count > 0 ? streams[0] : null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string epubPath = "sample.epub";
            string outputPath = "output.gif";

            // Ensure the input EPUB file exists; for demonstration, create an empty file if missing.
            if (!System.IO.File.Exists(epubPath))
            {
                using (var empty = System.IO.File.Create(epubPath))
                {
                    // No content needed for this example.
                }
            }

            System.IO.FileStream epubStream = new System.IO.FileStream(epubPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var provider = new MemoryMappedStreamProvider();
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

            System.IO.Stream gifStream = provider.GetFirstStream();
            if (gifStream != null)
            {
                gifStream.Position = 0;
                using (var file = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    gifStream.CopyTo(file);
                }
            }

            // Cleanup
            provider.Dispose();
            epubStream.Dispose();

            System.Console.WriteLine("Conversion completed. GIF saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}