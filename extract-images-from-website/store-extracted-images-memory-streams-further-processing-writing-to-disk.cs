// Store extracted images in memory streams for further processing before writing to disk.

using System;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
{
    public System.Collections.Generic.List<System.IO.MemoryStream> Streams { get; } = new System.Collections.Generic.List<System.IO.MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new System.IO.MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var ms = new System.IO.MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
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
            string inputPath = "sample.epub";
            string outputDir = "output_images";

            System.IO.Directory.CreateDirectory(outputDir);

            using (System.IO.Stream epubStream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                int index = 0;
                foreach (var memoryStream in provider.Streams)
                {
                    memoryStream.Position = 0;
                    string outputPath = System.IO.Path.Combine(outputDir, $"image_{index}.png");
                    using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                    index++;
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}