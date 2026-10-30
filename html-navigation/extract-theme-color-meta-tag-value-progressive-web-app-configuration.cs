// Extract the theme‑color meta tag value for use in progressive web app configuration.

using System;
using Aspose.Html;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"theme-color\" content=\"#ff0000\"><meta name=\"description\" content=\"sample\"></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("meta[name='theme-color']");
            string themeColor = null;
            if (elements.Length > 0)
            {
                Aspose.Html.HTMLElement meta = (Aspose.Html.HTMLElement)elements[0];
                themeColor = meta.GetAttribute("content");
            }
            System.Console.WriteLine("Extracted theme-color meta tag value: " + (themeColor ?? "not found"));
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}