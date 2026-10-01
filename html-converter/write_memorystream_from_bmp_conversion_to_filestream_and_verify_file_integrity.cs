// Write the MemoryStream obtained from BMP conversion to a FileStream and verify file integrity.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
        _streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file (replace with an existing file path or create a placeholder)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                // Create an empty placeholder file to avoid FileNotFoundException in the example
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Set up image save options for BMP format
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Create custom stream provider to capture in-memory output
                using (var provider = new MemoryStreamProvider())
                {
                    // Perform conversion
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    // Ensure at least one stream was generated
                    if (provider.Streams.Count == 0)
                    {
                        Console.WriteLine("No output streams were generated.");
                        return;
                    }

                    // Get the first generated memory stream
                    MemoryStream firstStream = provider.Streams[0];
                    firstStream.Position = 0;

                    // Write the memory stream to a file
                    string outputPath = "output.bmp";
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        firstStream.CopyTo(fileStream);
                    }

                    // Verify file integrity by comparing lengths
                    long memoryLength = firstStream.Length;
                    long fileLength = new FileInfo(outputPath).Length;

                    if (memoryLength == fileLength)
                    {
                        Console.WriteLine($"File saved successfully. Size verified: {fileLength} bytes.");
                    }
                    else
                    {
                        Console.WriteLine($"File size mismatch. Memory stream: {memoryLength} bytes, File: {fileLength} bytes.");
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