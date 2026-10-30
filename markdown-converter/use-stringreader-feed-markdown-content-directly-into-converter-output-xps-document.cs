// Use a StringReader to feed Markdown content directly into the converter and output an XPS document.

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
            // Sample markdown content
            string markdown = "# Sample Title\nThis is a **markdown** document converted to XPS.";

            // Use StringReader to read the markdown content
            using (StringReader reader = new StringReader(markdown))
            {
                string content = reader.ReadToEnd();
                byte[] bytes = Encoding.UTF8.GetBytes(content);
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    // Convert markdown to HTMLDocument
                    using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank"))
                    {
                        // Set XPS save options
                        XpsSaveOptions options = new XpsSaveOptions();

                        // Output path
                        string savePath = "output.xps";

                        // Convert HTMLDocument to XPS
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

                        Console.WriteLine("Conversion completed. XPS saved at " + savePath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}