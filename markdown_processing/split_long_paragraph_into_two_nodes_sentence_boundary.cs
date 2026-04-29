// Split a long paragraph into two separate nodes at the nearest sentence boundary.

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
            HTMLDocument doc = new HTMLDocument();
            HTMLElement body = doc.Body;
            HTMLHeadingElement h1 = (HTMLHeadingElement)doc.CreateElement("h1");
            Text txtH1 = doc.CreateTextNode("Sample Document");
            h1.AppendChild(txtH1);
            HTMLParagraphElement p = (HTMLParagraphElement)doc.CreateElement("p");
            string longText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
            Text txtP = doc.CreateTextNode(longText);
            p.AppendChild(txtP);
            body.AppendChild(h1);
            body.AppendChild(p);

            int half = longText.Length / 2;
            int splitPos = longText.IndexOf('.', half);
            if (splitPos != -1) splitPos++;
            else splitPos = half;

            Text secondPart = txtP.SplitText(splitPos);
            HTMLParagraphElement p2 = (HTMLParagraphElement)doc.CreateElement("p");
            p2.AppendChild(secondPart);
            body.AppendChild(p2);

            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}