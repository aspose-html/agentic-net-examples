// Identify all <img> elements in the DOM via document.Images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample</h1><img src='image1.png' alt='First'><p>Text</p><img src='image2.jpg'></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection images = document.Images;
            foreach (Aspose.Html.Dom.Element img in images)
            {
                string src = img.GetAttribute("src");
                Console.WriteLine("Image src: " + src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}