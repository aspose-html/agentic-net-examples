// Perform a depth‑first traversal to collect all text nodes into a list for bulk processing.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><div>Hello <span>World</span></div><p>Another <b>text</b></p></body></html>";

            // Load HTML document from string (base URI is required)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // List to hold text node contents
                List<string> textNodes = new List<string>();

                // Depth‑first traversal using a stack
                Stack<Aspose.Html.Dom.Node> stack = new Stack<Aspose.Html.Dom.Node>();
                stack.Push(document.Body);

                while (stack.Count > 0)
                {
                    Aspose.Html.Dom.Node current = stack.Pop();

                    if (current is Aspose.Html.Dom.Text textNode)
                    {
                        string text = textNode.TextContent.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            textNodes.Add(text);
                        }
                    }

                    // Push child nodes onto the stack
                    foreach (Aspose.Html.Dom.Node child in current.ChildNodes)
                    {
                        stack.Push(child);
                    }
                }

                // Output collected text nodes
                Console.WriteLine("Collected text nodes:");
                foreach (string txt in textNodes)
                {
                    Console.WriteLine("- " + txt);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}