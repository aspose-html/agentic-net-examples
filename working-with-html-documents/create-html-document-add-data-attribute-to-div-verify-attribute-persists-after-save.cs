// Create an HTML document, add a data‑attribute to a div, and verify attribute persists after save.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            // Create a <div> element and set a data-attribute
            Aspose.Html.HTMLElement div = (Aspose.Html.HTMLElement)doc.CreateElement("div");
            div.SetAttribute("data-test", "value");

            // Append the div to the body
            doc.Body.AppendChild(div);

            // Save the document to a file
            doc.Save(outputPath);

            // Load the document back from the file
            Aspose.Html.HTMLDocument loadedDoc = new Aspose.Html.HTMLDocument(outputPath);

            // Retrieve the first <div> element
            Aspose.Html.HTMLElement loadedDiv = null;
            foreach (Aspose.Html.Dom.Element el in loadedDoc.GetElementsByTagName("div"))
            {
                loadedDiv = el as Aspose.Html.HTMLElement;
                break;
            }

            // Verify that the data-attribute persists
            if (loadedDiv != null && loadedDiv.GetAttribute("data-test") == "value")
            {
                System.Console.WriteLine("Attribute persisted.");
            }
            else
            {
                System.Console.WriteLine("Attribute not found.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}