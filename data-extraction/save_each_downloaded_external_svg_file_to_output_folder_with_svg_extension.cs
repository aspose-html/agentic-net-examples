// Save each downloaded external SVG file to the output folder with .svg extension.

namespace AsposeHtmlSvgDownloader
{
    class Program
    {
        static void Main()
        {
            try
            {
                string outputFolder = "output";
                System.IO.Directory.CreateDirectory(outputFolder);
                string[] svgUrls = new string[]
                {
                    "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/acid.svg"
                };
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    foreach (var url in svgUrls)
                    {
                        string svgContent = httpClient.GetStringAsync(url).Result;
                        string fileName = System.IO.Path.GetFileName(new System.Uri(url).AbsolutePath);
                        if (string.IsNullOrEmpty(fileName))
                        {
                            fileName = "downloaded.svg";
                        }
                        string outputPath = System.IO.Path.Combine(outputFolder, fileName);
                        using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgContent, url))
                        {
                            svgDoc.Save(outputPath);
                        }
                    }
                }
                System.Console.WriteLine("SVG files saved to " + outputFolder);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}