// Write the MemoryStream obtained from TIFF conversion to a FileStream and log the file size.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (create a dummy file if it does not exist)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // minimal ZIP header
            }

            // Open input stream
            System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath);

            // Set image save options for TIFF
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

            // Create custom stream provider to capture in‑memory TIFF streams
            MemoryStreamProvider provider = new MemoryStreamProvider();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

            // Save each generated TIFF stream to a file and log its size
            int index = 0;
            foreach (System.IO.MemoryStream ms in provider.Streams)
            {
                ms.Position = 0;
                string outputPath = $"output_{index}.tiff";
                using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    ms.CopyTo(fileStream);
                    fileStream.Flush();
                    Console.WriteLine($"Saved '{outputPath}', size: {fileStream.Length} bytes");
                }
                index++;
            }

            // Cleanup
            provider.Dispose();
            inputStream.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom provider implementing Aspose.Html.IO.ICreateStreamProvider
class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<System.IO.MemoryStream> _streams = new List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed; streams are kept for later use
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }

    // Expose the captured streams for processing
    public IReadOnlyList<System.IO.MemoryStream> Streams => _streams;
}