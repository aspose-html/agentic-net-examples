// Render HTML to XPS with custom left margin of 8 points to align content precisely.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, XPS!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            var pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(8.0 / 72), // left margin: 8 points
                Aspose.Html.Drawing.Length.FromInches(0),       // top
                Aspose.Html.Drawing.Length.FromInches(0),       // right
                Aspose.Html.Drawing.Length.FromInches(0));      // bottom

            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, margin);

            string outputPath = "output.xps";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("HTML successfully converted to XPS: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}