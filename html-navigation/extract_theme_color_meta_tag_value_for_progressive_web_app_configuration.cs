// Extract the theme‑color meta tag value for use in progressive web app configuration.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"theme-color\" content=\"#ff0000\"></head><body></body></html>";
            System.IO.File.WriteAllText(inputPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Collections.NodeList metaElements = document.QuerySelectorAll("meta[name='theme-color']");

            bool found = false;
            foreach (Aspose.Html.HTMLElement element in metaElements)
            {
                string themeColor = element.GetAttribute("content");
                Console.WriteLine("Theme color meta tag value: " + themeColor);
                found = true;
                break;
            }

            if (!found)
            {
                Console.WriteLine("Theme color meta tag not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}