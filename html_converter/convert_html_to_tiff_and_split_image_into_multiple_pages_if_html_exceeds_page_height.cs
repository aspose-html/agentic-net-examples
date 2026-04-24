// Convert HTML to TIFF and split the resulting image into multiple pages if the HTML exceeds page height.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file and output TIFF base name
            string htmlPath = "input.html";
            string tiffPath = "output.tiff";

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure image save options for TIFF
            ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            // Convert HTML to a single TIFF image
            Converter.ConvertHTML(document, options, tiffPath);

            // Split the TIFF into multiple pages if height exceeds a threshold
            using (Image fullImage = Image.FromFile(tiffPath))
            {
                int pageHeight = 1000; // height of each page in pixels
                int totalPages = (int)Math.Ceiling((double)fullImage.Height / pageHeight);

                for (int i = 0; i < totalPages; i++)
                {
                    int currentHeight = Math.Min(pageHeight, fullImage.Height - i * pageHeight);
                    Rectangle srcRect = new Rectangle(0, i * pageHeight, fullImage.Width, currentHeight);

                    using (Bitmap pageBitmap = new Bitmap(srcRect.Width, srcRect.Height))
                    {
                        using (Graphics g = Graphics.FromImage(pageBitmap))
                        {
                            g.DrawImage(fullImage, new Rectangle(0, 0, srcRect.Width, srcRect.Height), srcRect, GraphicsUnit.Pixel);
                        }

                        string pagePath = $"output_page_{i + 1}.tiff";
                        pageBitmap.Save(pagePath, System.Drawing.Imaging.ImageFormat.Tiff);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}