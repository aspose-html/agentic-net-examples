// Convert a Markdown document containing code blocks to an HTML file preserving syntax highlighting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.html";

            string markdownContent = "# Sample Code\n\nHere is a code block:\n\n```csharp\nConsole.WriteLine(\"Hello, World!\");\n```\n";

            System.IO.File.WriteAllText(sourcePath, markdownContent);

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);

            Console.WriteLine("Conversion completed. HTML saved at " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}