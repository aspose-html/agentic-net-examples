// Convert an HTML file to an MHTML file with default MHTMLSaveOptions using the static ConvertHTML method.

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
            // Path to the source HTML file
            string sourcePath = "input.html";

            // Path where the resulting MHTML file will be saved
            string outputPath = "output.mht";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(sourcePath);

            // Create default MHTML save options
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Convert the HTML document to MHTML and save it to the specified path
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}