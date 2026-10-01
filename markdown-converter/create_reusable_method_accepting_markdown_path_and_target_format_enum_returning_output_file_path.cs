// Create a reusable method that accepts a Markdown path and target format enum, returning the output file path.

using System;
using System.IO;

namespace AsposeHtmlMarkdownConverter
{
    enum OutputFormat
    {
        Html
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare a sample markdown file
                string markdownPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
                File.WriteAllText(markdownPath, "# Hello Aspose.HTML\nThis is a **markdown** sample.");

                // Convert markdown to the desired format
                string resultPath = ConvertMarkdown(markdownPath, OutputFormat.Html);

                Console.WriteLine($"Conversion completed. Output file: {resultPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string ConvertMarkdown(string markdownPath, OutputFormat format)
        {
            if (format != OutputFormat.Html)
                throw new NotSupportedException("Only HTML output is supported in this example.");

            string outputPath = Path.ChangeExtension(markdownPath, ".html");
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, outputPath);
            return outputPath;
        }
    }
}