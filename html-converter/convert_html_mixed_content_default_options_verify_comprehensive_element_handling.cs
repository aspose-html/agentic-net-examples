// Convert HTML with mixed content using default options to verify comprehensive element handling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Mixed Content</title></head><body>" +
                                 "<h1>Header</h1>" +
                                 "<p>This is a paragraph with <strong>bold</strong> text.</p>" +
                                 "<img src='https://via.placeholder.com/150' alt='Sample Image'/>" +
                                 "<table border='1'><tr><th>Col1</th><th>Col2</th></tr><tr><td>Data1</td><td>Data2</td></tr></table>" +
                                 "<ul><li>Item 1</li><li>Item 2</li></ul>" +
                                 "<form><input type='checkbox' checked/>Check me</form>" +
                                 "</body></html>";

            string baseUri = "http://example.com/";
            string outputPath = "mixed_content_output.xps";

            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}