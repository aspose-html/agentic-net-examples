// Decrypt previously encrypted Markdown nodes to restore original content for further editing.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample\n\nEncrypted: [enc]SGVsbG8gd29ybGQ=[/enc]";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            var document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "https://example.com/");

            Aspose.Html.Dom.Node element = document.Body.FirstChild;
            while (element != null)
            {
                string text = element.TextContent;
                int start = text.IndexOf("[enc]");
                int end = text.IndexOf("[/enc]");
                if (start != -1 && end != -1 && end > start)
                {
                    string encoded = text.Substring(start + 5, end - (start + 5));
                    string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
                    string newText = text.Substring(0, start) + decoded + text.Substring(end + 6);
                    element.TextContent = newText;
                }
                element = element.NextSibling;
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine(document.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}