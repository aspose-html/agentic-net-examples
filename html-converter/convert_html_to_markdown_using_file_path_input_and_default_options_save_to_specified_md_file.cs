// Convert HTML to Markdown using file path input and default options, then save to a specified .md file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string savePath = "output.md";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1><p>This is a sample HTML.</p></body></html>");
            }

            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            Console.WriteLine($"HTML converted to Markdown successfully. Output saved to: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}