// Render HTML to XPS with custom left margin of 8 points to align content precisely.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace HtmlToXpsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";

                // Path for the generated XPS file
                string outputPath = "output.xps";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Create XPS save options
                XpsSaveOptions options = new XpsSaveOptions();

                // Set background color (optional)
                options.BackgroundColor = System.Drawing.Color.White;

                // Configure page size (8 inches width, 11 inches height) and margins
                // Left margin is set to 8 points (approximately 0.111 inches)
                options.PageSetup.AnyPage = new Page(
                    new Size(Length.FromInches(8), Length.FromInches(11)),
                    new Margin(0, 8, 0, 0) // Top, Left, Right, Bottom margins in points
                );

                // Convert HTML to XPS
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}