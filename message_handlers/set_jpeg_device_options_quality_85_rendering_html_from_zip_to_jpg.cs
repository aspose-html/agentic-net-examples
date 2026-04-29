// Set JPEG device options to use quality 85 when rendering HTML from ZIP to JPG.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "input.zip";
            string extractDir = "extracted";
            string outputJpg = "output.jpg";

            if (Directory.Exists(extractDir))
                Directory.Delete(extractDir, true);
            ZipFile.ExtractToDirectory(zipPath, extractDir);

            string htmlFile = Path.Combine(extractDir, "index.html");
            if (!File.Exists(htmlFile))
                throw new FileNotFoundException("HTML file not found in the extracted ZIP.", htmlFile);

            HTMLDocument document = new HTMLDocument(htmlFile);

            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = false;
            options.VerticalResolution = 75;
            options.HorizontalResolution = 75;

            ImageDevice device = new ImageDevice(options, outputJpg);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}