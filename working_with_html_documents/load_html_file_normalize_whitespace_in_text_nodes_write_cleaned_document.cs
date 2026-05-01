// Load an HTML file, normalize whitespace inside text nodes, and write the cleaned document.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the cleaned HTML will be saved
            string outputPath = "output.html";

            // Load the HTML document from the file system
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Normalize whitespace inside all text nodes of the document
            document.Normalize();

            // Save the normalized document to the specified output path
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine(ex.Message);
        }
    }
}