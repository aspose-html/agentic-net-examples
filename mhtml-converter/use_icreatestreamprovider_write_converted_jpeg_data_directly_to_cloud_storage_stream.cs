// Use ICreateStreamProvider to write converted JPEG data directly to a cloud storage stream.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        var memoryStream = new MemoryStream();
        _streams.Add(memoryStream);
        return memoryStream;
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // No action needed; streams are retained for later use.
    }

    public void Dispose()
    {
        foreach (var stream in _streams)
        {
            stream.Dispose();
        }
        _streams.Clear();
    }

    public System.Collections.Generic.IReadOnlyList<System.IO.MemoryStream> Streams => _streams;
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUrl = ".";

            // Create HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUrl);

            // Set up image save options for JPEG format
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Create custom stream provider to capture output in memory
            using (MemoryStreamProvider provider = new MemoryStreamProvider())
            {
                // Convert HTML to JPEG using the provider
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                // Ensure at least one stream was generated
                if (provider.Streams.Count > 0)
                {
                    System.IO.MemoryStream jpegStream = provider.Streams[0];
                    jpegStream.Seek(0, System.IO.SeekOrigin.Begin);

                    // Simulate cloud storage by writing to a file (replace with actual cloud stream as needed)
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "cloud-output.jpg");
                    using (System.IO.FileStream cloudStream = System.IO.File.Create(outputPath))
                    {
                        jpegStream.CopyTo(cloudStream);
                    }

                    Console.WriteLine("JPEG image successfully written to: " + outputPath);
                }
                else
                {
                    Console.WriteLine("No output streams were generated.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}