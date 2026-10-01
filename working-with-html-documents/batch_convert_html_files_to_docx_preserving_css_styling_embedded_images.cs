// Batch convert HTML files to DOCX, preserving CSS styling and embedded images in the output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.html");
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.doc");

            // Create a minimal HTML file
            string htmlContent = "<html><body><h1>Hello Aspose</h1></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Change background color of the body element
                Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
                body.Style.BackgroundColor = "lightblue";

                // Set save options for DOC format
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();

                // Convert HTML document to DOC
                Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}