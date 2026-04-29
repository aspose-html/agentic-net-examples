// Trim trailing spaces from each line to avoid unnecessary whitespace in the final output.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string htmlContent = "<html><body><p>Hello World   </p></body></html>";
            // Base URI for the HTML content
            string baseUri = "http://example.com/";
            // Options for Markdown conversion
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            // Temporary file to store the generated Markdown
            string tempPath = System.IO.Path.GetTempFileName();

            // Convert HTML string to Markdown and save to temporary file
            Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read the generated Markdown
            string markdown = System.IO.File.ReadAllText(tempPath);
            // Delete the temporary file
            System.IO.File.Delete(tempPath);

            // Trim trailing spaces from each line
            string[] lines = markdown.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd();
            }
            string trimmedMarkdown = string.Join(Environment.NewLine, lines);

            // Output the cleaned Markdown
            Console.WriteLine(trimmedMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}