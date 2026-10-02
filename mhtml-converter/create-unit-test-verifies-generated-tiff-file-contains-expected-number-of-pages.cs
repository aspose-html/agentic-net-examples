// Create a unit test that verifies the generated TIFF file contains the expected number of pages.

using System;
using System.IO;
using System.Collections.Generic;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams;

    public Stream GetStream(string name, string extension)
    {
        return GetStream(name, extension, 0);
    }

    public Stream GetStream(string name, string extension, int page)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed for in-memory streams
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

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a minimal HTML file with two pages
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, "<html><body><div style='page-break-after:always;'>Page 1</div><div>Page 2</div></body></html>");

            using (var document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                    int pageCount = provider.Streams.Count;
                    int expectedPages = 2;

                    if (pageCount != expectedPages)
                    {
                        throw new Exception($"TIFF page count mismatch. Expected {expectedPages}, but got {pageCount}.");
                    }

                    // Save each page stream to a separate TIFF file (optional verification)
                    int index = 1;
                    foreach (var ms in provider.Streams)
                    {
                        ms.Position = 0;
                        string outPath = $"page_{index}.tiff";
                        using (var file = File.Create(outPath))
                        {
                            ms.CopyTo(file);
                        }
                        index++;
                    }

                    Console.WriteLine($"TIFF conversion verification passed. Page count: {pageCount}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}