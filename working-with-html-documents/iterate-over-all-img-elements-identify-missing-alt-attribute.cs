// Iterate over all <img> elements and identify those missing an alt attribute.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body>" +
                          "<img src='image1.png' alt='Image 1'/>" +
                          "<img src='image2.png'/>" +
                          "<img src='image3.png' alt=' '/>" +
                          "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "auto-generated";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            document.Save("output.html");
            Console.WriteLine("Processing completed. Output saved to output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}