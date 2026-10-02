// Extract the theme‑color meta tag value for use in progressive web app configuration.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name='theme-color' content='#ff0000'></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList metaElements = document.QuerySelectorAll("meta[name='theme-color']");
            if (metaElements.Length > 0)
            {
                Aspose.Html.HTMLElement metaTag = (Aspose.Html.HTMLElement)metaElements[0];
                string themeColor = metaTag.GetAttribute("content");
                System.Console.WriteLine("Theme color meta tag value: " + themeColor);
            }
            else
            {
                System.Console.WriteLine("Theme color meta tag not found.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}