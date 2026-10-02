// Load a Markdown file from the local file system and convert it to an XPS document using default settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.xps";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a **test**.");
            }

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}