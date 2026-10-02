// Generate an XPS file from a Markdown document and embed custom metadata via XpsSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.md");
            string savePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.xps");

            // Create a minimal Markdown file
            string markdownContent = "# Sample Document\nThis is a **markdown** document converted to XPS.";
            System.IO.File.WriteAllText(sourcePath, markdownContent);

            using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                // Example of custom option (background color) – serves as metadata/customization
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
            }

            Console.WriteLine("Conversion completed. XPS saved to: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}