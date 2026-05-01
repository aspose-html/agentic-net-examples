// Add multiple img elements in a loop, each with unique source and dimensions, to the article section.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace AddMultipleImages
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                HTMLDocument doc = new HTMLDocument(inputPath);
                var articleElements = doc.GetElementsByTagName("article");
                HTMLElement container = articleElements.Length > 0 ? (HTMLElement)articleElements[0] : doc.Body;

                for (int i = 1; i <= 5; i++)
                {
                    Element element = doc.CreateElement("img");
                    HTMLImageElement img = (HTMLImageElement)element;
                    img.Src = $"https://example.com/image{i}.png";
                    img.Alt = $"Image {i}";
                    img.Width = 100 + i * 10;
                    img.Height = 80 + i * 10;
                    container.AppendChild(img);
                }

                doc.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}