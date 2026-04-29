// Convert a Markdown string directly to HTML by calling ConvertMarkdown with the string argument.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Markdown content to be converted
            string markdown = "# Hello\nThis is **markdown**.";

            // Create a memory stream from the markdown string
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                // Convert the markdown stream to an HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(stream, "");

                // Output the generated HTML
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}