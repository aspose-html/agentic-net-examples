// Ensure every heading node ends with a newline character to maintain valid Markdown syntax.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML source to be converted
            string htmlContent = "<h1>Sample Heading</h1><p>Some paragraph text.</p>";
            // Base URI (empty because content is inline)
            string baseUri = "";

            // Options for Markdown conversion
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Temporary file to store the generated Markdown
            string tempPath = Path.GetTempFileName();

            // Convert HTML to Markdown and write to temporary file
            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read the generated Markdown
            string markdown = File.ReadAllText(tempPath);

            // Clean up the temporary file
            File.Delete(tempPath);

            // Ensure every heading line ends with a newline character
            markdown = Regex.Replace(
                markdown,
                @"(^#{1,6} .+)(?!\r?\n)",
                "$1\n",
                RegexOptions.Multiline);

            // Output the final Markdown
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}