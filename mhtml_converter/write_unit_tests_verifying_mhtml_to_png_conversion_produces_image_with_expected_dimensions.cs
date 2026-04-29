// Write unit tests verifying that MHTML to PNG conversion produces an image with expected dimensions.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlMhtmlToPngTest");
            Directory.CreateDirectory(tempDir);

            string htmlPath = Path.Combine(tempDir, "sample.html");
            string mhtmlPath = Path.Combine(tempDir, "sample.mhtml");
            string pngPath = Path.Combine(tempDir, "result.png");

            // Create simple HTML file
            File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");

            // Load HTML and save as MHTML
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                document.Save(mhtmlPath, new Aspose.Html.Saving.MHTMLSaveOptions());
            }

            // Open MHTML stream
            System.IO.Stream stream = System.IO.File.OpenRead(mhtmlPath);

            // Configure rendering options with expected dimensions
            Aspose.Html.Rendering.MhtmlRenderer renderer = new Aspose.Html.Rendering.MhtmlRenderer();
            Aspose.Html.Rendering.Image.ImageRenderingOptions renderOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(300, 200));
            renderOptions.BackgroundColor = System.Drawing.Color.Bisque;

            // Create image device and render
            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(renderOptions, pngPath);
            renderer.Render(device, stream);
            stream.Close();

            // Verify output image dimensions
            using (Image img = Image.FromFile(pngPath))
            {
                if (img.Width == 300 && img.Height == 200)
                {
                    Console.WriteLine("Test passed: Image dimensions are as expected.");
                }
                else
                {
                    Console.WriteLine($"Test failed: Expected 300x200 but got {img.Width}x{img.Height}.");
                }
            }

            // Cleanup
            Directory.Delete(tempDir, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}