// Include linked images in MHTML output by enabling resource inclusion in MHTMLSaveOptions.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the resulting MHTML file will be saved
            string mhtmlPath = "output.mht";

            // Create MHTML save options
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Enable inclusion of linked resources (e.g., images) by setting handling depth
            options.ResourceHandlingOptions.MaxHandlingDepth = 10;

            // Convert HTML to MHTML with the configured options
            Converter.ConvertHTML(htmlPath, options, mhtmlPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}