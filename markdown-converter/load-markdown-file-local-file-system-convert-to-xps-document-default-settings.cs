// Load a Markdown file from the local file system and convert it to an XPS document using default settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.md";
            string savePath = "output.xps";

            // Create a minimal Markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Sample Document\nThis is a sample markdown file.";
                File.WriteAllText(sourcePath, markdownContent);
            }

            // Convert Markdown to HTMLDocument
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                // Create XPS save options with default settings
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Convert HTMLDocument to XPS file
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed successfully. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}