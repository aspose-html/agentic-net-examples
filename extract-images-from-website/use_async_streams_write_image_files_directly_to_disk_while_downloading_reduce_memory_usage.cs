// Use async streams to write image files directly to disk while downloading to reduce memory usage.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    public List<MemoryStream> Streams { get; } = new List<MemoryStream>();

    public Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        Streams.Add(ms);
        return ms;
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
        foreach (var ms in Streams)
        {
            ms.Dispose();
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            await File.WriteAllTextAsync(inputPath, htmlContent);

            // Output image path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            // Open input stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Load HTML document
                using (HTMLDocument document = new HTMLDocument(inputStream, ""))
                {
                    // Set image save options
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    // Create custom stream provider
                    using (MemoryStreamProvider provider = new MemoryStreamProvider())
                    {
                        // Convert HTML to image using provider
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                        // Write each generated image stream directly to disk asynchronously
                        int index = 0;
                        foreach (MemoryStream ms in provider.Streams)
                        {
                            ms.Position = 0;
                            string filePath = outputPath;
                            if (provider.Streams.Count > 1)
                            {
                                filePath = Path.Combine(Directory.GetCurrentDirectory(), $"output_{index}.jpg");
                            }

                            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                            {
                                await ms.CopyToAsync(fileStream);
                            }

                            index++;
                        }
                    }
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}