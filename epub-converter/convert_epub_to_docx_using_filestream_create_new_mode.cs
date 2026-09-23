// Convert an EPUB file to DOCX by writing the output using FileStream with create‑new mode.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

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
        // No action needed
    }

    public void Dispose()
    {
        foreach (var ms in _streams)
        {
            ms.Dispose();
        }
    }

    public MemoryStream GetFirstStream()
    {
        return _streams.FirstOrDefault();
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "output.docx";

            if (!File.Exists(sourcePath))
            {
                using (var fs = File.Create(sourcePath))
                {
                    // Placeholder EPUB file
                }
            }

            using (Stream inputStream = File.OpenRead(sourcePath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();

                using (var provider = new MemoryStreamProvider())
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, provider);

                    MemoryStream resultStream = provider.GetFirstStream();
                    if (resultStream != null)
                    {
                        resultStream.Position = 0;
                        using (FileStream outputFileStream = new FileStream(outputPath, FileMode.CreateNew, FileAccess.Write))
                        {
                            resultStream.CopyTo(outputFileStream);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No output stream was generated.");
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