// Batch process HTML files, converting each to PDF with a watermark added via drawing API.

using System;
using System.IO;
using System.Collections.Generic;

class InMemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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
        // No action needed for in‑memory streams
    }

    public void Dispose()
    {
        foreach (var s in _streams)
        {
            s.Dispose();
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Prepare input HTML files
            string[] inputs = new string[] { "input1.html", "input2.html" };
            string sampleHtml = "<html><body><h1>Hello World</h1></body></html>";
            foreach (var input in inputs)
            {
                if (!File.Exists(input))
                {
                    File.WriteAllText(input, sampleHtml);
                }
            }

            // Process each input file
            for (int i = 0; i < inputs.Length; i++)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputs[i], new Aspose.Html.Configuration()))
                {
                    // Add watermark element
                    Aspose.Html.Dom.Element div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute;top:10px;left:10px;color:red;font-size:24px;");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);

                    // Convert to JPEG image using in‑memory provider
                    Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    var provider = new InMemoryStreamProvider();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, provider);

                    // Save the image to file
                    MemoryStream memory = provider.Streams[0];
                    memory.Seek(0, SeekOrigin.Begin);
                    string imagePath = Path.Combine(outputDir, $"output_{i}.jpg");
                    using (FileStream fs = File.Create(imagePath))
                    {
                        memory.CopyTo(fs);
                    }

                    // Convert to PDF directly to file
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    string pdfPath = Path.Combine(outputDir, $"output_{i}.pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}