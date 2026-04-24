// Set DOCX page orientation to landscape using DocSaveOptions when converting HTML to DOCX.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Desired output DOCX file path
            string docxPath = "output.docx";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create save options for DOCX conversion
            DocSaveOptions options = new DocSaveOptions();

            // Define a landscape page size (A4 landscape in points)
            Size pageSize = new Size(842, 595);
            Page page = new Page(pageSize);

            // Apply the page layout to the save options
            options.PageSetup.AnyPage = page;

            // Convert HTML to DOCX with the specified options
            Converter.ConvertHTML(document, options, docxPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}