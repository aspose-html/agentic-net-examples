// Use a custom stream provider to write PNG output directly to a file.

using System;
using System.IO;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class FileStreamProvider : ICreateStreamProvider, IDisposable
{
    private readonly string _outputPath;
    private readonly string _outputDir;

    public FileStreamProvider(string outputPath)
    {
        _outputPath = outputPath;
        _outputDir = Path.GetDirectoryName(outputPath);
        if (!Directory.Exists(_outputDir))
            Directory.CreateDirectory(_outputDir);
    }

    // Called for formats that do not require page numbers (single page output)
    public Stream GetStream(string path, string mimeType)
    {
        return new FileStream(_outputPath, FileMode.Create, FileAccess.Write);
    }

    // Called when the converter generates multiple pages; each page gets its own file
    public Stream GetStream(string path, string mimeType, int pageNumber)
    {
        string fileName = $"{Path.GetFileNameWithoutExtension(_outputPath)}_page{pageNumber}{Path.GetExtension(_outputPath)}";
        string fullPath = Path.Combine(_outputDir, fileName);
        return new FileStream(fullPath, FileMode.Create, FileAccess.Write);
    }

    public void ReleaseStream(Stream stream)
    {
        stream?.Dispose();
    }

    public void Dispose()
    {
        // No unmanaged resources to release
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string epubPath = "sample.epub";

            // Desired output PNG file (or base name for multiple pages)
            string outputPath = "output.png";

            // Open the EPUB file as a stream
            using Stream epubStream = File.OpenRead(epubPath);

            // Set up image save options (defaults to PNG)
            ImageSaveOptions options = new ImageSaveOptions();

            // Create the custom stream provider that writes directly to a file
            using ICreateStreamProvider provider = new FileStreamProvider(outputPath);

            // Perform the conversion; the provider supplies the output streams
            Converter.ConvertEPUB(epubStream, options, provider);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}