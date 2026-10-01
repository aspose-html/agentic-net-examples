// Convert pixel dimensions to centimeters and use them to define table cell sizes in PDF output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Unit conversions
            double widthPixels = 800;
            double heightPixels = 600;
            const double ppi = 96.0;

            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F2} in = {widthCentimeters:F2} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F2} in = {heightCentimeters:F2} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Column and row size conversion
            double columnWidthPixels = 120.0;
            double rowHeightPixels = 30.0;
            double columnWidthMillimeters = columnWidthPixels / 96.0 * 25.4;
            double rowHeightMillimeters = rowHeightPixels / 96.0 * 25.4;
            Console.WriteLine($"Column width: {columnWidthPixels}px = {columnWidthMillimeters:F2} mm");
            Console.WriteLine($"Row height: {rowHeightPixels}px = {rowHeightMillimeters:F2} mm");

            // Margin conversion
            double leftPixels = 72.0;
            double topPixels = 72.0;
            double rightPixels = 72.0;
            double bottomPixels = 72.0;

            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),
                Aspose.Html.Drawing.Length.FromInches(rightInches),
                Aspose.Html.Drawing.Length.FromInches(bottomInches),
                Aspose.Html.Drawing.Length.FromInches(leftInches));

            // Create simple HTML document
            var document = new Aspose.Html.HTMLDocument();
            var body = document.Body;
            var p = (Aspose.Html.HTMLElement)document.CreateElement("p");
            p.InnerHTML = "Hello, Aspose.HTML!";
            body.AppendChild(p);

            // PDF rendering
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);
            options.BackgroundColor = System.Drawing.Color.White;

            string outputPath = "output.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            // Pixel to millimeters conversion example
            double pixels = 150.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            // Pixel to centimeters conversion example
            double pixels2 = 200.0;
            double centimeters = pixels2 / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}