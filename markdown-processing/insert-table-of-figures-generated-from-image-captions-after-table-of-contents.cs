// Insert a table of figures generated from image captions and place it after the table of contents.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Table of Contents heading
            Aspose.Html.HTMLHeadingElement tocHeading = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            tocHeading.AppendChild(document.CreateTextNode("Table of Contents"));
            body.AppendChild(tocHeading);

            // Table of Contents list
            Aspose.Html.HTMLElement tocList = (Aspose.Html.HTMLElement)document.CreateElement("ul");
            body.AppendChild(tocList);

            // Add sample sections and populate TOC
            for (int i = 1; i <= 2; i++)
            {
                // Section heading
                Aspose.Html.HTMLHeadingElement sectionHeading = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h2");
                string sectionId = "section" + i;
                sectionHeading.SetAttribute("id", sectionId);
                sectionHeading.AppendChild(document.CreateTextNode("Section " + i));
                body.AppendChild(sectionHeading);

                // TOC entry
                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                Aspose.Html.HTMLAnchorElement a = (Aspose.Html.HTMLAnchorElement)document.CreateElement("a");
                a.SetAttribute("href", "#" + sectionId);
                a.AppendChild(document.CreateTextNode("Section " + i));
                li.AppendChild(a);
                tocList.AppendChild(li);
            }

            // Add images with captions
            for (int i = 1; i <= 2; i++)
            {
                Aspose.Html.HTMLElement figure = (Aspose.Html.HTMLElement)document.CreateElement("figure");

                Aspose.Html.Dom.Element img = (Aspose.Html.Dom.Element)document.CreateElement("img");
                string imgId = "img" + i;
                img.SetAttribute("id", imgId);
                img.SetAttribute("src", "https://example.com/image" + i + ".png");
                img.SetAttribute("alt", "Image " + i + " caption");
                img.SetAttribute("width", "200");
                img.SetAttribute("height", "150");
                figure.AppendChild(img);

                Aspose.Html.HTMLElement caption = (Aspose.Html.HTMLElement)document.CreateElement("figcaption");
                caption.AppendChild(document.CreateTextNode("Figure " + i + ": Image " + i + " caption"));
                figure.AppendChild(caption);

                body.AppendChild(figure);
            }

            // Generate Table of Figures
            Aspose.Html.HTMLHeadingElement tofHeading = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h2");
            tofHeading.AppendChild(document.CreateTextNode("Table of Figures"));
            Aspose.Html.HTMLElement tofList = (Aspose.Html.HTMLElement)document.CreateElement("ul");

            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element img = (Aspose.Html.Dom.Element)images[i];
                string alt = img.GetAttribute("alt");
                string id = img.GetAttribute("id");

                Aspose.Html.HTMLElement li = (Aspose.Html.HTMLElement)document.CreateElement("li");
                Aspose.Html.HTMLAnchorElement a = (Aspose.Html.HTMLAnchorElement)document.CreateElement("a");
                a.SetAttribute("href", "#" + id);
                a.AppendChild(document.CreateTextNode(alt));
                li.AppendChild(a);
                tofList.AppendChild(li);
            }

            // Insert Table of Figures after Table of Contents
            Aspose.Html.Dom.Node nextSibling = tocList.NextSibling;
            if (nextSibling != null)
            {
                body.InsertBefore(tofHeading, nextSibling);
                body.InsertBefore(tofList, nextSibling);
            }
            else
            {
                body.AppendChild(tofHeading);
                body.AppendChild(tofList);
            }

            // Save the document
            string outputPath = "output.html";
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}