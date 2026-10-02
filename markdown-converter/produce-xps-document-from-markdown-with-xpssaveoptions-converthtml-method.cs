// Produce an XPS document from Markdown by supplying XpsSaveOptions to the ConvertHTML method.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input markdown file and output XPS file paths
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Hello Aspose.HTML\nThis is a **markdown** sample.");
            }

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Prepare XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Convert HTMLDocument to XPS file
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Markdown has been successfully converted to XPS:");
            Console.WriteLine(savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}