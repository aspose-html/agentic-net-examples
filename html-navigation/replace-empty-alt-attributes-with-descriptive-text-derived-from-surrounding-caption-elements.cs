// Replace empty alt attributes with descriptive text derived from surrounding caption elements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<html><body>" +
                "<figure><img src='img1.jpg' alt=''><figcaption>First image caption</figcaption></figure>" +
                "<p>Some text</p>" +
                "<img src='img2.png' alt=''>" +
                "<figure><img src='img3.jpg' alt=''><figcaption>Third image caption</figcaption></figure>" +
                "</body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";

                        Aspose.Html.Dom.Element parent = img.ParentNode as Aspose.Html.Dom.Element;
                        if (parent != null && string.Equals(parent.NodeName, "figure", StringComparison.OrdinalIgnoreCase))
                        {
                            Aspose.Html.Collections.HTMLCollection captions = parent.GetElementsByTagName("figcaption");
                            if (captions.Length > 0)
                            {
                                Aspose.Html.HTMLElement captionElement = captions[0] as Aspose.Html.HTMLElement;
                                if (captionElement != null)
                                {
                                    autoAlt = captionElement.InnerHTML.Trim();
                                }
                            }
                        }

                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}