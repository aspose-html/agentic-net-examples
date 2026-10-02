// Detect mismatched Markdown delimiters and automatically correct them to maintain valid syntax.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<p>This is <strong>bold</strong> and <em>italic</em> text.</p>";
            string baseUri = "about:blank";

            // Temporary file for intermediate markdown
            string tempPath = System.IO.Path.GetTempFileName();

            // Markdown conversion options
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            // Convert HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read generated markdown
            string markdown = System.IO.File.ReadAllText(tempPath);

            // Clean up temporary file
            System.IO.File.Delete(tempPath);

            // Fix mismatched delimiters
            string correctedMarkdown = FixDelimiters(markdown);

            // Save corrected markdown
            string outputPath = "corrected.md";
            System.IO.File.WriteAllText(outputPath, correctedMarkdown);

            Console.WriteLine("Corrected markdown saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }

    static string FixDelimiters(string text)
    {
        string[] delimiters = new string[] { "**", "*", "`" };
        foreach (string delim in delimiters)
        {
            int count = 0;
            int index = 0;
            while ((index = text.IndexOf(delim, index, StringComparison.Ordinal)) != -1)
            {
                count++;
                index += delim.Length;
            }
            if (count % 2 != 0)
            {
                text += delim;
            }
        }
        return text;
    }
}