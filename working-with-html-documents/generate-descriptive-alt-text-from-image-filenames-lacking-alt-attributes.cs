// Generate descriptive alt text from image filenames for images lacking alt attributes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with images lacking alt attributes
            string htmlContent = "<!DOCTYPE html><html><body>" +
                                 "<img src='images/photo1.jpg'>" +
                                 "<img src='images/logo.png' alt='Company Logo'>" +
                                 "<img src='images/banner-image.png'>" +
                                 "</body></html>";

            // Load HTML document from string (base URI is a placeholder)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string src = img.GetAttribute("src");
                        if (!string.IsNullOrEmpty(src))
                        {
                            string fileName = System.IO.Path.GetFileNameWithoutExtension(src);
                            string autoAlt = fileName.Replace("-", " ").Replace("_", " ");
                            img.SetAttribute("alt", autoAlt);
                        }
                    }
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Processed HTML saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}