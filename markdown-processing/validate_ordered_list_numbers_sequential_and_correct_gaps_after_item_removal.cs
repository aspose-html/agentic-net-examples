// Validate that ordered list numbers are sequential and correct any gaps after item removal.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with an ordered list
            string htmlContent = "<html><body><ol><li>Item 1</li><li>Item 2</li><li>Item 3</li></ol></body></html>";

            // Load the HTML document (base URI is required for string content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <ol> elements
            Aspose.Html.Collections.HTMLCollection olCollection = document.GetElementsByTagName("ol");

            for (int i = 0; i < olCollection.Length; i++)
            {
                Aspose.Html.Dom.Element olElement = (Aspose.Html.Dom.Element)olCollection[i];

                // Get all <li> elements within the current <ol>
                Aspose.Html.Collections.HTMLCollection liCollection = olElement.GetElementsByTagName("li");

                // Remove the second item to create a gap (if it exists)
                if (liCollection.Length > 1)
                {
                    Aspose.Html.Dom.Element liToRemove = (Aspose.Html.Dom.Element)liCollection[1];
                    liToRemove.ParentNode.RemoveChild(liToRemove);
                }

                // Renumber remaining <li> elements sequentially
                Aspose.Html.Collections.HTMLCollection updatedLiCollection = olElement.GetElementsByTagName("li");
                for (int j = 0; j < updatedLiCollection.Length; j++)
                {
                    Aspose.Html.Dom.Element li = (Aspose.Html.Dom.Element)updatedLiCollection[j];
                    li.SetAttribute("value", (j + 1).ToString());
                }
            }

            // Save the modified HTML to a file
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
            Console.WriteLine("Processed HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}