// Convert a Markdown string directly to HTML by calling ConvertMarkdown with the string argument.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");
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