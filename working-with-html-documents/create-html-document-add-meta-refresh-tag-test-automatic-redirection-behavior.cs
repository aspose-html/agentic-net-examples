// Create an HTML document, add a meta refresh tag, and test automatic redirection behavior.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Create HTML document and add a meta refresh tag
            string filePath = "redirect.html";
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument())
            {
                // Ensure <html> element exists
                Aspose.Html.Dom.Element htmlElem = doc.DocumentElement;
                if (htmlElem == null)
                {
                    htmlElem = doc.CreateElement("html");
                    doc.AppendChild(htmlElem);
                }

                // Get or create <head>
                Aspose.Html.Collections.HTMLCollection headCollection = doc.GetElementsByTagName("head");
                Aspose.Html.Dom.Element head = headCollection.Length > 0 ? (Aspose.Html.Dom.Element)headCollection[0] : null;
                if (head == null)
                {
                    head = doc.CreateElement("head");
                    htmlElem.AppendChild(head);
                }

                // Create meta refresh element
                Aspose.Html.Dom.Element meta = doc.CreateElement("meta");
                meta.SetAttribute("http-equiv", "refresh");
                meta.SetAttribute("content", "0;url=https://example.com");
                head.AppendChild(meta);

                // Get or create <body>
                Aspose.Html.Collections.HTMLCollection bodyCollection = doc.GetElementsByTagName("body");
                Aspose.Html.Dom.Element body = bodyCollection.Length > 0 ? (Aspose.Html.Dom.Element)bodyCollection[0] : null;
                if (body == null)
                {
                    body = doc.CreateElement("body");
                    htmlElem.AppendChild(body);
                }
                body.TextContent = "Redirecting...";

                // Save the document to a file
                doc.Save(filePath);
            }

            // Navigate to the saved document to test automatic redirection
            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument navDoc = new Aspose.Html.HTMLDocument())
            {
                string result = string.Empty;
                navDoc.OnReadyStateChange += (sender, e) =>
                {
                    if (navDoc.ReadyState == "complete")
                    {
                        result = navDoc.DocumentElement != null ? navDoc.DocumentElement.OuterHTML : string.Empty;
                        resetEvent.Set();
                    }
                };
                navDoc.Navigate(filePath);
                resetEvent.WaitOne();
                System.Console.WriteLine("Navigated document outer HTML:");
                System.Console.WriteLine(result);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}