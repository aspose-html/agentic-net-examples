// Load an HTML file, replace all <b> tags with <strong> tags, and save the updated file.

using System;
using System.IO;
using System.Text;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a meta tag
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"Original description\"></head><body><h1>Hello World</h1></body></html>";
            byte[] bytes = Encoding.UTF8.GetBytes(htmlContent);

            // Load HTML from memory stream
            using (var inputStream = new MemoryStream(bytes))
            using (var document = new Aspose.Html.HTMLDocument(inputStream, ""))
            {
                var metaElements = document.GetElementsByTagName("meta");
                foreach (Aspose.Html.Dom.Element meta in metaElements)
                {
                    if (meta.GetAttribute("name") == "description")
                    {
                        meta.SetAttribute("content", "Updated description");
                    }
                }

                string outputPath1 = Path.Combine(Environment.CurrentDirectory, "output1.html");
                document.Save(outputPath1);
                Console.WriteLine($"Saved modified HTML to {outputPath1}");
            }

            // Load the saved document and change body background color
            string outputPath1File = Path.Combine(Environment.CurrentDirectory, "output1.html");
            string outputPath2 = Path.Combine(Environment.CurrentDirectory, "output2.html");
            using (var document = new Aspose.Html.HTMLDocument(outputPath1File))
            {
                var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
                body.Style.BackgroundColor = "AliceBlue";

                document.Save(outputPath2);
                Console.WriteLine($"Saved with background color to {outputPath2}");
            }

            // Add a style element to the document
            string outputPath3 = Path.Combine(Environment.CurrentDirectory, "output3.html");
            using (var document = new Aspose.Html.HTMLDocument(outputPath2))
            {
                var style = (Aspose.Html.HTMLElement)document.CreateElement("style");
                style.TextContent = "body { background-color: rgb(229, 243, 253); }";

                var head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
                head.AppendChild(style);

                document.Save(outputPath3);
                Console.WriteLine($"Saved with added style to {outputPath3}");
            }

            // Configure security and load with configuration
            string outputPath4 = Path.Combine(Environment.CurrentDirectory, "output4.html");
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(outputPath3, config))
            {
                var body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
                body.Style.BackgroundColor = "LightYellow";

                document.Save(outputPath4);
                Console.WriteLine($"Saved final document to {outputPath4}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}