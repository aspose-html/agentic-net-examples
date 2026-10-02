// Extract the value of the robots meta tag to determine indexing directives.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta name=\"robots\" content=\"noindex, nofollow\"><title>Test</title></head><body><p>Hello</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Collections.HTMLCollection metaElements = document.GetElementsByTagName("meta");
            string robotsContent = null;
            for (int i = 0; i < metaElements.Length; i++)
            {
                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)metaElements[i];
                string nameAttr = element.GetAttribute("name");
                if (!string.IsNullOrEmpty(nameAttr) && nameAttr.Equals("robots", StringComparison.OrdinalIgnoreCase))
                {
                    robotsContent = element.GetAttribute("content");
                    break;
                }
            }
            if (robotsContent != null)
            {
                Console.WriteLine("Robots meta tag content: " + robotsContent);
            }
            else
            {
                Console.WriteLine("Robots meta tag not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}