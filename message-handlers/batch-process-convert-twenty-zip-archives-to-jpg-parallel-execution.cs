// Create a batch process that converts twenty ZIP archives to JPG with parallel execution.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        var ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public void ReleaseStream(System.IO.Stream stream)
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

    public IReadOnlyList<MemoryStream> Streams => _streams;
}

class Program
{
    static void Main()
    {
        try
        {
            var inputZips = new List<string>();
            for (int i = 1; i <= 20; i++)
            {
                string zipPath = $"input{i}.zip";
                inputZips.Add(zipPath);
                if (!File.Exists(zipPath))
                {
                    using (var zipToCreate = new FileStream(zipPath, FileMode.Create))
                    using (var archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                    {
                        var htmlEntry = archive.CreateEntry("document.html");
                        using (var entryStream = htmlEntry.Open())
                        using (var writer = new StreamWriter(entryStream))
                        {
                            writer.Write("<!DOCTYPE html><html><body><h1>Sample Document " + i + "</h1></body></html>");
                        }
                    }
                }
            }

            Parallel.ForEach(inputZips, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, inputZip =>
            {
                try
                {
                    using (var inputArchive = ZipFile.OpenRead(inputZip))
                    {
                        ZipArchiveEntry htmlEntry = null;
                        foreach (var entry in inputArchive.Entries)
                        {
                            if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                            {
                                htmlEntry = entry;
                                break;
                            }
                        }

                        if (htmlEntry == null)
                        {
                            Console.WriteLine($"No HTML file found in {inputZip}");
                            return;
                        }

                        using (var htmlStream = htmlEntry.Open())
                        {
                            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                            using (var provider = new MemoryStreamProvider())
                            {
                                var document = new Aspose.Html.HTMLDocument(htmlStream, "about:blank");
                                Aspose.Html.Converters.Converter.ConvertHTML(document, options, provider);

                                string outputZipPath = Path.ChangeExtension(inputZip, ".out.zip");

                                using (var outputZipStream = new FileStream(outputZipPath, FileMode.Create))
                                using (var outputArchive = new ZipArchive(outputZipStream, ZipArchiveMode.Create))
                                {
                                    int pageIndex = 0;
                                    foreach (var ms in provider.Streams)
                                    {
                                        ms.Position = 0;
                                        var entry = outputArchive.CreateEntry($"page{pageIndex}.jpg");
                                        using (var entryStream = entry.Open())
                                        {
                                            ms.CopyTo(entryStream);
                                        }
                                        pageIndex++;
                                    }
                                }

                                Console.WriteLine($"Converted {inputZip} to {outputZipPath}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {inputZip}: {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}