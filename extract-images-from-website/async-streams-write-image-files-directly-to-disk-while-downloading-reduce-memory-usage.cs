// Use async streams to write image files directly to disk while downloading to reduce memory usage.

using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            // Define URLs and paths
            string epubUrl = "https://example.com/sample.epub";
            string tempEpubPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.epub");
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output_images");
            System.IO.Directory.CreateDirectory(outputDir);

            // Download EPUB asynchronously to a file to avoid loading into memory
            using (var httpClient = new System.Net.Http.HttpClient())
            using (var response = await httpClient.GetAsync(epubUrl, System.Net.Http.HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                using (var downloadStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new System.IO.FileStream(tempEpubPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None, 8192, true))
                {
                    await downloadStream.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
            }

            // Open the downloaded EPUB file as a read-only stream
            using (var epubStream = System.IO.File.OpenRead(tempEpubPath))
            {
                // Set image save options (BMP format)
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Create custom stream provider to capture generated images in memory
                using (var provider = new MemoryStreamProvider())
                {
                    // Convert EPUB to images using the provider
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);

                    // Write each generated image to disk asynchronously
                    for (int i = 0; i < provider.Streams.Count; i++)
                    {
                        var memoryStream = provider.Streams[i];
                        memoryStream.Position = 0;
                        string outputPath = System.IO.Path.Combine(outputDir, $"page_{i + 1}.bmp");
                        using (var outStream = new System.IO.FileStream(outputPath, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None, 8192, true))
                        {
                            await memoryStream.CopyToAsync(outStream);
                            await outStream.FlushAsync();
                        }
                    }
                }
            }

            Console.WriteLine("Conversion completed. Images saved to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}