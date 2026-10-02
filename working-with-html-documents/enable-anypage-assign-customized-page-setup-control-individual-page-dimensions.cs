// Enable RenderingOptions.AnyPage and assign a customized PageSetup to control individual page dimensions.

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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Load HTML document from string (using base URI placeholder)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create DOC save options
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

                // Define custom page size (e.g., 800x600 pixels)
                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(800, 600);
                Aspose.Html.Drawing.Page customPage = new Aspose.Html.Drawing.Page(pageSize);

                // Enable AnyPage and assign custom page setup
                options.PageSetup.AnyPage = customPage;

                // Output file path
                string outputPath = "output.doc";

                // Convert HTML to DOC with the specified options
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}