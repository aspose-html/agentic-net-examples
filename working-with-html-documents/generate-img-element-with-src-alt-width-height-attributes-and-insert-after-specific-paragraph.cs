// Generate an img element with src, alt, width, and height attributes, and insert after a specific paragraph.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");

            if (paragraphs.Length >= 2)
            {
                Aspose.Html.Dom.Element img = document.CreateElement("img");
                img.SetAttribute("src", "https://example.com/image.png");
                img.SetAttribute("alt", "Example Image");
                img.SetAttribute("width", "200");
                img.SetAttribute("height", "150");

                Aspose.Html.Dom.Element secondParagraph = paragraphs[1];
                secondParagraph.ParentNode.InsertBefore(img, secondParagraph.NextSibling);
            }

            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            string outputPath = "output.html";
            document.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}