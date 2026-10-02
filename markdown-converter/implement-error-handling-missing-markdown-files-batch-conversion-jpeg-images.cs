// Implement error handling for missing Markdown files during batch conversion to JPEG images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputMarkdown";
            string outputFolder = "OutputImages";

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            string[] markdownFiles = System.IO.Directory.GetFiles(inputFolder, "*.md");
            if (markdownFiles.Length == 0)
            {
                throw new System.IO.FileNotFoundException($"No markdown files found in folder '{inputFolder}'.");
            }

            foreach (string mdPath in markdownFiles)
            {
                try
                {
                    Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdPath);
                    try
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        options.UseAntialiasing = true;
                        options.HorizontalResolution = 300;
                        options.VerticalResolution = 300;

                        string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(mdPath) + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        System.Console.WriteLine($"Converted '{mdPath}' to '{outputPath}'.");
                    }
                    finally
                    {
                        document.Dispose();
                    }
                }
                catch (Exception exFile)
                {
                    System.Console.WriteLine($"Failed to convert '{mdPath}': {exFile.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}