// Parse a remote web page URL and retrieve all <img> elements using HtmlDocument.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Remote web page URL
            string url = "https://example.com";

            // Load the HTML document from the URL
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
            {
                // Retrieve all <img> elements
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

                // Iterate and output the src attribute of each image
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        Console.WriteLine(src);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}