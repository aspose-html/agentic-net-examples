// Set ImageSaveOptions JPEG quality to 85 percent before converting SVG to JPG.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "sample.svg";
            if (!System.IO.File.Exists(svgPath))
            {
                System.IO.File.WriteAllText(svgPath,
                    "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>");
            }

            string outputPath = "output.jpg";

            Aspose.Html.Saving.ImageSaveOptions options =
                new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            // Note: ImageSaveOptions does not expose a JPEG quality property.

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            System.Console.WriteLine("SVG has been successfully converted to JPEG.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}