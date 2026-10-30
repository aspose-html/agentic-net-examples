// Identify and extract all data‑attribute values for custom JavaScript data binding in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with data- attributes
            string htmlContent = "<html><body>" +
                                 "<div data-id='123' data-name='test'></div>" +
                                 "<span data-value='abc'></span>" +
                                 "<p>No data attribute here</p>" +
                                 "</body></html>";

            // Load document from inline HTML (use two‑argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all elements in the document
            Aspose.Html.Collections.HTMLCollection allElements = document.GetElementsByTagName("*");

            // Iterate over each element
            for (int i = 0; i < allElements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)allElements[i];
                // Get the attribute collection of the element
                var attributes = element.Attributes;

                // Iterate over attributes
                for (int j = 0; j < attributes.Length; j++)
                {
                    Aspose.Html.Dom.Attr attribute = (Aspose.Html.Dom.Attr)attributes[j];
                    string name = attribute.Name;
                    if (name != null && name.StartsWith("data-"))
                    {
                        System.Console.WriteLine(attribute.Value);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}