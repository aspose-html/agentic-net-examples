// Add a comment node to the head section, then export the document preserving the comment.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal input file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head></head><body><p>Sample</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Locate the <head> element; create it if missing
            Aspose.Html.Dom.Node htmlNode = document.DocumentElement; // <html>
            Aspose.Html.HTMLElement headElement = null;
            Aspose.Html.Dom.Node child = htmlNode.FirstChild;
            while (child != null)
            {
                if (child.NodeName.Equals("head", StringComparison.OrdinalIgnoreCase))
                {
                    headElement = (Aspose.Html.HTMLElement)child;
                    break;
                }
                child = child.NextSibling;
            }
            if (headElement == null)
            {
                headElement = (Aspose.Html.HTMLElement)document.CreateElement("head");
                Aspose.Html.Dom.Node first = htmlNode.FirstChild;
                if (first != null)
                {
                    htmlNode.InsertBefore(headElement, first);
                }
                else
                {
                    htmlNode.AppendChild(headElement);
                }
            }

            // Create a comment node and add it to the head
            Aspose.Html.Dom.Comment commentNode = (Aspose.Html.Dom.Comment)document.CreateComment("Added comment to head");
            headElement.AppendChild(commentNode);

            // Save the modified document preserving the comment
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}