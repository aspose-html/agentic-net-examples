// Configure sandbox to allow images but block scripts, load a page, and confirm images display correctly.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with an image
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><img id='testImg' src='https://via.placeholder.com/1' /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox: allow images, block scripts
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;
            // Scripts are not added to the security flags, thus they remain blocked

            // Load the HTML document with the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Verify that the image element is present
                Element element = document.GetElementById("testImg");
                string src = element != null ? element.GetAttribute("src") : null;
                Console.WriteLine("Image src attribute: " + (src ?? "not found"));

                // Verify that the document's Images collection contains the image
                HTMLCollection images = document.Images;
                Console.WriteLine("Number of images in document: " + images.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}