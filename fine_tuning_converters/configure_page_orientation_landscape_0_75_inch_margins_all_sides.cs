// Configure DocRenderingOptions to set page orientation to Landscape and apply 0.75‑inch margins on all sides.

using System;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            // Create rendering options
            DocRenderingOptions options = new DocRenderingOptions();

            // Define 0.75‑inch margins on all sides
            Margin margin = new Margin(
                Length.FromInches(0.75),
                Length.FromInches(0.75),
                Length.FromInches(0.75),
                Length.FromInches(0.75));

            // Define a page size (example: A4 landscape in points)
            Size pageSize = new Size(842, 595);

            // Assign page with size and margins
            Page page = new Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            Console.WriteLine("DocRenderingOptions configured with landscape orientation and 0.75‑inch margins.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}