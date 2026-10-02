// Load an HTML file, extract all hyperlink URLs, and write them to a CSV file.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "links.csv";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<a href=\"https://example.com\">Example</a>" +
                                    "<a href=\"https://test.com\">Test</a>" +
                                    "</body></html>";
                File.WriteAllText(inputPath, sampleHtml, Encoding.UTF8);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                HTMLCollection linkElements = document.GetElementsByTagName("a");

                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    for (int i = 0; i < linkElements.Length; i++)
                    {
                        Element link = linkElements[i] as Element;
                        if (link != null)
                        {
                            string href = link.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href))
                            {
                                writer.WriteLine(href);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Hyperlink URLs have been written to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}