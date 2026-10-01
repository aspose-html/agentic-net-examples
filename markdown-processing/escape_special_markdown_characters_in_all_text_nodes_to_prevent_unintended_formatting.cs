// Escape special Markdown characters in all text nodes to prevent unintended formatting.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<p>Hello *world* _test_ `code` ~strike~</p>";
            string baseUri = "";
            var options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            string escapedMarkdown = EscapeMarkdown(markdown);

            Console.WriteLine("Escaped Markdown:");
            Console.WriteLine(escapedMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static string EscapeMarkdown(string input)
    {
        var sb = new StringBuilder();
        foreach (char c in input)
        {
            switch (c)
            {
                case '\\': sb.Append("\\\\"); break;
                case '*': sb.Append("\\*"); break;
                case '_': sb.Append("\\_"); break;
                case '`': sb.Append("\\`"); break;
                case '~': sb.Append("\\~"); break;
                case '[': sb.Append("\\["); break;
                case ']': sb.Append("\\]"); break;
                case '(': sb.Append("\\("); break;
                case ')': sb.Append("\\)"); break;
                case '#': sb.Append("\\#"); break;
                case '+': sb.Append("\\+"); break;
                case '-': sb.Append("\\-"); break;
                case '!': sb.Append("\\!"); break;
                default: sb.Append(c); break;
            }
        }
        return sb.ToString();
    }
}