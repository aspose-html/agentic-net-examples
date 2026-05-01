// Set border-color for all table elements using an internal CSS selector targeting table tags.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);

            Element head = document.QuerySelector("head");
            if (head == null)
            {
                // If <head> does not exist, create it and insert as the first child of <html>
                Element html = document.QuerySelector("html");
                if (html != null)
                {
                    head = document.CreateElement("head");
                    html.AppendChild(head);
                }
                else
                {
                    throw new InvalidOperationException("Unable to locate <html> element.");
                }
            }

            Element style = document.CreateElement("style");
            style.InnerHTML = "table { border-color: #0000ff; }";
            head.AppendChild(style);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}