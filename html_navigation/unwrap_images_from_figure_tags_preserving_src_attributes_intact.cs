// Unwrap images from surrounding figure tags while preserving their src attributes intact.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace UnwrapImages
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    HTMLCollection figures = document.GetElementsByTagName("figure");
                    for (int i = figures.Length - 1; i >= 0; i--)
                    {
                        Element figure = (Element)figures[i];
                        HTMLCollection imgs = figure.GetElementsByTagName("img");
                        if (imgs.Length > 0)
                        {
                            for (int j = 0; j < imgs.Length; j++)
                            {
                                Element img = (Element)imgs[j];
                                figure.ParentNode.InsertBefore(img, figure);
                            }
                            figure.ParentNode.RemoveChild(figure);
                        }
                    }
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}