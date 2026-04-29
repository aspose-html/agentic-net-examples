// Load an SVG from a memory stream and convert it directly to BMP using ImageSaveOptions.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string path, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string path, string extension, int index)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for memory streams
    }

    public void Dispose()
    {
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
        Streams.Clear();
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Load SVG data into a memory stream
            using (var svgFileStream = new MemoryStream(File.ReadAllBytes("input.svg")))
            using (var reader = new StreamReader(svgFileStream))
            {
                string svgContent = reader.ReadToEnd();

                // Prepare BMP image save options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Create a custom stream provider to capture the output in memory
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert SVG content to BMP, writing the result to the provider
                    Converter.ConvertSVG(svgContent, ".", options, provider);

                    // Retrieve the generated BMP bytes from the first memory stream
                    byte[] bmpBytes = provider.Streams[0].ToArray();

                    // Optionally, write the BMP to a file
                    File.WriteAllBytes("output.bmp", bmpBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}