// Write the MemoryStream obtained from TIFF conversion to a FileStream and log the file size.

using System;
using System.IO;
using System.Collections.Generic;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    System.IO.Stream Aspose.Html.IO.ICreateStreamProvider.GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    System.IO.Stream Aspose.Html.IO.ICreateStreamProvider.GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    void Aspose.Html.IO.ICreateStreamProvider.ReleaseStream(System.IO.Stream stream)
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
            // Ensure a sample input file exists
            const string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (System.IO.Stream inputStream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                int index = 0;
                foreach (var memoryStream in provider.Streams)
                {
                    memoryStream.Position = 0;
                    string outputPath = $"output_{index}.tiff";
                    using (System.IO.FileStream fileStream = System.IO.File.Create(outputPath))
                    {
                        memoryStream.CopyTo(fileStream);
                        fileStream.Flush();
                        Console.WriteLine($"Saved file: {outputPath}, size: {fileStream.Length} bytes");
                    }
                    index++;
                }

                provider.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}