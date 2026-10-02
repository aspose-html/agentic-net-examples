// Remove all deprecated <center> tags and replace them with CSS text‑align styling.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing deprecated <center> tags
            string htmlContent = "<html><body><center><h1>Welcome</h1></center><p>Some text.</p><center>Another centered text.</center></body></html>";

            // Load HTML from string using a dummy base URI
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <center> elements
            Aspose.Html.Collections.HTMLCollection centers = document.GetElementsByTagName("center");

            // Iterate backwards to safely replace nodes
            for (int i = centers.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element center = (Aspose.Html.Dom.Element)centers[i];

                // Create a <div> element with CSS text-align styling
                Aspose.Html.Dom.Element div = document.CreateElement("div");
                div.SetAttribute("style", "text-align:center;");

                // Move all child nodes from <center> to the new <div>
                while (center.FirstChild != null)
                {
                    Aspose.Html.Dom.Node child = center.FirstChild;
                    center.RemoveChild(child);
                    div.AppendChild(child);
                }

                // Replace the <center> element with the new <div>
                Aspose.Html.Dom.Node parent = center.ParentNode;
                parent.ReplaceChild(div, center);
            }

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            System.Console.WriteLine("Processing completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}