// Insert a table of figures generated from image captions and place it after the table of contents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Add Table of Contents heading
            Aspose.Html.Dom.Element tocHeading = doc.CreateElement("h2");
            tocHeading.SetAttribute("id", "toc");
            tocHeading.AppendChild(doc.CreateTextNode("Table of Contents"));
            body.AppendChild(tocHeading);

            // Sample content: two figures with captions
            for (int i = 1; i <= 2; i++)
            {
                Aspose.Html.Dom.Element figure = doc.CreateElement("figure");

                Aspose.Html.Dom.Element img = doc.CreateElement("img");
                img.SetAttribute("src", $"https://example.com/image{i}.png");
                img.SetAttribute("alt", $"Image {i}");
                figure.AppendChild(img);

                Aspose.Html.Dom.Element caption = doc.CreateElement("figcaption");
                caption.AppendChild(doc.CreateTextNode($"Figure {i} caption"));
                figure.AppendChild(caption);

                body.AppendChild(figure);
            }

            // Generate Table of Figures based on figcaption elements
            Aspose.Html.Collections.HTMLCollection figCaptions = doc.GetElementsByTagName("figcaption");

            if (figCaptions.Length > 0)
            {
                // Create container for Table of Figures
                Aspose.Html.Dom.Element tofDiv = doc.CreateElement("div");

                Aspose.Html.Dom.Element tofHeading = doc.CreateElement("h2");
                tofHeading.AppendChild(doc.CreateTextNode("Table of Figures"));
                tofDiv.AppendChild(tofHeading);

                Aspose.Html.Dom.Element ul = doc.CreateElement("ul");

                for (int i = 0; i < figCaptions.Length; i++)
                {
                    Aspose.Html.Dom.Element captionElem = figCaptions[i];
                    // Cast to HTMLElement to access TextContent
                    Aspose.Html.HTMLElement captionHtml = (Aspose.Html.HTMLElement)captionElem;
                    string captionText = captionHtml.TextContent;

                    Aspose.Html.Dom.Element li = doc.CreateElement("li");
                    li.AppendChild(doc.CreateTextNode(captionText));
                    ul.AppendChild(li);
                }

                tofDiv.AppendChild(ul);

                // Insert Table of Figures after the Table of Contents heading
                Aspose.Html.Dom.Element tocNext = (Aspose.Html.Dom.Element)tocHeading.NextSibling;
                if (tocNext != null)
                {
                    tocHeading.ParentNode.InsertBefore(tofDiv, tocNext);
                }
                else
                {
                    tocHeading.ParentNode.AppendChild(tofDiv);
                }
            }

            // Save the document
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            doc.Save("output.html", saveOptions);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}