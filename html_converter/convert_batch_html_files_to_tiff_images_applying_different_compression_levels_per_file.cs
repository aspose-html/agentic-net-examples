// Convert a batch of HTML files to TIFF images while applying different compression levels per file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "input_html";
            string outputFolder = "output_tiff";

            Directory.CreateDirectory(outputFolder);

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                string htmlPath = htmlFiles[i];

                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                    // Apply different compression per file: even-indexed files use No compression,
                    // odd-indexed files keep default compression.
                    if (i % 2 == 0)
                    {
                        options.Compression = Compression.None;
                    }

                    // Set resolution
                    options.HorizontalResolution = 150;
                    options.VerticalResolution = 150;

                    string outputPath = Path.Combine(
                        outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".tiff");

                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}