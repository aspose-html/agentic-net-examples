// Retrieve the value of the viewport meta tag to determine mobile rendering settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></head><body><p>Hello World</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            var document = new Aspose.Html.HTMLDocument(htmlPath);
            var metas = document.GetElementsByTagName("meta");
            bool found = false;

            foreach (Aspose.Html.Dom.Element meta in metas)
            {
                string nameAttr = meta.GetAttribute("name");
                if (!string.IsNullOrEmpty(nameAttr) && nameAttr.Equals("viewport", StringComparison.OrdinalIgnoreCase))
                {
                    string viewport = meta.GetAttribute("content");
                    Console.WriteLine("Viewport meta content: " + viewport);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Viewport meta tag not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}