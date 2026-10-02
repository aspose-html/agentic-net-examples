// Convert a Markdown string directly to HTML by calling ConvertMarkdown with the string argument.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string markdown = "# Hello World\nThis is a **markdown** sample.";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");
                Console.WriteLine(document.DocumentElement.OuterHTML);
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}