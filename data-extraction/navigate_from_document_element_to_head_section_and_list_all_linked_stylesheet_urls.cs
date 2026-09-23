// Navigate from the document element to the head section and list all linked stylesheet URLs.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style1.css\"><link rel=\"stylesheet\" href=\"style2.css\"><link rel=\"icon\" href=\"favicon.ico\"></head><body><p>Hello</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            HTMLDocument document = new HTMLDocument(tempFile);

            HTMLCollection heads = document.GetElementsByTagName("head");
            if (heads.Length > 0)
            {
                Element head = (Element)heads[0];
                HTMLCollection linkElements = head.GetElementsByTagName("link");
                List<string> stylesheetUrls = new List<string>();

                for (int i = 0; i < linkElements.Length; i++)
                {
                    Element link = (Element)linkElements[i];
                    string rel = link.GetAttribute("rel");
                    if (string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase))
                    {
                        string href = link.GetAttribute("href");
                        if (!string.IsNullOrEmpty(href))
                        {
                            stylesheetUrls.Add(href);
                        }
                    }
                }

                foreach (string url in stylesheetUrls)
                {
                    Console.WriteLine(url);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}