// Unwrap images from surrounding figure tags while preserving their src attributes intact.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><body><figure><img src=\"image1.png\" alt=\"Image1\"/></figure><p>Sample text</p></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Collections.HTMLCollection figures = document.GetElementsByTagName("figure");
                for (int i = figures.Length - 1; i >= 0; i--)
                {
                    Aspose.Html.Dom.Element figure = (Aspose.Html.Dom.Element)figures[i];
                    Aspose.Html.Collections.HTMLCollection imgs = figure.GetElementsByTagName("img");
                    if (imgs.Length > 0)
                    {
                        Aspose.Html.Dom.Element img = (Aspose.Html.Dom.Element)imgs[0];
                        figure.ParentNode.ReplaceChild(img, figure);
                    }
                }

                document.Save(outputPath);
            }

            System.Console.WriteLine("Processing completed. Output saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}