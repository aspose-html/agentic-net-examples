// Perform parallel EPUB to GIF conversions with a degree of parallelism limit to avoid overwhelming system resources.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // List of EPUB files to convert
            var inputFiles = new List<string>
            {
                "book1.epub",
                "book2.epub",
                "book3.epub"
            };

            // Ensure output directory exists
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Limit the degree of parallelism to avoid overwhelming resources
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                // Determine output GIF file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".gif");

                // Open EPUB file as a readable stream
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    // Configure image save options for GIF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                    // Perform the conversion
                    Converter.ConvertEPUB(stream, options, outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}