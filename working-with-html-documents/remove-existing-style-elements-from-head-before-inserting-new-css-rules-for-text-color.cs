// Remove existing style elements from the head before inserting new CSS rules for text color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with an existing <style> element
            string htmlContent = "<!DOCTYPE html><html><head><style>p {font-size:14px;}</style></head><body><p>Hello World</p></body></html>";

            // Load the HTML document from the string (base URI is required)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the <head> element
            var headCollection = document.GetElementsByTagName("head");
            if (headCollection.Length == 0)
                throw new Exception("The <head> element was not found.");

            var head = (Aspose.Html.Dom.Element)headCollection[0];

            // Remove all existing <style> elements from the document
            var styleCollection = document.GetElementsByTagName("style");
            for (int i = styleCollection.Length - 1; i >= 0; i--)
            {
                var styleElement = (Aspose.Html.Dom.Element)styleCollection[i];
                var parent = styleElement.ParentNode;
                if (parent != null)
                    parent.RemoveChild(styleElement);
            }

            // Create a new <style> element with a text color rule
            var newStyle = (Aspose.Html.Dom.Element)document.CreateElement("style");
            newStyle.TextContent = "body { color: blue; }";

            // Append the new <style> element to the <head>
            head.AppendChild(newStyle);

            // Save the modified document to a file
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved successfully to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}