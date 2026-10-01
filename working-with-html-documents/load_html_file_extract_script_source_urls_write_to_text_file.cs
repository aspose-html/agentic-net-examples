// Load an HTML file, extract all script source URLs, and write them to a text file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file for demonstration
            string htmlFilePath = "sample.html";
            File.WriteAllText(htmlFilePath,
                "<html>" +
                "<head><script src=\"script1.js\"></script></head>" +
                "<body><img src=\"image1.png\"/></body>" +
                "</html>");

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath);

            // Extract and display script src attributes
            Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");
            for (int i = 0; i < scriptElements.Length; i++)
            {
                Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                string src = scriptElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine("Script src: " + src);
                }
            }

            // Extract and display image src attributes, resolve URLs, and create request messages
            Aspose.Html.Collections.HTMLCollection imageElements = document.GetElementsByTagName("img");
            for (int i = 0; i < imageElements.Length; i++)
            {
                Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)imageElements[i];
                string src = imageElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Console.WriteLine("Image src: " + src);
                    Aspose.Html.Url url = new Aspose.Html.Url(src, document.BaseURI);
                    Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                    // RequestMessage created; actual request execution is omitted for brevity
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}