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
            File.WriteAllText(sourcePath, "# Sample Heading\nThis is a sample markdown document.");

            string savePath = "output.xps";

            // Convert Markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Add custom font via CSS
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "@font-face { font-family: 'CustomFont'; src: url('customfont.ttf'); } body { font-family: 'CustomFont'; }";

            // Append the style element to the head
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];
            head.AppendChild(style);

            // Set XPS save options (default options will embed referenced fonts)
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Convert HTMLDocument to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}