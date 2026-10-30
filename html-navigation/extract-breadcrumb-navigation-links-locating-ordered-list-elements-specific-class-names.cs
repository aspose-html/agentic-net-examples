// Extract breadcrumb navigation links by locating ordered list elements with specific class names.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML containing a breadcrumb ordered list
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<ol class='breadcrumb'>" +
                                 "<li><a href='home.html'>Home</a></li>" +
                                 "<li><a href='section.html'>Section</a></li>" +
                                 "<li><a href='page.html'>Page</a></li>" +
                                 "</ol>" +
                                 "</body></html>";

            // Load HTML from the string (base URI is a placeholder)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select all anchor elements inside ordered lists with class 'breadcrumb'
            Aspose.Html.Collections.NodeList nodeList = document.QuerySelectorAll("ol.breadcrumb a");

            // Iterate and output link text and href
            for (int i = 0; i < nodeList.Length; i++)
            {
                Aspose.Html.HTMLElement link = nodeList[i] as Aspose.Html.HTMLElement;
                if (link != null)
                {
                    string href = link.GetAttribute("href");
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                    System.Console.WriteLine($"Text: \"{text}\", Href: \"{href}\"");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}