// Verify that the Converter object releases unmanaged resources by checking memory usage after multiple conversions.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class CustomStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            const string epubPath = "sample.epub"; // replace with actual EPUB file path
            const int iterations = 10;

            var process = Process.GetCurrentProcess();
            long memoryBefore = process.PrivateMemorySize64;
            Console.WriteLine($"Memory before conversions: {memoryBefore} bytes");

            for (int i = 0; i < iterations; i++)
            {
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    var options = new ImageSaveOptions(ImageFormat.Png);
                    var provider = new CustomStreamProvider();

                    Converter.ConvertEPUB(epubStream, options, provider);

                    // Dispose provider to release memory streams
                    provider.Dispose();
                }
            }

            // Force garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            long memoryAfter = process.PrivateMemorySize64;
            Console.WriteLine($"Memory after conversions: {memoryAfter} bytes");
            Console.WriteLine($"Memory difference: {memoryAfter - memoryBefore} bytes");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}