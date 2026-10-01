// Use inline expressions to calculate and display total price from JSON line item values.

using System;
using System.IO;
using System.Text.Json;
using System.Globalization;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
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
            Console.WriteLine($"Width: {widthPixels}px = {widthInches:F4}in = {widthCentimeters:F4}cm = {widthMillimeters:F4}mm = {widthPoints:F4}pt = {widthPicas:F4}pc");
            Console.WriteLine($"Height: {heightPixels}px = {heightInches:F4}in = {heightCentimeters:F4}cm = {heightMillimeters:F4}mm = {heightPoints:F4}pt = {heightPicas:F4}pc");

            // Pixel conversion based on optional argument
            double pixels = 96.0;
            if (args.Length > 0 && double.TryParse(args[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double parsedPixels))
            {
                pixels = parsedPixels;
            }

            double inches = pixels / 96.0;
            double points = pixels * 72.0 / 96.0;
            double centimeters = inches * 2.54;
            double millimeters = centimeters * 10.0;

            var result = new
            {
                pixels = pixels,
                inches = Math.Round(inches, 4),
                points = Math.Round(points, 4),
                centimeters = Math.Round(centimeters, 4),
                millimeters = Math.Round(millimeters, 4)
            };

            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);

            // Prepare a simple HTML file with price spans
            string htmlFilePath = "sample.html";
            if (!File.Exists(htmlFilePath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <span class='price'>12.99</span>
    <span class='price'>7.50</span>
    <span class='price'>3.25</span>
</body>
</html>";
                File.WriteAllText(htmlFilePath, sampleHtml);
            }

            // Load the HTML document
            string baseUrl = "";
            string htmlContent = File.ReadAllText(htmlFilePath);
            using (HTMLDocument document = new HTMLDocument(baseUrl, htmlContent))
            {
                // Evaluate XPath to find price spans
                IXPathResult xpathResult = document.Evaluate(
                    "//span[contains(concat(' ', normalize-space(@class), ' '), ' price ')]",
                    document,
                    document.CreateNSResolver(document),
                    XPathResultType.Any,
                    null);

                double sum = 0;
                Node node;
                while ((node = xpathResult.IterateNext()) != null)
                {
                    if (double.TryParse(node.TextContent, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        sum += value;
                    }
                }

                Console.WriteLine($"Sum of prices: {sum.ToString(CultureInfo.InvariantCulture)}");
            }

            // Prepare a simple template file
            string templatePath = "template.html";
            if (!File.Exists(templatePath))
            {
                string templateContent = @"
<!DOCTYPE html>
<html>
<head><title>Template</title></head>
<body>
    <h1>{{title}}</h1>
    <p>{{message}}</p>
</body>
</html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create template data (JSON string)
            string jsonData = @"{ ""title"": ""Hello World"", ""message"": ""This is a generated template."" }";
            TemplateData data = new TemplateData(jsonData);
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Convert template to HTMLDocument
            HTMLDocument convertedDoc = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options);

            // Save the converted document
            string outputPath = "output.html";
            convertedDoc.Save(outputPath);
            Console.WriteLine($"Template converted and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}