// Use a StringReader to feed Markdown content directly into the converter and output an XPS document.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Markdown\n\nThis is a **test**.";
            using (StringReader reader = new StringReader(markdown))
            {
                string content = reader.ReadToEnd();
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                {
                    using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(ms, ""))
                    {
                        Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                        string savePath = "output.xps";
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
                        Console.WriteLine("Conversion completed. XPS saved at " + Path.GetFullPath(savePath));
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