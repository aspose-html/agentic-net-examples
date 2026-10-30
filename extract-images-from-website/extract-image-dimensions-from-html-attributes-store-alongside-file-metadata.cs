// Extract image dimensions from HTML attributes and store them alongside file metadata.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class ImageMetadata
{
    public string Src { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string htmlPath = "sample.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                string sampleHtml = "<html><body>" +
                                    "<img src=\"image1.jpg\" width=\"200\" height=\"100\" alt=\"First\"/>" +
                                    "<img src=\"image2.png\" width=\"300\" height=\"150\" alt=\"Second\"/>" +
                                    "</body></html>";
                File.WriteAllText(htmlPath, sampleHtml);
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Query all img elements
            Aspose.Html.Collections.NodeList imgNodes = document.QuerySelectorAll("img");

            // Store metadata
            List<ImageMetadata> metadataList = new List<ImageMetadata>();

            for (int i = 0; i < imgNodes.Length; i++)
            {
                Node node = imgNodes[i];
                Element element = node as Element;
                if (element != null)
                {
                    string src = element.GetAttribute("src");
                    string widthAttr = element.GetAttribute("width");
                    string heightAttr = element.GetAttribute("height");

                    int width = 0;
                    int height = 0;
                    if (!string.IsNullOrEmpty(widthAttr))
                    {
                        int.TryParse(widthAttr, out width);
                    }
                    if (!string.IsNullOrEmpty(heightAttr))
                    {
                        int.TryParse(heightAttr, out height);
                    }

                    metadataList.Add(new ImageMetadata
                    {
                        Src = src,
                        Width = width,
                        Height = height
                    });
                }
            }

            // Output extracted metadata
            foreach (ImageMetadata meta in metadataList)
            {
                Console.WriteLine($"Src: {meta.Src}, Width: {meta.Width}, Height: {meta.Height}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}