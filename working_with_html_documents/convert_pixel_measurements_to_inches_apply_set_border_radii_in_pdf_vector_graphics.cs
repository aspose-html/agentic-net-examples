// Convert pixel measurements to inches and apply them to set border radii in PDF vector graphics.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            double radiusPixels = 12.0;
            double radiusInches = radiusPixels / 96.0;
            string radiusInchesStr = $"{radiusInches:F4}in";

            string html = $@"
<!DOCTYPE html>
<html>
<head>
<style>
.box {{
    width: 200px;
    height: 200px;
    background: lightblue;
    border: 2px solid red;
    border-radius: {radiusInchesStr};
}}
</style>
</head>
<body>
<div class='box'></div>
</body>
</html>";

            var options = new PdfSaveOptions();
            string outputPath = "output.pdf";
            Converter.ConvertHTML(html, "", options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}