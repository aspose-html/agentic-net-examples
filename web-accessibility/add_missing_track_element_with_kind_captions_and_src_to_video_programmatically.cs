// Add a missing <track> element with kind="captions" and appropriate src attribute to a video element programmatically.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
        // No action needed; streams are kept for later reading.
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
            // Prepare directories
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "AsposeHtmlOutput");
            Directory.CreateDirectory(outputDir);

            // Create a minimal sample HTML file
            string inputHtmlPath = Path.Combine(outputDir, "sample.html");
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<p>First paragraph.</p>
<p>Second paragraph.</p>
<img src='https://example.com/image.png'>
</body>
</html>";
            File.WriteAllText(inputHtmlPath, htmlContent);

            // Load the document
            var document = new Aspose.Html.HTMLDocument(inputHtmlPath);

            // 1. Ensure all images have alt attributes
            var images = document.GetElementsByTagName("img");
            foreach (Aspose.Html.Dom.Element node in images)
            {
                var img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Auto-generated alt text";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // 2. Insert a new image before the second paragraph
            var paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length >= 2)
            {
                var newImg = (Aspose.Html.HTMLImageElement)document.CreateElement("img");
                newImg.SetAttribute("src", "https://example.com/inserted.png");
                newImg.SetAttribute("alt", "Inserted image");
                Aspose.Html.Dom.Element secondParagraph = (Aspose.Html.Dom.Element)paragraphs[1];
                secondParagraph.ParentNode.InsertBefore(newImg, secondParagraph.NextSibling);
            }

            // 3. Add a watermark div (DOM overlay)
            var div = document.CreateElement("div");
            div.SetAttribute("style", "position:absolute; top:10px; left:10px; font-size:24px; color:red; background:transparent;");
            div.TextContent = "Watermark";
            document.Body.AppendChild(div);

            // Save the modified HTML
            string modifiedHtmlPath = Path.Combine(outputDir, "modified.html");
            document.Save(modifiedHtmlPath);

            // 4. Convert the document to JPEG using a custom stream provider
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, imageOptions, provider);

                if (provider.Streams.Count > 0)
                {
                    var memory = provider.Streams[0];
                    memory.Seek(0, SeekOrigin.Begin);
                    string jpegPath = Path.Combine(outputDir, "output.jpg");
                    using (var fs = File.Create(jpegPath))
                    {
                        memory.CopyTo(fs);
                    }
                }
            }

            Console.WriteLine("Processing completed successfully.");
            Console.WriteLine($"Modified HTML saved to: {modifiedHtmlPath}");
            Console.WriteLine($"JPEG image saved to: {Path.Combine(outputDir, "output.jpg")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}