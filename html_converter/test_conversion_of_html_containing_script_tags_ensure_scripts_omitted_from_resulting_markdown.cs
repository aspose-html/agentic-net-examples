// Test conversion of HTML containing script tags to ensure scripts are omitted from the resulting Markdown.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlScriptToMarkdown
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define paths for the source HTML and the resulting Markdown files
                string htmlPath = "sample.html";
                string markdownPath = "output.md";

                // Create an HTML file that contains a script tag
                string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <script type=""text/javascript"">
        console.log('This script should be omitted in markdown.');
    </script>
    <title>Test Page</title>
</head>
<body>
    <h1>Hello World</h1>
    <p>This is a paragraph.</p>
</body>
</html>";
                File.WriteAllText(htmlPath, htmlContent);

                // Initialize default Markdown save options
                MarkdownSaveOptions options = new MarkdownSaveOptions();

                // Convert the HTML file to Markdown; scripts are omitted by default
                Converter.ConvertHTML(htmlPath, options, markdownPath);

                // Read and display the generated Markdown content
                string markdown = File.ReadAllText(markdownPath);
                Console.WriteLine("Markdown output:");
                Console.WriteLine(markdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}