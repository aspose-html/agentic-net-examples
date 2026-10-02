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
            // Encrypted markdown (Base64 encoded)
            string encryptedMarkdownBase64 = "I2hlYWRlciB0aXRsZQoKVGhpcyBpcyBhIHRlc3QgbWFya2Rvd24u";

            // Decrypt (Base64 decode) to obtain original markdown
            byte[] markdownBytes = Convert.FromBase64String(encryptedMarkdownBase64);
            string markdownContent = Encoding.UTF8.GetString(markdownBytes);

            // Convert markdown to HTMLDocument
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdownContent)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

                // Ensure <head> element exists
                Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
                if (head == null)
                {
                    head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                    document.DocumentElement.AppendChild(head);
                }

                // Add custom CSS style
                Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
                styleElement.TextContent = "body { font-family: Arial, sans-serif; margin: 20px; }";
                head.AppendChild(styleElement);

                // Save the resulting HTML
                string outputPath = Path.GetFullPath("output.html");
                document.Save(outputPath);

                // Output HTML to console
                Console.WriteLine(document.DocumentElement.OuterHTML);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}