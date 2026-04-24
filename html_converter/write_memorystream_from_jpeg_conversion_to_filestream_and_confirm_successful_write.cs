// Write the MemoryStream obtained from JPEG conversion to a FileStream and confirm successful write.

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

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

    public void ReleaseStream(Stream stream) { /* No action needed */ }

    public void Dispose() { /* No action needed */ }
}

class Program
{
    static void Main()
    {
        try
        {
            // Input MHTML file path
            string inputPath = "input.mhtml";
            // Output JPEG file path
            string outputPath = "output.jpg";

            // Open the source MHTML file as a stream
            using Stream inputStream = File.OpenRead(inputPath);

            // Set JPEG image save options
            var options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Create a custom stream provider to capture the JPEG output in memory
            var provider = new MemoryStreamProvider();

            // Convert MHTML to JPEG, result is stored in the provider's memory streams
            Converter.ConvertMHTML(inputStream, options, provider);

            // Retrieve the first generated memory stream
            MemoryStream memory = provider.Streams.First();

            // Rewind the memory stream to the beginning
            memory.Seek(0, SeekOrigin.Begin);

            // Write the memory stream contents to a file
            using FileStream fs = File.Create(outputPath);
            memory.CopyTo(fs);

            Console.WriteLine("JPEG image saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}