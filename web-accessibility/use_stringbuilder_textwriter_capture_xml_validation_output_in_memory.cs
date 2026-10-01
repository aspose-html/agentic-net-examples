// Use a StringBuilder with a TextWriter to capture XML validation output in memory.

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
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

public class Program
{
    public static void Main()
    {
        try
        {
            // Step 1: Convert HTML to XPS using a stream provider
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            using (var provider = new MemoryStreamProvider())
            {
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, xpsOptions, provider);
                var xpsStream = provider.Streams[0];
                xpsStream.Position = 0;
                string xpsOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.xps");
                using (var fs = File.Create(xpsOutputPath))
                {
                    xpsStream.CopyTo(fs);
                }
            }

            // Step 2: Accessibility validation
            using (var document = new Aspose.Html.HTMLDocument("<!DOCTYPE html><html><body><p>Sample</p></body></html>"))
            {
                var validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                var validationResult = validator.Validate(document);
                using (var sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    Console.WriteLine("Accessibility validation result:");
                    Console.WriteLine(sw.ToString());
                }
            }

            // Step 3: Convert multiple HTML files to JPEG images
            string outputDirImages = Path.Combine(Directory.GetCurrentDirectory(), "output_images");
            Directory.CreateDirectory(outputDirImages);
            string[] inputs = new string[]
            {
                Path.Combine(Directory.GetCurrentDirectory(), "sample1.html"),
                Path.Combine(Directory.GetCurrentDirectory(), "sample2.html")
            };
            foreach (var path in inputs)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "<html><body><p>Content</p></body></html>");
                }
            }

            for (int i = 0; i < inputs.Length; i++)
            {
                using (var document = new Aspose.Html.HTMLDocument(inputs[i], Path.GetDirectoryName(inputs[i])))
                {
                    var div = document.CreateElement("div");
                    div.SetAttribute("id", "myDiv");
                    div.TextContent = "Added by code";
                    document.Body.AppendChild(div);

                    var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    using (var provider = new MemoryStreamProvider())
                    {
                        Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, provider);
                        var memory = provider.Streams[0];
                        memory.Seek(0, SeekOrigin.Begin);
                        string outputPath = Path.Combine(outputDirImages, $"image_{i + 1}.jpeg");
                        using (var fs = File.Create(outputPath))
                        {
                            memory.CopyTo(fs);
                        }
                    }
                }
            }

            // Step 4: Convert with watermark element
            string outputDirWatermark = Path.Combine(Directory.GetCurrentDirectory(), "output_watermark");
            Directory.CreateDirectory(outputDirWatermark);
            for (int i = 0; i < inputs.Length; i++)
            {
                using (var document = new Aspose.Html.HTMLDocument(inputs[i], Path.GetDirectoryName(inputs[i])))
                {
                    var div = document.CreateElement("div");
                    div.SetAttribute("style", "position:absolute; top:10px; left:10px; color:red; font-size:24px;");
                    div.TextContent = "Watermark";
                    document.Body.AppendChild(div);

                    var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    using (var provider = new MemoryStreamProvider())
                    {
                        Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, provider);
                        var memory = provider.Streams[0];
                        memory.Seek(0, SeekOrigin.Begin);
                        string outputPath = Path.Combine(outputDirWatermark, $"watermark_{i + 1}.jpeg");
                        using (var fs = File.Create(outputPath))
                        {
                            memory.CopyTo(fs);
                        }
                    }
                }
            }

            // Step 5: Convert EPUB to XPS with timing
            string epubPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.epub");
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            var epubOptions = new Aspose.Html.Saving.XpsSaveOptions();
            using (var stream = File.OpenRead(epubPath))
            using (var provider = new MemoryStreamProvider())
            {
                var sw = Stopwatch.StartNew();
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, epubOptions, provider);
                sw.Stop();
                Console.WriteLine($"EPUB conversion took {sw.Elapsed.TotalSeconds} seconds.");

                if (provider.Streams.Count > 0)
                {
                    var resultStream = provider.Streams[0];
                    resultStream.Position = 0;
                    string epubOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample_from_epub.xps");
                    using (var fs = File.Create(epubOutputPath))
                    {
                        resultStream.CopyTo(fs);
                    }
                }
            }

            // Step 6: Batch convert EPUB files in a directory
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "epub_input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "epub_output");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string sampleEpubIn = Path.Combine(inputDir, "sample2.epub");
            if (!File.Exists(sampleEpubIn))
            {
                File.WriteAllBytes(sampleEpubIn, new byte[0]);
            }

            string[] files = Directory.GetFiles(inputDir, "*.epub");
            foreach (var inputPath in files)
            {
                try
                {
                    using (var stream = File.OpenRead(inputPath))
                    using (var streamProvider = new MemoryStreamProvider())
                    {
                        var options = new Aspose.Html.Saving.XpsSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, streamProvider);
                        if (streamProvider.Streams.Count > 0)
                        {
                            var resultStream = streamProvider.Streams[0];
                            resultStream.Position = 0;
                            string outPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".xps");
                            using (var output = File.Create(outPath))
                            {
                                resultStream.CopyTo(output);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to convert " + Path.GetFileName(inputPath) + ": " + ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}