// Use a StringReader to feed Markdown content directly into the converter and output an XPS document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample\nThis is **markdown**.";
            using (System.IO.StringReader reader = new System.IO.StringReader(markdown))
            {
                string content = reader.ReadToEnd();
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(content);
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes))
                {
                    using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank"))
                    {
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.xps");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                        Console.WriteLine("Conversion completed. XPS saved at " + outputPath);
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