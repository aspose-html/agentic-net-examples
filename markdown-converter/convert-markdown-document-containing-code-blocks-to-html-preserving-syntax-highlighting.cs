// Convert a Markdown document containing code blocks to an HTML file preserving syntax highlighting.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string outputPath = "output.html";

            string markdownContent = "# Sample Code\n\n```csharp\nConsole.WriteLine(\"Hello, World!\");\n```\n";
            File.WriteAllText(sourcePath, markdownContent);

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);

            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}