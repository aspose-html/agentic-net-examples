// Ensure caption tracks contain synchronized timestamps matching the associated media timeline.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

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
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(Stream stream)
    {
        // No action needed; streams are kept for later use.
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
            // Prepare sample HTML file
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            string currentDir = Directory.GetCurrentDirectory();
            string inputHtmlPath = Path.Combine(currentDir, "sample.html");
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // Get all paragraph elements
            var paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length >= 2)
            {
                // Create an image element
                var img = document.CreateElement("img");
                img.SetAttribute("src", "https://via.placeholder.com/150");
                img.SetAttribute("alt", "Placeholder Image");

                // Insert the image after the second paragraph
                var secondParagraph = (Aspose.Html.Dom.Element)paragraphs[1];
                secondParagraph.ParentNode.InsertBefore(img, secondParagraph.NextSibling);
            }

            // Save modified HTML
            string outputHtmlPath = Path.Combine(currentDir, "output.html");
            var saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputHtmlPath, saveOptions);

            // Load document from URL with timeout
            string url = "https://example.com";
            var request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(10);
            var urlDocument = new Aspose.Html.HTMLDocument(request);
            string urlHtml = ((Aspose.Html.HTMLElement)urlDocument.DocumentElement).OuterHTML;

            // Add watermark using DOM overlay (as per task intent)
            var div = document.CreateElement("div");
            div.SetAttribute("style", "position:absolute;top:10px;left:10px;color:red;font-size:24px;");
            div.TextContent = "Watermark";
            document.Body.AppendChild(div);

            // Convert HTML to JPEG image using a stream provider
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, imageOptions, provider);
                if (provider.Streams.Count > 0)
                {
                    var memory = provider.Streams[0];
                    memory.Seek(0, SeekOrigin.Begin);
                    string outputImagePath = Path.Combine(currentDir, "output.jpg");
                    using (var fs = File.Create(outputImagePath))
                    {
                        memory.CopyTo(fs);
                    }
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}