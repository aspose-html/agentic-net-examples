// Replace all <b> tags with <strong> tags to improve semantic markup throughout the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p>This is <b>bold</b> and <b>strong</b> text.</p></body></html>";

            // Load the document from inline HTML
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <b> elements
            var boldElements = document.GetElementsByTagName("b");

            // Copy elements to an array to avoid modification during iteration
            var boldArray = new System.Collections.Generic.List<Aspose.Html.HTMLElement>();
            foreach (var node in boldElements)
            {
                if (node is Aspose.Html.HTMLElement bElement)
                {
                    boldArray.Add(bElement);
                }
            }

            // Replace each <b> with <strong>
            foreach (var b in boldArray)
            {
                var strong = (Aspose.Html.HTMLElement)document.CreateElement("strong");

                // Move child nodes from <b> to <strong>
                while (b.FirstChild != null)
                {
                    strong.AppendChild(b.FirstChild);
                }

                // Replace <b> with <strong> in the DOM
                var parent = b.ParentNode as Aspose.Html.Dom.Element;
                if (parent != null)
                {
                    parent.ReplaceChild(strong, b);
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}