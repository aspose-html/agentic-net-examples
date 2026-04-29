// Append a new level‑two heading with custom text at the end of the Markdown document.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Sample Document\n\nThis is a sample markdown content.";
            string outputPath = "output.html";

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            HTMLDocument document = Converter.ConvertMarkdown(stream, "");

            HTMLHeadingElement h2 = (HTMLHeadingElement)document.CreateElement("h2");
            Text txt = document.CreateTextNode("Custom Heading Text");
            h2.AppendChild(txt);
            document.Body.AppendChild(h2);

            document.Save(outputPath);
            Console.WriteLine("HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}