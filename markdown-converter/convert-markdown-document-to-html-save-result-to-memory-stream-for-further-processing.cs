// Convert a Markdown document to HTML and save the result to a memory stream for further processing.

namespace AsposeHtmlMarkdownExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample markdown content
                string markdown = "# Hello World\nThis is a **markdown** sample.";

                // Convert markdown string to a memory stream
                using (System.IO.MemoryStream markdownStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown)))
                {
                    // Convert markdown stream to HTMLDocument (base URI can be a dummy value)
                    using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "about:blank"))
                    {
                        // Get the generated HTML as a string
                        string html = document.DocumentElement.OuterHTML;

                        // Save HTML string to a memory stream for further processing
                        System.IO.MemoryStream htmlStream = new System.IO.MemoryStream();
                        byte[] htmlBytes = System.Text.Encoding.UTF8.GetBytes(html);
                        htmlStream.Write(htmlBytes, 0, htmlBytes.Length);
                        htmlStream.Position = 0;

                        // Example of further processing: output length and content
                        System.Console.WriteLine("HTML length (bytes): " + htmlStream.Length);
                        using (System.IO.StreamReader reader = new System.IO.StreamReader(htmlStream, System.Text.Encoding.UTF8, true, 1024, true))
                        {
                            string resultHtml = reader.ReadToEnd();
                            System.Console.WriteLine("Converted HTML:");
                            System.Console.WriteLine(resultHtml);
                        }

                        // Dispose the HTML memory stream when done
                        htmlStream.Dispose();
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}