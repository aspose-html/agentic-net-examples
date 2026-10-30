// Create an HTML document, add a meta robots tag with noindex, and verify search engine directives.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare HTML content and write to a temporary file
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello, World!</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            // Create configuration with script sandbox (optional)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document from the temporary file
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                // Create <meta name="robots" content="noindex">
                Aspose.Html.HTMLElement meta = (Aspose.Html.HTMLElement)document.CreateElement("meta");
                meta.SetAttribute("name", "robots");
                meta.SetAttribute("content", "noindex");

                // Insert the meta tag into <head>
                Aspose.Html.Collections.HTMLCollection heads = document.GetElementsByTagName("head");
                if (heads.Length > 0)
                {
                    Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)heads[0];
                    head.AppendChild(meta);
                }

                // Verify the meta robots tag exists and output its content attribute
                Aspose.Html.Collections.HTMLCollection metas = document.GetElementsByTagName("meta");
                for (int i = 0; i < metas.Length; i++)
                {
                    Aspose.Html.HTMLElement m = (Aspose.Html.HTMLElement)metas[i];
                    if (m.GetAttribute("name") == "robots")
                    {
                        string content = m.GetAttribute("content");
                        Console.WriteLine($"Meta robots content: {content}");
                    }
                }

                // Output the final HTML
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Final HTML:");
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}