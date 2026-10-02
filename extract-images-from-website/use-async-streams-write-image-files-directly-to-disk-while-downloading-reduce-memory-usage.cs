// Use async streams to write image files directly to disk while downloading to reduce memory usage.

using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.IO;

class FileStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly string _outputDir;
    public List<string> FilePaths { get; } = new List<string>();

    public FileStreamProvider(string outputDir)
    {
        _outputDir = outputDir;
        Directory.CreateDirectory(_outputDir);
    }

    public Stream GetStream(string name, string extension)
    {
        string filePath = Path.Combine(_outputDir, $"{name}{extension}");
        var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
        FilePaths.Add(filePath);
        return fs;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        string filePath = Path.Combine(_outputDir, $"{name}_page{page}{extension}");
        var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true);
        FilePaths.Add(filePath);
        return fs;
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
        // No unmanaged resources to clean up in this example.
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // URL of the EPUB file to download (replace with a valid URL for real testing)
            string epubUrl = "https://example.com/sample.epub";
            string tempEpubPath = Path.Combine(Path.GetTempPath(), "sample.epub");

            // Download EPUB using async streams
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.GetAsync(epubUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                await using (Stream downloadStream = await response.Content.ReadAsStreamAsync())
                await using (FileStream fileStream = new FileStream(tempEpubPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true))
                {
                    await downloadStream.CopyToAsync(fileStream);
                }
            }

            // Convert EPUB pages to images, writing each image directly to disk via async streams
            using (FileStream epubStream = File.OpenRead(tempEpubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output_images");
                using var provider = new FileStreamProvider(outputDir);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, provider);
            }

            Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}