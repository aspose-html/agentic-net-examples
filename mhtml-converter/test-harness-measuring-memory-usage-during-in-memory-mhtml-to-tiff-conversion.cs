// Develop a test harness that measures memory usage during in‑memory MHTML to TIFF conversion.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.Collections.Generic.IReadOnlyList<MemoryStream> Streams => _streams;

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
        // No action needed; streams are kept for later use.
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
}

public class Program
{
    public static void Main()
    {
        try
        {
            string mhtmlPath = "sample.mhtml";
            if (!File.Exists(mhtmlPath))
            {
                string simpleHtml = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(mhtmlPath, simpleHtml);
            }

            using (FileStream inputStream = File.OpenRead(mhtmlPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                using (var provider = new MemoryStreamProvider())
                {
                    long memoryBefore = GC.GetTotalMemory(true);
                    Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, provider);
                    long memoryAfter = GC.GetTotalMemory(true);

                    Console.WriteLine($"Memory before: {memoryBefore} bytes");
                    Console.WriteLine($"Memory after : {memoryAfter} bytes");
                    Console.WriteLine($"Difference   : {memoryAfter - memoryBefore} bytes");

                    int index = 0;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outputPath = $"output_{index}.tiff";
                        using (FileStream file = File.Create(outputPath))
                        {
                            ms.CopyTo(file);
                        }
                        Console.WriteLine($"Saved TIFF: {outputPath}");
                        index++;
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