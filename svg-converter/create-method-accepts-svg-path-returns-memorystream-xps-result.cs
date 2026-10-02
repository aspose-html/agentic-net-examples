// Create a method that accepts an SVG path and returns a MemoryStream containing the XPS result.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MemoryStreamProvider : Aspose.Html.IO.ICreateStreamProvider, IDisposable
{
    private readonly List<MemoryStream> _streams = new List<MemoryStream>();

    public System.Collections.Generic.IReadOnlyList<MemoryStream> Streams => _streams;

    public System.IO.Stream GetStream(string name, string extension)
    {
        MemoryStream ms = new MemoryStream();
        _streams.Add(ms);
        return ms;
    }

    public System.IO.Stream GetStream(string name, string extension, int page)
    {
        return GetStream(name, extension);
    }

    public void ReleaseStream(System.IO.Stream stream)
    {
        if (stream != null)
        {
            stream.Flush();
        }
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
            // Create a minimal SVG file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            string tempSvgPath = Path.Combine(Path.GetTempPath(), "sample.svg");
            File.WriteAllText(tempSvgPath, svgContent);

            // Convert SVG to XPS in memory
            MemoryStream xpsStream = ConvertSvgToXps(tempSvgPath);

            // Output information
            Console.WriteLine("XPS conversion succeeded. Stream length: " + xpsStream.Length + " bytes.");

            // Optionally save to a file for verification
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");
            using (FileStream file = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                xpsStream.CopyTo(file);
            }
            Console.WriteLine("XPS file saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static MemoryStream ConvertSvgToXps(string svgPath)
    {
        var provider = new MemoryStreamProvider();
        var options = new Aspose.Html.Saving.XpsSaveOptions();

        // Base URI for relative resources (directory of the SVG file)
        string baseUri = Path.GetDirectoryName(svgPath) ?? string.Empty;

        // Perform conversion
        Aspose.Html.Converters.Converter.ConvertSVG(svgPath, baseUri, options, provider);

        // Retrieve the generated XPS stream
        MemoryStream generatedStream = provider.Streams[0];
        generatedStream.Position = 0;

        // Copy to a new MemoryStream to detach from provider before disposing
        MemoryStream result = new MemoryStream();
        generatedStream.CopyTo(result);
        result.Position = 0;

        provider.Dispose();
        return result;
    }
}