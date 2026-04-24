// Save the resulting Markdown content to a .md file after conversion using a user‑specified output path.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <htmlPath> <outputPath>");
            return;
        }

        string htmlPath = args[0];
        string savePath = args[1];

        try
        {
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            Converter.ConvertHTML(htmlPath, options, savePath);
            Console.WriteLine("Conversion completed. Markdown saved to " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}