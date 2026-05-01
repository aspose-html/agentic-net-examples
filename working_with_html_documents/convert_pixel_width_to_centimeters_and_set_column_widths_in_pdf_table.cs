// Convert pixel width to centimeters and use the result to set column widths in a PDF table.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel width of the column
            double columnPixelWidth = 200.0;

            // Convert pixels to centimeters (96 pixels per inch, 2.54 cm per inch)
            double columnCentimeters = columnPixelWidth / 96.0 * 2.54;

            // Prepare width value for HTML (e.g., "5.29cm")
            string widthValue = $"{columnCentimeters:F2}cm";

            // Create an empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a table element
            HTMLTableElement table = (HTMLTableElement)document.CreateElement("table");

            // Create a colgroup and a column with the calculated width
            HTMLTableColElement col = (HTMLTableColElement)document.CreateElement("col");
            col.Width = widthValue;

            HTMLTableColElement colGroup = (HTMLTableColElement)document.CreateElement("colgroup");
            colGroup.AppendChild(col);
            table.AppendChild(colGroup);

            // Add a simple row with a cell to visualize the column
            HTMLTableRowElement row = (HTMLTableRowElement)document.CreateElement("tr");
            HTMLTableCellElement cell = (HTMLTableCellElement)document.CreateElement("td");
            cell.InnerHTML = "Sample Text";
            row.AppendChild(cell);
            table.AppendChild(row);

            // Append the table to the document body
            document.Body.AppendChild(table);

            // Set up PDF rendering options (default page size)
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Render the HTML document to a PDF file
            using (PdfDevice device = new PdfDevice(options, "output.pdf"))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}