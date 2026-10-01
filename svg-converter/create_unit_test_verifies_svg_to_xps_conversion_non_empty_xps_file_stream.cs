// Create a unit test that verifies SVG to XPS conversion produces a non‑empty XPS file stream.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Html.IO;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.IO.Stream GetStream(string name, string extension)
    {
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        return GetStream(name, extension);
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        // Flush but do not close; the stream will be used later.
        stream.Flush();
    }

    public IReadOnlyList<MemoryStream> Streams => _streams.AsReadOnly();

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
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='green'/></svg>";
            string baseUri = "http://example.com/";

            // Convert SVG string to PDF using a stream provider
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, pdfOptions, provider);
                if (provider.Streams.Count > 0)
                {
                    var pdfStream = provider.Streams[0];
                    pdfStream.Position = 0;
                    using (var file = File.Create("output_from_provider.pdf"))
                    {
                        pdfStream.CopyTo(file);
                    }
                    Console.WriteLine("PDF saved via stream provider: output_from_provider.pdf");
                }
                else
                {
                    Console.WriteLine("No PDF stream was produced by the provider.");
                }
            }

            // Write SVG content to a temporary file for file‑based conversions
            string svgPath = "sample.svg";
            File.WriteAllText(svgPath, svgContent);

            // Convert SVG file to XPS
            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, xpsOptions, "output_file.xps");
            Console.WriteLine("XPS saved from file: output_file.xps");

            // Convert SVG file to JPEG image
            var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, imgOptions, "output_image.jpg");
            Console.WriteLine("Image saved from file: output_image.jpg");

            // Convert SVGDocument with page setup to XPS
            var svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent);
            var xpsOptions2 = new Aspose.Html.Saving.XpsSaveOptions
            {
                HorizontalResolution = 300,
                VerticalResolution = 300,
                BackgroundColor = System.Drawing.Color.AliceBlue
            };
            var page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            xpsOptions2.PageSetup.AnyPage = page;
            Aspose.Html.Converters.Converter.ConvertSVG(svgDoc, xpsOptions2, "output_document.xps");
            Console.WriteLine("XPS saved from SVGDocument with page setup: output_document.xps");

            // Convert HTML content containing SVG to PDF
            string htmlContent = $"<html><body>{svgContent}</body></html>";
            var htmlBaseUri = new Aspose.Html.Url(baseUri);
            var htmlDoc = new Aspose.Html.HTMLDocument(htmlContent, htmlBaseUri);
            string tempHtmlPath = "temp.html";
            htmlDoc.Save(tempHtmlPath);
            var pdfOptions2 = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(tempHtmlPath, pdfOptions2, "output_html.pdf");
            Console.WriteLine("PDF saved from HTML document: output_html.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}