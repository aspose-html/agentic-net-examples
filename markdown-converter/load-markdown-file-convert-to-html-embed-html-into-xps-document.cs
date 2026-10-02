// Load a Markdown file, convert it to HTML, and embed the HTML into an XPS document.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.md";
                string savePath = "output.xps";

                if (!File.Exists(sourcePath))
                {
                    File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a **markdown** document converted to XPS.");
                }

                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                }

                Console.WriteLine("Conversion completed. XPS saved at " + Path.GetFullPath(savePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}