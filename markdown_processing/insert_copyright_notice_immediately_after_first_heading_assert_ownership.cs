// Insert a copyright notice immediately after the first heading to assert ownership.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            // Create a new empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Get the body element
            HTMLElement body = document.Body;

            // Create the first heading (h1)
            HTMLHeadingElement h1 = (HTMLHeadingElement)document.CreateElement("h1");
            Text texth1 = document.CreateTextNode("Sample Document");
            h1.AppendChild(texth1);
            body.AppendChild(h1);

            // Insert copyright notice immediately after the first heading
            HTMLParagraphElement copyrightPara = (HTMLParagraphElement)document.CreateElement("p");
            Text copyrightText = document.CreateTextNode("© 2026 My Company. All rights reserved.");
            copyrightPara.AppendChild(copyrightText);
            body.AppendChild(copyrightPara);

            // Add an additional paragraph
            HTMLParagraphElement p = (HTMLParagraphElement)document.CreateElement("p");
            Text text = document.CreateTextNode("This is a sample paragraph.");
            p.AppendChild(text);
            body.AppendChild(p);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}