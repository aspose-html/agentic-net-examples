// Batch convert HTML files to DOCX, preserving CSS styling and embedded images in the output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing source HTML files
            string inputFolder = "InputHtml";
            // Folder where DOCX files will be saved
            string outputFolder = "OutputDocx";

            Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Configure DOCX saving options (default settings)
                DocSaveOptions options = new DocSaveOptions();

                // Build the output DOCX file path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(htmlPath) + ".docx");

                // Convert HTML to DOCX preserving CSS and images
                Converter.ConvertHTML(document, options, outputPath);

                // Release resources
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}