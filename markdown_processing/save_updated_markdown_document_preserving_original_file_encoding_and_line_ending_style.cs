// Save the updated Markdown document preserving the original file encoding and line ending style.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "input.html";
            string outputMdPath = "output.md";
            MarkdownSaveOptions options = MarkdownSaveOptions.Git;
            Converter.ConvertHTML(inputHtmlPath, options, outputMdPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}