// Convert an SVG to BMP with antialiasing enabled and verify image sharpness after conversion.

using System;
using System.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.svg";
            string savePath = "output.bmp";

            SVGDocument document = new SVGDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            options.BackgroundColor = Color.AliceBlue;
            options.UseAntialiasing = true;

            Converter.ConvertSVG(document, options, savePath);

            using (Bitmap bmp = new Bitmap(savePath))
            {
                if (bmp.Width == 0 || bmp.Height == 0)
                {
                    Console.WriteLine("Conversion failed: image has zero dimensions.");
                }
                else
                {
                    bool sharp = false;
                    for (int y = 0; y < bmp.Height - 1 && !sharp; y++)
                    {
                        for (int x = 0; x < bmp.Width - 1 && !sharp; x++)
                        {
                            Color c1 = bmp.GetPixel(x, y);
                            Color c2 = bmp.GetPixel(x + 1, y);
                            if (c1 != c2)
                            {
                                sharp = true;
                            }
                        }
                    }
                    Console.WriteLine(sharp ? "Image appears sharp." : "Image may lack sharpness.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}