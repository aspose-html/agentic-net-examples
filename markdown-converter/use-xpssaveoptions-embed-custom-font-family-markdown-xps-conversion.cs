// Use XpsSaveOptions to embed a custom font family during Markdown to XPS conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.xps";

            // Create a sample markdown file that references a custom font.
            string markdownContent = "# Sample\n\n<span style=\"font-family: 'MyCustomFont';\">Custom Font Text</span>\n\n<style>@font-face {font-family: 'MyCustomFont'; src: url('C:\\\\Windows\\\\Fonts\\\\arial.ttf');}</style>";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert Markdown to HTMLDocument.
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Set up XPS save options.
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Convert HTMLDocument to XPS, embedding the custom font.
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed. XPS saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}