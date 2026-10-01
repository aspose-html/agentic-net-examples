// Generate an XPS file from a Markdown document and embed custom metadata via XpsSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "document.md";
            string savePath = "document.xps";

            // Create a minimal Markdown file if it does not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "# Sample Markdown\nThis is a test document.");
            }

            // Convert Markdown to HTMLDocument
            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                // Create XPS save options (default settings)
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

                // Convert HTMLDocument to XPS file
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("XPS file has been saved to: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}