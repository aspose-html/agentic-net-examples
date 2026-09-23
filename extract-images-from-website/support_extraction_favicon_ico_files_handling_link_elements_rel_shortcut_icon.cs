// Support extraction of favicon.ico files by handling link elements with rel='shortcut icon'.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.XPath;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare a sample HTML file with a shortcut icon link
            string inputPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <link rel='shortcut icon' href='favicon.ico' />
    <title>Sample Page</title>
</head>
<body>
    <p>Hello, World!</p>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            HTMLDocument doc = new HTMLDocument(inputPath);

            // Find all link elements with rel='shortcut icon'
            IXPathResult result = doc.Evaluate("//link[@rel='shortcut icon']", doc, doc.CreateNSResolver(doc), XPathResultType.Any, null);

            Node node;
            while ((node = result.IterateNext()) != null)
            {
                HTMLLinkElement link = (HTMLLinkElement)node;
                Console.WriteLine("Favicon URL: " + link.Href);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}