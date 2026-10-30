// Convert EPUB to BMP using a FileStream to save the image file with explicit resource management.

using System;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, System.IDisposable
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string epubPath = "sample.epub";
            string outputPath = "output.bmp";

            // Create a minimal EPUB file if it does not exist
            if (!System.IO.File.Exists(epubPath))
            {
                System.IO.File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (System.IO.Stream epubStream = System.IO.File.OpenRead(epubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                var provider = new MemoryStreamProvider();

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                if (provider.Streams.Count > 0)
                {
                    var resultStream = provider.Streams[0];
                    resultStream.Position = 0;

                    using (System.IO.FileStream fileStream = System.IO.File.Create(outputPath))
                    {
                        resultStream.CopyTo(fileStream);
                    }

                    System.Console.WriteLine($"EPUB converted to BMP and saved to '{outputPath}'.");
                }
                else
                {
                    System.Console.WriteLine("No output streams were generated.");
                }

                provider.Dispose();
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}