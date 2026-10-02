// Retrieve the value of the viewport meta tag to determine mobile rendering settings.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("meta");
                string viewportContent = null;
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)elements[i];
                    string nameAttr = element.GetAttribute("name");
                    if (!System.String.IsNullOrEmpty(nameAttr) && nameAttr.Equals("viewport", System.StringComparison.OrdinalIgnoreCase))
                    {
                        viewportContent = element.GetAttribute("content");
                        break;
                    }
                }

                if (viewportContent != null)
                {
                    System.Console.WriteLine("Viewport meta content: " + viewportContent);
                }
                else
                {
                    System.Console.WriteLine("Viewport meta tag not found.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}