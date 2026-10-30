// Iterate through sibling nodes of a selected element and log each node's outer HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><div id='first'>First</div><p>Second</p><!-- comment --><span>Third</span></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.HTMLElement selectedElement = document.QuerySelector("#first") as Aspose.Html.HTMLElement;
                if (selectedElement == null)
                {
                    Console.WriteLine("Selected element not found.");
                    return;
                }

                Aspose.Html.Dom.Node sibling = selectedElement.NextSibling;
                while (sibling != null)
                {
                    if (sibling is Aspose.Html.HTMLElement element)
                    {
                        Console.WriteLine(element.OuterHTML);
                    }
                    sibling = sibling.NextSibling;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}