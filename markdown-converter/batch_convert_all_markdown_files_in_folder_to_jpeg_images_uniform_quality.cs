// Batch convert all Markdown files in a folder to JPEG images applying a uniform quality level.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "markdown");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputFolder);

            // Create a sample markdown file if none exist
            if (Directory.GetFiles(inputFolder, "*.md").Length == 0)
            {
                Directory.CreateDirectory(inputFolder);
                string samplePath = Path.Combine(inputFolder, "sample.md");
                File.WriteAllText(samplePath, "# Sample Markdown\n\nThis is a test.");
            }

            foreach (string mdPath in Directory.GetFiles(inputFolder, "*.md"))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath);
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(mdPath) + ".jpeg");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}