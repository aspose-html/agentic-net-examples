// Batch process a set of Markdown files, converting each to TIFF with lossless compression enabled.

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            System.IO.Directory.CreateDirectory(inputDir);
            System.IO.Directory.CreateDirectory(outputDir);

            var sampleFiles = new System.Collections.Generic.Dictionary<string, string>
            {
                { "sample1.md", "# Sample 1\r\nThis is a test." },
                { "sample2.md", "## Sample 2\r\nAnother test." }
            };

            foreach (var kvp in sampleFiles)
            {
                string path = System.IO.Path.Combine(inputDir, kvp.Key);
                System.IO.File.WriteAllText(path, kvp.Value);
            }

            string[] markdownFiles = System.IO.Directory.GetFiles(inputDir, "*.md");

            foreach (string sourcePath in markdownFiles)
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);

                string fileNameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(sourcePath);
                string savePath = System.IO.Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}