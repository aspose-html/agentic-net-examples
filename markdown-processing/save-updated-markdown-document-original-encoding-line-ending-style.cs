// Save the updated Markdown document preserving the original file encoding and line ending style.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "sample.md";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            MarkdownSaveOptions options = MarkdownSaveOptions.Git;
            Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

            Console.WriteLine("Markdown document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}