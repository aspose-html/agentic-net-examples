// Retrieve the value of the viewport meta tag to determine mobile rendering settings.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body><p>Hello</p></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("meta");
                string viewportContent = null;
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)elements[i];
                    string nameAttr = element.GetAttribute("name");
                    if (!string.IsNullOrEmpty(nameAttr) && nameAttr.Equals("viewport", StringComparison.OrdinalIgnoreCase))
                    {
                        viewportContent = element.GetAttribute("content");
                        break;
                    }
                }

                if (viewportContent != null)
                {
                    Console.WriteLine("Viewport meta tag content: " + viewportContent);
                }
                else
                {
                    Console.WriteLine("Viewport meta tag not found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}