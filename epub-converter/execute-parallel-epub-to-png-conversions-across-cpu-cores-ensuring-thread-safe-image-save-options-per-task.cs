// Execute parallel EPUB to PNG conversions across CPU cores, ensuring thread‑safe ImageSaveOptions usage for each task.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var inputFiles = new System.Collections.Generic.List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            var outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);

            System.Threading.Tasks.Parallel.ForEach(inputFiles, inputPath =>
            {
                try
                {
                    var outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(inputPath) + ".png");
                    using (var stream = System.IO.File.OpenRead(inputPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions();
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;
                        Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    }
                    System.Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"Error converting '{inputPath}': {ex.Message}");
                }
            });
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}