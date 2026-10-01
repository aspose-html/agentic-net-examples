// Convert HTML to BMP and log conversion parameters like DPI, page size, and compression.

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = "Output";
            System.IO.Directory.CreateDirectory(outputDir);
            string htmlPath = System.IO.Path.Combine(outputDir, "sample.html");
            string bmpPath = System.IO.Path.Combine(outputDir, "output.bmp");
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.Beige;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            System.Console.WriteLine("Conversion parameters:");
            System.Console.WriteLine($"DPI: {options.HorizontalResolution}x{options.VerticalResolution}");
            System.Console.WriteLine($"Page size: {options.PageSetup.AnyPage.Size.Width}x{options.PageSetup.AnyPage.Size.Height}");
            System.Console.WriteLine($"Margins: left={options.PageSetup.AnyPage.Margin.Left}, top={options.PageSetup.AnyPage.Margin.Top}, right={options.PageSetup.AnyPage.Margin.Right}, bottom={options.PageSetup.AnyPage.Margin.Bottom}");
            System.Console.WriteLine("Compression: N/A for BMP");
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, bmpPath);
            System.Console.WriteLine($"HTML converted to BMP at: {bmpPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}