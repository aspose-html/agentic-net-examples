// Load a previously saved XML representation of a syntax tree and reconstruct the Markdown document.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string xmlPath = "syntaxTree.xml";
            string outputPath = "output.doc";

            // Create a minimal XML file representing a markdown syntax tree
            string xmlContent = "<markdown># Hello World</markdown>";
            File.WriteAllText(xmlPath, xmlContent, Encoding.UTF8);

            // Load the XML content
            string loadedXml = File.ReadAllText(xmlPath, Encoding.UTF8);

            // Simple extraction of markdown content from the XML
            string startTag = "<markdown>";
            string endTag = "</markdown>";
            int startIndex = loadedXml.IndexOf(startTag) + startTag.Length;
            int endIndex = loadedXml.IndexOf(endTag);
            string markdown = loadedXml.Substring(startIndex, endIndex - startIndex);

            // Convert the markdown string to an HTMLDocument using a memory stream
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, string.Empty);

                // Save the resulting document to a file (DOC format)
                Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.DocSaveOptions(), outputPath);
            }

            Console.WriteLine("Conversion completed. Document saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}