// Convert an SVG loaded from a memory stream directly to BMP using ConvertSVG overload with ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

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
        return GetStream(name, extension);
    }

    public void ReleaseStream(Stream stream)
    {
        stream.Flush();
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
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

            using (var provider = new MemoryStreamProvider())
            {
                // Convert SVG content to BMP using an in‑memory stream provider
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, "about:blank", options, provider);

                if (provider.Streams.Count > 0)
                {
                    var resultStream = provider.Streams[0];
                    resultStream.Position = 0;
                    byte[] bmpBytes = resultStream.ToArray();
                    string outputPath = "output.bmp";
                    File.WriteAllBytes(outputPath, bmpBytes);
                    Console.WriteLine($"BMP image saved to: {outputPath}");
                }
                else
                {
                    Console.WriteLine("No output stream was generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}