// Add a comment node to the head section, then export the document preserving the comment.

using System;
using System.IO;
using System.Collections.Generic;

class HeaderCaptureHandler : Aspose.Html.Net.MessageHandler
{
    public static List<string> capturedHeaders = new List<string>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue to the next handler in the pipeline
        Next(context);

        foreach (object headerItem in context.Response.Headers)
        {
            if (headerItem != null)
            {
                capturedHeaders.Add(headerItem.ToString());
            }
        }
    }
}

class Program
{
    static void RemoveComments(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            // ✔ USE NodeName INSTEAD OF NodeType
            if (child.NodeName == "#comment")
            {
                node.RemoveChild(child);
            }
            else
            {
                RemoveComments(child);
            }

            child = next;
        }
    }

    static void Main()
    {
        try
        {
            // 1. Load a local HTML file, remove comments, and save.
            string inputPath = "sample.html";
            string outputPathCommentsRemoved = "output_no_comments.html";

            // Create a minimal sample input file if it does not exist.
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!-- Sample comment -->\n<html><body><p>Sample content.</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            RemoveComments(document.DocumentElement);
            document.Save(outputPathCommentsRemoved);
            document.Dispose();

            // 2. Capture network response headers when loading a URL and prepend them as a comment.
            string url = "https://example.com";
            string outputPathUrl = "output_url.html";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new HeaderCaptureHandler());

            using (Aspose.Html.HTMLDocument urlDoc = new Aspose.Html.HTMLDocument(url, configuration))
            {
                if (HeaderCaptureHandler.capturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", HeaderCaptureHandler.capturedHeaders) + "\n";
                    var commentNode = urlDoc.CreateComment(commentText);
                    urlDoc.InsertBefore(commentNode, urlDoc.DocumentElement);
                }

                urlDoc.Save(outputPathUrl);
            }

            // 3. Create a new HTML document with a heading and a paragraph, then save.
            string outputPathCreated = "output_created.html";

            Aspose.Html.HTMLDocument createdDoc = new Aspose.Html.HTMLDocument();
            Aspose.Html.HTMLElement body = createdDoc.Body;

            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)createdDoc.CreateElement("h1");
            Aspose.Html.Dom.Text txtH1 = createdDoc.CreateTextNode("Hello World");
            h1.AppendChild(txtH1);

            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)createdDoc.CreateElement("p");
            Aspose.Html.Dom.Text txtP = createdDoc.CreateTextNode("This is a paragraph.");
            p.AppendChild(txtP);

            body.AppendChild(h1);
            body.AppendChild(p);

            createdDoc.Save(outputPathCreated);
            createdDoc.Dispose();

            // 4. Simple document with plain text content.
            string outputPathSimple = "output_simple.html";

            using (Aspose.Html.HTMLDocument simpleDoc = new Aspose.Html.HTMLDocument())
            {
                simpleDoc.Body.AppendChild(simpleDoc.CreateTextNode("Simple text content."));
                simpleDoc.Save(outputPathSimple);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}