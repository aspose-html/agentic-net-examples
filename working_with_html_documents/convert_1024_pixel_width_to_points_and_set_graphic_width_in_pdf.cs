// Convert 1024 pixel width to points and use the result to set graphic width in PDF.

using System;
using System.Drawing;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            double pixels = 1024;
            double points = pixels * 72.0 / 96.0;

            using (PdfDevice device = new PdfDevice("output.pdf"))
            {
                device.BeginPage(new SizeF((float)points, 100));
                device.AddRect(new RectangleF(0, 0, (float)points, 100));
                device.Stroke();
                device.EndPage();
                device.EndDocument();
            }

            Console.WriteLine($"Converted {pixels} pixels to {points:F2} points and created PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}