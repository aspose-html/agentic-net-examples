// Create a console application that reads HTML from standard input and writes Markdown to standard output.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent;
            if (Console.IsInputRedirected)
            {
                using (var reader = new StreamReader(Console.OpenStandardInput()))
                {
                    htmlContent = reader.ReadToEnd();
                }
            }
            else
            {
                htmlContent = "<p>Hello, World!</p>";
            }

            string baseUri = "";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            Console.Write(markdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}