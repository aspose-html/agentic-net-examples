// Load a previously saved XML representation of a syntax tree and reconstruct the Markdown document.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the previously saved XML representation of the syntax tree
            string xmlPath = "syntaxTree.xml";

            // Path where the reconstructed Markdown document will be saved
            string markdownPath = "document.md";

            // Load the XML (assumed to be a valid HTML/XML document) into an HTMLDocument
            HTMLDocument document = new HTMLDocument(xmlPath);

            // Create default options for saving as Markdown
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert the HTMLDocument to a Markdown file
            Converter.ConvertHTML(document, options, markdownPath);

            Console.WriteLine("Markdown document reconstructed at: " + markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}