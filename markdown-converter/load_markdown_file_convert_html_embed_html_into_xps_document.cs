// Load a Markdown file, convert it to HTML, and embed the HTML into an XPS document.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.md";
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "# Hello World\nThis is a sample markdown.");
            }

            string savePath = "output.xps";

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed. XPS saved at " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}