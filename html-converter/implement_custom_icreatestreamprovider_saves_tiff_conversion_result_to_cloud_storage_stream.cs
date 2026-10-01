// Implement a custom ICreateStreamProvider that saves TIFF conversion result to a cloud storage stream.

using System;
using System.IO;
using System.Collections.Generic;

class CustomStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        return GetStream(name, extension);
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for MemoryStream in this example
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
        _streams.Clear();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();
}

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";

            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (Stream epubStream = File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                var provider = new CustomStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                int index = 0;
                foreach (var ms in provider.Streams)
                {
                    ms.Position = 0;
                    string outputPath = $"output_page_{index}.tiff";
                    using (var fileStream = File.Create(outputPath))
                    {
                        ms.CopyTo(fileStream);
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