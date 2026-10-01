// Load a Markdown file from disk and convert it to an HTML file using ConvertMarkdown.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.html";

            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Hello World\r\nThis is a sample markdown file.";
                File.WriteAllText(sourcePath, markdownContent);
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);
            Console.WriteLine("Conversion completed. HTML saved at " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}