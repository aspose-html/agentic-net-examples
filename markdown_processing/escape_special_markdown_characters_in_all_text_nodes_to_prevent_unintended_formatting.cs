// Escape special Markdown characters in all text nodes to prevent unintended formatting.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string htmlContent = File.ReadAllText(htmlPath);
            string escapedContent = EscapeMarkdown(htmlContent);
            string baseUri = "";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Converter.ConvertHTML(escapedContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);
            Console.WriteLine(markdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string EscapeMarkdown(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            switch (c)
            {
                case '*':
                case '_':
                case '`':
                case '~':
                case '#':
                case '>':
                case '[':
                case ']':
                case '(':
                case ')':
                case '\\':
                    sb.Append('\\').Append(c);
                    break;
                default:
                    sb.Append(c);
                    break;
            }
        }
        return sb.ToString();
    }
}