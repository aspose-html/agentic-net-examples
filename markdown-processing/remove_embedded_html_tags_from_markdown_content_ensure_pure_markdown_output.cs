// Remove any embedded HTML tags from the Markdown content to ensure pure Markdown output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string markdownContent = "This is **bold** text with <span style=\"color:red;\">HTML tag</span> inside.";
            string htmlContent = markdownContent;
            string baseUri = "";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string pureMarkdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);
            Console.WriteLine("Pure Markdown output:");
            Console.WriteLine(pureMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}