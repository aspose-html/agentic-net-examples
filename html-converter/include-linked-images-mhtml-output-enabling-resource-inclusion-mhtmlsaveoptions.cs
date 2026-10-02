// Include linked images in MHTML output by enabling resource inclusion in MHTMLSaveOptions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample image
            string imageFile = "sample.png";
            if (!File.Exists(imageFile))
            {
                using (Bitmap bmp = new Bitmap(100, 100))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Red);
                    }
                    bmp.Save(imageFile, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

            // Prepare HTML content with linked image
            string imagePath = Path.GetFullPath(imageFile);
            string imageUri = new Uri(imagePath).AbsoluteUri;
            string html = $"<html><body><h1>Sample MHTML with Image</h1><img src=\"{imageUri}\" alt=\"Sample Image\" /></body></html>";

            // Configure MHTML save options to include resources
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            mhtmlOptions.ResourceHandlingOptions.MaxHandlingDepth = 10;

            // Output MHTML file path
            string outputMhtml = "output.mhtml";

            // Convert HTML to MHTML
            Aspose.Html.Converters.Converter.ConvertHTML(html, mhtmlOptions, outputMhtml);

            Console.WriteLine($"MHTML file generated successfully at: {Path.GetFullPath(outputMhtml)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}