// Convert an SVG to TIFF with LZW compression by configuring the appropriate save options in the API.

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output TIFF paths
            string svgPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.svg");
            string tiffPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.tiff");

            // Create a minimal SVG file if it does not exist
            if (!System.IO.File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='blue'/></svg>";
                System.IO.File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            using (Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath))
            {
                // Set up image save options for TIFF
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert SVG to TIFF
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
            }

            System.Console.WriteLine("SVG successfully converted to TIFF at: " + tiffPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}