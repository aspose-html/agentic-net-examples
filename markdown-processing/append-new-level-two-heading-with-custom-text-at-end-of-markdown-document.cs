// Append a new level‑two heading with custom text at the end of the Markdown document.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string markdown = "# Sample Title\n\nThis is a sample markdown document.";
                string outputPath = "output.html";

                // Convert Markdown to HTMLDocument
                System.IO.MemoryStream markdownStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown));
                Aspose.Html.HTMLDocument doc = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "about:blank");

                // Append a new level-two heading with custom text
                Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
                h2.AppendChild(doc.CreateTextNode("Custom Level Two Heading"));
                doc.Body.AppendChild(h2);

                // Save the modified HTML document
                doc.Save(outputPath);
                System.Console.WriteLine("HTML saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}