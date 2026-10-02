// Download icon data synchronously using WebClient for each resolved icon URL resource.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><img src='https://via.placeholder.com/150.png' /><img src='https://via.placeholder.com/100.jpg' /></body></html>";
            string outputDir = "Icons";
            System.IO.Directory.CreateDirectory(outputDir);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                    string src = imgElement.GetAttribute("src");
                    if (string.IsNullOrEmpty(src))
                        continue;
                    Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, document.BaseURI);
                    string urlString = imageUrl.ToString();
                    string extension = System.IO.Path.GetExtension(urlString);
                    if (!extension.Equals(".png", System.StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpg", System.StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".jpeg", System.StringComparison.OrdinalIgnoreCase) &&
                        !extension.Equals(".gif", System.StringComparison.OrdinalIgnoreCase))
                        continue;
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                    {
                        byte[] imageBytes = webClient.DownloadData(urlString);
                        string fileName = System.IO.Path.GetFileName(urlString);
                        string savePath = System.IO.Path.Combine(outputDir, fileName);
                        System.IO.File.WriteAllBytes(savePath, imageBytes);
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}