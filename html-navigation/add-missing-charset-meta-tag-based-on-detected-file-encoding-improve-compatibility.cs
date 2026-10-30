// Add a missing charset meta tag based on detected file encoding to improve compatibility.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";
            string encodingName = "utf-8";

            // Ensure input file exists
            if (!File.Exists(sourcePath))
            {
                string minimalHtml = "<!DOCTYPE html><html><head></head><body><p>Sample content.</p></body></html>";
                File.WriteAllText(sourcePath, minimalHtml, Encoding.GetEncoding(encodingName));
            }

            // Read HTML content with detected encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding(encodingName));

            // Load document from inline HTML
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Check for existing <meta charset> tag
            bool hasCharsetMeta = false;
            var metaTags = document.GetElementsByTagName("meta");
            for (int i = 0; i < metaTags.Length; i++)
            {
                var metaElement = metaTags[i] as Aspose.Html.HTMLElement;
                if (metaElement != null && metaElement.HasAttribute("charset"))
                {
                    hasCharsetMeta = true;
                    break;
                }
            }

            if (!hasCharsetMeta)
            {
                // Get or create <head> element
                var headCollection = document.GetElementsByTagName("head");
                Aspose.Html.HTMLElement headElement;
                if (headCollection.Length > 0)
                {
                    headElement = headCollection[0] as Aspose.Html.HTMLElement;
                }
                else
                {
                    headElement = document.CreateElement("head") as Aspose.Html.HTMLElement;
                    var htmlElement = document.GetElementsByTagName("html")[0] as Aspose.Html.HTMLElement;
                    if (htmlElement != null)
                    {
                        htmlElement.AppendChild(headElement);
                    }
                }

                // Create <meta charset="..."> element
                var metaCharset = document.CreateElement("meta") as Aspose.Html.HTMLElement;
                metaCharset.SetAttribute("charset", Encoding.GetEncoding(encodingName).WebName);

                // Insert meta tag as first child of head
                var firstChild = headElement.FirstChild;
                if (firstChild != null)
                {
                    headElement.InsertBefore(metaCharset, firstChild);
                }
                else
                {
                    headElement.AppendChild(metaCharset);
                }
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine("Processed HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}