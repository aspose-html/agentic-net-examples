// Convert pixel measurements to inches and apply them to set border radii in PDF vector graphics.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Use predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

            // ✔ Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // ✔ Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // ✔ Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // ✔ Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // ✔ Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // ✔ Output results
            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in, {widthCentimeters:F2} cm, {widthMillimeters:F1} mm, {widthPoints:F2} pt, {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in, {heightCentimeters:F2} cm, {heightMillimeters:F1} mm, {heightPoints:F2} pt, {heightPicas:F2} pc");

            double borderPixels = 5.0;
            double borderPoints = borderPixels * 72.0 / 96.0;

            // Create HTML document
            var document = new Aspose.Html.HTMLDocument();

            // Create canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";
            document.Body.AppendChild(canvas);

            // Get 2D rendering context and draw a rectangle
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillRect(10, 10, 200, 100);

            // Render to PDF (simple)
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            // Define margins in pixels
            double leftPixels = 72;   // 1 inch
            double topPixels = 72;
            double rightPixels = 72;
            double bottomPixels = 72;

            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(topInches),
                Aspose.Html.Drawing.Length.FromInches(rightInches),
                Aspose.Html.Drawing.Length.FromInches(bottomInches),
                Aspose.Html.Drawing.Length.FromInches(leftInches));

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                margin);

            string outputPathWithMargin = "output_with_margin.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPathWithMargin))
            {
                document.RenderTo(device);
            }

            // Pixel count conversion example
            double pixelCount = 300.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            // Pixels to millimeters example
            double pixels = 200.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}